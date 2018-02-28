using System;

namespace SocialTrading.Connection.Interfaces
{
    public interface IConnectable
    {
        bool IsConnectedToInternet { get; }
        event Action<bool> OnConnectivityChanged;
    }
}