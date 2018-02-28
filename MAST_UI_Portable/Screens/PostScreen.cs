using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace MAST_UI_Portable
{
    public class PostScreen : ScreenBase
    {
        public Query postHeader_userAvatar_imageView;
        public Query postHeader_userFirstName_textView;
        public Query postHeader_forecastTimeValue_textView;
        public Query postHeader_options_button;
        public Query postHeader_postDate_textView;
        public Query postHeader_tool_textView;
        public Query postHeader_buySell_textView;
        public Query postHeader_buySellValue_textView;
        public Query postHeader_currentPriceValue_textView;
        public Query postHeader_difference_textView; //разница
        public Query postHeader_diffValue_textView; // количество пипс ( .. pips)
        public Query postBody_comment_textView;
        public Query postBody_image_imageView;
        public Query postSocial_like_textView;
        public Query postSocial_comment_textView;
        public Query postSocial_share_textView;




        public PostScreen(Platform platform, AppManager manager) : base(platform, manager)
        {
            if (OnAndroid)
            {
                //postBody_comment_textView_firstPost = x => x.Id("postBody_comment_textView");  
                postBody_comment_textView = x => x.Marked("postsRecyclerView").Child().Child().Child().Child(1).Child().Child(0);

                postHeader_userAvatar_imageView = x => x.Marked("postHeader_userAvatar_imageView");
                postHeader_userFirstName_textView = x => x.Marked("postHeader_userFirstName_textView");
                postHeader_forecastTimeValue_textView = x => x.Marked("postHeader_forecastTimeValue_textView");
                postHeader_options_button = x => x.Marked("postHeader_options_button");
                postHeader_postDate_textView = x => x.Marked("postHeader_postDate_textView");
                postHeader_tool_textView = x => x.Marked("postHeader_tool_textView");
                postHeader_buySell_textView = x => x.Marked("postHeader_buySell_textView");
                postHeader_buySellValue_textView = x => x.Marked("postHeader_buySellValue_textView");
                postHeader_currentPriceValue_textView = x => x.Marked("postHeader_currentPriceValue_textView");
                postHeader_difference_textView = x => x.Marked("postHeader_difference_textView");
                postHeader_diffValue_textView = x => x.Marked("postHeader_diffValue_textView");
                //postBody_comment_textView = x => x.Marked("postBody_comment_textView");
                postBody_image_imageView = x => x.Marked("postBody_image_imageView");
                postSocial_like_textView = x => x.Marked("postSocial_like_textView");
                postSocial_comment_textView = x => x.Marked("postSocial_comment_textView");
                postSocial_share_textView = x => x.Marked("postSocial_share_textView");

            }
            if (OniOS)
            {
                postBody_comment_textView = x => x.Class("net").Child();
            }

        }
    }
}
