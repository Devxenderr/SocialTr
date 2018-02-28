using UIKit;

using System;

using SocialTrading.Service;
using SocialTrading.iOS.Routers;
using SocialTrading.iOS.Theme;
using SocialTrading.ThemesStyles;
using SocialTrading.Tools.Validation;
using SocialTrading.Vipers.Registration.Email.Interfaces;
using SocialTrading.Vipers.Registration.Email.Implementation;

namespace SocialTrading.iOS
{
    public partial class RegEmailViewController : UIViewController
    {
        private IPresenterRegEmail _presenter;
        private IInteractorRegEmail _interactor;


        public RegEmailViewController (IntPtr handle) : base (handle)
        {
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _interactor = new InteractorRegEmail(DataService.RepositoryController.RepositoryRA, new ValidationRA());
            _presenter = new PresenterRegEmail(_registrationEmail, _interactor, new RouterRegEmail(this), new RegEmailStylesHolderIOS<GlobalControlsTheme>(new ThemeParser<GlobalControlsTheme>()), DataService.RepositoryController.RepositoryRA.LangRA);
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