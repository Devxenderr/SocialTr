namespace SocialTrading.Theme.ThemeStrings
{
    public class PostOtherThemeStrings
    {
        public string ToolBarBackImage { get; internal set; }
        public string ToolBarTitleColor { get; internal set; }
        public string ToolBarBackground { get; internal set; }

        public PostOtherThemeStrings()
        {
        }

        public PostOtherThemeStrings(string toolBarBackImage, string toolBarTitleColor, string toolBarBackground)
        {
            ToolBarBackImage = toolBarBackImage;
            ToolBarTitleColor = toolBarTitleColor;
            ToolBarBackground = toolBarBackground;
        }
    }
}
