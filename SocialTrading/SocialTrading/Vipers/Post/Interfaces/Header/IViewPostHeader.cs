using SocialTrading.Tools.Interfaces;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;

namespace SocialTrading.Vipers.Post.Interfaces.Header
{
    public interface IViewPostHeader : ISetConfig
    {
        IPresenterPostHeader Presenter { set; }

        void SetName(string name);
        void SetAvatar(string urlAvatar);
        void SetDefaultAvatar(IImageViewTheme theme);
        void SetCreateTime(string time);
        void SetQuote(string quote);

        void SetRecommend(string recommend);
        void SetRecommendValue(string recommend, int position);
        void SetRecommendBuySellImage(IImageViewTheme theme);

        void SetFavoriteState(bool state, IImageButtonTheme theme);

        void SetStateOnline(IImageViewTheme theme);

        void SetCurrentPrice(string currentPrice, int position);
        void SetCurrentPriceImg(IImageViewTheme theme);

        void SetDifference(string difference);
        void SetDifferenceValue(ITextViewTheme theme);

        void SetForecastTime(string time);

        void OptionsDialogShow(string title, string delete, string edit);
        void OptionsHide();
        void OptionsShow();
        void ShowErrorAlert(string message, string title);

        void CacheImage(string imageUrl);

        double GetPreviousPrice();

        void ShowDeletingDialog(string message, string title, string okButtonText, string cancelButtonText);

        void MoreOptionsButtonTheme(IImageButtonTheme theme);
        void SetFirstLastNameTheme(ITextViewTheme theme);
        void SetDateTheme(ITextViewTheme theme);
        void SetQuoteTheme(ITextViewTheme theme);
        void SetBuySellTheme(ITextViewTheme theme);
        void SetBuySellValueTheme(ITextViewTheme theme);
        void SetForecastTheme(ITextViewTheme theme);
        void SetCurrentPriceTheme(ITextViewTheme theme);
        void SetDiffTheme(ITextViewTheme theme);
        void SetDiffValueTheme(ITextViewTheme theme);
        void SetDifferenceLocale(string v);
        
    }
}
