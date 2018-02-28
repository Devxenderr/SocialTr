using UIKit;

using SocialTrading.iOS.Tools;
using SocialTrading.Vipers.Authorization.Interfaces;

namespace SocialTrading.iOS.Routers
{
    public class RouterAuth : IRouterAuth
    {
        private UIViewController _viewController;


        public RouterAuth(UIViewController viewController)
        {
            _viewController = viewController;
        }


        public void ToForgotPass()
        {
            _viewController.InvokeOnMainThread(() =>
            {
                _viewController.PerformSegue(iOS_DAL.SegueStrings.ToForgotPass, _viewController);
            });
        }

        public void ToPostsFeed()
        {
            _viewController.InvokeOnMainThread(() =>
            {
                _viewController.PerformSegue(iOS_DAL.SegueStrings.ToNavigationPostsFromAuth, _viewController);
            });
        }

        public void ToRegistration()
        {
            _viewController.InvokeOnMainThread(() =>
            {
                _viewController.PerformSegue(iOS_DAL.SegueStrings.ToRegistration, _viewController);
            });
        }
    }
}