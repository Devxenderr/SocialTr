using Android.App;
using Android.Content;

using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Registration.Name.Interfaces;
using SocialTrading.Droid.Fragments.RegistrationFragments;

namespace SocialTrading.Droid.Routers
{
    public class RouterRegName : IRouterRegName
    {
        private Context _context;


        public RouterRegName(Context context)
        {
            _context = context;
        }


        public void ToAuth()
        {
            (_context as Activity).Finish();
        }

        public void ToRegPhone()
        {
            var fm = (_context as Activity).FragmentManager.BeginTransaction();
            fm.Replace(Resource.Id.reg_fragment_container, new RegistrationPhoneFragment());
            fm.AddToBackStack(EFragment.Phone.ToString());
            fm.Commit();
        }
    }
}