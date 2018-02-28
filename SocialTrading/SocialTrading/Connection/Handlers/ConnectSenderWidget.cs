using System;
using System.Net;

using SocialTrading.DTO;
using SocialTrading.DTO.Response;
using SocialTrading.Connection.Interfaces;

namespace SocialTrading.Connection.Handlers
{
    internal class ConnectSenderWidget : IConnectionSender, ISocketModelConnector
    {
        private readonly ISocketWebConnection _connection;        

        public event Action<IModelResponse> OnMessage;


        public ConnectSenderWidget(ISocketWebConnection connection)
        {
            _connection = connection;
            _connection.OnMessage += HandleResponse;
        }

        public void Send(IModelSend senderModel)
        {
            if (senderModel == null)
            {
                return;
            }

            if (!_connection.IsOpen)
            {
                Connect();
            }

            _connection.Send(senderModel);
        }


        private void HandleResponse(IModelResponse response)
        {
            if (response == null)
            {
                OnMessage?.Invoke(new Response { Status = HttpStatusCode.Gone });
                return;
            }

            OnMessage?.Invoke(response);
        }

        public void Connect()
        {
            _connection.Connect();
        }

        public void Disconnect()
        {
            _connection.Disconnect();
        }
    }
}
