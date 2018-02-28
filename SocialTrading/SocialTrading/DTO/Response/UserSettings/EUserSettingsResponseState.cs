namespace SocialTrading.DTO.Response.UserSettings
{
    public enum EUserSettingsResponseState
    {
        Error = 10,
        UserNotFound = 11,
        Unauthorized = 12,
        UnprocessableEntity = 13,
        NoConnection = 14,

        Success = 20,
        Processing = 24
    }
}
