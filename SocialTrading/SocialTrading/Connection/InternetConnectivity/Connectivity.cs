using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;

namespace SocialTrading.Connection.InternetConnectivity
{
    public sealed class Connectivity : CrossConnectivity
    {
        private static Connectivity _connectivity;

        public static Connectivity GetInstance()
        {
            return _connectivity ?? (_connectivity = new Connectivity());
        }

        public IConnectivity GetCurrent()
        {
            return Current;
        }
    }
}
