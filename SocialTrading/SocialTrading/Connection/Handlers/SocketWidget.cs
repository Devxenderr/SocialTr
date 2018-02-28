using System;

using SocialTrading.Connection.Markers;

namespace SocialTrading.Connection.Handlers
{
    public sealed class SocketWidget : ASocket
    {
        private static SocketWidget _socketWidget;

        public static SocketWidget GetInstance(string address)
        {
            if (address == null && _socketWidget == null)
            {
                throw new ArgumentNullException(nameof(address));
            }
            else if (address != null && _socketWidget == null)
            {
                _socketWidget = new SocketWidget(address);
            }

            return _socketWidget;
        }

        private SocketWidget(string address) : base(typeof(WidgetSocketMarker))
        {
            ServerAddress = address;
            Connect();
        }

        //public override void OnMessage(string message, EResponseModule responseModule)
        //{
        //    // send "message" to Dispatcher by interface( IGetNetMessage ) *****************************************************
        //    if (!_isAboutToUpdateQc)
        //    {
        //        _isAboutToUpdateQc = true;
        // //       ConnectionDispatcher.QuotationResponse(message);
        //    }
        //    else
        //    {
        //   //     ConnectionDispatcher.QuotationUpdateResponse(message);
        //    }
        //    // ********************** Need fix it in SPRINT#11 *****************************************************************
        //}
    }
}
