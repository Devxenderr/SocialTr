using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.TextView;

namespace SocialTrading.Vipers.Registration.Name.Interfaces
{
    public interface IRegNameStylesHolder
    {
            ITextViewTheme HeaderLabelTheme         { get; }
            ITextViewTheme NameLabelTheme           { get; }
            ITextViewTheme LastNameLabelTheme       { get; }
            IButtonTheme NextButtonTheme            { get; }
            IImageButtonTheme BackButtonTheme       { get; }
            IImageViewTheme ViewTheme               { get; }
            IImageViewTheme LogoImageViewTheme      { get; }
            IEditTextTheme NameEditTextTheme        { get; }
            IEditTextTheme NameStateSuccess         { get; }
            IEditTextTheme NameStateFail            { get; }
            IEditTextTheme LastNameEditTextTheme    { get; }
            IEditTextTheme LastNameStateSuccess     { get; }
            IEditTextTheme LastNameStateFail        { get; }
            ITextViewTheme FeatureTextTheme         { get; }
            IImageViewTheme FeatureImageTheme       { get; }
    }
}