using SocialTrading.DTO;

namespace SocialTrading.Connection.Interfaces
{
    public interface IContactCreator
    {
        IContact CreateContact(IModelSend modelSend);
    }
}
