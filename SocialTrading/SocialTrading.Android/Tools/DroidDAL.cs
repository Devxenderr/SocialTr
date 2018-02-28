using System;
using System.IO;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Provider;
using Android.Graphics;
using Android.Util;
using HockeyApp.Android;
using HockeyApp.Android.Metrics;
using SocialTrading.Locale;
using SocialTrading.Droid.Theme;
using SocialTrading.ThemesStyles;

using Uri = Android.Net.Uri;

namespace SocialTrading.Droid.Tools
{
    public static class DroidDAL
    {
        public const int TabPageCount = 4;
        public const int AuthBackgroundHeightOffset = 100;

        public static readonly List<string> mainTabTitles = new List<string> { Localization.Lang.Posts, Localization.Lang.Favorites, Localization.Lang.Deals, Localization.Lang.Notification };

        public static ThemeParser<GlobalControlsTheme> ThemeParser;

        public static string GetImageBase64(this Bitmap bitmap)
        {
            var stream = new MemoryStream();
            bitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
            var data = stream.ToArray();
            var baseString = Convert.ToBase64String(data);

            return baseString;
        }

        public static string GetBase64(this string uri)
        {
            if (uri.Equals(string.Empty))
            {
                return string.Empty;
            }

            return MediaStore.Images.Media.GetBitmap(Application.Context.ContentResolver, Uri.Parse(uri)).GetImageBase64();
        }

        public static Bitmap FromBase64(this string image)
        {
            var bytes = Base64.Decode(image, Base64Flags.Default);
            var bitmap = BitmapFactory.DecodeByteArray(bytes, 0, bytes.Length);
            return bitmap;
        }

        public static void HockeyAppRegister(Context context)
        {
            string HOCKEYAPP_APPID = "2cc7cd8bfee64eccba506378485ce46f";
            CrashManager.Register(context, HOCKEYAPP_APPID);
            MetricsManager.Register(((Activity)context).Application, HOCKEYAPP_APPID);
        }
    }
}