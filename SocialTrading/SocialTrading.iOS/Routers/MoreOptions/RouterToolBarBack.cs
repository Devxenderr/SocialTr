using SocialTrading.Vipers.MoreOptions.ToolBar.Interfaces;
using UIKit;

namespace SocialTrading.iOS.Routers.MoreOptions
{
    public class RouterToolBarBack : IRouterToolBarBack
    {
        UINavigationController _navigationController;

        public RouterToolBarBack(UINavigationController navigationController)
        {
            _navigationController = navigationController;
        }

        public void GoBack()
        {
            _navigationController.PopViewController(true);
        }
    }
}
