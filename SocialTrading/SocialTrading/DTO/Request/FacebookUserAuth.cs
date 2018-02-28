using System;

using Newtonsoft.Json.Linq;

using SocialTrading.Connection.Markers;
using SocialTrading.Connection.Enumerations;

namespace SocialTrading.DTO.Request
{
    public class FacebookUserAuth : IModelSend
    {
        public ERestCommands Method { get; set; }
        public string ApiPath { get ; set; }

        public Type TypeMarker { get; } = typeof(RestRorMarker);
        public string Token { get; }

        public FacebookUserAuth(string token)
        {
            Token = token ?? string.Empty;
            ApiPath = "/auth/sign_in_social/facebook";
            Method = ERestCommands.POST;
        }

        public JObject PerformQuery()
        {
            var json = new JObject
            {
                ["access_token"] = Token
            };
            return json;
        }
    }
}
