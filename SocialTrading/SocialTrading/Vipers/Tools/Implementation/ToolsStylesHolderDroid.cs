using SocialTrading.ThemesStyles;
using SocialTrading.ThemesStyles.Implementation;
using SocialTrading.Vipers.Tools.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.TextView;

namespace SocialTrading.Vipers.Tools.Implementation
{
    public class ToolsStylesHolderDroid<T> : IToolsStylesHolder where T :AGlobalControlsTheme
    {
        private string _unselectedCellTheme = "ToolsUnselectedCellStyle";
        private string _selectedCellTheme = "ToolsSelectedCellStyle";
        private string _toolNameTheme = "ToolsNameStyle";

        public IViewTheme UnselectedCellTheme { get; }
        public IViewTheme SelectedCellTheme { get; }
        public ITextViewTheme ToolNameTheme { get; }

        public ToolsStylesHolderDroid(ThemeParser<T> themeParser)
        {
            UnselectedCellTheme = themeParser.GetThemeByName<IViewTheme>(_unselectedCellTheme);
            SelectedCellTheme = themeParser.GetThemeByName<IViewTheme>(_selectedCellTheme);
            ToolNameTheme = themeParser.GetThemeByName<ITextViewTheme>(_toolNameTheme);
        }
    }
}