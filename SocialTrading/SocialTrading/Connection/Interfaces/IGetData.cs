using System;

namespace SocialTrading.Connection.Interfaces
{
    public interface IGetData : ISender
    {
        event Action<IModel> OnRecieveModel;
    }
}
