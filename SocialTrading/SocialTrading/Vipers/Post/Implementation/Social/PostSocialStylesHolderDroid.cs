using SocialTrading.ThemesStyles;
using SocialTrading.ThemesStyles.Implementation;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.Vipers.Post.Interfaces.Social;

namespace SocialTrading.Vipers.Post.Implementation.Social
{
    public class PostSocialStylesHolderDroid<T> : IPostSocialStylesHolder where T : AGlobalControlsTheme
    {
        private string _notLikeThemeName = "PostSocialLikeNoneStyleDroid";
        private string _likeThemeName = "PostSocialLikeActiveStyleDroid";
        private string _commentThemeName = "PostSocialCommentStyleDroid";
        private string _shareThemeName = "PostSocialShareStyleDroid";

        public IButtonTheme NotLikeTheme { get; }
        public IButtonTheme LikeTheme { get; }
        public IButtonTheme CommentTheme { get; }
        public IButtonTheme ShareTheme { get; }

        public PostSocialStylesHolderDroid(ThemeParser<T> themeParser)
        {
            NotLikeTheme = themeParser.GetThemeByName<IButtonTheme>(_notLikeThemeName);
            LikeTheme = themeParser.GetThemeByName<IButtonTheme>(_likeThemeName);
            CommentTheme = themeParser.GetThemeByName<IButtonTheme>(_commentThemeName);
            ShareTheme = themeParser.GetThemeByName<IButtonTheme>(_shareThemeName);
        }
    }
}