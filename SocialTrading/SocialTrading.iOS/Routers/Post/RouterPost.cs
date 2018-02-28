using UIKit;
using Foundation;
using SocialTrading.Vipers.Post.Interfaces;

namespace SocialTrading.iOS.Routers
{
    public class RouterPost : IRouterPost 
    {
        private UIViewController _viewController;


        public RouterPost(UIViewController viewController)
        {
            _viewController = viewController;
        }
        
        public void ToDetailedPost()
        {
            
        }

        public void ToComments()
        {
            
        }

        public void ToShare(string link)
        {
            var activitiesItems = new[]
            {
                (NSString)link
            };

            var activityController = new UIActivityViewController(activitiesItems, null);
            _viewController.PresentViewController(activityController, true, null);
        }

        public void ToProfile()
        {
            
        }

        public void OnBack()
        {
            
        }

        public void ToDetailedPost(string id)
        {
            var detailedPostViewController = (DetailedPostViewController)UIStoryboard.FromName("Main", null).InstantiateViewController("DetailedPost");
            detailedPostViewController.PostId = id;
            _viewController.NavigationController?.PushViewController(detailedPostViewController, true);
        }

        public void ToEditPost(string postId)
        {
            var updatePostViewController = (UpdatePostViewController)UIStoryboard.FromName("Main", null).InstantiateViewController("UpdatePost");
            updatePostViewController.PostId = postId;
            _viewController.NavigationController?.PushViewController(updatePostViewController, true);
        }
    }
}