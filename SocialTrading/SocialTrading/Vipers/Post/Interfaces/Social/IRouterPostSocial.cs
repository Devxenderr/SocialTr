namespace SocialTrading.Vipers.Post.Interfaces.Social
{
    public interface IRouterPostSocial
    {
        void ToComments();
        void ToShare(string link);
    }
}
