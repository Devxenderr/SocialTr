using System;
using CoreAnimation;
using Foundation;
using SocialTrading.iOS.Theme;
using SocialTrading.iOS.Tools;
using SocialTrading.Service;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Tools.Interfaces;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Vipers.ProfileCell.Implementation;
using SocialTrading.Vipers.ProfileCell.Interfaces;
using UIKit;

namespace SocialTrading.iOS.Cells
{
    public partial class ProfileTableViewCell : UITableViewCell, IProfileCell
    {
        public static readonly NSString Key = new NSString("ProfileTableViewCell");
        public static readonly UINib Nib;

        private IPresenterProfileCell _presenter;
        private IInteractorProfileCell _interactor;

        static ProfileTableViewCell()
        {
            Nib = UINib.FromName("ProfileTableViewCell", NSBundle.MainBundle);
        }

        protected ProfileTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }


        public void SetData(EItemsOptions data)
        {
            this.SelectionStyle = UITableViewCellSelectionStyle.None;
            _interactor = new InteractorProfileCell(DataService.RepositoryController.RepositoryUser.UserId ,new OptionsProfileController(DataService.RepositoryController.RepositoryUserAuth));
            _presenter  = new PresenterProfileCell(_profileCellView, _interactor, new ProfileCellStylesHolderIOS <GlobalControlsTheme>(iOS_DAL.ThemeParser), DataService.RepositoryController.RepositoryMoreOptions.LangMoreOptions);
            _interactor.Presenter = _presenter;
            _presenter.SetConfig();
            _interactor.SendRequestForUserData();
        }
    }
}
