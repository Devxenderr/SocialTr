using Android.Content.Res;
using Android.Text;
using Android.Util;

using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Text.Style;
using Android.Graphics.Drawables;

using SocialTrading.ThemesStyles;
using SocialTrading.Theme.Enumerators;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;

namespace SocialTrading.Droid.Theme
{
    public static class ThemesHelperNew
    {
        //====== TODO REMOVE
        public static ThemeParser<GlobalControlsTheme> ThemeParser { private get; set; }

        public static void SetTheme(this View view, string themeName)
        {
            var theme = ThemeParser.GetThemeByName<IViewTheme>(themeName);

            if (theme.BackgroundColor != null)
            {
                if (theme.BackgroundColor is Color backgroundColor)
                {
                    view.SetBackgroundColor(backgroundColor);
                }
            }
        }

        public static void SetTheme(this TextView textView, string themeName)
        {
            SetTheme((View)textView, themeName);

            var theme = ThemeParser.GetThemeByName<ITextViewTheme>(themeName);

            if (theme.TextColor != null)
            {
                textView.SetTextColor((Color)theme.TextColor);
            }

            if (theme.TextSize > 0)
            {
                textView.SetTextSize(ComplexUnitType.Sp, theme.TextSize);
            }

            GradientDrawable gradientDrawable = new GradientDrawable();
            gradientDrawable.SetColor((Color)theme.BackgroundColor);

            if (theme.CornerRadius > 0)
            {
                
                gradientDrawable.SetCornerRadius(theme.CornerRadius);
                textView.Background = gradientDrawable;
            }

            if (theme.BorderWidth > 0)
            {
                gradientDrawable.SetStroke((int)theme.BorderWidth, (Color)theme.BorderColor);
            }

            textView.Background = gradientDrawable;

            if (theme.ImageRight != null)
            {
                textView.SetCompoundDrawablesWithIntrinsicBounds(null, null, (Drawable)theme.ImageRight, null);
            }

            if (theme.ImageLeft != null)
            {
                textView.SetCompoundDrawablesWithIntrinsicBounds((Drawable)theme.ImageLeft, null, null, null);
            }

            if (theme.TextStyle != null)
            {
                switch (theme.TextStyle)
                {
                    case EFontStyle.Bold:
                        textView.SetTypeface(Typeface.Default, TypefaceStyle.Bold);
                        break;
                    case EFontStyle.Italic:
                        textView.SetTypeface(Typeface.Default, TypefaceStyle.Italic);
                        break;
                    case EFontStyle.Underline:
                        textView.PaintFlags = PaintFlags.UnderlineText;
                        break;

                    case EFontStyle.Normal:
                    default:
                        textView.SetTypeface(Typeface.Default, TypefaceStyle.Normal);
                        break;
                }
            }
        }

        public static void SetTheme(this TextView textView, string mainThemeName, string mainText, string attrThemeName, string attrText, int position)
        {
            SetTheme(textView, mainThemeName);

            var mainTheme = ThemeParser.GetThemeByName<ITextViewTheme>(mainThemeName);
            var attrTheme = ThemeParser.GetThemeByName<ITextViewTheme>(attrThemeName);

            SpannableStringBuilder span = new SpannableStringBuilder(mainText.Insert(position, attrText));
            if (mainTheme.TextColor != null)
            {
                span.SetSpan(new ForegroundColorSpan((Color)mainTheme.TextColor), 0, position - 1, 0);
                span.SetSpan(new ForegroundColorSpan((Color)mainTheme.TextColor), position + attrText.Length - 1, span.Length() - 1, 0);
            }

            if (attrTheme.TextColor != null)
            {
                span.SetSpan(new ForegroundColorSpan((Color)attrTheme.TextColor), position, position + attrText.Length - 1, 0);
            }
            if (attrTheme.TextStyle != null)
            {
                switch (attrTheme.TextStyle)
                {
                    case EFontStyle.Bold:
                        span.SetSpan(new StyleSpan(TypefaceStyle.Bold), position, position + attrText.Length - 1, 0);
                        break;
                    case EFontStyle.Italic:
                        span.SetSpan(new StyleSpan(TypefaceStyle.Italic), position, position + attrText.Length - 1, 0);
                        break;
                    case EFontStyle.Underline:
                        span.SetSpan(new UnderlineSpan(), position, position + attrText.Length - 1, 0);
                        break;
                    case EFontStyle.Normal:
                    default:
                        textView.SetTypeface(Typeface.Default, TypefaceStyle.Normal);
                        break;
                }
            }

            span.SetSpan(new UnderlineSpan(), position, position + attrText.Length - 1, 0);
            textView.TextFormatted = span;
            textView.SetHighlightColor(Color.Transparent);
        }

        public static void SetTheme(this Button button, string themeName)
        {
            SetTheme((TextView)button, themeName);

            var theme = ThemeParser.GetThemeByName<ITextViewTheme>(themeName);
        }

        public static void SetTheme(this ImageButton imageButton, string themeName)
        {
            SetTheme((ImageView)imageButton, themeName);

            //var theme = ThemeParser.GetThemeByName<IImageButtonTheme>(themeName);
        }

        public static void SetTheme(this EditText editText, string themeName)
        {
            SetTheme((TextView)editText, themeName);

            var theme = ThemeParser.GetThemeByName<IEditTextTheme>(themeName);

            if (theme.HintTextColor != null)
            {
                editText.SetHintTextColor((Color)theme.HintTextColor);
            }
        }

        public static void SetTheme(this ImageView imageView, string themeName)
        {
            SetTheme((View)imageView, themeName);

            var theme = ThemeParser.GetThemeByName<IImageViewTheme>(themeName);

            if (theme.Image != null)
            {
                imageView.SetImageDrawable((Drawable)theme.Image);
            }
        }

        //====== TODO

        public static void SetTheme(this View view, IViewTheme theme)
        {
            if (theme.BackgroundColor == null)
            {
                return;
            }

            if (theme.BackgroundColor is Color backgroundColor)
            {
                view.SetBackgroundColor(backgroundColor);

            }
        }

        public static void SetTheme(this TextView textView, ITextViewTheme theme)
        {
            SetTheme((View)textView, (IViewTheme) theme);

            if (theme.TextColor != null)
            {
                textView.SetTextColor((Color)theme.TextColor);
            }

            if (theme.TextSize > 0)
            {
                textView.SetTextSize(ComplexUnitType.Sp, theme.TextSize);
            }

            if (theme.BackgroundColor != null || theme.CornerRadius > 0 || theme.BorderWidth > 0)
            {
                GradientDrawable gradientDrawable = new GradientDrawable();

                if (theme.BackgroundColor != null)
                {
                    gradientDrawable.SetColor((Color) theme.BackgroundColor);
                }

                if (theme.CornerRadius > 0)
                {
                    gradientDrawable.SetCornerRadius(theme.CornerRadius);
                }

                if (theme.BorderWidth > 0)
                {
                    gradientDrawable.SetStroke((int) theme.BorderWidth, (Color) theme.BorderColor);
                }

                textView.Background = gradientDrawable;
            }

            if (theme.ImageRight != null)
            {
                textView.SetCompoundDrawablesWithIntrinsicBounds(null, null, (Drawable) theme.ImageRight, null);
            }

            if (theme.ImageLeft != null)
            {
                textView.SetCompoundDrawablesWithIntrinsicBounds((Drawable)theme.ImageLeft, null, null, null);
            }

            if (theme.TextStyle == null)
            {
                return;
            }

            switch (theme.TextStyle)
            {
                case EFontStyle.Bold:
                    textView.SetTypeface(Typeface.Default, TypefaceStyle.Bold);
                    break;
                case EFontStyle.Italic:
                    textView.SetTypeface(Typeface.Default, TypefaceStyle.Italic);
                    break;
                case EFontStyle.Underline:
                    textView.PaintFlags = PaintFlags.UnderlineText;
                    break;

                case EFontStyle.Normal:
                default:
                    textView.SetTypeface(Typeface.Default, TypefaceStyle.Normal);
                    break;

            }
        }

        public static void SetTheme(this TextView textView, ITextViewTheme mainTheme, string mainText, ITextViewTheme attrTheme, string attrText, int position)
        {
            SetTheme(textView, mainTheme);

            var spanMain = new SpannableStringBuilder(mainText);
            var spanAttr = new SpannableStringBuilder(attrText);

            if (mainTheme.TextColor != null)
            {
                spanMain.SetSpan(new ForegroundColorSpan((Color)mainTheme.TextColor), 0, spanMain.Length(), 0);
            }

            if (attrTheme.TextColor != null)
            {
                spanAttr.SetSpan(new ForegroundColorSpan((Color) attrTheme.TextColor), 0, attrText.Length, 0);
            }

            switch (attrTheme.TextStyle)
            {
                case EFontStyle.Bold:
                    spanAttr.SetSpan(new StyleSpan(TypefaceStyle.Bold), 0, attrText.Length, 0);
                    break;
                case EFontStyle.Italic:
                    spanAttr.SetSpan(new StyleSpan(TypefaceStyle.Italic), 0, attrText.Length, 0);
                    break;
                case EFontStyle.Underline:
                    spanAttr.SetSpan(new UnderlineSpan(), 0, attrText.Length, 0);
                    break;

                case EFontStyle.Normal:
                default:
                    textView.SetTypeface(Typeface.Default, TypefaceStyle.Normal);
                    break;

            }

            var span = spanMain.Insert(position, spanAttr);
            span.SetSpan(new UnderlineSpan(), position, position + attrText.Length, 0);
            textView.TextFormatted = span;
            textView.SetHighlightColor(Color.Transparent);
        }

        public static void SetTheme(this Button button, IButtonTheme theme)
        {
            SetTheme((TextView)button, (ITextViewTheme) theme);
        }

        public static void SetTheme(this ImageButton imageButton, IImageButtonTheme theme)
        {
            SetTheme((ImageView)imageButton, (IImageViewTheme) theme);
        }

        public static void SetTheme(this EditText editText, IEditTextTheme theme)
        {
            SetTheme((TextView)editText, (ITextViewTheme) theme);

            if (theme.HintTextColor != null)
            {
                editText.SetHintTextColor((Color) theme.HintTextColor);
            }

            if (theme.BackgroundTint != null)
            {
                editText.Background.SetColorFilter((Color)theme.BackgroundTint, PorterDuff.Mode.SrcAtop);
            }
        }

        public static void SetTheme(this ImageView imageView, IImageViewTheme theme)
        {
            SetTheme((View)imageView, (IViewTheme) theme);
            
            if (theme.Image != null)
            {
                imageView.SetImageDrawable((Drawable) theme.Image);
            }
        }
    }
}