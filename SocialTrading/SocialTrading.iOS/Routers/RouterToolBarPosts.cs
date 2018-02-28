using SocialTrading.Vipers.Post.ToolBar.Intarfaces;
using UIKit;

namespace SocialTrading.iOS.Routers
{
    public class RouterToolBarPosts : IRouterToolBarPosts
    {
        private readonly UINavigationController _navigationController;

        public RouterToolBarPosts(UINavigationController navigationController)
        {
            _navigationController = navigationController;
        }

        public void GoToCreatePost()
        {
            var createPostViewController = (CreatePostViewController)UIStoryboard.FromName("Main", null).InstantiateViewController("CreatePost");
            _navigationController?.PushViewController(createPostViewController, true);
        }

        public void GoToMoreOptions()
        {
            var moreOptionsViewController = (MoreOptionsViewController)UIStoryboard.FromName("Main", null).InstantiateViewController("MoreOptionsViewController");
            _navigationController?.PushViewController(moreOptionsViewController, true);
        }
    }
}
