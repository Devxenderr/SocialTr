namespace SocialTrading.Vipers.ForgotPass
{
    public enum EForgotPassStatus
    {
        None = -10,
        Error = 0,

        RecoverySuccess = 10,

        UserNotFound = 20,
        ServerError = 21,
        NoConnection = 22
    }
}
