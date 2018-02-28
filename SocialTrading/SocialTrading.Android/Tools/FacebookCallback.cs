using System;
using Xamarin.Facebook;

using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Authorization.Interfaces;
using Xamarin.Facebook.Login;

namespace SocialTrading.Droid.Tools
{
    public class FacebookCallback : Java.Lang.Object, IFacebookCallback
    {
        private string _token;
        private readonly ISocialAuth _interactorAuth;

        public FacebookCallback(ISocialAuth interactorAuth)
        {
            _interactorAuth = interactorAuth;
        }

        public void OnCancel()
        {
            _interactorAuth.OnCancel(ESocialType.Facebook);
            LoginManager.Instance.LogOut();          
        }

        public void OnError(FacebookException ex)
        {
            _interactorAuth.OnError(ex.Message, ESocialType.Facebook);
        }

        public void OnSuccess(Java.Lang.Object result)
        {
            _token = AccessToken.CurrentAccessToken.Token;
            _interactorAuth.OnSuccess(_token, ESocialType.Facebook);
        }
    }
}