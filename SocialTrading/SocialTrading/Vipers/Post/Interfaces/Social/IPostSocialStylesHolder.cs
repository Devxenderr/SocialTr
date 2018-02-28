using SocialTrading.ThemesStyles.Interfaces.Button;

namespace SocialTrading.Vipers.Post.Interfaces.Social
{
    public interface IPostSocialStylesHolder
    {
        IButtonTheme NotLikeTheme { get; }
        IButtonTheme LikeTheme { get; }
        IButtonTheme CommentTheme { get; }
        IButtonTheme ShareTheme { get; }
    }
}