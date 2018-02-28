using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;

namespace SocialTrading.Vipers.Registration.Password.Interfaces
{
    public interface IRegPassStylesHolder
    {
        ITextViewTheme HeaderLabelTheme                 { get; }
        ITextViewTheme PasswordLabelTheme               { get; }
        ITextViewTheme ConfirmPasswordLabelTheme        { get; }
        IButtonTheme RegButtonTheme                     { get; }
        IImageButtonTheme BackButtonTheme               { get; }
        IImageViewTheme ViewTheme                       { get; }
        IImageViewTheme LogoImageViewTheme              { get; }
        IEditTextTheme PasswordEditTextTheme            { get; }
        IEditTextTheme PasswordStateSuccess             { get; }
        IEditTextTheme PasswordStateFail                { get; }
        IEditTextTheme PasswordConfirmEditTextTheme     { get; }
        IEditTextTheme PasswordConfirmStateSuccess      { get; }
        IEditTextTheme PasswordConfirmStatePassNotMatch { get; }
        IEditTextTheme PasswordConfirmStateFail         { get; }
        IButtonTheme UserAgreementMainTextTheme         { get; }
        IButtonTheme UserAgreementAttrTextTheme         { get; }
        ITextViewTheme FeatureTextTheme                 { get; }
        IImageViewTheme FeatureImageTheme               { get; }
    }
}