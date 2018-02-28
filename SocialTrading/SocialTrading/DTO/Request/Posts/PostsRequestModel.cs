using System;
using System.Collections.Generic;

using Newtonsoft.Json.Linq;

using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Markers;
using SocialTrading.Connection.Enumerations;

namespace SocialTrading.DTO.Request.Posts
{
    public class PostsRequestModel : IModelSend
    {
        public EPostsRequestType RequestType { get; protected set; }
        public string ApiPath { get; set; }
        public ERestCommands Method { get; set; }

        public Type TypeMarker => typeof(RestRorMarker);


        public PostsRequestModel(EPostsRequestType requestType)
        {
            ApiPath = "/api/v3/posts";
            Method = ERestCommands.GET;

            RequestType = requestType;
        }


        public virtual JObject PerformQuery()
        {
            return null;
        }

        public override bool Equals(object obj)
        {
            var model = obj as PostsRequestModel;
            return model != null &&
                   ApiPath == model.ApiPath &&
                   Method == model.Method;
        }

        public override int GetHashCode()
        {
            var hashCode = 656433274;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ApiPath);
            hashCode = hashCode * -1521134295 + Method.GetHashCode();
            return hashCode;
        }
    }
}
