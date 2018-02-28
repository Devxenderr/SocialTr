using UIKit;

using System;

using Facebook.LoginKit;

using SocialTrading.Theme;
using SocialTrading.Service;
using SocialTrading.iOS.Theme;
using SocialTrading.iOS.Tools;
using SocialTrading.Connection;
using SocialTrading.iOS.Routers;
using SocialTrading.ThemesStyles;
using SocialTrading.Tools.Validation;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Connection.Dispatcher;
using SocialTrading.Vipers.Authorization.Interfaces;
using SocialTrading.Vipers.Authorization.Implementation;
using SocialTrading.Tools.Enumerations;

namespace SocialTrading.iOS
{
    public partial class AuthViewController : UIViewController
    {
        private IPresenterAuth _presenter;
        private IInteractorAuth _interactor;
        private LoginManager _loginManager;

        public AuthViewController (IntPtr handle) : base (handle)
        {
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            _loginManager = new LoginManager();
            _loginManager.LoginBehavior = LoginBehavior.Web;
#if MOCK
            _interactor = new InteractorAuth(new AuthController(ConnectionController.GetInstance(), WebMsgParser.ParseResponseAuth), new ValidationRA());
            ThemeHolder.Init(DataService.RepositoryController.RepositoryThemes);
            _presenter = new PresenterAuthMOCK(_authView, _interactor, new RouterAuth(this), FacebookCallLoginAction, null, null, null, new AuthStylesHolderIOS<GlobalControlsTheme>(new ThemeParser<GlobalControlsTheme>()), DataService.RepositoryController.RepositoryRA.LangRA);
#else
            _interactor = new InteractorAuth(new AuthController(ConnectionController.GetInstance(), WebMsgParser.ParseResponseAuth), new ValidationRA());
            ThemeHolder.Init(DataService.RepositoryController.RepositoryThemes);
           
            _presenter = new PresenterAuth(_authView, _interactor, new RouterAuth(this), FacebookCallLoginAction, null, null, null, 
                new AuthStylesHolderIOS<GlobalControlsTheme>(new ThemeParser<GlobalControlsTheme>()), DataService.RepositoryController.RepositoryRA.LangRA);
#endif

            _presenter.SetConfig();

            _interactor.OnSocialLogOut += SocialLogout;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            _interactor.OnSocialLogOut -= SocialLogout;
        }

        private void SocialLogout(ESocialType type)
        {
            if (type == ESocialType.Facebook)
            {
                _interactor.OnCancel(ESocialType.Facebook);
                _loginManager.LogOut();
            }
        }

        public override UIStatusBarStyle PreferredStatusBarStyle()
        {
            return UIStatusBarStyle.LightContent;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            _presenter.DisposeRepositoryRA();
        }

        private void FacebookCallLoginAction()
        {
            _loginManager.LogInWithReadPermissions(new[] { "email", "public_profile" }, this, (result, error) => { FacebookLoginResultHandler.Handler(result, error, _interactor, _loginManager); });
        }
    }
}