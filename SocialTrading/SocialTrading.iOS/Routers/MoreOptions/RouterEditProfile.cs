using UIKit;

using SocialTrading.Vipers.MoreOptions.EditProfile.Interfaces;

namespace SocialTrading.iOS.Routers.MoreOptions
{
    public class RouterEditProfile : IRouterEditProfile
    {
        UINavigationController _navigationController;

        public RouterEditProfile(UINavigationController navigationController)
        {
            _navigationController = navigationController;
        }

        public void GoBack()
        {
            _navigationController.PopViewController(true);
        }
    }
}