using Android.Views;
using SocialTrading.Service;
using SocialTrading.Droid.Theme;
using Android.Support.V7.Widget;
using SocialTrading.Droid.Tools;
using SocialTrading.Droid.Views.MoreOptions;
using SocialTrading.Tools.Interfaces;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.ProfileCell.Interfaces;
using SocialTrading.Vipers.ProfileCell.Implementation;

namespace SocialTrading.Droid.ViewHolders
{
    internal class ProfileViewHolder : RecyclerView.ViewHolder, IProfileCell
    {
        private readonly IProfileCellView _profileCellView;       
        private IPresenterProfileCell _presenter;
        private IInteractorProfileCell _interactor;


        public ProfileViewHolder(View view) : base(view)
        {
            _profileCellView = view.FindViewById<ProfileCellView>(Resource.Id.moreOptions_profileCell_profileCellView);
        }

        public void SetData(EItemsOptions data)
        {
            _interactor = new InteractorProfileCell(DataService.RepositoryController.RepositoryUser.UserId ,new OptionsProfileController(DataService.RepositoryController.RepositoryUserAuth));
            _presenter  = new PresenterProfileCell(_profileCellView, _interactor, new ProfileCellStylesHolderDroid<GlobalControlsTheme>(DroidDAL.ThemeParser), DataService.RepositoryController.RepositoryMoreOptions.LangMoreOptions);
            _interactor.Presenter = _presenter;
            _presenter.SetConfig();
            _interactor.SendRequestForUserData();
        }       
    }
}