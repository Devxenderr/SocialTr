using SocialTrading.Tools.Interfaces;
using SocialTrading.Tools.Enumerations;

namespace SocialTrading.Vipers.ForgotPass.Interfaces
{
    public interface IPresenterForgotPass : ISetConfig
    {
        void EmailInput(string email);
        void PassRecoveryClick(string email);

        void SetEmailState(EState state);

        void ShowHideSpinner(bool isShow);

        void ShowAlertEmailRedirect(EForgotPassStatus eForgotPassState);

        void AlertButtonClick();

        void BackButtonClick();

        void SetLocale();
    }
}
