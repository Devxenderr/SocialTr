using Android.App;
using Android.Content;

using SocialTrading.Droid.Activities;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Droid.Fragments.RegistrationFragments;
using SocialTrading.Vipers.Registration.Password.Interfaces;

namespace SocialTrading.Droid.Routers
{
    public class RouterRegPass : IRouterRegPass
    {
        private Context _context;


        public RouterRegPass(Context context)
        {
            _context = context;
        }


        public void ToAuth()
        {
            Intent intent = new Intent(_context, typeof(AuthActivity));
            _context.StartActivity(intent);

            (_context as Activity).Finish();
        }

        public void ToRegEmail()
        {
            (_context as Activity).FragmentManager.PopBackStack();
        }

        public void ToUserAgreement()
        {
            var fm = (_context as Activity).FragmentManager.BeginTransaction();
            fm.Replace(Resource.Id.reg_fragment_container, new UserAgreementFragment());
            fm.AddToBackStack(EFragment.UserAgreement.ToString());
            fm.Commit();
        }
    }
}