using System;
using System.Globalization;

using Newtonsoft.Json;

using SocialTrading.Theme.Enumerators;
using SocialTrading.ThemesStyles.Implementation;
using UIKit;

namespace SocialTrading.iOS.Theme
{
    public class GlobalControlsTheme : AGlobalControlsTheme
    {

        [JsonConstructor]
        public GlobalControlsTheme(object background, object tintColor, float borderWidth, object borderColor, float cornerRadius, object borderSide, object textColor, float textSize, object textStyle, object textFont, object textAlignment, object imageLeft, object imageRight, object imageBackground, object hintTextColor, object image, object backgroundTint)
            :base(background, tintColor, borderWidth, borderColor, cornerRadius, borderSide, textColor, textSize, textStyle, textFont, textAlignment, imageLeft, imageRight, imageBackground, hintTextColor, image, backgroundTint)
        {
        }

        public override void GetNativeComponents()
        {
            if (BackgroundColor != null)
            {
                BackgroundColor = GetColor((string)BackgroundColor);
            }

            if (TintColor != null)
            {
                TintColor = GetColor((string)TintColor);
            }

            if (BorderColor != null)
            {
                BorderColor = GetColor((string)BorderColor);
            }
            //public object BorderSide { get; set; }

            if (TextColor != null)
            {
                TextColor = GetColor((string)TextColor);
            }

            EFontStyle textStyle;
            if (Enum.TryParse((string)TextStyle, true, out textStyle))
            {
                TextStyle = textStyle;
            }
            if (TextFont != null)
            {
                TextFont = UIFont.FromName((string) TextFont, TextSize);
            }
            //public object TextAlignment { get; set; }

            if (ImageLeft != null)
            {
                ImageLeft = GetDrawable((string)ImageLeft);
            }

            if (ImageRight != null)
            {
                ImageRight = GetDrawable((string)ImageRight);
            }

            if (ImageBackground != null)
            {
                ImageBackground = GetDrawable((string)ImageBackground);
            }

            if (HintTextColor != null)
            {
                HintTextColor = GetColor((string)HintTextColor);
            }

            if (Image != null)
            {
                Image = GetDrawable((string)Image);
            }

            if (BackgroundTint != null)
            {
                BackgroundTint = GetColor((string) BackgroundTint);
            }
        }

        private UIImage GetDrawable(string resourceName)
        {
            return UIImage.FromBundle(resourceName);
        }

        private UIColor GetColor(string resourceName)
        {
            if (resourceName.Contains("#"))
            {
                var colorString = resourceName.Replace("#", String.Empty);
                var rgb = int.Parse(colorString, NumberStyles.HexNumber);
                float r, g, b, a = 1;

                if (resourceName.Length == 7)
                {
                    r = (float) (((rgb & 0xFF0000) >> 16) / 255.0);
                    g = (float) (((rgb & 0x00FF00) >> 8) / 255.0);
                    b = (float) ((rgb & 0x0000FF) / 255.0);
                }
                else if (resourceName.Length == 9)
                {
                    a = (float) (((rgb & 0xFF000000) >> 24) / 255.0);
                    r = (float) (((rgb & 0x00FF0000) >> 16) / 255.0);
                    g = (float) (((rgb & 0x0000FF00) >> 8) / 255.0);
                    b = (float) ((rgb & 0x000000FF) / 255.0);
                }
                else
                {
                    return new UIColor(0, 0, 0, 1);
                }
                return new UIColor(r, g, b, a);
            }
            else
            {
                return UIColor.FromPatternImage(GetDrawable(resourceName));
            }
        }
    }
}