using Android.App;
using Android.Content;

using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Registration.Phone.Interfaces;
using SocialTrading.Droid.Fragments.RegistrationFragments;

namespace SocialTrading.Droid.Routers
{
    public class RouterRegPhone : IRouterRegPhone
    {
        private Context _context;


        public RouterRegPhone(Context context)
        {
            _context = context;
        }
        

        public void ToRegEmail()
        {
            var fm = (_context as Activity).FragmentManager.BeginTransaction();
            fm.Replace(Resource.Id.reg_fragment_container, new RegistrationEmailFragment());
            fm.AddToBackStack(EFragment.Email.ToString());
            fm.Commit();
        }

        public void ToRegName()
        {
            (_context as Activity).FragmentManager.PopBackStack();
        }
    }
}