using System;

using SocialTrading.Vipers.Entity;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Service.Interfaces.Repository;

namespace SocialTrading.Vipers.Registration.Password.Interfaces
{
    public interface IInteractorRegPass : IConnectionMessage, IDisposable
    {
        IPresenterRegPass Presenter { set; }

        bool PasswordInput(string pass);
        bool PasswordConfirmInput(string pass, string passConfirm);
        
        void RegistrationClick(RegistrationPasswordStrings data);

        void SaveData(RegistrationPasswordStrings data);
        RegistrationPasswordStrings LoadData();

        void CleanRepositoryRA();

        IRepositoryRA GetRepository();
    }
}
