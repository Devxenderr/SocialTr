using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;

using SocialTrading.Connection.Markers;
using SocialTrading.Connection.Enumerations;

namespace SocialTrading.DTO.Request
{
    public class UserInfoRequestModel : IModelSend
    {
        public ERestCommands Method { get; set; }
        public string ApiPath { get; set; }

        public Type TypeMarker { get; private set; } = typeof(RestRorMarker);

        public UserInfoRequestModel(string userId)
        {
            ApiPath = "/api/v3/get_user_info/" + userId;
            Method = ERestCommands.GET;
        }

        public JObject PerformQuery()
        {
            return null;
        }

        public override bool Equals(object obj)
        {
            return obj is UserInfoRequestModel model &&
                   Method == model.Method &&
                   ApiPath == model.ApiPath;
        }

        public override int GetHashCode()
        {
            var hashCode = -1498187238;
            hashCode = hashCode * -1521134295 + Method.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ApiPath);
            return hashCode;
        }
    }
}
