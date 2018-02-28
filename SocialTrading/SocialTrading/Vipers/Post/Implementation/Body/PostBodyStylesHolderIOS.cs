using SocialTrading.ThemesStyles;
using SocialTrading.ThemesStyles.Implementation;
using SocialTrading.Vipers.Post.Interfaces.Body;
using SocialTrading.ThemesStyles.Interfaces.TextView;

namespace SocialTrading.Vipers.Post.Implementation.Body
{
    public class PostBodyStylesHolderIOS<T> : IPostBodyStylesHolder where T : AGlobalControlsTheme
    {
        private string _contentTheme = "PostBodyCommentCollapsedStyle";
        private string _moreTextTheme  = "PostBodyCommentExpandedStyle";

        public ITextViewTheme ContentTheme { get; }
        public ITextViewTheme MoreTextTheme { get; }

        public PostBodyStylesHolderIOS(ThemeParser<T> themeParser)
        {
            ContentTheme = themeParser.GetThemeByName<ITextViewTheme>(_contentTheme);
            MoreTextTheme  = themeParser.GetThemeByName<ITextViewTheme>(_moreTextTheme);
        }
    }
}