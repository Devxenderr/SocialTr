namespace SocialTrading.DTO.Response.Post.Interfaces
{
    public interface IPostSocialModel
    {
        bool IsLiked { get; set; }
        int LikeCount { get; set; }
        int CommentCount { get; set; }
    }
}
