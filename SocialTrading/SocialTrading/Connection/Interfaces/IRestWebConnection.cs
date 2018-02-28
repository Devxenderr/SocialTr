using System;
using System.Net.Http;
using System.Threading;

using SocialTrading.Connection.Enumerations;

namespace SocialTrading.Connection.Interfaces
{
    public interface IRestWebConnection : IWebConnection
    {
        void Send(HttpClient client, string parameters, CancellationTokenSource tokenSource, ERestCommands method);
        Action<HttpResponseMessage> OnMessage { get; set; }
    }
}