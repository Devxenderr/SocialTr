using UIKit;

using System.Linq;

using SocialTrading.Vipers.Tools.Interfaces.Router;

namespace SocialTrading.iOS.Routers.CreatePost
{
    public class RouterToolsIOS : IRouterTools
    {
        private UIViewController _viewController;

        public RouterToolsIOS(UIViewController viewCntroller)
        {
            _viewController = viewCntroller;
        }

        public void GoBack(string selectedKey)
        {
            var previousController = _viewController.NavigationController.ViewControllers
                .FirstOrDefault(x => x is CreatePostViewController) as CreatePostViewController;

            if (previousController != null)
            {
                previousController.SelectedKey = selectedKey;
            }

            _viewController.NavigationController.PopViewController(true);
        }
    }
}
