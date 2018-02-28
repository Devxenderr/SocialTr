using SocialTrading.ThemesStyles;
using SocialTrading.ThemesStyles.Implementation;
using SocialTrading.Vipers.CreatePost.Interfaces;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;

namespace SocialTrading.Vipers.CreatePost.Implementation
{
    public class CreatePostStylesHolderIOS<T> : ICreatePostStylesHolder where T : AGlobalControlsTheme
    {
        private string _dividingLineTheme = "CreatePostDividingLineStyle";
        private string _nameTheme = "CreatePostNameStyle";
        private string _titleTheme = "CreatePostTitleStyle";
        private string _avatarTheme = "CreatePostAvatarStyle";
        private string _backButtonTheme = "CreatePostBackButtonStyleIOS";
        private string _attachImageButtonTheme = "CreatePostAttachImageButtonStyle";
        private string _cancelAttachButtonTheme = "CreatePostCancelAttachButtonStyle";
        private string _publishTextViewTheme = "CreatePostPublishButtonStyle";
        private string _toolBarViewTheme = "CreatePostToolbarStyle";
        private string _toolsStateNoneTheme = "CreatePostToolsNoneStyle";
        private string _toolsStateFailTheme = "CreatePostToolsFailStyle";
        private string _priceTextViewTheme = "CreatePostPriceStyle";
        private string _buySellStateNoneTheme = "CreatePostSelectorsNoneStyle";
        private string _buySellStateFailTheme = "CreatePostSelectorsFailStyle";
        private string _accessModeStateNoneTheme = "CreatePostSelectorsNoneStyle";
        private string _accessModeStateFailTheme = "CreatePostSelectorsFailStyle";
        private string _forecastTimeStateNoneTheme = "CreatePostSelectorsNoneStyle";
        private string _forecastTimeStateFailTheme = "CreatePostSelectorsFailStyle";
        private string _commentStateNoneTheme = "CreatePostCommentNoneStyle";
        private string _commentStateFailTheme = "CreatePostCommentFailStyle";

        public IViewTheme DividingLineTheme { get; }
        public ITextViewTheme NameTheme { get; }
        public ITextViewTheme TitleTheme { get; }
        public IImageViewTheme AvatarTheme { get; }
        public IImageButtonTheme BackButtonTheme { get; }
        public IImageButtonTheme AttachImageButtonTheme { get; }
        public IImageButtonTheme CancelAttachButtonTheme { get; }
        public IButtonTheme PublishTextViewTheme { get; }
        public IViewTheme ToolBarViewTheme { get; }
        public IButtonTheme ToolsStateNoneTheme { get; }
        public IButtonTheme ToolsStateFailTheme { get; }
        public IButtonTheme PriceTextViewTheme { get; }
        public IButtonTheme BuySellStateNoneTheme { get; }
        public IButtonTheme BuySellStateFailTheme { get; }
        public IButtonTheme AccessModeStateNoneTheme { get; }
        public IButtonTheme AccessModeStateFailTheme { get; }
        public IButtonTheme ForecastTimeStateNoneTheme { get; }
        public IButtonTheme ForecastTimeStateFailTheme { get; }
        public IEditTextTheme CommentStateNoneTheme { get; }
        public IEditTextTheme CommentStateFailTheme { get; }

        public CreatePostStylesHolderIOS(ThemeParser<T> themeParser)
        {
            DividingLineTheme = themeParser.GetThemeByName<IViewTheme>(_dividingLineTheme);
            NameTheme = themeParser.GetThemeByName<ITextViewTheme>(_nameTheme);
            TitleTheme = themeParser.GetThemeByName<ITextViewTheme>(_titleTheme);
            AvatarTheme = themeParser.GetThemeByName<IImageViewTheme>(_avatarTheme);
            BackButtonTheme = themeParser.GetThemeByName<IImageButtonTheme>(_backButtonTheme);
            AttachImageButtonTheme = themeParser.GetThemeByName<IImageButtonTheme>(_attachImageButtonTheme);
            CancelAttachButtonTheme = themeParser.GetThemeByName<IImageButtonTheme>(_cancelAttachButtonTheme);
            PublishTextViewTheme = themeParser.GetThemeByName<IButtonTheme>(_publishTextViewTheme);
            ToolBarViewTheme = themeParser.GetThemeByName<IViewTheme>(_toolBarViewTheme);
            ToolsStateNoneTheme = themeParser.GetThemeByName<IButtonTheme>(_toolsStateNoneTheme);
            ToolsStateFailTheme = themeParser.GetThemeByName<IButtonTheme>(_toolsStateFailTheme);
            PriceTextViewTheme = themeParser.GetThemeByName<IButtonTheme>(_priceTextViewTheme);
            BuySellStateNoneTheme = themeParser.GetThemeByName<IButtonTheme>(_buySellStateNoneTheme);
            BuySellStateFailTheme = themeParser.GetThemeByName<IButtonTheme>(_buySellStateFailTheme);
            AccessModeStateNoneTheme = themeParser.GetThemeByName<IButtonTheme>(_accessModeStateNoneTheme);
            AccessModeStateFailTheme = themeParser.GetThemeByName<IButtonTheme>(_accessModeStateFailTheme);
            ForecastTimeStateNoneTheme = themeParser.GetThemeByName<IButtonTheme>(_forecastTimeStateNoneTheme);
            ForecastTimeStateFailTheme = themeParser.GetThemeByName<IButtonTheme>(_forecastTimeStateFailTheme);
            CommentStateNoneTheme = themeParser.GetThemeByName<IEditTextTheme>(_commentStateNoneTheme);
            CommentStateFailTheme = themeParser.GetThemeByName<IEditTextTheme>(_commentStateFailTheme);
        }
    }
}
