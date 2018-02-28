using SocialTrading.DTO.Response;

namespace SocialTrading.Connection.Interfaces
{
    public interface IConnectionReciever
    {
        void SetMessage(IModelResponse responseModel);
    }
}
