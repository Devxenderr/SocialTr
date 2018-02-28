using SocialTrading.Vipers.CreatePost;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Vipers.CreatePost.Interfaces;

namespace SocialTrading.DTO.Response.Post
{
    public class DataModelOnePost : ICreatePostResponseStatus, IModel
    {
        public DataModelPost ModelPost { get; set; }

        public EPostResponseStatus Status { get; set; }
        public EControllerStatus ControllerStatus { get; set; }
    }
}
