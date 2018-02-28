using Android.App;
using Android.Content;

using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Registration.Email.Interfaces;
using SocialTrading.Droid.Fragments.RegistrationFragments;

namespace SocialTrading.Droid.Routers
{
    public class RouterRegEmail : IRouterRegEmail
    {
        private Context _context;


        public RouterRegEmail(Context context)
        {
            _context = context;
        }


        public void ToRegPassword()
        {
            var fm = (_context as Activity).FragmentManager.BeginTransaction();
            fm.Replace(Resource.Id.reg_fragment_container, new RegistrationPasswordFragment());
            fm.AddToBackStack(EFragment.Password.ToString());
            fm.Commit();
        }

        public void ToRegPhone()
        {
            (_context as Activity).FragmentManager.PopBackStack();
        }
    }
}