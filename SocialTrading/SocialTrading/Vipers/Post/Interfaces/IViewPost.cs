using SocialTrading.Tools.Enumerations;
using SocialTrading.Tools.Interfaces;
using SocialTrading.Vipers.Trade.Interfaces;
using SocialTrading.Vipers.Post.Interfaces.Body;
using SocialTrading.Vipers.Post.Interfaces.Chart;
using SocialTrading.Vipers.Post.Interfaces.Header;
using SocialTrading.Vipers.Post.Interfaces.Social;
using SocialTrading.Vipers.Post.Interfaces.Statistics;

namespace SocialTrading.Vipers.Post.Interfaces
{
    public interface IViewPost : ISetConfig
    {
        IPresenterPost Presenter { set; }

        IViewPostBody ViewPostBody { get; }
        IViewPostChart ViewPostChart { get; }
        IViewPostHeader ViewPostHeader { get; }
        IViewPostSocial ViewPostSocial { get; }
        IViewPostStatistics ViewPostStatistics { get; }
        IViewTrade ViewTrade { get; }
        void SetTheme();

        void SetPostMarket(EMarketTypes type);

    }
}
