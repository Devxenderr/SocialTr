using SocialTrading.Connection.Interfaces;

namespace SocialTrading.Vipers.Controllers.Interfaces
{
    public interface IForgotPassController : IGetData, IConnectionReciever
    {
        IContactCreator ContactCreator { set; }
    }
}
