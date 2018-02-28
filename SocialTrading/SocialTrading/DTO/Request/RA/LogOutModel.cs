using System;
using Newtonsoft.Json.Linq;
using SocialTrading.Connection.Enumerations;
using SocialTrading.Connection.Markers;

namespace SocialTrading.DTO.Request.RA
{
    public class LogOutModel : IModelSend
    {
        public ERestCommands Method { get; set; } 
        public string ApiPath { get ; set ; }

        public Type TypeMarker { get; } = typeof(RestRorMarker);
        
        public LogOutModel()
        {
            ApiPath = "/auth/sign_out";
            Method = ERestCommands.DELETE;
        }

        public JObject PerformQuery()
        {
            return null;
        }
    }
}
