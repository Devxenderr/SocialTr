using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;

namespace SocialTrading.Vipers.Post.ToolBar.Intarfaces
{
    public interface IToolBarPostsStylesHolder
    {
        IImageButtonTheme MoreButtonTheme { get; }
        ITextViewTheme TitleTheme { get; }
        IViewTheme ToolbarViewTheme { get; }
        ITextViewTheme CreatePostButton { get; }
    }
}
