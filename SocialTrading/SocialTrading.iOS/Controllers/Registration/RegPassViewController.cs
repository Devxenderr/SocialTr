using UIKit;

using System;

using SocialTrading.Service;
using SocialTrading.iOS.Theme;
using SocialTrading.Connection;
using SocialTrading.iOS.Routers;
using SocialTrading.ThemesStyles;
using SocialTrading.Tools.Validation;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Connection.Dispatcher;
using SocialTrading.Vipers.Registration.Password.Interfaces;
using SocialTrading.Vipers.Registration.Password.Implementation;

namespace SocialTrading.iOS
{
    public partial class RegPassViewController : UIViewController
    {
        private IPresenterRegPass _presenter;
        private IInteractorRegPass _interactor;


		public RegPassViewController (IntPtr handle) : base (handle)
        {
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
		
            _interactor = new InteractorRegPass(new RegController(ConnectionController.GetInstance(), WebMsgParser.ParseResponseReg), DataService.RepositoryController.RepositoryRA, new ValidationRA());
            _presenter = new PresenterRegPass(_registrationPassword, _interactor, new RouterRegPass(this), new RegPassStylesHolderIOS<GlobalControlsTheme>(new ThemeParser<GlobalControlsTheme>()), DataService.RepositoryController.RepositoryRA.LangRA);
            _presenter.SetConfig();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
         //   _presenter.Subscribe();
			_presenter.LoadData();
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
          //  _presenter.UnSubscribe();
            _presenter.SaveData();
        }

        public override UIStatusBarStyle PreferredStatusBarStyle()
        {
            return UIStatusBarStyle.LightContent;
        }
    }
}