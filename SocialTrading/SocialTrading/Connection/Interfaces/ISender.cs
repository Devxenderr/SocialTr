using SocialTrading.DTO;

namespace SocialTrading.Connection.Interfaces
{
    public interface ISender
    {
        void Send(IModelSend senderModel);
    }
}
