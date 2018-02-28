namespace SocialTrading.Vipers.Entity
{
    public class CreatePostStrings
    {
        public string AccessMode { get; set; }
        public string BuySell { get; set; }
        public string ForecastTime { get; set; }
        public string Comment { get; set; }

        public CreatePostStrings(string accessMode, string buySell, string forecastTime, string comment)
        {
            AccessMode = accessMode;
            BuySell = buySell;
            ForecastTime = forecastTime;
            Comment = comment;
        }
    }
}
