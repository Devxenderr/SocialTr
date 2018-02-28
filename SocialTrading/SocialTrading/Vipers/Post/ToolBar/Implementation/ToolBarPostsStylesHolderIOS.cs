using SocialTrading.ThemesStyles;
using SocialTrading.ThemesStyles.Implementation;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.Vipers.Post.ToolBar.Intarfaces;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;

namespace SocialTrading.Vipers.Post.ToolBar.Implementation
{
    public class ToolBarPostsStylesHolderIOS<T> : IToolBarPostsStylesHolder where T : AGlobalControlsTheme
    {
        private string _moreButtonTheme = "PostsMenuButtonStyleIOS";
        private string _titleTheme      = "PostsToolBarTitleStyle";
        private string _viewTheme       = "PostsToolBarStyle";
        private string _createPostTheme = "PostsCreatePostStyle";
        
        public IImageButtonTheme MoreButtonTheme { get; }
        public ITextViewTheme TitleTheme         { get; }
        public IViewTheme ToolbarViewTheme       { get; }
        public ITextViewTheme CreatePostButton   { get; }

        public ToolBarPostsStylesHolderIOS(ThemeParser<T> themeParser)
        {
            MoreButtonTheme = themeParser.GetThemeByName<IImageButtonTheme>(_moreButtonTheme);
            TitleTheme = themeParser.GetThemeByName<ITextViewTheme>(_titleTheme);
            ToolbarViewTheme = themeParser.GetThemeByName<IViewTheme>(_viewTheme);
            CreatePostButton = themeParser.GetThemeByName<ITextViewTheme>(_createPostTheme);
        }
    }
}
