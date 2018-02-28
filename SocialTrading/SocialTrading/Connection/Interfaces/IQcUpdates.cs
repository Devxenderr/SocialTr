using System;

namespace SocialTrading.Connection.Interfaces
{
    public interface IQcUpdates
    {
        event Action<IModel> OnQcModelUpdate;
    }
}