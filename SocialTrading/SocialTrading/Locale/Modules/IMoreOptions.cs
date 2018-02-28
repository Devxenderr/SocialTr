namespace SocialTrading.Locale.Modules
{
    public interface IMoreOptions : IAlert
    {
        string ViewMyProfile { get; }
		string Settings { get; }
		string MoreOptionsLogOut { get; }
		string MoreOptionsContacts        { get; }
		string MoreOptionsProfileSettings { get; }
        string MoreOprionsToolbarTitle    { get; }
    }
}
