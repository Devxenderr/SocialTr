using SocialTrading.Vipers.Post.Interfaces.Chart;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Service.Interfaces.Notifications;

namespace SocialTrading.Vipers.Post.Implementation.Chart
{
    public class InteractorPostChart : IInteractorPostChart
    {
        public IPresenterPostChart Presenter { set; private get; }

        private readonly IRepositoryPost _repository;
        private readonly INotificationCenter _notificationCenter;


        public InteractorPostChart(INotificationCenter notificationCenter, IRepositoryPost repository)
        {
            _repository = repository;
            _notificationCenter = notificationCenter;
        }
    }
}
