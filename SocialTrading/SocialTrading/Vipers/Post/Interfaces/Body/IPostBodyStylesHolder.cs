using SocialTrading.ThemesStyles.Interfaces.TextView;

namespace SocialTrading.Vipers.Post.Interfaces.Body
{
    public interface IPostBodyStylesHolder
    {
        ITextViewTheme ContentTheme { get; }
        ITextViewTheme MoreTextTheme { get; }
    }
}