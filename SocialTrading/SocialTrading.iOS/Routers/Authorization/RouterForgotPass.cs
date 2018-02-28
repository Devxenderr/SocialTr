using UIKit;

using SocialTrading.Vipers.ForgotPass.Interfaces;
using SocialTrading.iOS.Tools;

namespace SocialTrading.iOS.Routers
{
    public class RouterForgotPass : IRouterForgotPass
    {
        private UIViewController _viewController;


        public RouterForgotPass(UIViewController viewController)
        {
            _viewController = viewController;
        }


        public void ToAuth()
        {
            _viewController.InvokeOnMainThread(() =>
            {
                _viewController.PerformSegue(iOS_DAL.SegueStrings.ToAuthFromForgotFass, _viewController);
            });
        }
    }
}