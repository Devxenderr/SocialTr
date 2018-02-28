using System;

using Android.App;
using Android.Views.InputMethods;

using SocialTrading.Droid.Fragments.MoreOptions;
using SocialTrading.Vipers.EditContact.Interfaces;

namespace SocialTrading.Droid.Routers.MoreOptions
{
    public class RouterEditContact : IRouterEditContact
    {
        private readonly EditContactFragment _fragment;


        public RouterEditContact(EditContactFragment fragment)
        {
            _fragment = fragment ?? throw new NullReferenceException(nameof(fragment));
        }


        public void ToCountrySelection()
        {
            var manager = (InputMethodManager)_fragment.Activity.GetSystemService(Activity.InputMethodService);
            manager.HideSoftInputFromWindow(_fragment.Activity.CurrentFocus?.WindowToken, 0);

            var fmTransaction = _fragment.FragmentManager.BeginTransaction();
            fmTransaction.Replace(Resource.Id.moreOptions_fragment_container, new CountriesFragment());
            fmTransaction.AddToBackStack(null);
            fmTransaction.Commit();
        }

        public void GoBack()
        {
            var manager = (InputMethodManager)_fragment.Activity.GetSystemService(Activity.InputMethodService);
            manager.HideSoftInputFromWindow(_fragment.Activity.CurrentFocus?.WindowToken, 0);

            _fragment.FragmentManager.PopBackStack();
        }
    }
}