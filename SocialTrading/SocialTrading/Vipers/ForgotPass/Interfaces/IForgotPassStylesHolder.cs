using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;

namespace SocialTrading.Vipers.ForgotPass.Interfaces
{
    public interface IForgotPassStylesHolder
    {
        IEditTextTheme EmailEditTextTheme { get; }

        IImageViewTheme ViewTheme { get; }

        IButtonTheme RecoveryButtonTheme { get; }

        ITextViewTheme HeaderLabelTheme { get; }

        IImageViewTheme LogoImageViewTheme { get; }

        IImageButtonTheme BackButtonTheme { get; }

        ITextViewTheme EmailLabelTheme { get; }

        IEditTextTheme EmailStateSuccess { get; }

        IEditTextTheme EmailStateFail { get; }
    }
}
