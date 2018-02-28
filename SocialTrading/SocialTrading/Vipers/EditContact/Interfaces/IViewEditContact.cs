using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.View;

namespace SocialTrading.Vipers.EditContact.Interfaces
{
    public interface IViewEditContact
    {
        IPresenterForViewEditContact Presenter { set; }

        void SetEmail(string text);
        void SetSkype(string text);
        void SetPhone(string text);
        void SetCountry(string text);
        void SetCity(string text);

        void ShowSuccessAlert(string message, string buttonTitle);
        void ShowFailAlert(string message, string buttonTitle);

        void SetEmailLabelLocale(string text);
        void SetSkypeLabelLocale(string text);
        void SetPhoneLabelLocale(string text);
        void SetCountryLabelLocale(string text);
        void SetCityLabelLocale(string text);
        void SetSaveButtonLocale(string text);
        void SetCancelButtonLocale(string text);

        void SetSaveButtonTheme(IButtonTheme theme);
        void SetCancelButtonTheme(IButtonTheme theme);
        void SetEmailTextViewTheme(ITextViewTheme theme);
        void SetSkypeTextViewTheme(ITextViewTheme theme);
        void SetPhoneTextViewTheme(ITextViewTheme theme);
        void SetCountryTextViewTheme(ITextViewTheme theme);
        void SetCityTextViewTheme(ITextViewTheme theme);
        void SetEmailEditTextTheme(IEditTextTheme theme);
        void SetSkypeEditTextTheme(IEditTextTheme theme);
        void SetPhoneEditTextTheme(IEditTextTheme theme);
        void SetCountryEditTextTheme(IEditTextTheme theme);
        void SetCityEditTextTheme(IEditTextTheme theme);
        void SetViewTheme(IViewTheme theme);

        void ShowSpinner();
        void HideSpinner();
    }
}
