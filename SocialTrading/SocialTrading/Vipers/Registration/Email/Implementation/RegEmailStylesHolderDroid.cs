using SocialTrading.ThemesStyles;
using SocialTrading.ThemesStyles.Implementation;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.Vipers.Registration.Email.Interfaces;

namespace SocialTrading.Vipers.Registration.Email.Implementation
{
    public class RegEmailStylesHolderDroid<T> : IRegEmailStylesHolder where T : AGlobalControlsTheme
    {
        private string _headerLabelTheme    = "AuthHeaderStyle";
        private string _emailLabelTheme     = "AuthForgotPassLabelStyle";
        private string _nextButtonTheme     = "AuthButtonStyle";
        private string _backButtonTheme     = "AuthBackButtonStyle";
        private string _viewTheme           = "AuthImageViewBackgroundStyle";
        private string _logoImageViewTheme  = "AuthLogoImageViewStyle";
        private string _emailEditTextTheme  = "AuthEditTextStyle";
        private string _emailStateSuccess   = "AuthEditTextSuccessStyle";
        private string _emailStateFail      = "AuthEditTextFailStyle";
        private string _featureTextTheme    = "AuthFeatureLabelStyle";
        private string _featureImageTheme   = "AuthEmailFeatureImageViewStyle";

        public ITextViewTheme HeaderLabelTheme      { get; }
        public ITextViewTheme EmailLabelTheme       { get; }
        public IButtonTheme NextButtonTheme         { get; }
        public IImageButtonTheme BackButtonTheme    { get; }
        public IImageViewTheme ViewTheme            { get; }
        public IImageViewTheme LogoImageViewTheme   { get; }
        public IEditTextTheme EmailEditTextTheme    { get; }
        public IEditTextTheme EmailStateSuccess     { get; }
        public IEditTextTheme EmailStateFail        { get; }
        public ITextViewTheme FeatureTextTheme      { get; }
        public IImageViewTheme FeatureImageTheme    { get; }

        public RegEmailStylesHolderDroid(ThemeParser<T> themeParser)
        {
            HeaderLabelTheme = themeParser.GetThemeByName<ITextViewTheme>(_headerLabelTheme);
            EmailLabelTheme = themeParser.GetThemeByName<ITextViewTheme>(_emailLabelTheme);
            NextButtonTheme = themeParser.GetThemeByName<IButtonTheme>(_nextButtonTheme);
            BackButtonTheme = themeParser.GetThemeByName<IImageButtonTheme>(_backButtonTheme);
            ViewTheme = themeParser.GetThemeByName<IImageViewTheme>(_viewTheme);
            LogoImageViewTheme = themeParser.GetThemeByName<IImageViewTheme>(_logoImageViewTheme);
            EmailEditTextTheme = themeParser.GetThemeByName<IEditTextTheme>(_emailEditTextTheme);
            EmailStateSuccess = themeParser.GetThemeByName<IEditTextTheme>(_emailStateSuccess);
            EmailStateFail = themeParser.GetThemeByName<IEditTextTheme>(_emailStateFail);
            FeatureTextTheme = themeParser.GetThemeByName<ITextViewTheme>(_featureTextTheme);
            FeatureImageTheme = themeParser.GetThemeByName<IImageViewTheme>(_featureImageTheme);
        }
    }
}