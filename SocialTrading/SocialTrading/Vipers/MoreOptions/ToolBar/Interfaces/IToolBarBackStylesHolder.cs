using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.View;

namespace SocialTrading.Vipers.MoreOptions.ToolBar.Interfaces
{
    public interface IToolBarBackStylesHolder
    {
        IImageButtonTheme BackButtonTheme  { get; }
        ITextViewTheme TitleTheme          { get; }
        IViewTheme ToolbarViewTheme        { get; }
    }
}