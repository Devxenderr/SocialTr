using SocialTrading.DTO;

namespace SocialTrading.Service.Interfaces.Repository
{
    public interface IRepositoryQcPrice
    {
        QcBidAsk GetQcBidAsk(string quote);
    }
}
