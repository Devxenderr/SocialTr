using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;

using SocialTrading.Connection.Markers;
using SocialTrading.Connection.Enumerations;

namespace SocialTrading.DTO.Request
{
    public class PostLikeRequestModel : IModelSend
    {
        public string ApiPath { get; set; }
        public ERestCommands Method { get; set; }
        public EResponseModule ResponseModule { get; set; }

        public Type TypeMarker { get; private set; } = typeof(RestRorMarker);

        public PostLikeRequestModel(string postId)
        {
            ApiPath = "/api/v3/posts/" + postId + "/like";
            Method = ERestCommands.POST;
            ResponseModule = EResponseModule.PostLike;
        }

        public JObject PerformQuery()
        {
            return null;
        }

        public override bool Equals(object obj)
        {
            var model = obj as PostLikeRequestModel;
            return model != null &&
                   ApiPath == model.ApiPath &&
                   Method == model.Method &&
                   ResponseModule == model.ResponseModule;
        }

        public override int GetHashCode()
        {
            var hashCode = 656433274;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ApiPath);
            hashCode = hashCode * -1521134295 + Method.GetHashCode();
            hashCode = hashCode * -1521134295 + ResponseModule.GetHashCode();
            return hashCode;
        }
    }
}
