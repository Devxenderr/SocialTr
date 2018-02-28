using UIKit;

using SocialTrading.iOS.Tools;
using SocialTrading.Vipers.Registration.Phone.Interfaces;

namespace SocialTrading.iOS.Routers
{
    public class RouterRegPhone : IRouterRegPhone
    {
        private UIViewController _viewController;


        public RouterRegPhone(UIViewController viewController)
        {
            _viewController = viewController;
        }
        

        public void ToRegEmail()
        {
            _viewController.PerformSegue(iOS_DAL.SegueStrings.ToRegistrationEmail, _viewController);
        }

        public void ToRegName()
        {
            _viewController.PerformSegue(iOS_DAL.SegueStrings.ToNameFromRegPhone, _viewController);
		}
    }
}