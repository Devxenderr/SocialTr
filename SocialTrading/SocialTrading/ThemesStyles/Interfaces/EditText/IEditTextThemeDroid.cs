using SocialTrading.Interfaces.EditText;

namespace SocialTrading.ThemesStyles.Interfaces.EditText
{
    public interface IEditTextThemeDroid : IEditTextThemeCommon
    {
        object HintTextColor { get; set; }
        object BackgroundTint { get; set; }
    }
}
