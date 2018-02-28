using SocialTrading.ThemesStyles;
using SocialTrading.ThemesStyles.Implementation;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.Vipers.Registration.Phone.Interfaces;

namespace SocialTrading.Vipers.Registration.Phone.Implementation
{
    public class RegPhoneStylesHolderIOS<T> : IRegPhoneStylesHolder where T : AGlobalControlsTheme
    {
        private string _headerLabelTheme            = "AuthHeaderStyle";
        private string _phoneCountryLabelTheme      = "AuthForgotPassLabelStyle";
        private string _phoneNumberLabelTheme       = "AuthForgotPassLabelStyle";
        private string _nextButtonTheme             = "AuthButtonStyleIOS";
        private string _skipButtonTheme             = "AuthButtonStyleIOS";
        private string _backButtonTheme             = "AuthBackButtonStyle";
        private string _viewTheme                   = "AuthViewBackgroundStyleIOS";
        private string _logoImageViewTheme          = "AuthLogoImageViewStyle";
        private string _phoneCountryEditTextTheme   = "AuthEditTextStyle";
        private string _phoneCountryStateSuccess    = "AuthEditTextSuccessStyleIOS";
        private string _phoneCountryStateFail       = "AuthEditTextFailStyle";
        private string _phoneNumberEditTextTheme    = "AuthEditTextStyle";
        private string _phoneNumberStateSuccess     = "AuthEditTextSuccessStyleIOS";
        private string _phoneNumberStateFail        = "AuthEditTextFailStyleIOS";
        private string _featureTextTheme            = "AuthFeatureLabelStyle";
        private string _featureImageTheme           = "AuthPhoneFeatureImageViewStyle";

        public ITextViewTheme HeaderLabelTheme          { get; }
        public ITextViewTheme PhoneCountryLabelTheme    { get; }
        public ITextViewTheme PhoneNumberLabelTheme     { get; }
        public IButtonTheme NextButtonTheme             { get; }
        public IButtonTheme SkipButtonTheme             { get; }
        public IImageButtonTheme BackButtonTheme        { get; }
        public IImageViewTheme ViewTheme                { get; }
        public IImageViewTheme LogoImageViewTheme       { get; }
        public IEditTextTheme PhoneCountryEditTextTheme { get; }
        public IEditTextTheme PhoneCountryStateSuccess  { get; }
        public IEditTextTheme PhoneCountryStateFail     { get; }
        public IEditTextTheme PhoneNumberEditTextTheme  { get; }
        public IEditTextTheme PhoneNumberStateSuccess   { get; }
        public IEditTextTheme PhoneNumberStateFail      { get; }
        public ITextViewTheme FeatureTextTheme          { get; }
        public IImageViewTheme FeatureImageTheme        { get; }

        public RegPhoneStylesHolderIOS(ThemeParser<T> themeParser)
        {
            HeaderLabelTheme = themeParser.GetThemeByName<ITextViewTheme>(_headerLabelTheme);
            PhoneCountryLabelTheme = themeParser.GetThemeByName<ITextViewTheme>(_phoneCountryLabelTheme);
            PhoneNumberLabelTheme = themeParser.GetThemeByName<ITextViewTheme>(_phoneNumberLabelTheme);
            NextButtonTheme = themeParser.GetThemeByName<IButtonTheme>(_nextButtonTheme);
            SkipButtonTheme = themeParser.GetThemeByName<IButtonTheme>(_skipButtonTheme);
            BackButtonTheme = themeParser.GetThemeByName<IImageButtonTheme>(_backButtonTheme);
            ViewTheme = themeParser.GetThemeByName<IImageViewTheme>(_viewTheme);
            LogoImageViewTheme = themeParser.GetThemeByName<IImageViewTheme>(_logoImageViewTheme);
            PhoneCountryEditTextTheme = themeParser.GetThemeByName<IEditTextTheme>(_phoneCountryEditTextTheme);
            PhoneCountryStateSuccess = themeParser.GetThemeByName<IEditTextTheme>(_phoneCountryStateSuccess);
            PhoneCountryStateFail = themeParser.GetThemeByName<IEditTextTheme>(_phoneCountryStateFail);
            PhoneNumberEditTextTheme = themeParser.GetThemeByName<IEditTextTheme>(_phoneNumberEditTextTheme);
            PhoneNumberStateSuccess = themeParser.GetThemeByName<IEditTextTheme>(_phoneNumberStateSuccess);
            PhoneNumberStateFail = themeParser.GetThemeByName<IEditTextTheme>(_phoneNumberStateFail);
            FeatureTextTheme = themeParser.GetThemeByName<ITextViewTheme>(_featureTextTheme);
            FeatureImageTheme = themeParser.GetThemeByName<IImageViewTheme>(_featureImageTheme);
        }
    }
}