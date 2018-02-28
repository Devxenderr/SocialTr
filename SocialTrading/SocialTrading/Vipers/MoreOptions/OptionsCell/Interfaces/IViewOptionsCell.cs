using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;

namespace SocialTrading.Vipers.MoreOptions.OptionsCell.Interfaces
{
    public interface IViewOptionsCell
    {
        IPresenterOptionsCellForView Presenter { set; }

        void SetBackgroundTheme(IViewTheme theme);
        void SetImageTheme(IImageViewTheme theme);
        void SetTextTheme(ITextViewTheme theme);

        void SetImage(string imageName);
        void SetText(string localeString);
    }
}
