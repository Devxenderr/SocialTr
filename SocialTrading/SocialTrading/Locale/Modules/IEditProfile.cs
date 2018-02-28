namespace SocialTrading.Locale.Modules
{
    public interface IEditProfile : IAlert
    {
        string EditProfileNameTitle { get; }
        string EditProfileLastnameTitle { get; }
        string EditProfileStatusTitle { get; }
        string EditProfileSaveButtonTitle { get; }
        string EditProfileCancelButtonTitle { get; }
        string EditProfileToolbarTitle { get; }
        string EditProfileAlertSuccess { get; }
        string EditProfileAlertFail { get; }
    }
}