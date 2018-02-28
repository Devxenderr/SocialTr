using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.EditText;

namespace SocialTrading.Vipers.EditContact.Interfaces
{
    public interface IEditContactStyleHolder
    {
        IViewTheme BackgroundTheme              { get; }
        IEditTextTheme EditTextNoneTheme        { get; }
        IEditTextTheme UnEditableTextNoneTheme  { get; }
        IEditTextTheme EditTextFailTheme        { get; }
        ITextViewTheme TextViewTheme            { get; }
        IButtonTheme SaveButtonTheme            { get; }
        IButtonTheme CancelButtonTheme          { get; }
    }
}
