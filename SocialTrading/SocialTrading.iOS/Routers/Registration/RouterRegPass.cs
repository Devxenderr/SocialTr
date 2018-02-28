using UIKit;

using SocialTrading.iOS.Tools;
using SocialTrading.Vipers.Registration.Password.Interfaces;

namespace SocialTrading.iOS.Routers
{
    public class RouterRegPass : IRouterRegPass
    {
        private UIViewController _viewController;


        public RouterRegPass(UIViewController viewController)
        {
            _viewController = viewController;
        }
        
        
        public void ToRegEmail()
        {
            _viewController.PerformSegue(iOS_DAL.SegueStrings.ToEmailFromRegPass, _viewController);
		}

        public void ToUserAgreement()
        {
            _viewController.PerformSegue(iOS_DAL.SegueStrings.ToUserAgreement, _viewController);
        }

        public void ToAuth()
        {
            var authViewController = UIStoryboard.FromName("Main", null).InstantiateViewController("AuthViewController");
            _viewController.PresentViewController(authViewController, true, null);
        }
    }
}