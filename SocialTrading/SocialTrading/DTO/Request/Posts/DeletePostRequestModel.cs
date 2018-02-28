using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;

using SocialTrading.Connection.Markers;
using SocialTrading.Connection.Enumerations;

namespace SocialTrading.DTO.Request
{
    public class DeletePostRequestModel : IModelSend
    {
        public EResponseModule ResponseModule { get; set; }
        public ERestCommands Method { get; set; }
        public string ApiPath { get; set; }

        public Type TypeMarker { get; private set; } = typeof(RestRorMarker);

        public DeletePostRequestModel(string postId)
        {
            ApiPath = "/api/v3/posts/" + postId;
            Method = ERestCommands.DELETE;
            ResponseModule = EResponseModule.PostDelete;
        }

        public JObject PerformQuery()
        {
            return null;
        }

        public override bool Equals(object obj)
        {
            var model = obj as DeletePostRequestModel;
            return model != null &&
                   ResponseModule == model.ResponseModule &&
                   Method == model.Method &&
                   ApiPath == model.ApiPath;
        }

        public override int GetHashCode()
        {
            var hashCode = -1498187238;
            hashCode = hashCode * -1521134295 + ResponseModule.GetHashCode();
            hashCode = hashCode * -1521134295 + Method.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ApiPath);
            return hashCode;
        }
    }
}
