using System;

using SocialTrading.Connection.Interfaces;

namespace SocialTrading.Vipers.Controllers.Interfaces
{
    public interface IPostHeaderController : IGetData, IConnectionReciever, IQcUpdates, IDisposable
    {
        IContactCreator ContactCreator { set; }
        void GetQc();
    }
}
