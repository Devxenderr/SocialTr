using SocialTrading.ThemesStyles;
using SocialTrading.ThemesStyles.Implementation;
using SocialTrading.Vipers.UpdatePost.Interfaces;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.Vipers.CreatePost.Implementation;

namespace SocialTrading.Vipers.UpdatePost.Implementation
{
    public class UpdatePostStylesHolderDroid<T> :  CreatePostStylesHolderDroid<T>, IUpdatePostStylesHolder where T : AGlobalControlsTheme
    {
        private string _toolsDisableTheme = "UpdatePostToolsDisableStyle";
        private string _textFieldsDisableTheme = "UpdatePostTextFieldsDisableStyle";
        
        public IButtonTheme ToolsDisableTheme { get; }
        public IButtonTheme TextFieldsDisableTheme { get; }

        public UpdatePostStylesHolderDroid(ThemeParser<T> themeParser) : base (themeParser)
        {
            ToolsDisableTheme = themeParser.GetThemeByName<IButtonTheme>(_toolsDisableTheme);
            TextFieldsDisableTheme = themeParser.GetThemeByName<IButtonTheme>(_textFieldsDisableTheme);
        }
    }
}
