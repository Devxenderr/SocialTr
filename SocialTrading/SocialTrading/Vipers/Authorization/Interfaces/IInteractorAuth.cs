using System;

using SocialTrading.Tools.Enumerations;
using SocialTrading.Service.Interfaces.Repository;

namespace SocialTrading.Vipers.Authorization.Interfaces
{
    public interface IInteractorAuth : IDisposable, ISocialAuth
    {
        IPresenterAuth Presenter { set; }

        bool EmailInput(string email);
        bool PasswordInput(string pass);

        void LoginClick(string email, string pass);

        IRepositoryRA GetRepository();
        void DisposeRepositoryRA();
        void SocialLoginPerform(ESocialType socialType, Action loginActionPlatform);
    }
}
