using SocialTrading.Connection.Interfaces;

namespace SocialTrading.Vipers.Controllers.Interfaces
{
    public interface IRegController : IGetData, IConnectionReciever
    {
        IContactCreator ContactCreator { set; }
    }
}
