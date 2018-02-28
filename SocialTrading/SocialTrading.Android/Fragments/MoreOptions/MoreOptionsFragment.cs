using System;
using Android.OS;
using Android.App;
using Android.Views;
using Android.Content;
using Android.Support.V7.Widget;

using SocialTrading.Locale;
using SocialTrading.Service;
using SocialTrading.Droid.Theme;
using SocialTrading.Droid.Tools;
using SocialTrading.DTO.Request;
using SocialTrading.DTO.Request.RA;
using SocialTrading.Locale.Modules;
using SocialTrading.Droid.Activities;
using SocialTrading.Tools.Interfaces;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Dispatcher;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Droid.Adapters.Recycler;
using SocialTrading.Droid.Views.MoreOptions;
using SocialTrading.Droid.Routers.MoreOptions;
using SocialTrading.Vipers.MoreOptions.ToolBar.Interfaces;
using SocialTrading.Vipers.MoreOptions.ToolBar.Implementation;
using SocialTrading.Vipers.MoreOptions.OptionsCell.Interfaces;

namespace SocialTrading.Droid.Fragments.MoreOptions
{
    public class MoreOptionsFragment : Fragment, ISetConfig
    {
        private View _view;
        private Holder _holder;
        private RouterOptionsCell _routerForViper;
        private LogOutController _logOutController;
        private MoreOptionsController _moreOptionsController;


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            _view = inflater.Inflate(Resource.Layout.MoreOptionsFragment, null, false);
            _routerForViper = new RouterOptionsCell(FragmentManager);
            _holder = new Holder(_view, this, _routerForViper);
            _logOutController = new LogOutController(Connection.ConnectionController.GetInstance(), DataService.RepositoryController);
            _moreOptionsController = new MoreOptionsController(Connection.ConnectionController.GetInstance(),
                DataService.RepositoryController.RepositoryUserSettings, DataService.RepositoryController.RepositoryUserAuth, 
                WebMsgParser.ParseResponseUserSettings);

            SetConfig();

            return _view;
        }

        public override void OnResume()
        {
            base.OnResume();
            _routerForViper.OnLogoutClick += OnLogoutClick;
            _logOutController.OnRecieveModel += OnRecieveModelLogOut;
            _moreOptionsController.OnRecieveModel += OnRecieveModel;
        }

        public override void OnPause()
        {
            base.OnPause();
            _routerForViper.OnLogoutClick -= OnLogoutClick;
            _logOutController.OnRecieveModel -= OnRecieveModelLogOut;
            _moreOptionsController.OnRecieveModel -= OnRecieveModel;
        }

        public void SetConfig()
        {
            _moreOptionsController.Send(new UserInfoRequestModel(DataService.RepositoryController.RepositoryUserSettings.UserId
                ?? throw new NullReferenceException(nameof(DataService.RepositoryController.RepositoryUserSettings.UserId))));

            var routerToolBarBack = new RouterToolBarBack(Activity);
            var stylesHolderToolBarBack = new ToolBarBackStylesHolderDroid<GlobalControlsTheme>(DroidDAL.ThemeParser);
            var title = DataService.RepositoryController.RepositoryToolbar.LangToolbar.ToolbarTitle;
            var presenterToolBarBack = new PresenterToolBarBack(_holder.ToolBarBackView, routerToolBarBack, stylesHolderToolBarBack, title);
            presenterToolBarBack.SetConfig();
        }
        
        private void OnLogoutClick()
        {
            var locale = Localization.Lang as IAlert;

            AlertDialog.Builder alert = new AlertDialog.Builder(_view.Context);
            alert.SetTitle(Localization.Lang.MoreOptionsLogOut);
            alert.SetMessage(locale.LogoutAlert);

            alert.SetPositiveButton(locale.Yes, (senderAlert, args) =>
            {
                _logOutController.Send(new LogOutModel());
            });

            alert.SetNegativeButton(locale.No, (senderAlert, args) => { });

            Dialog dialog = alert.Create();
            (_view.Context as Activity)?.RunOnUiThread(() =>
            {
                dialog.Show();
            });
        }

        private void OnRecieveModel(IModel response)
        {
            var locale = Localization.Lang as IAlert;

            switch (response.ControllerStatus)
            {
                case EControllerStatus.NoConnection:
                    ShowError(locale.NoConnection);
                    break;

                case EControllerStatus.Error:
                    ShowError(locale.Error);
                    break;

                default:
                    break;
            }
        }

        private void OnRecieveModelLogOut(IModel response)
        {
            var locale = Localization.Lang as IAlert;

            switch (response.ControllerStatus)
            {
                case EControllerStatus.Ok:
                    GoToAuth();
                    break;

                case EControllerStatus.NoConnection:
                    ShowError(locale.NoConnection);
                    break;

                case EControllerStatus.Error:
                    ShowError(locale.Error);
                    break;

                default:
                    break;
            }
        }

        private void GoToAuth()
        {
            (_view.Context as Activity).FinishAffinity();
            Intent intent = new Intent((_view.Context as Activity).ApplicationContext, typeof(AuthActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            _view.Context.StartActivity(intent);
        }

        public void ShowError(string message)
        {
            var locale = Localization.Lang as IAlert;

            AlertDialog.Builder alert = new AlertDialog.Builder(_view.Context);
            alert.SetMessage(message);
            alert.SetPositiveButton(locale.OK, (senderAlert, args) => { });
            Dialog dialog = alert.Create();

            (_view.Context as Activity)?.RunOnUiThread(() =>
            {
                dialog.Show();
            });
        }

        private class Holder
        {
            public RecyclerView RecyclerView { get; }
            public MoreOptionsRecyclerAdapter MoreOptionsRecyclerAdapter { get; private set; }
            public IToolBarBackView ToolBarBackView { get; private set; }

            public Holder(View view, MoreOptionsFragment fragment, IRouterOptionsCell router)
            {
                Context context = fragment.Activity;

                MoreOptionsRecyclerAdapter = new MoreOptionsRecyclerAdapter(new DataForMoreOptions(), router);

                RecyclerView = view.FindViewById<RecyclerView>(Resource.Id.moreOptions_options_recyclerView);
                RecyclerView.SetLayoutManager(new LinearLayoutManager(context));
                RecyclerView.SetAdapter(MoreOptionsRecyclerAdapter);
                ToolBarBackView = view.FindViewById<ToolBarBackView>(Resource.Id.toolbarBackButtonTitle_toolbar);
            }
        }
    }
}