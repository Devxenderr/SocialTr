using System;
using System.Reflection;

using Android.Util;
using Android.Text;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Graphics;
using Android.Text.Style;
using Android.Support.V7.Widget;
using Android.Graphics.Drawables;

using SocialTrading.Theme;
using SocialTrading.Droid.Tools;
using SocialTrading.Theme.Enumerators;

using Toolbar = Android.Support.V7.Widget.Toolbar;
using SearchView = Android.Widget.SearchView;

namespace SocialTrading.Droid.Theme
{
    public static class ThemesHelper
    {
        private static Context _context;
        private static NativeTheme _theme;
        private const int CamelNumbersLength = 2;

        public static void PerformTheme(Context context, ThemeModel model)
        {
            _context = context;
            _theme = new NativeTheme();
            
            foreach (var item in model.Colors)
            {
                _theme.Colors.Add(item.Key, Color.ParseColor(item.Value));
            }

            foreach (var item in model.Images)
            {
                var field = typeof(Resource.Drawable).GetRuntimeField(item.Value);
                var id = Convert.ToInt32(field.GetValue(field));

                _theme.Images.Add(item.Key, id);
            }

            _theme.FontSizes = new System.Collections.Generic.Dictionary<string, int>(model.FontSizes);
            _theme.FontStyles = new System.Collections.Generic.Dictionary<string, EFontStyle>(model.FontStyles);
            _theme.Font = model.Font;
        }


        public static void SetTheme(this EditText editText, string backgroundColor, string textColor, string hintColor, string borderColor, int borderWidth, int cornerRadius, string drawableEnd = null)
        {
            GradientDrawable gradientDrawable = new GradientDrawable();
            gradientDrawable.SetColor(_theme.Colors[backgroundColor]);
            gradientDrawable.SetStroke(borderWidth, _theme.Colors[borderColor]);
            gradientDrawable.SetCornerRadius(cornerRadius);
            editText.Background = gradientDrawable;
            editText.SetTextColor(_theme.Colors[textColor]);
            editText.SetHintTextColor(_theme.Colors[hintColor]);

            if (!string.IsNullOrWhiteSpace(drawableEnd))
            {
                editText.SetCompoundDrawablesWithIntrinsicBounds(0, 0, _theme.Images[drawableEnd], 0);
            }
        }

        public static void SetTheme(this Toolbar toolbar, string backgroundColor, int todo)
        {
            toolbar.SetBackgroundColor(_theme.Colors[backgroundColor]);
        }
        
        public static void SetTheme(this Button button, string backgroundColor = null, string textColor = null, int cornerRadius = 0)
        {
            GradientDrawable gradientDrawable = new GradientDrawable();
            gradientDrawable.SetColor(_theme.Colors[backgroundColor]);
            gradientDrawable.SetCornerRadius(cornerRadius);
            button.Background = gradientDrawable;
            button.SetTextColor(_theme.Colors[textColor]);
        }

        public static void SetUserAgreementTheme(this TextView textView, string color, string titleSize,
            string titleText, string fontStyle, string backgroundColor, string linkColor,
            string linkTitleText, string linkFontStyle)
        {
            textView.SetBackgroundColor(_theme.Colors[backgroundColor]);
            textView.SetTextSize(ComplexUnitType.Sp, _theme.FontSizes[titleSize]);

            SpannableStringBuilder span = new SpannableStringBuilder(titleText + " " + linkTitleText);
            span.SetSpan(new ForegroundColorSpan(_theme.Colors[color]), 0, titleText.Length, 0);
            
            span.SetSpan(new ForegroundColorSpan(_theme.Colors[color]), titleText.Length + 1, span.Length(), 0);
            span.SetSpan(new UnderlineSpan(), titleText.Length + 1, span.Length(), 0);
            span.SetSpan(new StyleSpan(TypefaceStyle.Bold), titleText.Length, span.Length(), 0);
            
            textView.TextFormatted = span;
            textView.SetHighlightColor(Color.Transparent);
        }

        public static void SetTheme(this TextView textView, string backgroundColor = null, string textColor = null,
            string textSize = null, int cornerRadius = 0, string fontStyle = null, string drawableEnd = null)

        {
            GradientDrawable gradientDrawable = new GradientDrawable();
            if (!string.IsNullOrWhiteSpace(backgroundColor))
            {
                gradientDrawable.SetColor(_theme.Colors[backgroundColor]);
            }
            gradientDrawable.SetCornerRadius(cornerRadius);
            
            textView.Background = gradientDrawable;

            if (!string.IsNullOrWhiteSpace(textColor))
            {
                textView.SetTextColor(_theme.Colors[textColor]);
            }
            if (!string.IsNullOrWhiteSpace(textSize))
            {
                textView.SetTextSize(ComplexUnitType.Sp, _theme.FontSizes[textSize]);
            }

            if (!string.IsNullOrWhiteSpace(fontStyle))
            {
                switch (_theme.FontStyles[fontStyle]) {
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

        public static void SetDrawable(this TextView textView, string drawableEnd = null, string drawableStart = null, int padding = 0)
        {
            if (!string.IsNullOrWhiteSpace(drawableEnd))
            {
                textView.SetCompoundDrawablesWithIntrinsicBounds(0, 0, _theme.Images[drawableEnd], 0);
                textView.CompoundDrawablePadding = padding;
            }

            if (!string.IsNullOrWhiteSpace(drawableStart))
            {
                textView.SetCompoundDrawablesWithIntrinsicBounds(_theme.Images[drawableStart], 0, 0, 0);
                textView.CompoundDrawablePadding = padding;
            }
        }

        //public static void SetDrawable(this Button button, string drawableEnd = null, string drawableStart = null, int padding = 0)
        //{
        //    if (!string.IsNullOrWhiteSpace(drawableEnd))
        //    {
        //        button.SetCompoundDrawablesWithIntrinsicBounds(0, 0, _theme.Images[drawableEnd], 0);
        //        button.CompoundDrawablePadding = padding;
        //    }

        //    if (!string.IsNullOrWhiteSpace(drawableStart))
        //    {
        //        button.SetCompoundDrawablesWithIntrinsicBounds(_theme.Images[drawableStart], 0, 0, 0);
        //        button.CompoundDrawablePadding = padding;
        //    }
        //}

        public static void SetPostContentTheme(this TextView textView, string content, string readMore, string backgroundColor, string textColor, string textSize, string fontStyle, 
            string readMoreTextColor, string readMoreFontStyle)
        {
            textView.SetBackgroundColor(_theme.Colors[backgroundColor]);
            textView.SetTextSize(ComplexUnitType.Sp, _theme.FontSizes[textSize]);
            
            int minimizedContentSymbolsCount = content.Length;

            SpannableStringBuilder span = new SpannableStringBuilder(content + " " + readMore);
            span.SetSpan(new ForegroundColorSpan(_theme.Colors[textColor]), 0, minimizedContentSymbolsCount, 0);

            span.SetSpan(new ForegroundColorSpan(_theme.Colors[readMoreTextColor]), minimizedContentSymbolsCount + 1, span.Length(), 0);
            span.SetSpan(new UnderlineSpan(), minimizedContentSymbolsCount + 1, span.Length(), 0);

            switch (_theme.FontStyles[fontStyle])
            {
                case EFontStyle.Bold:
                    span.SetSpan(new StyleSpan(TypefaceStyle.Bold), minimizedContentSymbolsCount, span.Length(), 0);
                    break;
                case EFontStyle.Italic:
                    span.SetSpan(new StyleSpan(TypefaceStyle.Italic), minimizedContentSymbolsCount, span.Length(), 0);
                    break;
                case EFontStyle.Underline:
                    span.SetSpan(new UnderlineSpan(), minimizedContentSymbolsCount + 1, span.Length(), 0);
                    break;

                case EFontStyle.Normal:
                default:
                    span.SetSpan(new StyleSpan(TypefaceStyle.Normal), minimizedContentSymbolsCount, span.Length(), 0);
                    break;
            }

            

            textView.TextFormatted = span;
            textView.SetHighlightColor(Color.Transparent);
        }

        public static void SetTheme(this ImageView imageView, string background, bool isDrawable)
        {
            if (isDrawable)
            {
                imageView.SetBackgroundResource(_theme.Images[background]);
            }
            else
            {
                imageView.SetBackgroundColor(_theme.Colors[background]);
            }
        }

        public static void SetTheme(this ImageView imageView, string drawableId, float imageHeight)
        {
            var bmp = BitmapFactory.DecodeResource(_context.Resources, _theme.Images[drawableId]);
            var aspectRatio = Convert.ToSingle(bmp.Width) / Convert.ToSingle(bmp.Height);
            var height = Convert.ToInt32(imageHeight);
            var width = bmp.Width != bmp.Height ? Convert.ToInt32(height * aspectRatio) : height;

            using (var scaledBmp = Bitmap.CreateScaledBitmap(bmp, width, height, true))
            {
                bmp.Recycle();
                bmp.Dispose();

                imageView.Background = new BitmapDrawable(_context.Resources, scaledBmp);
            }
        }

        public static void SetTheme(this RelativeLayout layout, string background, bool isDrawable)
        {
            if (isDrawable)
            {
                BitmapFactory.Options options = new BitmapFactory.Options()
                {
                    InSampleSize = 8
                };

                var bmp = BitmapFactory.DecodeResource(_context.Resources, _theme.Images[background], options); 
                using (var scaledBmp = Bitmap.CreateScaledBitmap(bmp, _context.Resources.DisplayMetrics.WidthPixels, _context.Resources.DisplayMetrics.HeightPixels - DroidDAL.AuthBackgroundHeightOffset, true))
                {
                    bmp.Recycle();
                    bmp.Dispose();

                    layout.Background = new BitmapDrawable(_context.Resources, scaledBmp);
                }
            }
            else
            {
                layout.SetBackgroundColor(_theme.Colors[background]);
            }
        }
        
        public static void SetTheme(this View view, string backgroundColor, int todo)
        {
            view.SetBackgroundColor(_theme.Colors[backgroundColor]);
        }

        private static EditText GetEditTextFromSearchView(LinearLayout ll)
        {
            for (var i = 0; i < ll?.ChildCount; i++)
            {
                if (ll?.GetChildAt(i) is EditText item)
                {
                    return item;
                }
                else if (ll?.GetChildAt(i) is LinearLayout internalLl)
                {
                    return GetEditTextFromSearchView(internalLl);
                }
            }

            return null;
        }

        public static void SetTheme(this SearchView searchView, string editTextBackground, string textColor = null, string textSize = null, string fontStyle = null)
        {
            searchView.SetBackgroundColor(_theme.Colors[editTextBackground]);
            var editText = GetEditTextFromSearchView(searchView);
            editText.SetTheme(
                backgroundColor: editTextBackground, 
                textColor: textColor, 
                textSize: textSize,
                fontStyle: fontStyle);
        }

        public static void SetTheme(this SwitchCompat view, string thumbColorOff, string trackColorOff, string thumbColorOn, string trackColorOn)
        {
            if (view.Checked)
            {
                view.TrackDrawable.SetColorFilter(_theme.Colors[trackColorOn], PorterDuff.Mode.SrcAtop);
                view.ThumbDrawable.SetColorFilter(_theme.Colors[thumbColorOn], PorterDuff.Mode.SrcAtop);
            }
            else
            {
                view.TrackDrawable.SetColorFilter(_theme.Colors[trackColorOff], PorterDuff.Mode.SrcAtop);
                view.ThumbDrawable.SetColorFilter(_theme.Colors[thumbColorOff], PorterDuff.Mode.SrcAtop);
            }
        }

        public static void SetTheme(this ImageButton button, string image, string tintColor)
        {
            button.SetBackgroundResource(_theme.Images[image]);
        }

        public static void SetThemeDifferentLetterSize(this TextView textView, string text, int position)
        {
            if(text.Equals("0") || string.IsNullOrEmpty(text))
            {
                return;
            }

            var spn = new SpannableString(text);
            spn.SetSpan(new RelativeSizeSpan(1.5f), position, position + CamelNumbersLength, SpanTypes.Priority);
            textView.TextFormatted = spn;
        }


    }
}