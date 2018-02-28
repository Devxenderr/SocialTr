using SocialTrading.Vipers.Post.Interfaces.Body;
using SocialTrading.Vipers.Post.Interfaces.Chart;
using SocialTrading.Vipers.Post.Interfaces.Header;
using SocialTrading.Vipers.Post.Interfaces.Social;

namespace SocialTrading.Vipers.Post.Interfaces
{
    public interface IRouterPost : IRouterPostBody, IRouterPostChart, IRouterPostHeader, IRouterPostSocial
    {
        void OnBack();
    }
}
