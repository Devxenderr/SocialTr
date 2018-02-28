using System;

using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;

using Newtonsoft.Json;

using SocialTrading.Theme.Enumerators;
using SocialTrading.ThemesStyles.Implementation;

namespace SocialTrading.Droid.Theme
{
    public class GlobalControlsTheme : AGlobalControlsTheme
    {
        [JsonConstructor]
        public GlobalControlsTheme(object background, object tintColor, float borderWidth, object borderColor, float cornerRadius, object borderSide, object textColor, float textSize, object textStyle, object textFont, object textAlignment, object imageLeft, object imageRight, object imageBackground, object hintTextColor, object image, object backgroundTint)
            : base(background, tintColor, borderWidth, borderColor, cornerRadius, borderSide, textColor, textSize, textStyle, textFont, textAlignment, imageLeft, imageRight, imageBackground, hintTextColor, image, backgroundTint)
        {
        }

        public override void GetNativeComponents()
        {
            var context = Application.Context;
            if (BackgroundColor != null)
            {
                var s = BackgroundColor as string;
                if (s != null && s.Contains("#"))
                {
                    BackgroundColor = GetColor(s);
                }
                else
                {
                    BackgroundColor = GetDrawable(s);
                }
            }

            if (TintColor != null)
            {
                TintColor = GetColor((string)TintColor);
            }

            if (BorderColor != null)
            {
                BorderColor = GetColor((string)BorderColor);
            }

            //public object BorderSide { get; set; }       // TODO

            if (TextColor != null)
            {
                TextColor = GetColor((string)TextColor);
            }
            
            if (Enum.TryParse((string)TextStyle, true, out EFontStyle textStyle))
            {
                TextStyle = textStyle;
            }
            if (TextFont != null)
            {
                TextFont = Typeface.CreateFromAsset(context.Assets, (string)TextFont);
            }

            //public object TextAlignment { get; set; }    // TODO

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

        private Drawable GetDrawable(string resourceName)
        {
            var context = Application.Context;
            var id = context.Resources.GetIdentifier(resourceName, "drawable",
                context.PackageName);
            if (id == 0)
            {
                try
                {
                    id = (int)typeof(Resource.Drawable).GetField(resourceName).GetValue(null);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return ContextCompat.GetDrawable(context, id);
        }

        private Color GetColor(string resourceName)
        {
            return Color.ParseColor(resourceName);
        }
    }
}