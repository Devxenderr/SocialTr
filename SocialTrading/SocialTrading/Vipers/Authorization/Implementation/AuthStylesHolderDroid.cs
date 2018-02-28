using SocialTrading.ThemesStyles;
using SocialTrading.ThemesStyles.Implementation;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.Vipers.Authorization.Interfaces;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.ImageView;

namespace SocialTrading.Vipers.Authorization.Implementation
{
    public class AuthStylesHolderDroid<T> : IAuthStylesHolder where T : AGlobalControlsTheme
    {
        private string _viewTheme = "AuthImageViewBackgroundStyle";
        private string _headerLabelTheme = "AuthHeaderStyle";
        private string _noAccountLabelTheme = "AuthNoAccountLabelStyle";
        private string _logInButtonTheme = "AuthButtonStyle";
        private string _facebookButtonTheme = "AuthFacebookButtonStyle";
        private string _registrationButtonTheme = "AuthButtonStyle";
        private string _forgetPassTheme = "AuthForgotPassLabelStyle";
        private string _emailEditTextTheme = "AuthEditTextStyle";
        private string _passwordEditTextTheme  = "AuthEditTextStyle";
        private string _logoImageViewTheme = "AuthLogoImageViewStyle";

        private string _emailStateSuccess  = "AuthEditTextSuccessStyle";
        private string _emailStateFail  = "AuthEditTextFailStyle";
        private string _passwordStateSuccess  = "AuthEditTextSuccessStyle";
        private string _passwordStateFail = "AuthEditTextFailStyle";

        private string _emailLabelTheme = "";
        private string _passwordLabelTheme = "";
        private string _socialNetworkLabelTheme ="";

        public IImageViewTheme ViewTheme { get; }
        public ITextViewTheme HeaderLabelTheme { get; } 
        public ITextViewTheme NoAccountLabelTheme { get; }
        public IButtonTheme LogInButtonTheme { get; }
        public IButtonTheme FacebookButtonTheme { get; }
        public IButtonTheme RegistrationButtonTheme { get; }
        public IButtonTheme ForgetPassTheme { get; }
        public IEditTextTheme EmailEditTextTheme { get; }
        public IEditTextTheme PasswordEditTextTheme { get; } 
        public IImageViewTheme LogoImageViewTheme { get; }

        public IEditTextTheme EmailStateSuccess { get; }
        public IEditTextTheme EmailStateFail { get; }
        public IEditTextTheme PasswordStateSuccess { get; }
        public IEditTextTheme PasswordStateFail { get; }

        public ITextViewTheme EmailLabelTheme { get; }
        public ITextViewTheme PasswordLabelTheme { get; }
        public ITextViewTheme SocialNetworkLabelTheme { get; }


        public AuthStylesHolderDroid(ThemeParser<T> themeParser)
        {
            ViewTheme = themeParser.GetThemeByName<IImageViewTheme>(_viewTheme);
            HeaderLabelTheme = themeParser.GetThemeByName<ITextViewTheme>(_headerLabelTheme);
            NoAccountLabelTheme = themeParser.GetThemeByName<ITextViewTheme>(_noAccountLabelTheme);
            LogInButtonTheme = themeParser.GetThemeByName<IButtonTheme>(_logInButtonTheme);
            FacebookButtonTheme = themeParser.GetThemeByName<IButtonTheme>(_facebookButtonTheme);
            RegistrationButtonTheme = themeParser.GetThemeByName<IButtonTheme>(_registrationButtonTheme);
            ForgetPassTheme = themeParser.GetThemeByName<IButtonTheme>(_forgetPassTheme); 
            EmailEditTextTheme = themeParser.GetThemeByName<IEditTextTheme>(_emailEditTextTheme);
            PasswordEditTextTheme = themeParser.GetThemeByName<IEditTextTheme>(_passwordEditTextTheme);
            LogoImageViewTheme = themeParser.GetThemeByName<IImageViewTheme>(_logoImageViewTheme); 

            EmailStateSuccess = themeParser.GetThemeByName<IEditTextTheme>(_emailStateSuccess); 
            EmailStateFail = themeParser.GetThemeByName<IEditTextTheme>(_emailStateFail); 
            PasswordStateSuccess = themeParser.GetThemeByName<IEditTextTheme>(_passwordStateSuccess); 
            PasswordStateFail = themeParser.GetThemeByName<IEditTextTheme>(_passwordStateFail);
            
            EmailLabelTheme = themeParser.GetThemeByName<ITextViewTheme>(_emailLabelTheme); 
            PasswordLabelTheme = themeParser.GetThemeByName<ITextViewTheme>(_passwordLabelTheme);
            SocialNetworkLabelTheme = themeParser.GetThemeByName<ITextViewTheme>(_socialNetworkLabelTheme); 
        }
    }
}