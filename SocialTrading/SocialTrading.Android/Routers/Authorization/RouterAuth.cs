using Android.Content;

using SocialTrading.Droid.Activities;
using SocialTrading.Vipers.Authorization.Interfaces;

namespace SocialTrading.Droid.Routers
{
    public class RouterAuth : IRouterAuth
    {
        private Context _context;


        public RouterAuth(Context context)
        {
            _context = context;
        }


        public void ToForgotPass()
        {
            Intent intent = new Intent(_context, typeof(ForgotPassActivity));
            _context.StartActivity(intent);
        }

        public void ToPostsFeed()
        {
            Intent intent = new Intent(_context, typeof(TabbedActivity));
            _context.StartActivity(intent);
        }

        public void ToRegistration()
        {
            Intent intent = new Intent(_context, typeof(RegistrationActivity));
            _context.StartActivity(intent);
        }
    }
}