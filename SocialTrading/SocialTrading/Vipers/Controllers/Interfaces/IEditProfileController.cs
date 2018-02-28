using SocialTrading.Connection.Interfaces;

namespace SocialTrading.Vipers.Controllers.Interfaces
{
    public interface IEditProfileController : IGetData, IConnectionReciever
    {
        IContactCreator ContactCreator { set; }
    }
}