using SocialTrading.Tools.Interfaces;
using SocialTrading.Tools.Enumerations;

namespace SocialTrading.Vipers.Authorization.Interfaces
{
    public interface IPresenterAuth : ISetConfig
    {
        void EmailInput(string email);
        void PasswordInput(string pass);
        void LoginClick(string email, string pass);

        void SetEmailState(EState state);
        void SetPasswordState(EState state);
        void CheckAuthState(EAuthResponseStatus state);

        void RegistrationClick();
        void ForgotPasswordClick();

        void ShowHideSpinner(bool isShow);

        void SetLocale();
        //string GetOkLocale();
        //string GetErrorLocale();
        //string GetFacebookAuthErrorLocale();

        void DisposeRepositoryRA();

        void FacebookLoginClick();
        void GoogleLoginClick();
        void VkLoginClick();
        void OkLoginClick();
    }
}
