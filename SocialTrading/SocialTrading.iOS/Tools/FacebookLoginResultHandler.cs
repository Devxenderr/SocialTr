using System;
using Facebook.LoginKit;

using Foundation;

using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Authorization.Interfaces;

namespace SocialTrading.iOS.Tools
{
    public static class FacebookLoginResultHandler
    {
        private static ISocialAuth _interactor;
        private static LoginManager _loginManager;
        public static void Handler(LoginManagerLoginResult result, NSError error, ISocialAuth interactor, LoginManager loginManager)
        {
            _loginManager = loginManager;
            _interactor = interactor;

            if (error != null) 
            {
                _interactor.OnError(error.LocalizedDescription, ESocialType.Facebook);
            }
            else if(result.IsCancelled)
            {
                _interactor.OnCancel(ESocialType.Facebook);

                _loginManager.LogOut();
                var r = new Facebook.CoreKit.GraphRequest("me/permissions", null, "DELETE");
                r.Start( (connection, result1, error1) => {
                    Console.WriteLine("GraphRequest");
                });
            }
            else
            {
                var token = result.Token.TokenString;
                _interactor.OnSuccess(token, ESocialType.Facebook);
            }
        }
    }
}
