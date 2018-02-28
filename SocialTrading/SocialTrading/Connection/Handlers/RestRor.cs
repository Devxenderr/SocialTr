using System;
using SocialTrading.Connection.Markers;
using SocialTrading.Connection.Dispatcher;
using SocialTrading.Connection.Enumerations;
using SocialTrading.Connection.Interfaces;
using SocialTrading.DTO.Response;

namespace SocialTrading.Connection.Handlers
{
    public sealed class RestRor : ARest
    {
        public RestRor(string address) : base(typeof(RestRorMarker))
        {
            ServerAddress = address;
        }

        //public override void OnMessage(string message, EResponseModule responseModule)
        //{
            //switch (responseModule)
            //{
            //    case EResponseModule.Auth:
            //        ConnectionDispatcher.AuthResponse(message, StatusCode, HeaderModel);
            //        break;
            //    case EResponseModule.Reg:
            //        ConnectionDispatcher.RegResponse(message, StatusCode, HeaderModel);
            //        break;
            //    case EResponseModule.CreatePost:
            //        ConnectionDispatcher.CreatePostResponse(message, StatusCode, HeaderModel);
            //        break;
            //    case EResponseModule.Post:
            //        ConnectionDispatcher.PostsResponse(message, StatusCode, HeaderModel);
            //        break;
            //    case EResponseModule.PostLike:
            //        ConnectionDispatcher.PostLikeResponse(message, StatusCode, HeaderModel);
            //        break;
            //    case EResponseModule.PostDelete:
            //        ConnectionDispatcher.PostDeleteResponse(message, StatusCode, HeaderModel);
            //        break;
            //    case EResponseModule.UserInfo:
            //        ConnectionDispatcher.UserInfoResponse(message, StatusCode, HeaderModel);
            //        break;
            //    case EResponseModule.RecoveryPassword:
            //        ConnectionDispatcher.RecoveryPasswordResponse(message, StatusCode, HeaderModel);
            //        break;

            //    default:
            //        // TODO: Send error about server response
            //        break;
            //}
        //}
        
    }
}
