using System;
using System.Net;

using SocialTrading.DTO;
using SocialTrading.Tools;
using SocialTrading.DTO.Response;
using SocialTrading.Connection.Markers;
using SocialTrading.Connection.Handlers;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Connection.InternetConnectivity;

namespace SocialTrading.Connection
{
    public class ConnectionController : ISocketConnector, IContactCreator, IConnectable, ITokenFail
    {
        #region Singleton
        private static ConnectionController _controller;
        private ConnectSenderWidget _widgetSocket;

        public static ConnectionController GetInstance()
        {
            return _controller ?? (_controller = new ConnectionController());
        }
        #endregion

        public const string RorUri = "https://api.socialtrading.maximarkets.site";
        public const string WidgetUri = "wss://informer.umarkets.com/wss/Server.ashx?subscriber=true";

        public bool IsConnectedToInternet { get; private set; }
        

        public event Action<bool> OnConnectivityChanged;
        public event Action OnTokenFail;

        protected ConnectionController()
        {
            IsConnectedToInternet = Connectivity.GetInstance().GetCurrent().IsConnected;
            Connectivity.GetInstance().GetCurrent().ConnectivityChanged += ConnectivityChanged;
        }

        public void ConnectSockets() 
        {
            _widgetSocket?.Connect();
        }

        public void DisconnectSockets()
        {
            _widgetSocket?.Disconnect();
        }

        private IConnectionSender GetConnection(Type modelType)
        {
            if (modelType == typeof(RestRorMarker))
            {
                return new ConnectSenderRor(new RestRor(RorUri),
                    Service.DataService.RepositoryController.RepositoryRestHeader, DAL.SendDelay, DAL.RestHeaderValues, OnTokenFail);
            }
            else if (modelType == typeof(WidgetSocketMarker))
            {
                if (_widgetSocket == null)
                {
                    _widgetSocket = new ConnectSenderWidget(SocketWidget.GetInstance(WidgetUri));
                }
                ConnectSockets();
                return _widgetSocket;
            }

            return null;
        }

        public IContact CreateContact(IModelSend modelSend)
        {
            var sender = Connectivity.GetInstance().GetCurrent().IsConnected
                ? GetConnection(modelSend.TypeMarker)
                : new ConnectSender();

            var contactTable = new Contact(sender);

            return contactTable;
        }

        private void ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            IsConnectedToInternet = e.IsConnected;
            OnConnectivityChanged?.Invoke(IsConnectedToInternet);

            if (IsConnectedToInternet)
            {
                ConnectSockets();
            }
            else
            {
                DisconnectSockets();
            }
        }


        private class ConnectSender : IConnectionSender
        {
            public event Action<IModelResponse> OnMessage;

            public void Send(IModelSend senderModel)
            {
                OnMessage?.Invoke(new Response { Status = HttpStatusCode.BadGateway });
            }
        }
    }
}
