using UIKit;

using System;

using SocialTrading.Theme;
using SocialTrading.Service;
using SocialTrading.iOS.Routers;
using SocialTrading.iOS.Theme;
using SocialTrading.ThemesStyles;
using SocialTrading.Tools.Validation;
using SocialTrading.Vipers.Registration.Name.Interfaces;
using SocialTrading.Vipers.Registration.Name.Implementation;

namespace SocialTrading.iOS
{
    public partial class RegNameViewController : UIViewController
    {
        private IPresenterRegName _presenter;
        private IInteractorRegName _interactor;

        public RegNameViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _interactor = new InteractorRegName(DataService.RepositoryController.RepositoryRA, new ValidationRA());
          
            _presenter = new PresenterRegName(_registrationName, new InteractorRegName(DataService.RepositoryController.RepositoryRA, new ValidationRA()), 
                                              new RouterRegName(this), new RegNameStylesHolderIOS<GlobalControlsTheme>(new ThemeParser<GlobalControlsTheme>()), DataService.RepositoryController.RepositoryRA.LangRA);
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