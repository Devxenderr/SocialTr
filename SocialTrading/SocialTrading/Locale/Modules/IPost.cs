namespace SocialTrading.Locale.Modules
{
    public interface IPost : IAlert
    {
        string Posts { get; }

        // Social
        string Like { get; }
        string Comments { get; }
        string ShareWith { get; }
        string LikeError { get; }

        // Body
        string ReadMore { get; }

        // Header
        string ForecastTime { get; }
        string Offline { get; }
        string Online { get; }
        string Difference { get; }
        string DealsPost { get; }
        string Margin { get; }
        string PnL { get; }
        string OptionsHeader { get; }
        string UpdatePost { get; }
        string DeletePost { get; }
        string ShortLabel { get; }
        string LongLabel { get; }
        string DeletePostMessage { get; }
        string DeletePostTitle { get; }
        string DeletePostErrorMessage { get; }
        string DeletePostSuccessMessage { get; }
        string ForecastTimeDay { get; }
		string Edit { get; }
		string Pips { get; }
		
		string HourEnding { get; }
		string CreateNow { get; }
		string ForecastTimeEnd { get; }

        System.Collections.Generic.List<string> MonthsCreatedAt { get; }
        string MinutesEndingCreatedAt { get; }

        string DetailedPostTitle { get; }

        string PostsTitle { get; }
        string PostsButtonCreatePost { get; }
    }
}
