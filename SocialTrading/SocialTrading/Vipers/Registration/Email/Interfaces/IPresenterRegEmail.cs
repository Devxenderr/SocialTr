using SocialTrading.Tools.Enumerations;
using SocialTrading.Tools.Interfaces;

namespace SocialTrading.Vipers.Registration.Email.Interfaces
{
    public interface IPresenterRegEmail : ISetConfig
    {
        void EmailInput();

        void SetEmailState(EState state);

        void NextClick();
        void BackClick();

        void SaveData();
        void LoadData();

        void SetLocale();

        string GetShowEmailsAlertTitleLocale();
        string GetOkLocale();
        string GetCancelLocale();
    }
}
