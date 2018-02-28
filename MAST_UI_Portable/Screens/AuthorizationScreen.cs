using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace MAST_UI_Portable
{
    public class AuthorizationScreen : ScreenBase
    {
        
        public Query auth_logo_imageView  = x => x.Marked("auth_logo_imageView");
        public Query auth_slogan_textViewView = x => x.Marked("auth_slogan_textViewView");
        
        public Query auth_email_editText = x => x.Marked("auth_email_editText"); // Текстбокс эмейла auth_socialEnter_textView
        public Query auth_pass_editText = x => x.Marked("auth_pass_editText");
        public Query auth_auth_button = x => x.Marked("auth_auth_button");
        public Query auth_forgot_textView = x => x.Marked("auth_forgot_textView");
        //public Query auth_socialEnter_textView;
        //public Query auth_vk_imageButton;
        //public Query auth_odnokl_imageButton;
        //public Query auth_google_imageButton;
        public Query newauth_facebook_imageButton = x => x.Marked("newauth_facebook_imageButton");
        public Query auth_noAccount_textView = x => x.Marked("auth_noAccount_textView");
        public Query auth_reg_button = x => x.Marked("auth_reg_button");

        public Query auth_email_textView_iOS;
        public Query auth_pass_textView_iOS;

        //ForgotPass screen
        public Query pass_retrive_button = x => x.Marked("pass_retrive_button");
        public Query pass_email_editText = x => x.Marked("pass_email_editText");
        public Query pass_back_imageButton = x => x.Marked("pass_back_imageButton");
        public Query pass_header_textView = x => x.Marked("pass_header_textView");

        public Query pass_logo_imageView = x => x.Marked("pass_logo_imageView");



        public Query pass_email_textView_iOS;



        //public Query auth_invalid_email_textView; //подпись невалидного эмейла
        //public Query auth_invalid_pass_textView;



        public AuthorizationScreen(Platform platform, AppManager manager) : base(platform, manager)
        {
            if (OnAndroid)
            {
                
                //auth_logo_imageView;
                //auth_slogan_textViewView  = x => x.Marked("auth_slogan_textViewView");
                //auth_email_editText = x => x.Marked("auth_email_editText");
                //auth_invalid_email_textView = x => x.Marked("auth_invalid_email_textView");
                //auth_pass_editText = x => x.Marked("auth_pass_editText");
                //auth_invalid_pass_textView = x => x.Marked("auth_invalid_pass_textView");
                //auth_auth_button = x => x.Marked("auth_auth_button");
                //auth_forgot_textView = x => x.Marked("auth_forgot_textView");
                //auth_socialEnter_textView = x => x.Marked("auth_socialEnter_textView");
                //auth_vk_imageButton = x => x.Marked("auth_vk_imageButton");
                //auth_odnokl_imageButton = x => x.Marked("auth_odnokl_imageButton");
                //auth_google_imageButton = x => x.Marked("auth_google_imageButton");
                //auth_facebook_imageButton = x => x.Marked("newauth_facebook_imageButton");
                //auth_noAccount_textView = x => x.Marked("auth_noAccount_textView");
                //auth_reg_button = x => x.Marked("auth_reg_button");

                // foregot pass
                //pass_retrive_button = x => x.Marked("pass_retrive_button");
                //pass_email_editText = x => x.Marked("pass_email_editText");
                //pass_back_imageButton = x => x.Marked("pass_back_imageButton");
                //pass_header_textView = x => x.Marked("pass_header_textView");




            }
            if (OniOS)
            {
                //auth_logo_imageView = x => x.Class("UIImageView").Marked("auth_logo_imageView");
                //auth_slogan_textViewView = x => x.Class("UILabel").Marked("auth_slogan_textViewView");
                auth_email_textView_iOS = x => x.Marked("auth_email_textView_iOS");
                auth_pass_textView_iOS = x => x.Marked("auth_pass_textView_iOS");
                //auth_email_editText = x => x.Class("UITextField").Marked("auth_email_editText");
                //auth_invalid_email_textView = x => x.Marked("auth_invalid_email_textView");
                //auth_pass_editText = x => x.Class("UITextField").Marked("auth_pass_editText");
                //auth_invalid_pass_textView = x => x.Marked("auth_invalid_pass_textView");
                //auth_auth_button = x => x.Class("UIButton").Marked("auth_auth_button");

                //auth_forgot_textView = x => x.Class("UIButton").Marked("auth_forgot_textView");
                //auth_socialEnter_textView = x => x.Class("UILabel").Marked("auth_socialEnter_textView");

                //auth_vk_imageButton = x => x.Class("UIButton").Marked("auth_vk_imageButton");
                //auth_odnokl_imageButton = x => x.Class("UIButton").Marked("auth_odnokl_imageButton");
                //auth_google_imageButton = x => x.Class("UIButton").Marked("auth_google_imageButton");
                //auth_facebook_imageButton = x => x.Class("UIButton").Marked("newauth_facebook_imageButton");
                //auth_noAccount_textView = x => x.Class("UILabel").Marked("auth_noAccount_textView");
                //auth_reg_button = x => x.Class("UIButton").Marked("auth_reg_button");

                // forgot pass

                //pass_retrive_button = x => x.Marked("pass_retrive_button");
                //pass_email_editText = x => x.Marked("pass_email_editText");
                //pass_back_imageButton = x => x.Marked("pass_back_imageButton");
                //pass_header_textView = x => x.Class("UILabel").Marked("pass_header_textView");
                pass_email_textView_iOS = x => x.Marked("pass_email_textView_iOS");
            }

        }
    }
}
