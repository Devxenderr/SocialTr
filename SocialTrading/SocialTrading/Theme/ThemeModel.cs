using System.Collections.Generic;

using SocialTrading.Theme.Enumerators;

namespace SocialTrading.Theme
{
    public class ThemeModel
    {
        public Dictionary<string, string> Colors            { get; set; }
        public Dictionary<string, string> Images            { get; set; }
        public Dictionary<string, int> FontSizes            { get; set; }
        public Dictionary<string, EFontStyle> FontStyles    { get; set; }
        public string Font                                  { get; set; }

        public ThemeModel()
        {
            Colors = new Dictionary<string, string>();
            Images = new Dictionary<string, string>();
            FontSizes = new Dictionary<string, int>();
            FontStyles = new Dictionary<string, EFontStyle>();
        }
    }
}
