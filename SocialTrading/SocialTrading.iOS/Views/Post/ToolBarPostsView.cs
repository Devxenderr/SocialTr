using UIKit;

using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.Vipers.Post.ToolBar.Intarfaces;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;

namespace SocialTrading.iOS.Views.Post
{
    public class ToolBarPostsView : IViewToolBarPosts
    {
        private readonly UIBarButtonItem _moreButton;
        private readonly UIBarButtonItem _createPostButton;
        private readonly UINavigationItem _navigationItem;
        private readonly UINavigationBar _navigationBar;

        public ToolBarPostsView(UINavigationItem navigationItem, UINavigationBar navigationBar)
        {
            _navigationItem = navigationItem;
            _navigationBar = navigationBar;

            _moreButton = new UIBarButtonItem(new UIImage(), UIBarButtonItemStyle.Plain, (sender, e) => { Presenter.MoreClick(); });
            _navigationItem.SetLeftBarButtonItem(_moreButton, true);

            _createPostButton = new UIBarButtonItem("", UIBarButtonItemStyle.Plain, (sender, e) => { Presenter.CreatePostClick(); });
            _navigationItem.SetRightBarButtonItem(_createPostButton, true);
        }
        
        public IPresenterToolBarPosts Presenter { private get; set; }
        
        public void SetCreatePostTheme(ITextViewTheme theme)
        {
            var strAttr = new UITextAttributes();
            strAttr.TextColor = (UIColor)theme.TextColor;
            _createPostButton.SetTitleTextAttributes(strAttr, UIControlState.Normal);
        }

        public void SetTitle(string title)
        {
            _navigationItem.Title = title;
        }

        public void SetCreatePostString(string title)
        {
            _createPostButton.Title = title;
        }

        public void SetTitleTheme(ITextViewTheme theme)
        {
            var strAttr = new UIStringAttributes();
            strAttr.ForegroundColor = (UIColor)theme.TextColor;
            _navigationBar.TitleTextAttributes = strAttr;
        }

        public void SetMoreButtonTheme(IImageButtonTheme theme)
        {
            _moreButton.Image = (UIImage)theme.Image;
            _navigationBar.TintColor = (UIColor)theme.TintColor;
        }

        public void SetViewTheme(IViewTheme theme)
        {
            _navigationBar.Translucent = false;
            _navigationBar.BarTintColor = (UIColor)theme.BackgroundColor;
        }
    }
}