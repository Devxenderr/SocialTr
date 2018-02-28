using SocialTrading.ThemesStyles;
using SocialTrading.ThemesStyles.Implementation;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.Vipers.Post.Interfaces.Social;

namespace SocialTrading.Vipers.Post.Implementation.Social
{
    public class PostSocialStylesHolderIOS<T> : IPostSocialStylesHolder where T : AGlobalControlsTheme
    {
        private string _notLikeThemeName = "PostSocialLikeNoneStyleIOS";
        private string _likeThemeName = "PostSocialLikeActiveStyleIOS";
        private string _commentThemeName = "PostSocialCommentStyleIOS";
        private string _shareThemeName = "PostSocialShareStyleIOS";

        public IButtonTheme NotLikeTheme { get; }
        public IButtonTheme LikeTheme { get; }
        public IButtonTheme CommentTheme { get; }
        public IButtonTheme ShareTheme { get; }

        public PostSocialStylesHolderIOS(ThemeParser<T> themeParser)
        {
            NotLikeTheme = themeParser.GetThemeByName<IButtonTheme>(_notLikeThemeName);
            LikeTheme = themeParser.GetThemeByName<IButtonTheme>(_likeThemeName);
            CommentTheme = themeParser.GetThemeByName<IButtonTheme>(_commentThemeName);
            ShareTheme = themeParser.GetThemeByName<IButtonTheme>(_shareThemeName);
        }
    }
}