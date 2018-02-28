using SocialTrading.Connection.Interfaces;

namespace SocialTrading.Vipers.Controllers.Interfaces
{
    public interface IEditContactController : IGetData, IConnectionReciever
    {
        IContactCreator ContactCreator { set; }
    }
}