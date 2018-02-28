using System;

using SocialTrading.DTO;
using SocialTrading.DTO.Response;

namespace SocialTrading.Connection.Interfaces
{
    public interface ISocketWebConnection : IWebConnection, ISocketModelConnector
    {
        bool IsOpen { get; }

        void Send(IModelSend model);
        Action<IModelResponse> OnMessage { get; set; }
    }
}