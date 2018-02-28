using System;
using SocialTrading.Tools.Interfaces;

namespace SocialTrading.Vipers.ProfileCell.Interfaces
{
    public interface IInteractorProfileCell : ISetConfig, IDisposable
    {
        IPresenterProfileCellForInteractor Presenter { set; }

        void SendRequestForUserData();
        
    }
}
