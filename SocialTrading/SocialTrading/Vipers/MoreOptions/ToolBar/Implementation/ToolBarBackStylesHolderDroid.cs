using SocialTrading.ThemesStyles;
using SocialTrading.ThemesStyles.Implementation;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.Vipers.MoreOptions.ToolBar.Interfaces;

namespace SocialTrading.Vipers.MoreOptions.ToolBar.Implementation
{
    public class ToolBarBackStylesHolderDroid<T> : IToolBarBackStylesHolder where T : AGlobalControlsTheme
    {
        private string _backButtonTheme  = "MoreOptionsToolBarBackButtonStyle";
        private string _titleTheme       = "MoreOptionsToolBarTitleStyle";
        private string _toolbarViewTheme = "MoreOptionsToolBarStyle";

        public IImageButtonTheme BackButtonTheme { get; }
        public ITextViewTheme TitleTheme         { get; }
        public IViewTheme ToolbarViewTheme       { get; }

        public ToolBarBackStylesHolderDroid(ThemeParser<T> themeParser)
        {
            BackButtonTheme  = themeParser.GetThemeByName<IImageButtonTheme>(_backButtonTheme);
            TitleTheme       = themeParser.GetThemeByName<ITextViewTheme>(_titleTheme);
            ToolbarViewTheme = themeParser.GetThemeByName<IViewTheme>(_toolbarViewTheme);
        }
    }
}