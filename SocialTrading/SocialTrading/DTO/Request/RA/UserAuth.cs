using System;

using Newtonsoft.Json.Linq;

using SocialTrading.Connection.Markers;
using SocialTrading.Connection.Enumerations;

namespace SocialTrading.DTO.Request.RA
{
    public class UserAuth : IModelSend
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public string ApiPath { get; set; }
        public ERestCommands Method { get; set; }
        public EResponseModule ResponseModule { get; set; }

        public Type TypeMarker { get; private set; } = typeof(RestRorMarker);

        public UserAuth(string email, string pass)
        {
            Email = email?.ToLower() ?? string.Empty;
            Password = pass ?? string.Empty;
            ApiPath = "/auth/sign_in";
            Method = ERestCommands.POST;
            ResponseModule = EResponseModule.Auth;
        }

        public JObject PerformQuery()
        {
            var json = new JObject
            {
                ["email"] = Email,
                ["password"] = Password
            };
            return json;
        }
    }
}
