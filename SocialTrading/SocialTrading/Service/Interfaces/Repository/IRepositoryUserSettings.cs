namespace SocialTrading.Service.Interfaces.Repository
{
    public interface IRepositoryUserSettings : IRepositoryEditContact, IRepositoryEditProfile
    {
        bool IsRepositoryUserSettingsCleaned { get; }

        string UserId { get; set; }
        
        void ConfigRepositoryUserSettings();
        void DisposeRepositoryUserSettings();
    }
}
