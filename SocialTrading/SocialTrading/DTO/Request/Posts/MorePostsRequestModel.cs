using SocialTrading.Tools.Enumerations;

namespace SocialTrading.DTO.Request.Posts
{
    public sealed class MorePostsRequestModel : PostsRequestModel
    {
        public MorePostsRequestModel(string creationDateOfLastPost) : base(EPostsRequestType.InfiniteScroll)
        {
            ApiPath += $"?last_created_at={creationDateOfLastPost}";
        }
    }
}