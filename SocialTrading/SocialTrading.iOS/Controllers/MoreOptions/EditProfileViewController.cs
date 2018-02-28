using System;

using UIKit;

using SocialTrading.Locale;
using SocialTrading.Service;
using SocialTrading.iOS.Theme;
using SocialTrading.iOS.Tools;
using SocialTrading.Connection;
using SocialTrading.Tools.Validation;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Vipers.ModelCreators;
using SocialTrading.Connection.Dispatcher;
using SocialTrading.iOS.Views.MoreOptions;
using SocialTrading.iOS.Routers.MoreOptions;
using SocialTrading.Vipers.MoreOptions.ToolBar.Implementation;
using SocialTrading.Vipers.MoreOptions.EditProfile.Implementation;

namespace SocialTrading.iOS.Controllers.MoreOptions
{
    public partial class EditProfileViewController : UIViewController
    {
        public EditProfileViewController(IntPtr handle) : base(handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
            NavigationController.NavigationBar.Hidden = false;

            var locale = Localization.Lang;
            _editProfileView.GetViewController = iOS_DAL.GetViewControllerForView;
            var interactorEditProfile = new InteractorEditProfile(new ValidationEditProfile(),
                new EditProfileController(ConnectionController.GetInstance(), 
                                          DataService.RepositoryController.RepositoryUserSettings,
                                          WebMsgParser.ParseResponsePersonalInfo),
                new EditProfileModelCreator(DataService.RepositoryController.RepositoryUserSettings));
            var preseneterEditProfile = new PresenterEditProfile(_editProfileView, 
                                                                 interactorEditProfile,
                                                                 new RouterEditProfile(NavigationController), 
                                                                 new EditProfileStylesHolderIOS<GlobalControlsTheme>(iOS_DAL.ThemeParser), 
                                                                 locale);

            var toolbarBackView = new ToolBarBackView(NavigationItem, NavigationController.NavigationBar);
            var routerToolBarBack = new RouterToolBarBack(NavigationController);
            var stylesHolderToolBarBack = new ToolBarBackStylesHolderIOS<GlobalControlsTheme>(iOS_DAL.ThemeParser);
            var title = locale.EditProfileToolbarTitle;
            var presenterToolBarBack = new PresenterToolBarBack(toolbarBackView, routerToolBarBack, stylesHolderToolBarBack, title);
            presenterToolBarBack.SetConfig();
        }
    }
}