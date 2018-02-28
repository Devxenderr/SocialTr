using System;

using SocialTrading.Tools.Enumerations;

namespace SocialTrading.Connection.Interfaces
{
    public interface IWebConnection : ITypeConnection
    {
        string ServerAddress { get; set; }
        Action<EResponseState> OnException { get; set; }
    }
}