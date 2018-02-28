using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.Tools.Interfaces;

namespace SocialTrading.Vipers.ProfileCell.Interfaces
{
    public interface IProfileCellView : ISetConfig
    {
        IPresenterProfileCellForView Presenter { set; }

        void SetBackgroundTheme(IViewTheme theme);
        void SetNameTheme(ITextViewTheme theme);
        void SetProfileLabelTheme(ITextViewTheme theme);
        void SetAvatarTheme(IImageViewTheme theme);

        void SetName(string name);
        void SetAvatar(string name);
        void SetProfileLabel(string name);
    }
}
