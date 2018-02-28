using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;

namespace SocialTrading.Vipers.Authorization.Interfaces
{
    public interface IAuthStylesHolder
    {
        IImageViewTheme ViewTheme { get; }
        ITextViewTheme HeaderLabelTheme { get; }
        ITextViewTheme NoAccountLabelTheme { get; }
        IButtonTheme LogInButtonTheme { get; }
        IButtonTheme FacebookButtonTheme { get; }
        IButtonTheme RegistrationButtonTheme { get; }
        IButtonTheme ForgetPassTheme { get; }
        IEditTextTheme EmailEditTextTheme { get; }
        IEditTextTheme PasswordEditTextTheme { get; }
        IImageViewTheme LogoImageViewTheme { get; }

        IEditTextTheme EmailStateSuccess { get; }
        IEditTextTheme EmailStateFail { get; }
        IEditTextTheme PasswordStateSuccess { get; }
        IEditTextTheme PasswordStateFail { get; }

        ITextViewTheme EmailLabelTheme { get; }
        ITextViewTheme PasswordLabelTheme { get; }
        ITextViewTheme SocialNetworkLabelTheme { get; }
    }
}