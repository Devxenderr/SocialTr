using Newtonsoft.Json;

using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;

namespace SocialTrading.ThemesStyles.Implementation
{
    public abstract class AGlobalControlsTheme : IViewTheme, ITextViewTheme, IEditTextTheme, IImageViewTheme, IImageButtonTheme, IButtonTheme
    {
        public object BackgroundColor { get; set; }
        public object TintColor { get; set; }

        public float BorderWidth { get; set; }
        public object BorderColor { get; set; }
        public float CornerRadius { get; set; }
        public object BorderSide { get; set; }
        public object TextColor { get; set; }
        public float TextSize { get; set; }
        public object TextStyle { get; set; }
        public object TextFont { get; set; }
        public object TextAlignment { get; set; }
        public object ImageLeft { get; set; }
        public object ImageRight { get; set; }
        public object ImageBackground { get; set; }

        public object HintTextColor { get; set; }
        public object BackgroundTint { get; set; }
        public object Image { get; set; }

        [JsonConstructor]
        public AGlobalControlsTheme(object background, object tintColor, float borderWidth, object borderColor, float cornerRadius, object borderSide, object textColor, float textSize, object textStyle, object textFont, object textAlignment, object imageLeft, object imageRight, object imageBackground, object hintTextColor, object image, object backgroundTint)
        {
            BackgroundColor = background;
            TintColor = tintColor;
            BorderWidth = borderWidth;
            BorderColor = borderColor;
            CornerRadius = cornerRadius;
            BorderSide = borderSide;
            TextColor = textColor;
            TextSize = textSize;
            TextStyle = textStyle;
            TextFont = textFont;
            TextAlignment = textAlignment;
            ImageLeft = imageLeft;
            ImageRight = imageRight;
            ImageBackground = imageBackground;
            HintTextColor = hintTextColor;
            Image = image;
            BackgroundTint = backgroundTint;
        }

        public abstract void GetNativeComponents();

    }
}