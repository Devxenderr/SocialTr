using UIKit;

using SocialTrading.Vipers.UpdatePost.Interfaces;

namespace SocialTrading.iOS.Routers.UpdatePost
{
    public class RouterUpdatePost : IRouterUpdatePost
    {
        private readonly UIViewController _viewController;


        public RouterUpdatePost(UIViewController viewController)
        {
            _viewController = viewController;
        }


        public void ToGallery()
        {
            _viewController.PresentViewControllerAsync((_viewController as UpdatePostViewController).ImagePicker.ImagePicker, true);
        }

        public void ToPostsFeed()
        {
            _viewController.NavigationController?.PopViewController(true);
        }
    }
}