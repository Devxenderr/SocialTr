using Android.App;
using Android.Content;

using SocialTrading.Vipers.ForgotPass.Interfaces;

namespace SocialTrading.Droid.Routers
{
    public class RouterForgotPass : IRouterForgotPass
    {
        private readonly Context _context;


        public RouterForgotPass(Context context)
        {
            _context = context;
        }


        public void ToAuth()
        {
            (_context as Activity).Finish();
        }
    }
}