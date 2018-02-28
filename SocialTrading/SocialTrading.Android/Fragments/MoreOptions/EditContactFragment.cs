using Android.OS;
using Android.App;
using Android.Views;

using SocialTrading.Service;
using SocialTrading.Droid.Theme;
using SocialTrading.Droid.Tools;
using SocialTrading.Tools.Validation;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Vipers.ModelCreators;
using SocialTrading.Connection.Dispatcher;
using SocialTrading.Droid.Views.EditContact;
using SocialTrading.Droid.Views.MoreOptions;
using SocialTrading.Droid.Routers.MoreOptions;
using SocialTrading.Vipers.EditContact.Implementation;
using SocialTrading.Vipers.EditContact.Interfaces;
using SocialTrading.Vipers.MoreOptions.ToolBar.Interfaces;
using SocialTrading.Vipers.MoreOptions.ToolBar.Implementation;

namespace SocialTrading.Droid.Fragments.MoreOptions
{
    public class EditContactFragment : Fragment
    {
        public string SelectedKey { get; set; }
        private IPresenterEditContact _presenter;


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.EditContactFragment, null, false);
            var editContactView = view.FindViewById<EditContactView>(Resource.Id.editContact_view_EditContactView);

            Holder holder = new Holder(view);

            var interactor = new InteractorEditContact(
                new EditContactController(Connection.ConnectionController.GetInstance(),
                    DataService.RepositoryController.RepositoryUserSettings, WebMsgParser.ParseResponsePersonalInfo),
                new EditContactModelCreator(DataService.RepositoryController.RepositoryUserSettings), new ValidationEditContact());

            _presenter = new PresenterEditContact(editContactView, interactor, new RouterEditContact(this));
            _presenter.SetConfig();
            _presenter.SetLocale(Locale.Localization.Lang);
            _presenter.SetTheme(new EditContactStyleHolderDroid<GlobalControlsTheme>(DroidDAL.ThemeParser));

            var routerToolBarBack = new RouterToolBarBack(Activity);
            var stylesHolderToolBarBack = new ToolBarBackStylesHolderDroid<GlobalControlsTheme>(DroidDAL.ThemeParser);

            var presenterToolBarBack = new PresenterToolBarBack(holder.ToolBarBackView, routerToolBarBack,
                stylesHolderToolBarBack, Locale.Localization.Lang.EditContactToolbarTitle);
            presenterToolBarBack.SetConfig();

            return view;
        }

        public override void OnResume()
        {
            base.OnResume();

            if (!string.IsNullOrEmpty(SelectedKey))
            {
                _presenter.SetSelectedCountry(SelectedKey);
            }
        }

        private class Holder
        {
            public IToolBarBackView ToolBarBackView { get; private set; }

            public Holder(View view)
            {
                ToolBarBackView = view.FindViewById<ToolBarBackView>(Resource.Id.toolbarBackButtonTitle_toolbar);
            }
        }
    }
}