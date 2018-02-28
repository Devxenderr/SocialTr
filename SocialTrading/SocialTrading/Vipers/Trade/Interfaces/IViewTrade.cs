using SocialTrading.Tools.Interfaces;

namespace SocialTrading.Vipers.Trade.Interfaces
{
    public interface IViewTrade : ISetConfig
    {
        IPresenterTrade Presenter { set; }
    }
}
