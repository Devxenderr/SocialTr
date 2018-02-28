using System;

using SocialTrading.Connection.Interfaces;

namespace SocialTrading.Vipers.Controllers.Interfaces
{
    public interface ICreatePostController : IGetData, IConnectionReciever, IQcUpdates, IDisposable
    {
        IContactCreator ContactCreator { set; }
        void SetQuote(string quote);
    }
}
