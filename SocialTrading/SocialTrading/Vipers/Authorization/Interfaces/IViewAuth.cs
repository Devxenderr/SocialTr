using SocialTrading.Tools.Interfaces;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;

namespace SocialTrading.Vipers.Authorization.Interfaces
{
    public interface IViewAuth : ISetConfig
    {
        IPresenterAuth Presenter { set; }

        void ShowAlert(string title,string okLocale, string message);

        void ShowSpinner();
        void HideSpinner();

        void SetHeaderLabelTheme(ITextViewTheme theme);
		void SetEmailLabelTheme(ITextViewTheme theme);
		void SetPasswordLabelTheme(ITextViewTheme theme);
		void SetNoAccountLabelTheme(ITextViewTheme theme);
		void SetSocialNetworkLabelTheme(ITextViewTheme theme);
		void SetLogInButtonTheme(IButtonTheme theme);
        void SetFacebookButtonTheme(IButtonTheme theme);

        void SetRegistrationButtonTheme(IButtonTheme theme);
		void SetForgetPassTheme(IButtonTheme theme);
		void SetViewTheme(IImageViewTheme theme);

		void SetFbAuthTheme(string backgroundImage, string tintColor);
		void SetGoogleAuthTheme(string backgroundImage, string tintColor);
		void SetOkAuthTheme(string backgroundImage, string tintColor);
		void SetVkAuthTheme(string backgroundImage, string tintColor);

		void SetLogoImageViewTheme(IImageViewTheme theme);
        void SetEmailEditTextTheme(IEditTextTheme theme);
        void SetPasswordEditTextTheme(IEditTextTheme theme);
    
        void SetInteractionUnavailable();
        void SetInteractionAvailable();

        void SetEmailLocale(string emailHint);
        void SetPassLocale(string passwordHint);
        void SetRegButtonLocale(string regButton);
        void SetAuthButtonLocale(string logInButton);
        void SetFacebookButtonLocale(string enterFacebook);
        void SetForgotPassLocale(string forgetPasswordLink);
        void SetSloganLocale(string authSlogan);
        void SetNoAccountLocale(string authNoAccount);
        void SetSocialEnterLocale(string authSocialEnter);

        void FacebookLoginClick();
        void GoogleLoginClick();
        void VkLoginClick();
        void OkLoginClick();
    }
}
