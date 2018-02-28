using System;

using SocialTrading.Connection.Interfaces;

namespace SocialTrading.Vipers.ForgotPass.Interfaces
{
    public interface IInteractorForgotPass : IConnectionMessage, IDisposable
    {
        IPresenterForgotPass Presenter { set; }

        bool EmailInput(string email);
        void PassRecoveryClick(string email);
    }
}
