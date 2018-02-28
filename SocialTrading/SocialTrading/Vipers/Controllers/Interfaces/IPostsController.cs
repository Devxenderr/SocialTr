using SocialTrading.Connection.Interfaces;

namespace SocialTrading.Vipers.Controllers.Interfaces
{
    public interface IPostsController : IGetData, IConnectionReciever
    {
        IContactCreator ContactCreator { set; }
    }
}
