using SocialTrading.Tools.Interfaces;
using SocialTrading.Tools.Enumerations;
using SocialTrading.DTO.Response.Post.Interfaces;
using SocialTrading.Vipers.Post.Implementation.Social;

namespace SocialTrading.Vipers.Post.Interfaces.Social
{
    public interface IPresenterPostSocial : ISetConfig
    {
        void SetSocial(IPostSocialModel model);

        void LikeClick();
        void CommentClick();
        void ShareClick();

        void CheckLikedState(EPostSocialResponseStatus state);
        void Share(string link);

        void SetLocale();

        string GetOkLocale();
    }
}
