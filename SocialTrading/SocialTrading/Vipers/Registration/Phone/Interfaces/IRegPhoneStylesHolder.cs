using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;

namespace SocialTrading.Vipers.Registration.Phone.Interfaces
{
    public interface IRegPhoneStylesHolder
    {
        ITextViewTheme HeaderLabelTheme             { get; }
        ITextViewTheme PhoneCountryLabelTheme       { get; }
        ITextViewTheme PhoneNumberLabelTheme        { get; }
        IButtonTheme NextButtonTheme                { get; }
        IButtonTheme SkipButtonTheme                { get; }
        IImageButtonTheme BackButtonTheme           { get; }
        IImageViewTheme ViewTheme                   { get; }
        IImageViewTheme LogoImageViewTheme          { get; }
        IEditTextTheme PhoneCountryEditTextTheme    { get; }
        IEditTextTheme PhoneCountryStateSuccess     { get; }
        IEditTextTheme PhoneCountryStateFail        { get; }
        IEditTextTheme PhoneNumberEditTextTheme     { get; }
        IEditTextTheme PhoneNumberStateSuccess      { get; }
        IEditTextTheme PhoneNumberStateFail         { get; }
        ITextViewTheme FeatureTextTheme             { get; }
        IImageViewTheme FeatureImageTheme           { get; }
    }
}