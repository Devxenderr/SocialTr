using Newtonsoft.Json;

using System.Collections.Generic;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Post.Interfaces.Social;
using SocialTrading.Vipers.Post.Implementation.Social;

namespace SocialTrading.DTO.Response.Post
{
    public class DataModelPostLike : ARoRResponse, IModel, IPostSocialResponseStatus
    {
        public string PostId { get; }
        public int CountLikes { get; }
        public bool IsLiked { get; }

        public EPostSocialResponseStatus Status { get; set; }

        [JsonConstructor]
        public DataModelPostLike(string liked_id, int count_likes, bool liked, string[] errors) : base(errors ?? new string[0])
        {
            PostId = liked_id;
            CountLikes = count_likes;
            IsLiked = liked;
        }

        public override bool Equals(object obj)
        {
            var postLike = obj as DataModelPostLike;

            return PostId == postLike?.PostId &&
                   CountLikes == postLike?.CountLikes &&
                   IsLiked == postLike?.IsLiked;
        }

        public override int GetHashCode()
        {
            var hashCode = -1499811332;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PostId);
            hashCode = hashCode * -1521134295 + CountLikes.GetHashCode();
            hashCode = hashCode * -1521134295 + IsLiked.GetHashCode();
            return hashCode;
        }

        public EControllerStatus ControllerStatus { get; set; }
    }
}
