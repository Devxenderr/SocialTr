using UIKit;
using Foundation;

using System;
using SocialTrading.iOS.Theme;
using SocialTrading.ThemesStyles;

namespace SocialTrading.iOS.Tools
{
    public static class iOS_DAL
    {
        public static ThemeParser<GlobalControlsTheme> ThemeParser;
        static iOS_DAL()
        {
            SegueStrings = new SegueStrings();
        }

        public static SegueStrings SegueStrings;

        public static UIColor ColorFromHex(this string hexString)
        {
            hexString = hexString.Replace("#", "");

            int red = Int32.Parse(hexString.Substring(0, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            int green = Int32.Parse(hexString.Substring(2, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            int blue = Int32.Parse(hexString.Substring(4, 2), System.Globalization.NumberStyles.AllowHexSpecifier);

            return UIColor.FromRGB(red, green, blue);
        }

        public static UIImage FromBase64(this string base64String)
        {
            byte[] encodedDataAsBytes = Convert.FromBase64String(base64String);
            NSData data = NSData.FromArray(encodedDataAsBytes);
            return UIImage.LoadFromData(data);
        }

        public static UIViewController GetViewControllerForView(this UIView view)
        {
            var superView = view.Superview;
            while (superView != null)
            {
                var resp = superView.NextResponder;
                if (resp is UIViewController viewcontroller)
                {
                    return viewcontroller;
                    break;
                }
                superView = superView.Superview;
            }

            return null;
        }
    }
}