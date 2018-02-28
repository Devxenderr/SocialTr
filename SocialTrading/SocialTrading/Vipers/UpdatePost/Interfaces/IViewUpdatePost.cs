using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;

namespace SocialTrading.Vipers.UpdatePost.Interfaces
{
    public interface IViewUpdatePost
    {
        IPresenterUpdatePost Presenter { set; }
        string AttachmentImage { get; }
        
        void SetUserAvatar(string image);
        void SetUserName(string name);

        void ShowSuccessAlert(string message, string buttonTitle);
        void ShowFailAlert(string message, string buttonTitle);
        
        void ShowSpinner();
        void HideSpinner();

        void SetDividingLineTheme(IViewTheme theme);
        void SetNameTheme(ITextViewTheme theme);
        void SetTitleTheme(ITextViewTheme theme);
        void SetAvatarTheme(IImageViewTheme theme);
        void SetBackButtonTheme(IImageButtonTheme theme);
        void SetAttachImageButtonTheme(IImageButtonTheme theme);
        void SetCancelAttachButtonTheme(IImageButtonTheme theme);
        void SetPublishTextViewTheme(IButtonTheme theme);
        void SetToolsTheme(IButtonTheme theme);
        void SetPriceTextViewTheme(IButtonTheme theme);
        void SetBuySellTheme(IButtonTheme theme);
        void SetAccessModeTheme(IButtonTheme theme);
        void SetForecastTimeTheme(IButtonTheme theme);
        void SetCommentTheme(IEditTextTheme theme);
        void SetToolbarTheme(IViewTheme theme);
        
        void SetComment(string enterCommentLabel);
        void SetCommentHint(string enterCommentLabel);
        void SetForecastTime(string timeTextView);
        void SetAccessMode(string accessModeTextView);
        void SetBuySell(string buySellTextView);
        void SetTools(string toolsButton);
        void SetPrice(string priceLabel);
        void SetImage(string image);
        void SetImageLink(string imageLink);
        void ImageDeleted();

        void AccessModeSelection(string alertTitle, string cancelTitle, string okTitle = null);

        void NeedToSaveData();

        void SetToolBarPublishButtonLocale(string locale);
        void SetToolBarTitleTextViewLocale(string locale);
    }
}
