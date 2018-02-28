using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.TextView;

namespace SocialTrading.Vipers.Registration.Email.Interfaces
{
    public interface IRegEmailStylesHolder
    {
        ITextViewTheme HeaderLabelTheme     { get; }
        ITextViewTheme EmailLabelTheme      { get; }
        IButtonTheme NextButtonTheme        { get; }
        IImageButtonTheme BackButtonTheme   { get; }
        IImageViewTheme ViewTheme           { get; }
        IImageViewTheme LogoImageViewTheme  { get; }
        IEditTextTheme EmailEditTextTheme   { get; }
        IEditTextTheme EmailStateSuccess    { get; }
        IEditTextTheme EmailStateFail       { get; }
        ITextViewTheme FeatureTextTheme     { get; }
        IImageViewTheme FeatureImageTheme   { get; }
    }
}