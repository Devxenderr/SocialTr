using System;
using System.Collections.Generic;
using System.Net;
using Websockets;

using SocialTrading.DTO;
using SocialTrading.DTO.Response;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Interfaces;
using System.Diagnostics;

namespace SocialTrading.Connection.Handlers
{
    public abstract class ASocket : ISocketWebConnection, IDisposable
    {
        private IWebSocketConnection _websocket;
        private List<IModelSend> _messageQueue;
        private bool _isOpening = false;

        public string ServerAddress { get; set; }

        public Action<EResponseState> OnException { get; set; }
        public Action<IModelResponse> OnMessage { get; set; }

        public Type TypeMarker { get; set; }

        public bool IsOpen
        {
            get
            {
                return _websocket.IsOpen;
            }
        }

        protected ASocket(Type typeMarker)
        {
            _messageQueue = new List<IModelSend>();
            TypeMarker = typeMarker;
            _websocket = WebSocketFactory.Create();

            _websocket.OnMessage += OnMessageReceive;
            _websocket.OnOpened += OnOpened;
            _websocket.OnClosed += OnClosed;
            _websocket.OnError += OnError;
        }

        
        public void Send(IModelSend model)
        {
            if (model == null)
            {
                return;
            }

            if (_websocket.IsOpen)
            {
#if DEBUG
                Debug.WriteLine(" * ASocket_SEND = " + model.PerformQuery()?.ToString());
#endif
                _websocket.Send(model.PerformQuery()?.ToString() ?? string.Empty);
            }
            else
            {
                _websocket.Open(ServerAddress);
                lock (this)
                {
                    _messageQueue.Add(model);
                }
            }
        }


        public void Connect()
        {
            lock (this)
            {
                if (!_isOpening)
                {
                    _isOpening = true;
                    _websocket.Open(ServerAddress);
                }
            }
        }
        
        public void Disconnect()
        {
            _websocket.Close();
        }


        private void OnClosed()
        {
            _isOpening = false;
            OnMessage?.Invoke(null);
        }

        private void OnOpened()
        {
            _isOpening = false;
            lock (this)
            {
                for (var i = 0; i < _messageQueue.Count; i++)
                {
                    Send(_messageQueue[i]);
                }
                _messageQueue.Clear();
            }
        }

        private void OnError(string message)
        {
#if DEBUG
            Debug.WriteLine(" * ASocket_!!!OnError!!! = " + message);
#endif
            _isOpening = false;
            OnMessage?.Invoke(new Response { Body = message, Status = HttpStatusCode.ExpectationFailed });
        }

        private void OnMessageReceive(string message)
        {
#if DEBUG
            Debug.WriteLine(" * ASocket_GET = " + message);
#endif
            _isOpening = false;
            OnMessage?.Invoke(new Response { Body = message, Status = HttpStatusCode.OK });
        }


        public void Dispose()
        {
            _websocket.OnMessage -= OnMessageReceive;
            _websocket.OnOpened -= OnOpened;
            _websocket.OnClosed -= OnClosed;
            _websocket.OnError -= OnError;

            ServerAddress = null;
            _messageQueue.Clear();
            _messageQueue = null;

            Disconnect();
            _websocket?.Dispose();
            _websocket = null;
            WebSocketFactory.DisposeAll();
        }
    }
}
