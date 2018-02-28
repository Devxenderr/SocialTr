using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.Tools.Interfaces;

namespace SocialTrading.Vipers.CreatePost.Interfaces
{
    public interface IViewCreatePost : ISetConfig
    {
        IPresenterCreatePost Presenter { set; }
        string AttachmentImage { get; }
       
        string AccessModeText { get; set; }
        string BuySellText { get; set; }
        string ForecastTimeText { get; set; }
        string CommentText { get; set; }
        string Price { get; set; }

        void SetAttachment();

        void SetSelectedTool(string tool);
        
        void ImageSelected(string image);
        void ImageDeleted();

        void SetUserAvatar(string image);
        void SetUserName(string name);
        
        void ShowErrorAlert(string message);
        void AddPostSuccess();

        void SetInteractionUnavailable();
        void SetInteractionAvailable();

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


        void SetCommentLocale(string enterCommentLabel);
        void SetForecastTimeLocale(string timeTextView);
        void SetAccessModeLocale(string accessModeTextView);
        void SetBuySellLocale(string buySellTextView);
        void SetToolsLocale(string toolsButton);
		void SetPriceLocale(string priceLabel);
    }
}
