
namespace SocialTrading.Vipers.CreatePost
{
    public enum EPostResponseStatus
    {
        Error = 10,
        Unauthorized = 11,
        UnprocessableEntity = 12,
        BadRequest = 13,
        TooLargeImage = 14,
        NoConnection = 15,

        Success = 20
    }
}
