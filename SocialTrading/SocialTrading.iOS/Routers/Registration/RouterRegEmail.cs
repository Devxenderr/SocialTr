using UIKit;

using SocialTrading.iOS.Tools;
using SocialTrading.Vipers.Registration.Email.Interfaces;

namespace SocialTrading.iOS.Routers
{
    public class RouterRegEmail : IRouterRegEmail
    {
        private UIViewController _viewController;


        public RouterRegEmail(UIViewController viewController)
        {
            _viewController = viewController;
        }


        public void ToRegPassword()
        {
            _viewController.PerformSegue(iOS_DAL.SegueStrings.ToRegistrationPassword, _viewController);
        }

        public void ToRegPhone()
        {
           _viewController.PerformSegue(iOS_DAL.SegueStrings.ToPhoneFromRegEmail, _viewController);
        }
    }
}