using SocialTrading.ThemesStyles.Interfaces.View;

namespace SocialTrading.ThemesStyles.Interfaces.TextView
{
    public interface ITextViewThemeCommon : IViewThemeCommon
    {
        float BorderWidth { get; set; }
        object BorderColor { get; set; }
        float CornerRadius { get; set; }

        object BorderSide{ get; set; }

        object TextColor { get; set; }
        float TextSize { get; set; }
        object TextStyle { get; set; }
        object TextFont { get; set; }
        object TextAlignment { get; set; }

        object ImageLeft{ get; set; }
        object ImageRight { get; set; }
    }
}
