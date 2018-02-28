using SocialTrading.Connection.Interfaces;

namespace SocialTrading.Vipers.Controllers.Interfaces
{
    public interface ILogOutController : IGetData, IConnectionReciever
    {
        IContactCreator ContactCreator { set; }
    }
}
