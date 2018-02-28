using System;

using Newtonsoft.Json.Linq;

using SocialTrading.Connection.Markers;
using SocialTrading.Connection.Enumerations;

namespace SocialTrading.DTO.Request.Posts
{
    public class CurrentPostIdRequest : IModelSend
    {
        private const string _uri = "/api/v3/posts/";
        public string CurrentPostId { get; private set; }

        public Type TypeMarker { get; } = typeof(RestRorMarker);
        public ERestCommands Method { get; set; }
        public string ApiPath { get; set; }

        public CurrentPostIdRequest(string postID)
        {
            CurrentPostId = postID;
            ApiPath = _uri + CurrentPostId;
            Method = ERestCommands.GET;
        }

        public JObject PerformQuery()
        {
            return null;
        }
    }
}
