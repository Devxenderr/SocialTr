using SocialTrading.Connection.Interfaces;

namespace SocialTrading.Connection
{
    internal class Contact : IContact
    {
        private IConnectionReciever _reciever;

        public IConnectionSender Sender { get; private set; }

        public IConnectionReciever Reciever
        {
            get => _reciever;
            set
            {
                _reciever = value;
                Sender.OnMessage += Reciever.SetMessage;
            }
        }

        public Contact(IConnectionSender sender)
        {
            Sender = sender;
        }

        public void Dispose()
        {
            Sender.OnMessage -= Reciever.SetMessage;
            Sender = null;
            _reciever = null;
        }
    }
}
