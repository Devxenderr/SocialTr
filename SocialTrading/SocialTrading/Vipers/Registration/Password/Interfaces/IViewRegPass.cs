using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.Tools.Interfaces;

namespace SocialTrading.Vipers.Registration.Password.Interfaces
{
    public interface IViewRegPass : ISetConfig
    {
        IPresenterRegPass Presenter { set; }
        
        void ShowRegSuccess(string title, string message);
        void ShowRegFail(string title, string message);

        void ShowSpinner();
        void HideSpinner();

        void SetPassword(string pass);
        void SetConfirmPass(string confirmPass);

        string GetPassword();
        string GetConfirmPassword();

        void SetInteractionUnavailable();
        void SetInteractionAvailable();

        void SetHeaderLabelTheme(ITextViewTheme themeName);
        void SetPasswordLabelTheme(ITextViewTheme themeName);
        void SetConfirmPasswordLabelTheme(ITextViewTheme themeName);
        void SetRegButtonTheme(IButtonTheme themeName);
        void SetBackButtonTheme(IImageButtonTheme themeName);
        void SetViewTheme(IImageViewTheme themeName);
        void SetLogoImageViewTheme(IImageViewTheme themeName);
        void SetPasswordEditTextTheme(IEditTextTheme themeName);
        void SetConfirmPasswordEditTextTheme(IEditTextTheme themeName);

        void SetUserAgreementTheme(IButtonTheme mainThemeName, string mainText, IButtonTheme attrThemeName, string attrText, int insertPosition);

		void SetFeatureImageTheme(IImageViewTheme themeName);
		void SetFeatureTextTheme(ITextViewTheme themeName);

        void SetPasswordLocale(string passwordHint);
        void SetConfirmPasswordLocale(string regPassConfirmHint);
        void SetRegButtonLocale(string regButton);
        void SetUserAgreementLocale(string regUserAgreement);
        void SetTitleLocale(string regPassTextView);
		void SetFeatureTextLocale(string featureText);

	}
}
