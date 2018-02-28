using System.Net;

namespace SocialTrading.Connection.Dispatcher
{
    public class SuccessCodes
    {
        public const HttpStatusCode AuthSuccessCode = HttpStatusCode.OK;
        public const HttpStatusCode RegSuccessCode = HttpStatusCode.OK;
        public const HttpStatusCode CreatePostSuccessCode = HttpStatusCode.Created;
        public const HttpStatusCode GetPostsSuccessCode = HttpStatusCode.OK;
        public const HttpStatusCode PostLikeSuccessCode = HttpStatusCode.OK;
        public const HttpStatusCode PostDeleteSuccessCode = HttpStatusCode.OK;
        public const HttpStatusCode GetUserInfoSuccessCode = HttpStatusCode.OK;
        public const HttpStatusCode RecoveryPasswordSuccessCode = HttpStatusCode.OK;
    }
}
