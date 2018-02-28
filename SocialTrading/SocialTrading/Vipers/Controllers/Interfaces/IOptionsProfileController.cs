using SocialTrading.Connection.Interfaces;

namespace SocialTrading.Vipers.Controllers.Interfaces
{
    public interface IOptionsProfileController : IGetData, IConnectionReciever
    {
        IContactCreator ContactCreator { set; }
    }
}
