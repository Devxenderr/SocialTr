using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.TextView;

namespace SocialTrading.Vipers.MoreOptions.EditProfile.Interfaces
{
    public interface IEditProfileStylesHolder
    {
        ITextViewTheme LabelsTheme { get; }
        IEditTextTheme EditTextsTheme { get; }
        IEditTextTheme EditTextsFailTheme { get; }
        IButtonTheme SaveButtonTheme { get; }
        IButtonTheme CancelButtonTheme { get; }
        IViewTheme ViewTheme { get; }
    }
}