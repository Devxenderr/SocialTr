using SocialTrading.ThemesStyles;
using SocialTrading.ThemesStyles.Implementation;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.Vipers.MoreOptions.EditProfile.Interfaces;

namespace SocialTrading.Vipers.MoreOptions.EditProfile.Implementation
{
    public class EditProfileStylesHolderDroid<T> : IEditProfileStylesHolder where T : AGlobalControlsTheme
    {
        private string _labelsTheme = "EditProfileTextViewStyle";
        private string _editTextsTheme = "EditProfileEditTextStyle";
        private string _editTextsFailTheme = "EditProfileEditTextFailStyle";
        private string _saveButtonTheme = "EditProfileSaveButtonStyle";
        private string _cancelButtonTheme = "EditProfileCancelButtonStyle";
        private string _viewTheme = "EditProfileViewStyle";

        public ITextViewTheme LabelsTheme { get; }
        public IEditTextTheme EditTextsTheme { get; }
        public IEditTextTheme EditTextsFailTheme { get; }
        public IButtonTheme SaveButtonTheme { get; }
        public IButtonTheme CancelButtonTheme { get; }
        public IViewTheme ViewTheme { get; }

        public EditProfileStylesHolderDroid(ThemeParser<T> themeParser)
        {
            LabelsTheme = themeParser.GetThemeByName<ITextViewTheme>(_labelsTheme);
            EditTextsTheme = themeParser.GetThemeByName<IEditTextTheme>(_editTextsTheme);
            EditTextsFailTheme = themeParser.GetThemeByName<IEditTextTheme>(_editTextsFailTheme);
            ViewTheme = themeParser.GetThemeByName<IViewTheme>(_viewTheme);
            SaveButtonTheme = themeParser.GetThemeByName<IButtonTheme>(_saveButtonTheme);
            CancelButtonTheme = themeParser.GetThemeByName<IButtonTheme>(_cancelButtonTheme);
        }
    }
}