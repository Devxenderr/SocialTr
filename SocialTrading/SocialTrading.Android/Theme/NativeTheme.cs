using Android.Graphics;

using System.Collections.Generic;

using SocialTrading.Theme.Enumerators;

namespace SocialTrading.Droid.Theme
{
    public class NativeTheme
    {
        public Dictionary<string, Color> Colors { get; set; }
        public Dictionary<string, int> Images { get; set; }
        public Dictionary<string, int> FontSizes { get; set; }
        public Dictionary<string, EFontStyle> FontStyles { get; set; }
        public string Font { get; set; }

        public NativeTheme()
        {
            Colors = new Dictionary<string, Color>();
            Images = new Dictionary<string, int>();
            FontSizes = new Dictionary<string, int>();
            FontStyles = new Dictionary<string, EFontStyle>();
        }
    }
}