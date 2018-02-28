using SocialTrading.ThemesStyles;
using SocialTrading.ThemesStyles.Implementation;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.Vipers.Registration.Password.Interfaces;

namespace SocialTrading.Vipers.Registration.Password.Implementation
{
    public class RegPassStylesHolderDroid<T> : IRegPassStylesHolder where T : AGlobalControlsTheme
    {
        private string _headerLabelTheme                    = "AuthHeaderStyle";
        private string _passwordLabelTheme                  = "AuthForgotPassLabelStyle";
        private string _confirmPasswordLabelTheme           = "AuthForgotPassLabelStyle";
        private string _regButtonTheme                      = "AuthButtonStyle";
        private string _backButtonTheme                     = "AuthBackButtonStyle";
        private string _viewTheme                           = "AuthImageViewBackgroundStyle";
        private string _logoImageViewTheme                  = "AuthLogoImageViewStyle";
        private string _passwordEditTextTheme               = "AuthEditTextStyle";
        private string _passwordStateSuccess                = "AuthEditTextSuccessStyle";
        private string _passwordStateFail                   = "AuthEditTextFailStyle";
        private string _passwordConfirmEditTextTheme        = "AuthEditTextStyle";
        private string _passwordConfirmStateSuccess         = "AuthEditTextSuccessStyle";
        private string _passwordConfirmStatePassNotMatch    = "AuthEditTextFailStyle";
        private string _passwordConfirmStateFail            = "AuthEditTextFailStyle";
        private string _userAgreementMainTextTheme          = "AuthAgreementLabelMainStyle";
        private string _userAgreementAttrTextTheme          = "AuthAgreementButtonLinkedStyle";
        private string _featureTextTheme                    = "AuthFeatureLabelStyle";
        private string _featureImageTheme                   = "AuthPassFeatureImageViewStyle";

        public ITextViewTheme HeaderLabelTheme                 { get; }
        public ITextViewTheme PasswordLabelTheme               { get; }
        public ITextViewTheme ConfirmPasswordLabelTheme        { get; }
        public IButtonTheme RegButtonTheme                     { get; }
        public IImageButtonTheme BackButtonTheme               { get; }
        public IImageViewTheme ViewTheme                       { get; }
        public IImageViewTheme LogoImageViewTheme              { get; }
        public IEditTextTheme PasswordEditTextTheme            { get; }
        public IEditTextTheme PasswordStateSuccess             { get; }
        public IEditTextTheme PasswordStateFail                { get; }
        public IEditTextTheme PasswordConfirmEditTextTheme     { get; }
        public IEditTextTheme PasswordConfirmStateSuccess      { get; }
        public IEditTextTheme PasswordConfirmStatePassNotMatch { get; }
        public IEditTextTheme PasswordConfirmStateFail         { get; }
        public IButtonTheme UserAgreementMainTextTheme         { get; }
        public IButtonTheme UserAgreementAttrTextTheme         { get; }
        public ITextViewTheme FeatureTextTheme                 { get; }
        public IImageViewTheme FeatureImageTheme               { get; }

        public RegPassStylesHolderDroid(ThemeParser<T> themeParser)
        {
            HeaderLabelTheme = themeParser.GetThemeByName<ITextViewTheme>(_headerLabelTheme);
            PasswordLabelTheme = themeParser.GetThemeByName<ITextViewTheme>(_passwordLabelTheme);
            ConfirmPasswordLabelTheme = themeParser.GetThemeByName<ITextViewTheme>(_confirmPasswordLabelTheme);
            RegButtonTheme = themeParser.GetThemeByName<IButtonTheme>(_regButtonTheme);
            BackButtonTheme = themeParser.GetThemeByName<IImageButtonTheme>(_backButtonTheme);
            ViewTheme = themeParser.GetThemeByName<IImageViewTheme>(_viewTheme);
            LogoImageViewTheme = themeParser.GetThemeByName<IImageViewTheme>(_logoImageViewTheme);
            PasswordEditTextTheme = themeParser.GetThemeByName<IEditTextTheme>(_passwordEditTextTheme);
            PasswordStateSuccess = themeParser.GetThemeByName<IEditTextTheme>(_passwordStateSuccess);
            PasswordStateFail = themeParser.GetThemeByName<IEditTextTheme>(_passwordStateFail);
            PasswordConfirmEditTextTheme = themeParser.GetThemeByName<IEditTextTheme>(_passwordConfirmEditTextTheme);
            PasswordConfirmStateSuccess = themeParser.GetThemeByName<IEditTextTheme>(_passwordConfirmStateSuccess);
            PasswordConfirmStatePassNotMatch = themeParser.GetThemeByName<IEditTextTheme>(_passwordConfirmStatePassNotMatch);
            PasswordConfirmStateFail = themeParser.GetThemeByName<IEditTextTheme>(_passwordConfirmStateFail);
            UserAgreementMainTextTheme = themeParser.GetThemeByName<IButtonTheme>(_userAgreementMainTextTheme);
            UserAgreementAttrTextTheme = themeParser.GetThemeByName<IButtonTheme>(_userAgreementAttrTextTheme);
            FeatureTextTheme = themeParser.GetThemeByName<ITextViewTheme>(_featureTextTheme);
            FeatureImageTheme = themeParser.GetThemeByName<IImageViewTheme>(_featureImageTheme);
        }
    }
}