using SocialTrading.Tools.Interfaces;

namespace SocialTrading.Vipers.Post.Interfaces.Statistics
{
    public interface IViewPostStatistics : ISetConfig
    {
        IPresenterPostStatistics Presenter { set; }

        void SetPnL(string PnL);
        void SetPnLStateNone();
        void SetPnLStatePositive();
        void SetPnLStateNegative();

        void SetDeals(string deals);
        void SetDealsStateNone();
        void SetDealsStatePositive();
        
        void SetLong(int size);

        void SetLongPercent(string percent);

        void SetShortPercent(string percent);

        int GetStatisticsLineSize();
    }
}
