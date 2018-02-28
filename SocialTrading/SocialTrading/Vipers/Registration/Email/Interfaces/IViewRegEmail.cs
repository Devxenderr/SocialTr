using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.Tools.Interfaces;

namespace SocialTrading.Vipers.Registration.Email.Interfaces
{
    public interface IViewRegEmail : ISetConfig
    {
        IPresenterRegEmail Presenter { set; }
        
		void SetEmail(string email);
		string GetEmail();
        
        void ShowConnectedEmails();

        void SetHeaderLabelTheme(ITextViewTheme themeName);
        void SetEmailLabelTheme(ITextViewTheme themeName);
        void SetNextButtonTheme(IButtonTheme themeName);
        void SetBackButtonTheme(IImageButtonTheme themeName);
        void SetViewTheme(IImageViewTheme backgroundImage);
        void SetLogoImageViewTheme(IImageViewTheme backgroundImage);
        void SetEmailEditTextTheme(IEditTextTheme themeName);
		void SetFeatureImageTheme(IImageViewTheme themeName);
		void SetFeatureTextTheme(ITextViewTheme themeName);

        void SetEmailLocale(string regEmailTextView);
        void SetNextButtonLocale(string buttonNext);
        void SetTitleLocale(string regEmailTextView);
        void SetFeatureTextLocale(string featureText);

    }
}
