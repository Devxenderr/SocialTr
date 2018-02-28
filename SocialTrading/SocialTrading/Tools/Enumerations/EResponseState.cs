namespace SocialTrading.Tools.Enumerations
{
    public enum EResponseState
    {
        None,

        Waiting,

        NoConnection,
        NoResponse,
        NotFound,
        ServiceUnavailable,
        Unknown,

        AuthError,
        AuthSuccess,

        RegError,
        RegSuccess,

        CreatePostBadRequest,
        CreatePostUnauthorized,
        CreatePostUnprocessableEntity,
        CreatePostSuccess,

        GetPostsError,
        GetPostsSuccess,

        PostLikeError,
        PostLikeSuccess,

        PostDeleteSuccess,
        PostDeleteError,

        GetUserInfoSuccess,
        GetUserInfoError,

        PasswordRecoverySuccess,
        PasswordRecoveryError,
        PasswordRecoveryErrorUnauthorized

    }
}
