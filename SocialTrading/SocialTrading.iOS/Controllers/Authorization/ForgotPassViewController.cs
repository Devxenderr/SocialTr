using UIKit;

using System;

using SocialTrading.Service;
using SocialTrading.iOS.Theme;
using SocialTrading.iOS.Tools;
using SocialTrading.Connection;
using SocialTrading.iOS.Routers;
using SocialTrading.Tools.Validation;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Connection.Dispatcher;
using SocialTrading.Vipers.ForgotPass.Implementation;

namespace SocialTrading.iOS
{
    public partial class ForgotPassViewController : UIViewController
    {
        public ForgotPassViewController (IntPtr handle) : base (handle)
        {
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var interactor = new InteractorForgotPass(new ValidationRA(), new ForgotPassController(ConnectionController.GetInstance(), WebMsgParser.ParseResponseRecoveryPassword));
            var presenter = new PresenterForgotPass(_forgotPassView, interactor , new RouterForgotPass(this), DataService.RepositoryController.RepositoryRA.LangRA, 
                new ForgotPassStylesHolderIOS<GlobalControlsTheme>(iOS_DAL.ThemeParser));

            presenter.SetConfig();
		}


        public override UIStatusBarStyle PreferredStatusBarStyle()
        {
            return UIStatusBarStyle.LightContent;
        }
    }
}