using Android.OS;
using Android.App;
using Android.Views;

using SocialTrading.Locale;
using SocialTrading.Service;
using SocialTrading.Connection;
using SocialTrading.Droid.Theme;
using SocialTrading.Droid.Tools;
using SocialTrading.Tools.Validation;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Vipers.ModelCreators;
using SocialTrading.Connection.Dispatcher;
using SocialTrading.Droid.Views.EditProfile;
using SocialTrading.Droid.Views.MoreOptions;
using SocialTrading.Droid.Routers.MoreOptions;
using SocialTrading.Vipers.MoreOptions.ToolBar.Interfaces;
using SocialTrading.Vipers.MoreOptions.EditProfile.Interfaces;
using SocialTrading.Vipers.MoreOptions.ToolBar.Implementation;
using SocialTrading.Vipers.MoreOptions.EditProfile.Implementation;

namespace SocialTrading.Droid.Fragments.MoreOptions
{
    public class EditProfileFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.EditProfileFragment, null, false);

            var holder = new Holder(view);
            
            var interactorEditProfile = new InteractorEditProfile(new ValidationEditProfile(), 
                new EditProfileController(ConnectionController.GetInstance(), DataService.RepositoryController.RepositoryUserSettings, 
                WebMsgParser.ParseResponsePersonalInfo), new EditProfileModelCreator(DataService.RepositoryController.RepositoryUserSettings));
            var preseneterEditProfile = new PresenterEditProfile(holder.EditProfileView, interactorEditProfile, 
                new RouterEditProfile(this), new EditProfileStylesHolderDroid<GlobalControlsTheme>(DroidDAL.ThemeParser), Localization.Lang);

            var routerToolBarBack = new RouterToolBarBack(Activity);
            var stylesHolderToolBarBack = new ToolBarBackStylesHolderDroid<GlobalControlsTheme>(DroidDAL.ThemeParser);
            var presenterToolBarBack = new PresenterToolBarBack(holder.ToolBarBackView, routerToolBarBack,
                stylesHolderToolBarBack, Localization.Lang.MoreOptionsProfileSettings);
            presenterToolBarBack.SetConfig();

            return view;
        }


        private class Holder
        {
            public IToolBarBackView ToolBarBackView { get; private set; }
            public IViewEditProfile EditProfileView { get; private set; }

            public Holder(View view)
            {
                ToolBarBackView = view.FindViewById<ToolBarBackView>(Resource.Id.toolbarBackButtonTitle_editProfile_toolbar);
                EditProfileView = view.FindViewById<EditProfileView>(Resource.Id.editProfile_view_EditProfileView);
            }
        }
    }
}