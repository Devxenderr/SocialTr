using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.Vipers.CreatePost.Interfaces;

namespace SocialTrading.Vipers.UpdatePost.Interfaces
{
    public interface IUpdatePostStylesHolder : ICreatePostStylesHolder
    {
        IButtonTheme ToolsDisableTheme { get; }
        IButtonTheme TextFieldsDisableTheme { get; }
    }
}
