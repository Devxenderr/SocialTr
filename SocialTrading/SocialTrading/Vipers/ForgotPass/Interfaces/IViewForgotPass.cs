using SocialTrading.Tools.Interfaces;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;

namespace SocialTrading.Vipers.ForgotPass.Interfaces
{
    public interface IViewForgotPass : ISetConfig
    {
        IPresenterForgotPass Presenter { set; }

        void ShowAlertEmailRedirect(string msg, string btnOk);

        void ShowSpinner();
        void HideSpinner();

        void SetLogoImageViewTheme(IImageViewTheme theme);
        void SetEmailEditTextTheme(IEditTextTheme theme);
        void SetRecoveryButtonTheme(IButtonTheme theme);
        void SetBackButtonTheme(IImageButtonTheme theme);
        void SetViewTheme(IImageViewTheme theme);
        void SetHeaderLabelTheme(ITextViewTheme theme);
        void SetEmailLabelTheme(ITextViewTheme theme);

        void SetButtonLocale(string forgotPassButton);
        void SetHeaderLabelLocale(string passwordRecovery);
        void SetHintLocale(string emailHint);
    }
}
