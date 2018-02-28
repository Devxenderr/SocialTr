namespace SocialTrading.Locale.Modules
{
    public interface IEditContact : IAlert
    {
        string EditContactToolbarTitle { get; }
        string EditContactEmail { get; }
        string EditContactSkype { get; }
        string EditContactCountry { get; }
        string EditContactCity { get; }
        string EditContactPhone { get; }
        string EditContactSave { get; }
        string EditContactCancel { get; }
        string EditContactAlertOk { get; }
        string EditContactAlertSuccess { get; }
        string EditContactAlertFail { get; }
        string EditContactCountries { get; }
        string EditContactCountriesToolbar { get; }
    }
}
