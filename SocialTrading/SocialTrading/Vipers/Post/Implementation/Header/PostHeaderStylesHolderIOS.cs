using SocialTrading.ThemesStyles;
using SocialTrading.ThemesStyles.Implementation;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.Vipers.Post.Interfaces.Header;

namespace SocialTrading.Vipers.Post.Implementation.Header
{
    public class PostHeaderStylesHolderIOS<T> : IPostHeaderStylesHolder where T : AGlobalControlsTheme
    {
        private string _moreOptionsButtonTheme = "PostHeaderOptionsButtonStyle";
        private string _firstLastNameTheme     = "PostHeaderFirstLastNameStyle";
        private string _dateTheme              = "PostHeaderDateStyle";
        private string _quoteTheme             = "PostHeaderQuoteStyle";
        private string _buySellTheme           = "PostHeaderBuySellStyle";
        private string _buySellValueTheme      = "PostHeaderBuySellValueStyle";
        private string _forecastTheme          = "PostHeaderForecastStyle";
        private string _currentPriceTheme      = "PostHeaderCurrentPriceStyle";
        private string _diffTheme              = "PostHeaderDiffStyle";
        private string _diffValueTheme         = "PostHeaderDiffValueStyle";
        private string _defaultAvatar          = "PostHeaderDefaultAvatarStyle";
        private string _favoriteStateActive    = "PostHeaderFavoriteStateActiveStyle";
        private string _favoriteStateNone      = "PostHeaderFavoriteStateNoneStyle";
        private string _recommendSellImage     = "PostHeaderRecommendSellImageStyle";
        private string _recommendBuyImage      = "PostHeaderRecommendBuyImageStyle";
        private string _differenceValuePositive = "PostHeaderDifferenceValuePositiveStyle";
        private string _differenceValueNegative = "PostHeaderDifferenceValueNegativeStyle";
        private string _currentPriceImgUp       = "PostHeaderCurrentPriceImgUpStyleIOS";
        private string _currentPriceImgDown     = "PostHeaderCurrentPriceImgDownStyleIOS";
        private string _stateOnline             = "PostHeaderStateOnlineImageStyle";
        private string _stateOffline            = "PostHeaderStateOfflineImageStyle";

        public IImageButtonTheme MoreOptionsButtonTheme { get; }
        public ITextViewTheme FirstLastNameTheme { get; }
        public ITextViewTheme DateTheme { get; }
        public ITextViewTheme QuoteTheme { get; }
        public ITextViewTheme BuySellTheme { get; }
        public ITextViewTheme BuySellValueTheme { get; }
        public ITextViewTheme ForecastTheme { get; }
        public ITextViewTheme CurrentPriceTheme { get; }
        public ITextViewTheme DiffTheme { get; }
        public ITextViewTheme DiffValueTheme { get; }
        public IImageViewTheme DefaultAvatar { get; }
        public IImageButtonTheme FavoriteStateActive { get; }
        public IImageButtonTheme FavoriteStateNone { get; }
        public IImageViewTheme RecommendSellImage { get; }
        public IImageViewTheme RecommendBuyImage { get; }
        public ITextViewTheme DifferenceValuePositive { get; }
        public ITextViewTheme DifferenceValueNegative { get; }
        public IImageViewTheme CurrentPriceImgUp { get; }
        public IImageViewTheme CurrentPriceImgDown { get; }
        public IImageButtonTheme StateOnline { get; }
        public IImageButtonTheme StateOffline { get; }

        public PostHeaderStylesHolderIOS(ThemeParser<T> themeParser)
        {
            MoreOptionsButtonTheme = themeParser.GetThemeByName<IImageButtonTheme>(_moreOptionsButtonTheme);
            FirstLastNameTheme     = themeParser.GetThemeByName<ITextViewTheme>(_firstLastNameTheme);
            DateTheme              = themeParser.GetThemeByName<ITextViewTheme>(_dateTheme);
            QuoteTheme             = themeParser.GetThemeByName<ITextViewTheme>(_quoteTheme);
            BuySellTheme           = themeParser.GetThemeByName<ITextViewTheme>(_buySellTheme);
            BuySellValueTheme      = themeParser.GetThemeByName<ITextViewTheme>(_buySellValueTheme);
            ForecastTheme          = themeParser.GetThemeByName<ITextViewTheme>(_forecastTheme);
            CurrentPriceTheme      = themeParser.GetThemeByName<ITextViewTheme>(_currentPriceTheme);
            DiffTheme              = themeParser.GetThemeByName<ITextViewTheme>(_diffTheme);
            DiffValueTheme         = themeParser.GetThemeByName<ITextViewTheme>(_diffValueTheme);
            DefaultAvatar          = themeParser.GetThemeByName<IImageViewTheme>(_defaultAvatar);
            FavoriteStateActive    = themeParser.GetThemeByName<IImageButtonTheme>(_favoriteStateActive);
            FavoriteStateNone      = themeParser.GetThemeByName<IImageButtonTheme>(_favoriteStateNone);
            RecommendSellImage     = themeParser.GetThemeByName<IImageViewTheme>(_recommendSellImage);
            RecommendBuyImage      = themeParser.GetThemeByName<IImageViewTheme>(_recommendBuyImage);
            DifferenceValuePositive = themeParser.GetThemeByName<ITextViewTheme>(_differenceValuePositive);
            DifferenceValueNegative = themeParser.GetThemeByName<ITextViewTheme>(_differenceValueNegative);
            CurrentPriceImgUp       = themeParser.GetThemeByName<IImageViewTheme>(_currentPriceImgUp);
            CurrentPriceImgDown     = themeParser.GetThemeByName<IImageViewTheme>(_currentPriceImgDown);
            StateOnline             = themeParser.GetThemeByName<IImageButtonTheme>(_stateOnline);
            StateOffline            = themeParser.GetThemeByName<IImageButtonTheme>(_stateOffline);
        }
    }
}