namespace SocialTrading.Locale.Modules
{
    public interface IRegAuth : IAlert
    {
        string EmptyFill { get; }
        string NotValidData { get; }
        string PassNotMatch { get; }
        string FacebookAuthError { get; }
        string PasswordRecovery { get; }
        string AuthError { get; }
        string PasswordRecoveryError { get; }
        string PasswordRecoverySuccess { get; }
        string UserAgreementNotChecked { get; }
        string UserDataError { get; }
        string RegSuccess { get; }
        string ButtonNext { get; }
        string RegNameHint { get; }
        string RegLastNameHint { get; }
        string RegNameTextView { get; }
        string RegEmailTextView { get; }
        string PasswordHint { get; }
        string EmailHint { get; }
        string RegPassConfirmHint { get; }
        string RegPassTextView { get; }
        string RegUserAgreementTextView { get; }
        string RegUserAgreementLink { get; }
        string RegButton { get; }
        string ForgetPasswordLink { get; }
        string LogInButton { get; }
        string FacebookButton { get; }
        string AcceptButton { get; }
        string DeclineButton { get; }
        string AuthActivityTitle { get; }
        string RegActivityTitle { get; }
        string ForgotPassActivityTitle { get; }
		string ShowEmailsAlertTitle { get; }
		string RegPhoneNumberHeader { get; }
		string RegPhoneNumberButtonSkip { get; }
		string RegPhoneNumberHint { get; }
		string RegPhoneCountryHint { get; }
        string AuthSlogan { get; }
        string AuthNoAccount { get; }
        string AuthSocialEnter { get; }
		string RegNameFeatureText { get; }
		string RegEmailFeatureText { get; }
		string RegPhoneFeatureText { get; }
		string RegPassFeatureText { get; }
        string ForgotPassMsgRecovery { get; }
        string ForgotPassButton { get; }
        string RegPasswordIsTooShort { get; }
        string RegEmailIsInvalid { get; }
        string RegFirstNameIsIncorrect { get; }
        string RegLastNameIsIncorrect { get; }
        string RegError { get; }
    }
}
