namespace SocialTrading.Locale.Modules
{
    public interface IAlert
    {
        string OK { get; }
        string Cancel { get; }
        string Error { get; }
        string NoConnection { get; }
        string NoResponse { get; }
        string NotFound { get; }
        string ServiceUnavailable { get; }
        string UnknownError { get; }
        string LogoutAlert { get; }
        string Yes { get; }
        string No { get; }
        string UnprocessableEntity { get; }
        string Unauthorized { get; }
        string BadRequest { get; }
        string BadToken { get; }
    }
}
