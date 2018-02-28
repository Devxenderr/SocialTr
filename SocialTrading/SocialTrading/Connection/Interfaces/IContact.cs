using System;

namespace SocialTrading.Connection.Interfaces
{
    public interface IContact : IDisposable
    {
        IConnectionSender Sender { get; }
        IConnectionReciever Reciever { set; get; }
    }
}
