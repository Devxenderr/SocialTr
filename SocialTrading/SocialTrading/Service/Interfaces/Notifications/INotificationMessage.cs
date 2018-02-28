namespace SocialTrading.Service.Interfaces.Notifications
{
    public interface INotificationMessage
    {
        void OnNotificationIncome<T>(T data);
    }
}
