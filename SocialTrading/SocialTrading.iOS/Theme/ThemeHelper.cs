﻿﻿﻿using System;
   using System.Net;
   using UIKit;
using Foundation;

using SocialTrading.Theme;
using SocialTrading.Theme.Enumerators;
using SocialTrading.iOS.Cells.Interfaces;

namespace SocialTrading.iOS.Theme
{
    public static class ThemeHelper
    {
        private static NativeTheme _nativeTheme;
        private static ThemeModel _themeModel;
        private const int CamelNumbersLength = 2;

        public static void PerformTheme(ThemeModel themeModel)
        {
            _themeModel = themeModel;
            _nativeTheme = new NativeTheme();

            foreach (var item in themeModel.Colors)
            {
                _nativeTheme.Colors.Add(item.Key, ColorFromHex(item.Value));
            }

            foreach (var item in themeModel.FontStyles)
            {
                _nativeTheme.UnderlineStyles.Add(item.Key, UnderlineStyleFromEnum(item.Value));
            }

            _nativeTheme.Font = themeModel.Font;
            _nativeTheme.FontSizes = themeModel.FontSizes;
            _nativeTheme.Images = themeModel.Images;
        }

        private static UIColor ColorFromHex(string hexString)
        {
            hexString = hexString.Replace("#", "");

            int red = Int32.Parse(hexString.Substring(0, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            int green = Int32.Parse(hexString.Substring(2, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            int blue = Int32.Parse(hexString.Substring(4, 2), System.Globalization.NumberStyles.AllowHexSpecifier);

            return UIColor.FromRGB(red, green, blue);
        }

        public static UIFont FontStyleFromEnum(EFontStyle font, int size)
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

        private static NSUnderlineStyle UnderlineStyleFromEnum(EFontStyle font)
        {
            NSUnderlineStyle underlineStyle;

            switch (font)
            {
                case EFontStyle.Underline:
                    {
                        underlineStyle = NSUnderlineStyle.Single;
                        break;
                    }

                case EFontStyle.Italic:
                case EFontStyle.Bold:
                case EFontStyle.Normal:
                default:
                    {
                        underlineStyle = NSUnderlineStyle.None;
                        break;
                    }
            }
            return underlineStyle;
        }

        public static void SetTheme(this UILabel label, string color, string size, string font)
        {
            EFontStyle fontStyle = _themeModel.FontStyles[font];
            label.TextColor = _nativeTheme.Colors[color];
            label.Font = FontStyleFromEnum(fontStyle, _nativeTheme.FontSizes[size]);
        }

        public static void SetTheme(this UILabel label, string color, int todo)
        {
            label.TextColor = _nativeTheme.Colors[color];
        }

        public static void SetTheme(this UIButton button, string color, string size, string title, string fontStyle)
        {
            UIFont forgetPassButtonFont = FontStyleFromEnum(_themeModel.FontStyles[fontStyle], _nativeTheme.FontSizes[size]);
            var themeAttributeString = new NSMutableAttributedString(title, new UIStringAttributes
            {
                Font = forgetPassButtonFont,
                ForegroundColor = _nativeTheme.Colors[color],
                UnderlineStyle = _nativeTheme.UnderlineStyles[fontStyle]
            });

            button.SetAttributedTitle(themeAttributeString, UIControlState.Normal);
        }

        public static void SetThemeUserAgreement(this UIButton button, string color, string titleSize, string titleText, string fontStyle, string backgroungColor,
                                                 string linkColor, string linkTitleText, string linkFontStyle)
        {
            UIFont forgetPassButtonFont = FontStyleFromEnum(_themeModel.FontStyles[fontStyle], _nativeTheme.FontSizes[titleSize]);

            var firstAttributes = new UIStringAttributes
            {
                ForegroundColor = _nativeTheme.Colors[color],
                Font = forgetPassButtonFont
            };

            var secondAttributes = new UIStringAttributes
            {
                Font = forgetPassButtonFont,
                ForegroundColor = _nativeTheme.Colors[color],
                UnderlineStyle = _nativeTheme.UnderlineStyles[linkFontStyle]
            };

            var prettyString = new NSMutableAttributedString(titleText + " " + linkTitleText);

            prettyString.SetAttributes(firstAttributes.Dictionary, new NSRange(0, titleText.Length + 1));
            prettyString.SetAttributes(secondAttributes.Dictionary, new NSRange(titleText.Length + 1, linkTitleText.Length));

            button.SetAttributedTitle(prettyString, UIControlState.Normal);

        }

        public static void SetThemeDifferentLetterSize(this UILabel label, string text, int position)
        {
            if(text.Equals("0") || string.IsNullOrEmpty(text))
            {
                return;
            }
            
            var biggerAttributes = new UIStringAttributes
            {
                Font = FontStyleFromEnum(EFontStyle.Normal, (int)(label.Font.LineHeight * 1.3))
            };

            var differentLetterSizeString = new NSMutableAttributedString(text);
            differentLetterSizeString.SetAttributes(biggerAttributes.Dictionary, new NSRange(position, CamelNumbersLength));
            label.AttributedText = differentLetterSizeString;
        }

        public static void SetPostContentTheme(this UILabel textView, string content, string readMore, string backgroundColor, string textColor, string textSize, string fontStyle,
            string readMoreTextColor, string readMoreFontStyle)
        {
            int minimizedContentSymbolsCount = content.Length;

            UIFont forgetPassButtonFont = FontStyleFromEnum(_themeModel.FontStyles[fontStyle], _nativeTheme.FontSizes[textSize]);

            var firstAttributes = new UIStringAttributes
            {
                ForegroundColor = _nativeTheme.Colors[textColor],
                Font = forgetPassButtonFont
            };

            var secondAttributes = new UIStringAttributes
            {
                Font = forgetPassButtonFont,
                ForegroundColor = _nativeTheme.Colors[readMoreTextColor],
                UnderlineStyle = _nativeTheme.UnderlineStyles[readMoreFontStyle],
            };

            var prettyString = new NSMutableAttributedString(content + " " + readMore);

            prettyString.SetAttributes(firstAttributes.Dictionary, new NSRange(0, minimizedContentSymbolsCount));
            prettyString.SetAttributes(secondAttributes.Dictionary, new NSRange(minimizedContentSymbolsCount + 1, prettyString.Length - minimizedContentSymbolsCount - 1));

            textView.AttributedText = prettyString;
        }

        public static void SetTheme(this UIButton button, string color, string titleColor)
        {
            button.BackgroundColor = _nativeTheme.Colors[color];
            button.SetTitleColor(_nativeTheme.Colors[titleColor], UIControlState.Normal);
        }

        public static void SetThemeButtonImageTint(this UIButton button, string image, string tint)
        {
            button.SetImage(UIImage.FromBundle(_nativeTheme.Images[image]), UIControlState.Normal);
            if (tint != null)
            {
                button.TintColor = _nativeTheme.Colors[tint];
            }
        }

        public static void SetTheme(this UIImageView imageView, string image, int todo)
        {
            imageView.Image = UIImage.FromBundle(_nativeTheme.Images[image]);
        }

        public static void SetTheme(this UIImageView imageView, string image, string backgroundColor)
        {
            var uiImage = UIImage.FromBundle(_nativeTheme.Images[image]);
            imageView.Image = uiImage;
            imageView.BackgroundColor = _nativeTheme.Colors[backgroundColor];
        }

        public static void SetTheme(this UIView rootView, string image, int todo = 0)
        {
            UIImage backgroundImage = UIImage.FromBundle(_nativeTheme.Images[image]);
            if (backgroundImage != null)
            {
                rootView.BackgroundColor = UIColor.FromPatternImage(backgroundImage);
            }
        }

        public static void SetTheme(this UIButton button, string drawable, int todo)
        {
            button.SetImage(
                   UIImage.FromBundle(_nativeTheme.Images[drawable])?.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal), UIControlState.Normal
               );
        }

        public static void SetBackgroundTheme(this UIButton button, string drawable)
        {
            button.SetBackgroundImage(
                   UIImage.FromBundle(_nativeTheme.Images[drawable])?.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal), UIControlState.Normal
               );
        }

        public static void SetTheme(this UITextField editText, string borderColor, string textColor, int borderWidth)
        {
            editText.Layer.BorderColor = _nativeTheme.Colors[borderColor].CGColor;
            editText.TextColor = _nativeTheme.Colors[textColor];
            editText.Layer.BorderWidth = borderWidth;
        }

        public static void SetTheme(this UISwitch switchView, string onTintColor, string thumbTintColor)
        {
            switchView.OnTintColor = _nativeTheme.Colors[onTintColor];
            switchView.ThumbTintColor = _nativeTheme.Colors[thumbTintColor];
        }

        public static void SetTheme(this UITextView textView, string backgroundColor, string textColor)
        {
            textView.BackgroundColor = _nativeTheme.Colors[backgroundColor];
            textView.TextColor = _nativeTheme.Colors[textColor];
        }

        public static void SetThemeBackgroundColor(this UIView view, string backgroundColor)
        {
            view.BackgroundColor = _nativeTheme.Colors[backgroundColor];
        }

        public static void SetThemeTitleColor(this UIButton button, string titleColor)
        {
            button.SetTitleColor(_nativeTheme.Colors[titleColor], UIControlState.Normal);
        }

        public static void SetThemeButtonTextImage(this UIButton button, string titleColor, string backgroundColor, string image, string tintColor)
        {
            button.BackgroundColor = _nativeTheme.Colors[backgroundColor];
            button.SetTitleColor(_nativeTheme.Colors[titleColor], UIControlState.Normal);
            button.SetImage(UIImage.FromBundle(_nativeTheme.Images[image]), UIControlState.Normal);
            button.TintColor = _nativeTheme.Colors[tintColor];
            button.TitleEdgeInsets = new UIEdgeInsets(0, -button.ImageView.Frame.Size.Width, 0, button.ImageView.Frame.Size.Width);
            //	button.TitleEdgeInsets = new UIEdgeInsets(0, -10, 0, 10);
            button.ImageEdgeInsets = new UIEdgeInsets(0, button.Frame.Size.Width - button.ImageView.Frame.Size.Width * 4, 0, -(button.Frame.Size.Width - button.ImageView.Frame.Size.Width * 4));

        }

        #region TableView

        public static void SetThemeTableViewSeparator(this UITableView tableView, string separatorLineColor, string separatorLineSize, string separatorLineType)
        {
            tableView.SeparatorColor = _nativeTheme.Colors[separatorLineColor];
            //tableView.SeparatorInset = _nativeTheme.;
        }

        #endregion

        public static void SetToolViewCellTheme(this IToolViewCell cell, string cellColor, string fontStyle, string textColor, string textSize)
        {
            cell.ToolLabel.Font = FontStyleFromEnum(_themeModel.FontStyles[fontStyle], _nativeTheme.FontSizes[textSize]);
            cell.ToolLabel.TextColor = _nativeTheme.Colors[textColor];
            cell.ToolLabel.BackgroundColor = _nativeTheme.Colors[cellColor];
            ((UITableViewCell) cell).BackgroundColor = _nativeTheme.Colors[cellColor];
        }

        public static void SetTheme(this UISearchBar searchBar, string editTextBackground, string textColor, string textSize, string fontStyle)
        {
            searchBar.BarTintColor = _nativeTheme.Colors[editTextBackground];
            var searchField = searchBar.ValueForKey((NSString)"searchField");
            if (searchField.GetType() == typeof(UITextField))
            {
                ((UITextField)searchField).Font = FontStyleFromEnum(_themeModel.FontStyles[fontStyle], _nativeTheme.FontSizes[textSize]);
                ((UITextField)searchField).TextColor = _nativeTheme.Colors[textColor];
            }
        }

        public static void SetTheme(this UINavigationBar navigationBar, string background, string fontStyle, string textColor, string textSize)
        {
            navigationBar.BarTintColor = _nativeTheme.Colors[background];
            navigationBar.TitleTextAttributes = new UIStringAttributes(){
                Font = FontStyleFromEnum(_themeModel.FontStyles[fontStyle], _nativeTheme.FontSizes[textSize]),
                ForegroundColor = _nativeTheme.Colors[textColor],
            };
        }

        public static void SetTheme(this UINavigationItem navigationItem, string arrowBackImage, EventHandler buttonAction)
        {
            navigationItem.HidesBackButton = true;
            navigationItem.LeftBarButtonItem = new UIBarButtonItem(UIImage.FromBundle(_nativeTheme.Images[arrowBackImage]), UIBarButtonItemStyle.Plain, buttonAction);
        }
    }
}
