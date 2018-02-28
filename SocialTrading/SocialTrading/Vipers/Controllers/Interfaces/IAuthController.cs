using SocialTrading.Connection.Interfaces;

namespace SocialTrading.Vipers.Controllers.Interfaces
{
    public interface IAuthController : IGetData, IConnectionReciever
    {
        IContactCreator ContactCreator { set; }
    }
}
