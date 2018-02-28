using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.TextView;

namespace SocialTrading.Vipers.Tools.Interfaces.View
{
    public interface IToolsStylesHolder
    {
        IViewTheme UnselectedCellTheme { get; }
        IViewTheme SelectedCellTheme { get; }
        ITextViewTheme ToolNameTheme { get; }
    }
}