using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.View;

namespace SocialTrading.Vipers.CreatePost.Interfaces
{
    public interface ICreatePostStylesHolder
    {
        IViewTheme DividingLineTheme                { get; }
        ITextViewTheme NameTheme                    { get; }
        ITextViewTheme TitleTheme                   { get; }
        IImageViewTheme AvatarTheme                 { get; }
        IImageButtonTheme BackButtonTheme           { get; }
        IImageButtonTheme AttachImageButtonTheme    { get; }
        IImageButtonTheme CancelAttachButtonTheme   { get; }
        IButtonTheme PublishTextViewTheme           { get; }
        IViewTheme ToolBarViewTheme                 { get; }
        IButtonTheme ToolsStateNoneTheme            { get; }
        IButtonTheme ToolsStateFailTheme            { get; }
        IButtonTheme PriceTextViewTheme             { get; }
        IButtonTheme BuySellStateNoneTheme          { get; }
        IButtonTheme BuySellStateFailTheme          { get; }
        IButtonTheme AccessModeStateNoneTheme       { get; }
        IButtonTheme AccessModeStateFailTheme       { get; }
        IButtonTheme ForecastTimeStateNoneTheme     { get; }
        IButtonTheme ForecastTimeStateFailTheme     { get; }
        IEditTextTheme CommentStateNoneTheme        { get; }
        IEditTextTheme CommentStateFailTheme        { get; }
    }
}
