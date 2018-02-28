using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;

namespace SocialTrading.Vipers.MoreOptions.OptionsCell.Interfaces
{
    public interface IOptionsCellStyleHolder
    {
        ITextViewTheme TextTheme        { get; }
        IImageViewTheme ImageViewTheme  { get; }
        IViewTheme BackgroundTheme      { get; }
    }
}
