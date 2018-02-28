using System.Collections.Generic;

using SocialTrading.Vipers.CreatePost;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Vipers.Post.Interfaces;

namespace SocialTrading.DTO.Response.Post
{
    public class DataModelListPosts : ARoRResponse, IModel, IPostsResponseStatus
    {
        public List<string> PostIds { get; set; }
        public EPostResponseStatus Status { get; set; }


        public DataModelListPosts(string[] errors = null) : base(errors ?? new string[0])
        {
        }

        public EControllerStatus ControllerStatus { get; set; }
    }
}
