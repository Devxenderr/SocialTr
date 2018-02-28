using UIKit;

using SocialTrading.Vipers.CreatePost.Interfaces;

namespace SocialTrading.iOS.Routers
{
    public class RouterCreatePost : IRouterCreatePost
    {
        private readonly CreatePostViewController _viewController;


        public RouterCreatePost(CreatePostViewController viewController)
        {
            _viewController = viewController;
        }

        public void ToGallery()
        {
            _viewController.PresentViewControllerAsync(_viewController.ImagePicker.ImagePicker, true);
        }

        public void ToPostsFeed()
        {
            _viewController.NavigationController?.PopViewController(true);
        }

        public void ToToolSelection()
        {
            var toolViewController = (ToolsViewController)UIStoryboard.FromName("Main", null).InstantiateViewController("ToolsList");
            _viewController.NavigationController?.PushViewController(toolViewController, true);
        }
    }
}