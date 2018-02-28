namespace SocialTrading.Theme.ThemeStrings
{
    public class PostBodyThemeStrings
    {
        public string ContentBackgroundColor { get; internal set; }
        public string ContentTextSize { get; internal set; }
        public string ContentTextColor { get; internal set; }
        public string ContentFontStyle { get; internal set; }

        public string ReadMoreTextColor { get; internal set; }
        public string ReadMoreFontStyle { get; internal set; }

        public PostBodyThemeStrings()
        {
        }

        public PostBodyThemeStrings(string contentBackgroundColor, string contentTextSize, string contentTextColor, string contentFontStyle, string readMoreTextColor, string readMoreFontStyle)
        {
            ContentBackgroundColor = contentBackgroundColor;
            ContentTextSize = contentTextSize;
            ContentTextColor = contentTextColor;
            ContentFontStyle = contentFontStyle;
            ReadMoreTextColor = readMoreTextColor;
            ReadMoreFontStyle = readMoreFontStyle;
        }
    }
}
