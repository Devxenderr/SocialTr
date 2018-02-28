using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.View;

namespace SocialTrading.Vipers.ProfileCell.Interfaces
{
    public interface IProfileCellStylesHolder
    {
        IViewTheme CellBackgroundTheme { get; }
        IImageViewTheme AvatarImageViewTheme { get; }
        ITextViewTheme NameLabelTheme { get; }
        ITextViewTheme YourProfileLabelTheme { get; }
    }
}
