using SocialTrading.Tools.Interfaces;
using SocialTrading.Tools.Enumerations;

namespace SocialTrading.Vipers.Registration.Password.Interfaces
{
    public interface IPresenterRegPass : ISetConfig
    {
        void PasswordInput();
        void PasswordConfirmInput();

        void RegisterClick();
        void UserAgreementClick();

        void SetPasswordState(EState state);
        void SetPasswordConfirmState(EState state);

        void BackClick();
        
        void RegStateSuccess(string msg);
        void RegStateFail(ERegResponseStatus state);

        void ShowHideSpinner(bool isShow);

        void AlertOkClick();
        
        void SaveData();
        void LoadData();

        void SetLocale();

        string GetOkLocale();
    }
}
