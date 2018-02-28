using SocialTrading.Connection.Interfaces;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.CreatePost;
using SocialTrading.Vipers.CreatePost.Interfaces;

namespace SocialTrading.DTO.Response.Post
{
    public class DataModelCreatePost : ARoRResponse, ICreatePostResponseStatus, IModel
    {
        public DataModelPost ModelPost { get; set; }

        public EPostResponseStatus Status { get; set; }


        public DataModelCreatePost(string[] errors = null) : base(errors ?? new string[0])
        {
        }

        public EControllerStatus ControllerStatus { get; set; }
    }
}
