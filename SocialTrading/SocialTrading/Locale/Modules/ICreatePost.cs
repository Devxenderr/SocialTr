namespace SocialTrading.Locale.Modules
{
    public interface ICreatePost : IAlert
    {
		string ToolsButton { get; }
		string PriceLabel  { get; }
		string EnterCommentLabel { get; }
		string AddPostButton { get; }
        string AttachedImageNone { get; }
        string AttachedImageOne { get; }
        string None { get; }
        string Buy { get; }
        string Sell { get; }
        string Public { get; }
        string Private { get; }
        string Minute15 { get; }
        string Minute30 { get; }
        string Hour1 { get; }
        string Hour4 { get; }
        string Hour8 { get; }
        string Hour24 { get; }
        string Week1 { get; }
        string Other { get; }
        string BuySellTextView { get; }
        string TimeTextView { get; }
        string AccessModeTextView { get; }
        string CreatePostActivityTitle { get; }
        string UpdatePostActivityTitle { get; }
        string CreatePostToolsActivityTitle { get; }
        string PublishButton { get; }
        string RecommendAlertTitle { get; }
        string ForecastTimeAlertTitle { get; }
        string AccessModeAlertTitle { get; }
        string AnotherForecastTimeAlertTitle { get; }
        string TooLargeImage { get; }
      
        System.Collections.Generic.List<string> Hours { get; }

        string CreatePostSuccess { get; }
        string UpdatePostSuccess { get; }
        string CreatePostBadRequest { get; }
        string CreatePostUnauthorized { get; }
        string CreatePostUnprocessableEntity { get; }

        System.Collections.Generic.List<string> Months { get; }
        string MinutesEnding { get; }
    }
}
