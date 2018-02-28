using SocialTrading.Theme;
using SocialTrading.Tools.Constants;

namespace SocialTrading.Tools
{
    public static class DAL
    {
        static DAL()
        {
            RestHeaderValues = new RestHeaderValues();
			ThemeKeyStrings = new ThemeKeyStrings();
            MaxForecastTime = 140;
            SendDelay = 14000;
            DividerPointConstant = 1000000;
            DictionaryForOptions = new DictionaryForOptions();
        }


        public static RestHeaderValues RestHeaderValues;
        public static ThemeKeyStrings ThemeKeyStrings;
        public static double DividerPointConstant;
        public static int MaxForecastTime { get; set; }
        public static int SendDelay { get; set; }
        public static DictionaryForOptions DictionaryForOptions { get; }
    }
}
