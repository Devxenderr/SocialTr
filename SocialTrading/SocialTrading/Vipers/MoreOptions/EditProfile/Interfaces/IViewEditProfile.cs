using System;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.Vipers.MoreOptions.EditProfile.Models;

namespace SocialTrading.Vipers.MoreOptions.EditProfile.Interfaces
{
    public interface IViewEditProfile
    {
        void SetLabelsTheme(ITextViewTheme theme);
        void SetNameEditTextTheme(IEditTextTheme theme);
        void SetLastnameEditTextTheme(IEditTextTheme theme);
        void SetStatusEditTextTheme(IEditTextTheme theme);
        void SetSaveButtonTheme(IButtonTheme theme);
        void SetCancelButtonTheme(IButtonTheme theme);

        void SetName(string text);
        void SetNameLabel(string localeString);
        void SetLastname(string text);
        void SetLastnameLabel(string localeString);
        void SetStatus(string text);
        void SetStatusLabel(string localeString);
        void SetSaveButtonTitle(string title);
        void SetCancelButtonTitle(string title);
        void ShowAlert(string message, string btnOkTitle, EEditProfileAlertType alertType);
        void ShowSpinner();
        void HideSpinner();

        event Action<string, string, string> SaveButtonClick;
        event Action<string> NameWasChanged;
        event Action<string> LastNameWasChanged;
        event Action<string> StatusWasChanged;
        event Action CancelButtonClick;
        event Action<EEditProfileAlertType> AlertButtonClick;
    }
}