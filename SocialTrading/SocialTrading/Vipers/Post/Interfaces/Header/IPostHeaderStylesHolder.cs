using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;

namespace SocialTrading.Vipers.Post.Interfaces.Header
{
    public interface IPostHeaderStylesHolder
    {
        IImageButtonTheme MoreOptionsButtonTheme { get; }
        ITextViewTheme FirstLastNameTheme { get; }
        ITextViewTheme DateTheme { get; }
        ITextViewTheme QuoteTheme { get; }
        ITextViewTheme BuySellTheme { get; }
        ITextViewTheme BuySellValueTheme { get; }
        ITextViewTheme ForecastTheme { get; }
        ITextViewTheme CurrentPriceTheme { get; }
        ITextViewTheme DiffTheme { get; }
        ITextViewTheme DiffValueTheme { get; }
        IImageViewTheme DefaultAvatar { get; }
        IImageButtonTheme FavoriteStateActive { get; }
        IImageButtonTheme FavoriteStateNone { get; }
        IImageViewTheme RecommendSellImage { get; }
        IImageViewTheme RecommendBuyImage { get; }
        ITextViewTheme DifferenceValuePositive { get; }
        ITextViewTheme DifferenceValueNegative { get; }
        IImageViewTheme CurrentPriceImgUp { get; }
        IImageViewTheme CurrentPriceImgDown { get; }
        IImageButtonTheme StateOnline { get; }
        IImageButtonTheme StateOffline { get; }
    }
}