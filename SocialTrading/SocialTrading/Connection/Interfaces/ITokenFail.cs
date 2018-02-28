using System;

namespace SocialTrading.Connection.Interfaces
{
    public interface ITokenFail
    {
        event Action OnTokenFail;
    }
}
