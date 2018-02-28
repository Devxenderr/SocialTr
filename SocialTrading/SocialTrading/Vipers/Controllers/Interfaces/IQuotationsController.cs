using SocialTrading.Connection.Interfaces;

namespace SocialTrading.Vipers.Controllers.Interfaces
{
    public interface IQuotationsController : IGetData, IConnectionReciever
    {
        IContactCreator ContactCreator { set; }
    }
}