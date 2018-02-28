using System;

using SocialTrading.DTO.Response;

namespace SocialTrading.Connection.Interfaces
{
    public interface IConnectionSender : ISender
    {
        event Action<IModelResponse> OnMessage;
    }
}