using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.Tools.Interfaces;

namespace SocialTrading.Vipers.Registration.Name.Interfaces
{
    public interface IViewRegName : ISetConfig
    {
        IPresenterRegName Presenter { set; }

        void SetFirstName(string firstName);
        void SetLastName(string lastName);

        string GetFirstName();
        string GetLastName();

        void SetHeaderLabelTheme(ITextViewTheme themeName);
        void SetNameLabelTheme(ITextViewTheme themeName);
        void SetLastNameLabelTheme(ITextViewTheme themeName);
        void SetNextButtonTheme(IButtonTheme themeName);
        void SetBackButtonTheme(IImageButtonTheme themeName);
        void SetViewTheme(IImageViewTheme themeName);
        void SetLogoImageViewTheme(IImageViewTheme themeName);
        void SetNameEditTextTheme(IEditTextTheme themeName);
        void SetLastNameEditTextTheme(IEditTextTheme themeName);
		void SetFeatureImageTheme(IImageViewTheme themeName);
		void SetFeatureTextTheme(ITextViewTheme themeName);

        void SetNameLocale(string regNameHint);
        void SetLastNameLocale(string regLastNameHint);
        void SetNextButtonLocale(string buttonNext);
        void SetTitleLocale(string regNameTextView);
		void SetFeatureTextLocale(string featureText);
    }
}
