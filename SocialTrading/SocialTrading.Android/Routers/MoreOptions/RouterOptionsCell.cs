using System;

using Android.App;

using SocialTrading.Tools.Enumerations;
using SocialTrading.Droid.Fragments.MoreOptions;
using SocialTrading.Vipers.MoreOptions.OptionsCell.Interfaces;

namespace SocialTrading.Droid.Routers.MoreOptions
{
    public class RouterOptionsCell : IRouterOptionsCell
    {
        private readonly FragmentManager _fragmentManager;

        public event Action OnLogoutClick;

        public RouterOptionsCell(FragmentManager fragmentManager)
        {
            _fragmentManager = fragmentManager ?? throw new NullReferenceException(nameof(_fragmentManager));
        }

        public void GoTo(EItemsOptions option)
        {
            FragmentTransaction fmTransaction;
            switch (option)
            {
                case EItemsOptions.EditProfileCell:
                    fmTransaction = _fragmentManager.BeginTransaction();
                    fmTransaction.Replace(Resource.Id.moreOptions_fragment_container, new EditProfileFragment());
                    fmTransaction.AddToBackStack(null);
                    fmTransaction.Commit();
                    break;
                case EItemsOptions.EditContactCell:
                    fmTransaction = _fragmentManager.BeginTransaction();
                    fmTransaction.Replace(Resource.Id.moreOptions_fragment_container, new EditContactFragment(), nameof(EditContactFragment));
                    fmTransaction.AddToBackStack(null);
                    fmTransaction.Commit();
                    break;
                case EItemsOptions.LogoutCell:
                    OnLogoutClick?.Invoke();                    
                    break;
                default:
                    break;
            }
        }
    }
}