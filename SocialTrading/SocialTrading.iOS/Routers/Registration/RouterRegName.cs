using UIKit;

using SocialTrading.iOS.Tools;
using SocialTrading.Vipers.Registration.Name.Interfaces;

namespace SocialTrading.iOS.Routers
{
    public class RouterRegName : IRouterRegName
    {
        private UIViewController _viewController;


        public RouterRegName(UIViewController viewController)
        {
            _viewController = viewController;
        }


        public void ToAuth()
        {
            _viewController.PerformSegue(iOS_DAL.SegueStrings.ToAuthFromRegName, _viewController);

		}

        public void ToRegPhone()
        {
            _viewController.PerformSegue(iOS_DAL.SegueStrings.ToRegistrationPhoneNumber, _viewController);
        }
    }
}