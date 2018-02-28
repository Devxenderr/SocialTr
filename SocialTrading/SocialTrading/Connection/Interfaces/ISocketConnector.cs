using System;

namespace SocialTrading.Connection.Interfaces
{
    public interface ISocketConnector
    {
        void ConnectSockets();
        void DisconnectSockets();
    }
}
