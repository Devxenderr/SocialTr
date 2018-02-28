using SocialTrading.Theme.ThemeStrings;

namespace SocialTrading.Vipers.Post.Interfaces
{
    public interface IViewDetailedPost
    {
        void SetToolbarTheme(PostOtherThemeStrings otherThemeStrings, string title);
        void SetActions();
    }
}
