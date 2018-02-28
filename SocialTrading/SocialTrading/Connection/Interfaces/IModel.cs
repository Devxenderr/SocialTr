using SocialTrading.Tools.Enumerations;

namespace SocialTrading.Connection.Interfaces
{
    public interface IModel
    {
        EControllerStatus ControllerStatus { get; }
    }
}
