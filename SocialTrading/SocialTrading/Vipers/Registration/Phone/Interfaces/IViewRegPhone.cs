using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.Tools.Interfaces;

namespace SocialTrading.Vipers.Registration.Phone.Interfaces
{
    public interface IViewRegPhone : ISetConfig
    {
        IPresenterRegPhone Presenter { set; }

        void SetPhoneCountry(string phoneCountry);
        string GetPhoneCountry();

        void SetPhoneNumber(string phoneNumber);
        string GetPhoneNumber();

        void SetHeaderLabelTheme(ITextViewTheme themeName);
        void SetPhoneCountryLabelTheme(ITextViewTheme themeName);
        void SetPhoneNumberLabelTheme(ITextViewTheme themeName);
        void SetNextButtonTheme(IButtonTheme themeName);
        void SetSkipButtonTheme(IButtonTheme themeName);
        void SetBackButtonTheme(IImageButtonTheme themeName);
        void SetViewTheme(IImageViewTheme themeName);
        void SetLogoImageViewTheme(IImageViewTheme themeName);
        void SetPhoneCountryEditTextTheme(IEditTextTheme themeName);
        void SetPhoneNumberEditTextTheme(IEditTextTheme themeName);
		void SetFeatureTextTheme(ITextViewTheme themeName);
		void SetFeatureImageTheme(IImageViewTheme image);

        void SetPhoneCountryLocale(string regPhoneCountryHint);
        void SetPhoneNumberLocale(string regPhoneNumberHint);
        void SetNextButtonLocale(string buttonNext);
        void SetSkipButtonLocale(string regPhoneNumberButtonSkip);
        void SetTitleLocale(string regPhoneNumberHeader);
		void SetFeatureTextLocale(string featureText);

	}
}
