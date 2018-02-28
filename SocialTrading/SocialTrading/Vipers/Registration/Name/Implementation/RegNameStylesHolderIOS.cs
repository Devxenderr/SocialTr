using SocialTrading.ThemesStyles;
using SocialTrading.ThemesStyles.Implementation;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.Vipers.Registration.Name.Interfaces;

namespace SocialTrading.Vipers.Registration.Name.Implementation
{
    public class RegNameStylesHolderIOS<T> : IRegNameStylesHolder where T : AGlobalControlsTheme
    {
        private string _headerLabelTheme        = "AuthHeaderStyle";
        private string _nameLabelTheme          = "AuthForgotPassLabelStyle";
        private string _lastNameLabelTheme      = "AuthForgotPassLabelStyle";
        private string _nextButtonTheme         = "AuthButtonStyleIOS";
        private string _backButtonTheme         = "AuthBackButtonStyle";
        private string _viewTheme               = "AuthViewBackgroundStyleIOS";
        private string _logoImageViewTheme      = "AuthLogoImageViewStyle";
        private string _nameEditTextTheme       = "AuthEditTextStyle";
        private string _nameStateSuccess        = "AuthEditTextSuccessStyleIOS";
        private string _nameStateFail           = "AuthEditTextFailStyleIOS";
        private string _lastNameEditTextTheme   = "AuthEditTextStyle";
        private string _lastNameStateSuccess    = "AuthEditTextSuccessStyleIOS";
        private string _lastNameStateFail       = "AuthEditTextFailStyleIOS";
        private string _featureTextTheme        = "AuthFeatureLabelStyle";
        private string _featureImageTheme       = "AuthNameFeatureImageViewStyle";

        public ITextViewTheme HeaderLabelTheme          { get; }
        public ITextViewTheme NameLabelTheme            { get; }
        public ITextViewTheme LastNameLabelTheme        { get; }
        public IButtonTheme NextButtonTheme             { get; }
        public IImageButtonTheme BackButtonTheme        { get; }
        public IImageViewTheme ViewTheme                { get; }
        public IImageViewTheme LogoImageViewTheme       { get; }
        public IEditTextTheme NameEditTextTheme         { get; }
        public IEditTextTheme NameStateSuccess          { get; }
        public IEditTextTheme NameStateFail             { get; }
        public IEditTextTheme LastNameEditTextTheme     { get; }
        public IEditTextTheme LastNameStateSuccess      { get; }
        public IEditTextTheme LastNameStateFail         { get; }
        public ITextViewTheme FeatureTextTheme          { get; }
        public IImageViewTheme FeatureImageTheme        { get; }

        public RegNameStylesHolderIOS(ThemeParser<T> themeParser)
        {
            HeaderLabelTheme = themeParser.GetThemeByName<ITextViewTheme>(_headerLabelTheme);
            NameLabelTheme = themeParser.GetThemeByName<ITextViewTheme>(_nameLabelTheme);
            LastNameLabelTheme = themeParser.GetThemeByName<ITextViewTheme>(_lastNameLabelTheme);
            NextButtonTheme = themeParser.GetThemeByName<IButtonTheme>(_nextButtonTheme);
            BackButtonTheme = themeParser.GetThemeByName<IImageButtonTheme>(_backButtonTheme);
            ViewTheme = themeParser.GetThemeByName<IImageViewTheme>(_viewTheme);
            LogoImageViewTheme = themeParser.GetThemeByName<IImageViewTheme>(_logoImageViewTheme);
            NameEditTextTheme = themeParser.GetThemeByName<IEditTextTheme>(_nameEditTextTheme);
            NameStateSuccess = themeParser.GetThemeByName<IEditTextTheme>(_nameStateSuccess);
            NameStateFail = themeParser.GetThemeByName<IEditTextTheme>(_nameStateFail);
            LastNameEditTextTheme = themeParser.GetThemeByName<IEditTextTheme>(_lastNameEditTextTheme);
            LastNameStateSuccess = themeParser.GetThemeByName<IEditTextTheme>(_lastNameStateSuccess);
            LastNameStateFail = themeParser.GetThemeByName<IEditTextTheme>(_lastNameStateFail);
            FeatureTextTheme = themeParser.GetThemeByName<ITextViewTheme>(_featureTextTheme);
            FeatureImageTheme = themeParser.GetThemeByName<IImageViewTheme>(_featureImageTheme);
        }
    }
}