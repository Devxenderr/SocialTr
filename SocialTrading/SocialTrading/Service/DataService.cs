namespace SocialTrading.Service
{
    public static class DataService
    {
        public static RepositoryController RepositoryController { get; private set; }
        public static NotificationCenter NotificationCenter { get; private set; }

        static DataService()
        {
            NotificationCenter = new NotificationCenter();
            RepositoryController = RepositoryController.GetInstance();
        }
    }
}

