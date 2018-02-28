using System;

using UIKit;
using Foundation;

using SocialTrading.ThemesStyles;
using SocialTrading.Theme.Enumerators;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.ThemesStyles.Interfaces.ImageView;

namespace SocialTrading.iOS.Theme
{
    public static class ThemesHelperNew
    {
        // =========== TODO REMOVE
        public static ThemeParser<GlobalControlsTheme> ThemeParser { private get; set; }

        //==================================================================================
        public static void SetTheme(this UIView view, string themeName)
        {
            var theme = ThemeParser.GetThemeByName<IViewTheme>(themeName);

            if (theme.BackgroundColor != null)
            {
                view.BackgroundColor = (UIColor)theme.BackgroundColor;
            }
            if (theme.TintColor != null)
            {
                view.TintColor = (UIColor)theme.TintColor;
            }
        }

        public static void SetTheme(this UILabel label, string themeName)
        {
            SetTheme((UIView)label, themeName);

            var theme = ThemeParser.GetThemeByName<ITextViewTheme>(themeName);

            if (theme.TextColor != null)
            {
                label.TextColor = (UIColor)theme.TextColor;
            }

            if (theme.TextSize > 0)
            {
                label.Font = FontStyleFromEnum(theme.TextStyle, (int)theme.TextSize);
            }

            if (theme.CornerRadius > 0)
            {
                label.Layer.CornerRadius = theme.CornerRadius;
            }

            if (theme.BorderWidth > 0)
            {
                label.Layer.BorderWidth = theme.BorderWidth;
            }
        }

        public static void SetTheme(this UIButton button, string themeName)
        {
            SetTheme((UIView)button, themeName);

            var theme = ThemeParser.GetThemeByName<ITextViewTheme>(themeName);

            if (theme.TextColor != null)
            {
                button.SetTitleColor((UIColor)theme.TextColor, UIControlState.Normal);
            }

            if (theme.TextSize > 0)
            {
                button.Font = FontStyleFromEnum(theme.TextStyle, (int)theme.TextSize);
            }

            if (theme.CornerRadius > 0)
            {
                button.Layer.CornerRadius = theme.CornerRadius;
            }

            if (theme.BorderWidth > 0)
            {
                button.Layer.BorderWidth = theme.BorderWidth;
            }

            if (theme.ImageLeft != null)
            {
                button.SetImage((UIImage)theme.ImageLeft, UIControlState.Normal);
                button.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
                var availableSpace = button.ContentEdgeInsets.InsetRect(button.Bounds);
                var availableWidth = availableSpace.Width - button.ImageEdgeInsets.Right - (button.ImageView?.Frame.Width ?? 0) - (button.TitleLabel?.Frame.Width ?? 0);
                button.TitleEdgeInsets = new UIEdgeInsets(top: 0, left: availableWidth / 2, bottom: 0, right: 0);
            }

            if (theme.ImageRight != null)
            {
                button.SetImage((UIImage)theme.ImageRight, UIControlState.Normal);
                button.SemanticContentAttribute = UISemanticContentAttribute.ForceRightToLeft;
                button.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
                var availableSpace = button.ContentEdgeInsets.InsetRect(button.Bounds);
                var availableWidth = availableSpace.Width - button.ImageEdgeInsets.Left - (button.ImageView?.Frame.Width ?? 0) - (button.TitleLabel?.Frame.Width ?? 0);
                button.TitleEdgeInsets = new UIEdgeInsets(top: 0, left: 0, bottom: 0, right: availableWidth / 2);
            }

            var themeImageButton = ThemeParser.GetThemeByName<IImageButtonTheme>(themeName);

            if (themeImageButton.Image != null)
            {
                button.SetBackgroundImage((UIImage)themeImageButton.Image, UIControlState.Normal);
            }
        }

        public static void SetTheme(this UIButton button, string mainThemeName, string mainText, string attrThemeName, string attrText, int position)
        {
            SetTheme(button, mainThemeName);

            var mainTheme = ThemeParser.GetThemeByName<ITextViewTheme>(mainThemeName);
            var attrTheme = ThemeParser.GetThemeByName<ITextViewTheme>(attrThemeName);

            var firstAttributes = new UIStringAttributes();
            if (mainTheme.TextColor != null)
            {
                firstAttributes.ForegroundColor = (UIColor)mainTheme.TextColor;
            }
            if (mainTheme.TextSize > 0)
            {
                firstAttributes.Font = FontStyleFromEnum(mainTheme.TextStyle, (int)mainTheme.TextSize);
            }

            var secondAttributes = new UIStringAttributes
            {
                Font = FontStyleFromEnum(attrTheme.TextStyle, (int)attrTheme.TextSize),
                ForegroundColor = (UIColor)attrTheme.TextColor,
                UnderlineStyle = NSUnderlineStyle.Single //_nativeTheme.UnderlineStyles[linkFontStyle]
            };

            var prettyString = new NSMutableAttributedString(mainText.Insert(position, attrText));

            prettyString.SetAttributes(firstAttributes.Dictionary, new NSRange(0, position - 1));
            prettyString.SetAttributes(firstAttributes.Dictionary, new NSRange(position + attrText.Length - 1, prettyString.Length - position - attrText.Length));
            prettyString.SetAttributes(secondAttributes.Dictionary, new NSRange(position, attrText.Length));

            button.SetAttributedTitle(prettyString, UIControlState.Normal);
        }

        public static void SetTheme(this UITextField editText, string themeName)
        {
            SetTheme((UIView)editText, themeName);

            var theme = ThemeParser.GetThemeByName<IEditTextTheme>(themeName);

            if (theme.HintTextColor != null)
            {
            }

            if (theme.TextColor != null)
            {
                editText.TextColor = (UIColor)theme.TextColor;
            }

            if (theme.TextSize > 0)
            {
                editText.Font = FontStyleFromEnum(theme.TextStyle, (int)theme.TextSize);
            }

            if (theme.CornerRadius > 0)
            {
                editText.Layer.CornerRadius = theme.CornerRadius;
            }

            if (theme.BorderWidth > 0)
            {
                editText.Layer.BorderWidth = theme.BorderWidth;
            }

            if (theme.BorderColor != null)
            {
                editText.Layer.BorderColor = ((UIColor)theme.BorderColor).CGColor;
            }
        }

        public static void SetTheme(this UIImageView imageView, string themeName)
        {
            SetTheme((UIView)imageView, themeName);

            var theme = ThemeParser.GetThemeByName<IImageViewTheme>(themeName);

            if (theme.Image != null)
            {
                imageView.Image = (UIImage)theme.Image;
            }
        }
        // =========== TODO
        private static UIFont FontStyleFromEnum(object font, int size)
        {
            UIFont fontStyle;

            switch (font)
            {
                case EFontStyle.Bold:
                {
                    fontStyle = UIFont.BoldSystemFontOfSize(Convert.ToSingle(size));
                    break;
                }
                case EFontStyle.Italic:
                {
                    fontStyle = UIFont.ItalicSystemFontOfSize(Convert.ToSingle(size));
                    break;
                }
                case EFontStyle.Underline:
                {
                    fontStyle = UIFont.SystemFontOfSize(Convert.ToSingle(size));
                    break;
                }

                case EFontStyle.Normal:
                default:
                {
                    fontStyle = UIFont.SystemFontOfSize(Convert.ToSingle(size));
                    break;
                }
            }

            return fontStyle;
        }


        //==================================================================================
        public static void SetTheme(this UIView view, IViewTheme theme)
        {
            if (theme.BackgroundColor != null)
            {
                view.BackgroundColor = (UIColor) theme.BackgroundColor;
            }

            if (theme.TintColor != null)
            {
                view.TintColor = (UIColor) theme.TintColor;
            }
        }

        public static void SetTheme(this UILabel label, ITextViewTheme theme)
        {
            SetTheme((UIView)label, (IViewTheme) theme);

            if (theme.TextColor != null)
            {
                label.TextColor = (UIColor)theme.TextColor;
            }

            if (theme.TextSize > 0)
            {
                label.Font = FontStyleFromEnum(theme.TextStyle, (int)theme.TextSize);
            }

            if (theme.CornerRadius > 0)
            {
                label.Layer.CornerRadius = theme.CornerRadius;
            }

            if (theme.BorderWidth > 0)
            {
                label.Layer.BorderWidth = theme.BorderWidth;
            }
        }

        public static void SetTheme(this UILabel label, ITextViewTheme mainTheme, string mainText, ITextViewTheme attrTheme, string attrText, int position)
        {
            SetTheme(label, mainTheme);

            var firstAttributes = new UIStringAttributes();

            if (mainTheme.TextColor != null)
            {
                firstAttributes.ForegroundColor = (UIColor)mainTheme.TextColor;
            }

            if (mainTheme.TextSize > 0)
            {
                firstAttributes.Font = FontStyleFromEnum(mainTheme.TextStyle, (int)mainTheme.TextSize);
            }

            var secondAttributes = new UIStringAttributes
            {
                Font = FontStyleFromEnum(attrTheme.TextStyle, (int)attrTheme.TextSize),
                ForegroundColor = (UIColor)attrTheme.TextColor,
                UnderlineStyle = NSUnderlineStyle.Single //_nativeTheme.UnderlineStyles[linkFontStyle]
            };

            var prettyString = new NSMutableAttributedString(mainText.Insert(position, attrText));

            prettyString.SetAttributes(firstAttributes.Dictionary, new NSRange(0, position - 1));
            prettyString.SetAttributes(firstAttributes.Dictionary, new NSRange(position + attrText.Length - 1, prettyString.Length - position - attrText.Length));
            prettyString.SetAttributes(secondAttributes.Dictionary, new NSRange(position, attrText.Length));

            label.AttributedText = prettyString;
        }

        public static void SetTheme(this UIButton button, IButtonTheme theme)
        {
            SetTheme((UIView)button, (IViewTheme) theme);

            if (theme.TextColor != null)
            {
                button.SetTitleColor((UIColor)theme.TextColor, UIControlState.Normal);
            }

            if (theme.TextSize > 0)
            {
                button.Font = FontStyleFromEnum(theme.TextStyle, (int)theme.TextSize);
            }

            if (theme.CornerRadius > 0)
            {
                button.Layer.CornerRadius = theme.CornerRadius;
            }

            if (theme.BorderWidth > 0)
            {
                button.Layer.BorderWidth = theme.BorderWidth;
            }

            if (theme.BorderColor != null)
            {
                button.Layer.BorderColor = ((UIColor)theme.BorderColor).CGColor;
            }

            if (theme.ImageLeft != null)
            {
                button.SetImage((UIImage) theme.ImageLeft, UIControlState.Normal);
                //button.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
                //var availableSpace = button.ContentEdgeInsets.InsetRect(button.Bounds);
                //var availableWidth = availableSpace.Width - button.ImageEdgeInsets.Right - (button.ImageView?.Frame.Width ?? 0) - (button.TitleLabel?.Frame.Width ?? 0);
                //button.TitleEdgeInsets = new UIEdgeInsets(top: 0, left: availableWidth / 2, bottom: 0, right: 0);
            }

            if (theme.ImageRight != null)
            {
                button.SetImage((UIImage)theme.ImageRight, UIControlState.Normal);
                button.TitleEdgeInsets = new UIEdgeInsets(0, -button.ImageView.Frame.Size.Width, 0, button.ImageView.Frame.Size.Width);
                button.ImageEdgeInsets = new UIEdgeInsets(0, button.Frame.Size.Width - button.ImageView.Frame.Size.Width * 4, 0, -(button.Frame.Size.Width - button.ImageView.Frame.Size.Width));
               }
        }

        public static void SetTheme(this UIButton button, IImageViewTheme theme)
        {
            SetTheme((UIView)button, (IViewTheme)theme);
            SetTheme(button, (IButtonTheme) theme);

            if (theme.Image != null)
            {
                button.SetBackgroundImage((UIImage) theme.Image, UIControlState.Normal);
            }
        }

        public static void SetTheme(this UIButton button, IButtonTheme mainTheme, string mainText, IButtonTheme attrTheme, string attrText, int position)
        {
            SetTheme(button, mainTheme);

            var firstAttributes = new UIStringAttributes();

            if (mainTheme.TextColor != null)
            {
                firstAttributes.ForegroundColor = (UIColor) mainTheme.TextColor;
            }

            if (mainTheme.TextSize > 0)
            {
                firstAttributes.Font = FontStyleFromEnum(mainTheme.TextStyle, (int) mainTheme.TextSize);
            }

            var secondAttributes = new UIStringAttributes
            {
                Font = FontStyleFromEnum(attrTheme.TextStyle, (int)attrTheme.TextSize),
                ForegroundColor = (UIColor) attrTheme.TextColor,
                UnderlineStyle = NSUnderlineStyle.Single //_nativeTheme.UnderlineStyles[linkFontStyle]
            };

            var prettyString = new NSMutableAttributedString(mainText.Insert(position, attrText));

            prettyString.SetAttributes(firstAttributes.Dictionary, new NSRange(0, position - 1));
            prettyString.SetAttributes(firstAttributes.Dictionary, new NSRange(position + attrText.Length - 1, prettyString.Length - position - attrText.Length));
            prettyString.SetAttributes(secondAttributes.Dictionary, new NSRange(position, attrText.Length));

            button.SetAttributedTitle(prettyString, UIControlState.Normal);
        }

        public static void SetTheme(this UITextField editText, IEditTextTheme theme)
        {
            SetTheme((UIView)editText, (IViewTheme) theme);

            if (theme.HintTextColor != null)
            {
            }

            if (theme.TextColor != null)
            {
                editText.TextColor = (UIColor)theme.TextColor;
            }

            if (theme.TextSize > 0)
            {
                editText.Font = FontStyleFromEnum(theme.TextStyle, (int)theme.TextSize);
            }

            if (theme.CornerRadius > 0)
            {
                editText.Layer.CornerRadius = theme.CornerRadius;
            }

            if (theme.BorderWidth > 0)
            {
                editText.Layer.BorderWidth = theme.BorderWidth;
            }

            if (theme.BorderColor != null)
            {
                editText.Layer.BorderColor = ((UIColor) theme.BorderColor).CGColor;
            }
        }

        public static void SetTheme(this UIImageView imageView, IImageViewTheme theme)
        {
            SetTheme((UIView) imageView, (IViewTheme) theme);

            if (theme.Image != null)
            {
                imageView.Image = (UIImage) theme.Image;
            }
        }
    }
}