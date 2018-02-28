using SocialTrading.ThemesStyles;
using SocialTrading.ThemesStyles.Implementation;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.Vipers.MoreOptions.OptionsCell.Interfaces;

namespace SocialTrading.Vipers.MoreOptions.OptionsCell.Implementation
{
    public class OptionsCellStylesHolderIOS<T> : IOptionsCellStyleHolder where T : AGlobalControlsTheme
    {
        private string _textTheme       = "MoreOptionsOptionItemTextStyle";
        private string _imageViewTheme  = "MoreOptionsOptionItemImageStyle";
        private string _backgroundTheme = "MoreOptionsOptionItemBackgroundStyle";

        public ITextViewTheme TextTheme         { get; }
        public IImageViewTheme ImageViewTheme   { get; }
        public IViewTheme BackgroundTheme       { get; }

        public OptionsCellStylesHolderIOS(ThemeParser<T> themeParser)
        {
            TextTheme = themeParser.GetThemeByName<ITextViewTheme>(_textTheme);
            ImageViewTheme = themeParser.GetThemeByName<IImageViewTheme>(_imageViewTheme);
            BackgroundTheme = themeParser.GetThemeByName<IViewTheme>(_backgroundTheme);
        }
    }
}
