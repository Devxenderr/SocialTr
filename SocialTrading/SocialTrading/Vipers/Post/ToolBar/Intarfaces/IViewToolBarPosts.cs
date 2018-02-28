using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;

namespace SocialTrading.Vipers.Post.ToolBar.Intarfaces
{
    public interface IViewToolBarPosts
    {
        IPresenterToolBarPosts Presenter { set; }

        void SetMoreButtonTheme(IImageButtonTheme theme);
        void SetViewTheme(IViewTheme theme);
        void SetTitleTheme(ITextViewTheme theme);
        void SetCreatePostTheme(ITextViewTheme theme);

        void SetTitle(string title);
        void SetCreatePostString(string title);
    }
}
