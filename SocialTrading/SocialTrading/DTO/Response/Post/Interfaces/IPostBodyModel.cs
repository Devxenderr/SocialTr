namespace SocialTrading.DTO.Response.Post.Interfaces
{
    public interface IPostBodyModel
    {
        string Content { get; }
        string Image { get; }
        string CachedImage { get; set; }
    }
}
