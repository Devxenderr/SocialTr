namespace SocialTrading.DTO.Response.Post
{
    public class DataModelUpdatePost : DataModelCreatePost
    {
        public DataModelUpdatePost(string[] errors = null) : base(errors ?? new string[0])
        {
        }
    }
}
