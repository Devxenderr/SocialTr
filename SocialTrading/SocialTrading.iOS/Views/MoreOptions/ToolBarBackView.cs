using UIKit;

using SocialTrading.Vipers.MoreOptions;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.Vipers.MoreOptions.ToolBar.Interfaces;

namespace SocialTrading.iOS.Views.MoreOptions
{
    public class ToolBarBackView : IToolBarBackView
    {
        UIBarButtonItem _backButton;
        UINavigationItem _navigationItem;
        UINavigationBar _navigationBar;

        public ToolBarBackView(UINavigationItem navigationItem, UINavigationBar navigationBar)
        {
            _navigationItem = navigationItem;
            _navigationBar = navigationBar;

            _backButton = new UIBarButtonItem(new UIImage(), UIBarButtonItemStyle.Plain, (sender, e) => {Presenter.BackClick();});
            _navigationItem.SetLeftBarButtonItem(_backButton, true);
        }

        #region IToolBarBackView
        public IPresenterToolBarBack Presenter { private get; set; }

        public void SetBackButtonTheme(IImageButtonTheme theme)
        {
            _backButton.Image = (UIImage) theme.Image;
            _navigationBar.TintColor = (UIColor) theme.TintColor;
        }

        public void SetTitle(string title)
        {
            _navigationItem.Title = title;
        }

        public void SetTitleTheme(ITextViewTheme theme)
        {
            var strAttr = new UIStringAttributes();
            strAttr.ForegroundColor = (UIColor) theme.TextColor;
            _navigationBar.TitleTextAttributes = strAttr;
        }

        public void SetViewTheme(IViewTheme theme)
        {
            _navigationBar.Translucent = false;
            _navigationBar.BarTintColor = (UIColor)theme.BackgroundColor;
        }

        #endregion
    }
}
