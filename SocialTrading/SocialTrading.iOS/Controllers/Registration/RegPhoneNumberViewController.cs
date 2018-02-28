using UIKit;

using System;

using SocialTrading.Service;
using SocialTrading.iOS.Routers;
using SocialTrading.iOS.Theme;
using SocialTrading.ThemesStyles;
using SocialTrading.Tools.Validation;
using SocialTrading.Vipers.Registration.Phone.Interfaces;
using SocialTrading.Vipers.Registration.Phone.Implementation;

namespace SocialTrading.iOS
{
    public partial class RegPhoneNumberViewController : UIViewController
    {
        private IPresenterRegPhone _presenter;
        private IInteractorRegPhone _interactor;

        public RegPhoneNumberViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
           _interactor = new InteractorRegPhone(DataService.RepositoryController.RepositoryRA, new ValidationRA());
            _presenter = new PresenterRegPhone(_registrationPhoneNumber, _interactor, new RouterRegPhone(this), new RegPhoneStylesHolderIOS<GlobalControlsTheme>(new ThemeParser<GlobalControlsTheme>()), DataService.RepositoryController.RepositoryRA.LangRA);
            _presenter.SetConfig();
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
            _presenter.LoadData();
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
			_presenter.SaveData();
        }

        public override UIStatusBarStyle PreferredStatusBarStyle()
        {
            return UIStatusBarStyle.LightContent;
        }
    }
}