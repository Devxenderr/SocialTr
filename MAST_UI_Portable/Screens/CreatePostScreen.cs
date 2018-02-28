using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;



namespace MAST_UI_Portable
{
    public class CreatePostScreen : ScreenBase // Пересмотреть колекцию !!!

    {
        public Query toolbarOneButtonBack_back_imageButton = x => x.Marked("toolbarOneButtonBack_back_imageButton");
        public Query toolbarOneButtonBack_title_textView = x => x.Marked("toolbarOneButtonBack_title_textView");
        public Query toolbarOneButtonBack_button = x => x.Marked("toolbarOneButtonBack_button"); //создать пост

        public Query createPost_profilePhoto_imageView = x => x.Marked("createPost_profilePhoto_imageView");
        public Query createPost_profileName_textView = x => x.Marked("createPost_profileName_textView");
        public Query createPost_tools_textView = x => x.Marked("createPost_tools_textView");
        public Query createPost_price_textView = x => x.Marked("createPost_price_textView"); // цена котировки
        public Query createPost_buySell_textView = x => x.Marked("createPost_buySell_textView"); // Я рекомендую
        public Query createPost_time_textView = x => x.Marked("createPost_time_textView");
        public Query createPost_accessMode_textView = x => x.Marked("createPost_accessMode_textView");
        public Query createPost_comment_editText = x => x.Marked("createPost_comment_editText");
                //createPost_attachment_textView = x => x.Marked("createPost_attachment_textView");
        public Query createPost_addImage_button = x => x.Marked("createPost_addImage_button");

        
        // For iOS
        public Query createPost_done_picker;
        public Query createPost_cancel_picker;
        public Query createPost_label_picker;

        public Query createPost_recommend_sell_ios;
        public Query createPost_recommend_buy_ios;

        public Query createPost_forecastTime_15m_ios;
        public Query createPost_forecastTime_30m_ios;
        public Query createPost_forecastTime_1h_ios;
        public Query createPost_forecastTime_4h_ios;
        public Query createPost_forecastTime_8h_ios;
        public Query createPost_forecastTime_24h_ios;
        public Query createPost_forecastTime_1w_ios;
        public Query createPost_forecastTime_ather_ios;

        public Query createPost_access_private_ios;
        public Query createPost_access_public_ios;


        public CreatePostScreen(Platform platform, AppManager manager) : base(platform, manager)
        {
            if (OnAndroid)
            {
               
            }
            if (OniOS)
            {

                //createPost_profilePhoto_imageView = x => x.Class("UIImageView").Marked("createPost_profilePhoto_imageView");
                //createPost_tools_textView = x => x.Class("UIButton").Marked("createPost_tools_textView");
                //createPost_price_textView = x => x.Class("UILabel").Marked("createPost_price_textView");
                //createPost_buySell_textView = x => x.Class("UIButton").Marked("createPost_buySell_textView");
                //createPost_time_textView = x => x.Class("UIButton").Marked("createPost_time_textView");
                //createPost_accessMode_textView = x => x.Class("UILabel").Marked("createPost_accessMode_textView");
                //createPost_comment_editText = x => x.Class("UITextField").Marked("createPost_comment_editText");
                //createPost_attachment_textView = x => x.Class("").Marked("createPost_attachment_textView");
                //createPost_addImage_button = x => x.Class("UIButton").Marked("createPost_addImage_button");

                createPost_done_picker = x => x.Marked("createPost_done_picker");
                createPost_cancel_picker = x => x.Marked("createPost_done_picker");
                createPost_label_picker = x => x.Marked("createPost_done_picker");

                createPost_recommend_sell_ios = x => x.Marked("Купить");
                createPost_recommend_buy_ios = x => x.Marked("Продать");

                createPost_forecastTime_15m_ios = x => x.Marked("15м");
                createPost_forecastTime_30m_ios = x => x.Marked("30м");
                createPost_forecastTime_1h_ios = x => x.Marked("1Ч");
                createPost_forecastTime_4h_ios = x => x.Marked("4ч");
                createPost_forecastTime_8h_ios = x => x.Marked("8ч");
                createPost_forecastTime_24h_ios = x => x.Marked("24ч");
                createPost_forecastTime_1w_ios = x => x.Marked("1 неделя");
                createPost_forecastTime_ather_ios = x => x.Marked("Другое");

                createPost_access_public_ios = x => x.Marked("Публичный");
                createPost_access_private_ios = x => x.Marked("Приватный");


            }
        }


    }
}
