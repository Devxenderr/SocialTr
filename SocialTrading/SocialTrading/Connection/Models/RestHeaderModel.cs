namespace SocialTrading.Connection.Models
{
    public sealed class RestHeaderModel
    {
        public string AccessTokenTitle { get; private set; } 
        public string ClientTitle { get; private set; } 
        public string UidTitle { get; private set; }
        public string AcceptLangTitle { get; private set; }

        public string ContentType { get; private set; }

        public string AccessToken { get; set; }
        public string AcceptLang { get; set; }
        public string Client { get; set; }
        public string Uid { get; set; }


        public RestHeaderModel(string accessTokenTitle, string clientTitle, string uidTitle, string acceptLangTitle, string contentType, string acceptLang)
        {
            AccessTokenTitle = accessTokenTitle;
            AcceptLangTitle = acceptLangTitle;
            ClientTitle = clientTitle;
            ContentType = contentType;
            AcceptLang = acceptLang;
            UidTitle = uidTitle;
        }


        public void Update(string accessToken, string client, string uid)
        {
            AccessToken = accessToken;
            Client = client;
            Uid = uid;
        }
    }
}
