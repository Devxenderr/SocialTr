using System;
using Newtonsoft.Json.Linq;
using SocialTrading.Connection.Enumerations;
using SocialTrading.Connection.Markers;

namespace SocialTrading.DTO.Request.RA
{
    public class EmailModel : IModelSend
    {
        public EResponseModule ResponseModule { get; set; }
        public ERestCommands Method { get; set; }
        public string ApiPath { get; set; }

        public Type TypeMarker => typeof(RestRorMarker);

        public string Email { get; set; }

        public EmailModel(string email)
        {
            if (email == null)
            {
                throw new ArgumentNullException("email cannot be Null");
            }

            Email = email?.ToLower() ?? string.Empty;
            ApiPath = "/auth/password";
            Method = ERestCommands.POST;
            ResponseModule = EResponseModule.RecoveryPassword;
        }

        public JObject PerformQuery()
        {
            var json = new JObject
            {
                ["email"] = Email
            };
            return json;
        }
    }
}
