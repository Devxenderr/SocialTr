using System;
using SocialTrading.Tools.Enumerations;

namespace SocialTrading.Vipers.Authorization.Interfaces
{
    public interface ISocialAuth
    {        
        void OnCancel(ESocialType socialType);        
        void OnError(string error, ESocialType socialType);        
        void OnSuccess(string accessToken, ESocialType socialType);

        event Action<ESocialType> OnSocialLogOut;
    }
}
