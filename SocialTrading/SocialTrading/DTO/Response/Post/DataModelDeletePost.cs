using SocialTrading.Connection.Interfaces;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Post.Interfaces.Header;
using SocialTrading.Vipers.Post.Implementation.Header;

namespace SocialTrading.DTO.Response.Post
{
    public class DataModelDeletePost : ARoRResponse, IModel, IPostHeaderResponseStatus
    {
        public DataModelDeletePost(string[] errors = null) : base(errors ?? new string[0])
        {
        }

        public EPostHeaderResponseStatus Status { get; set; }
        public EControllerStatus ControllerStatus { get; set; }
    }
}
