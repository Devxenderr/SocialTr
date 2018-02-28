using SocialTrading.DTO.Response.Post.Interfaces;

namespace SocialTrading.Vipers.Post.Interfaces.Body
{
    public interface IPresenterPostBody
    {
        void SetBody(IPostBodyModel model, int symbolsCount = 0);
        void ReadMoreClick();

        bool IsPostDetailed { get; }

        void SaveCachedImage(string base64);
    }
}
