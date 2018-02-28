using System;

using Android.App;
using Android.Views.InputMethods;

using SocialTrading.Droid.Fragments.MoreOptions;
using SocialTrading.Vipers.MoreOptions.EditProfile.Interfaces;

namespace SocialTrading.Droid.Routers.MoreOptions
{
    public class RouterEditProfile : IRouterEditProfile
    {
        private readonly EditProfileFragment _fragment;


        public RouterEditProfile(EditProfileFragment fragment)
        {
            _fragment = fragment ?? throw new NullReferenceException(nameof(fragment));
        }


        public void GoBack()
        {
            var manager = (InputMethodManager)_fragment.Activity.GetSystemService(Activity.InputMethodService);
            manager.HideSoftInputFromWindow(_fragment.Activity.CurrentFocus?.WindowToken, 0);

            _fragment.FragmentManager.PopBackStack();
        }
    }
}