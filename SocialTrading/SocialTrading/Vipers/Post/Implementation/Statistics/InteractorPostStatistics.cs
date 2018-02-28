using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Service.Interfaces.Notifications;
using SocialTrading.Vipers.Post.Interfaces.Statistics;

namespace SocialTrading.Vipers.Post.Implementation.Statistics
{
    public class InteractorPostStatistics : IInteractorPostStatistics
    {
        public IPresenterPostStatistics Presenter { set; private get; }

        private readonly IRepositoryPost _repository;
        private readonly INotificationCenter _notificationCenter;


        public InteractorPostStatistics(INotificationCenter notificationCenter, IRepositoryPost repository)
        {
            _repository = repository;
            _notificationCenter = notificationCenter;
        }


        public int CalculateStatisticsLongLineSize(int peercentLong, int size)
        {
            var longSize = (peercentLong * size) / 100;
            return longSize;
        }
    }
}
