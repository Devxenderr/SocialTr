using SocialTrading.Connection.Interfaces;

namespace SocialTrading.Vipers.Controllers.Interfaces
{
    public interface IMoreOptionsController : IGetData, IConnectionReciever
    {
        IContactCreator ContactCreator { set; }
    }
}