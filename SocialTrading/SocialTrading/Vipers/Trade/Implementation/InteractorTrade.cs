using SocialTrading.Vipers.Trade.Interfaces;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Service.Interfaces.Notifications;

namespace SocialTrading.Vipers.Trade.Implementation
{
    public class InteractorTrade : IInteractorTrade
    {
        public IPresenterTrade Presenter { set; private get; }

        private readonly IRepositoryPost _repository;
        private readonly INotificationCenter _notificationCenter;


        public InteractorTrade(INotificationCenter notificationCenter, IRepositoryPost repository)
        {
            _repository = repository;
            _notificationCenter = notificationCenter;
        }
    }
}
