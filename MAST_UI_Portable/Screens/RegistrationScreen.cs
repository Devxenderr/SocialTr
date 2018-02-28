using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace MAST_UI_Portable
{
    public class RegistrationScreen : ScreenBase
    {
        public Query regName_back_imageButton = x => x.Marked("regName_back_imageButton");
        public Query regName_logo_imageView;
        public Query reg_enterName_textView;
        public Query reg_name_textView_ios;
        public Query reg_lastname_textView_ios;
        public Query reg_name_editText;
        public Query reg_lastname_editText;
        //public Query reg_invalid_name_textView;
        //public Query reg_invalid_lastname_textView;
        public Query reg_follow_phone_button;



        // Screen add phone
        public Query regPhone_back_imageButton = x => x.Marked("regPhone_back_imageButton");
        public Query regPhone_logo_imageView;
        public Query reg_enterPhone_textView;
        public Query reg_phoneCountry_editText;
        public Query reg_phoneNumber_editText;
        public Query reg_follow_email_button;
        public Query reg_skip_phone_button;
        public Query reg_phoneCountry_textView_ios; // iOS only
        public Query reg_phoneNumber_textView_ios; // iOS only


        // screen add email
        public Query regEmail_back_imageButton = x => x.Marked("regEmail_back_imageButton");
        public Query regEmail_logo_imageView;
        public Query reg_enterEmail_textView;
        public Query reg_email_editText;
        public Query reg_follow_pass_button;
        public Query reg_email_textView_ios; // iOS only
        //public Query reg_invalid_email_textView;


        // screen pass 
        public Query regPass_back_imageButton = x => x.Marked("regPass_back_imageButton"); 
        public Query regPass_logo_imageView;
        public Query reg_enterPass_textView;
        public Query reg_pass_editText;
        public Query reg_confirm_pass_editText;
        public Query reg_userAgreement_textView; 
        public Query reg_follow_main_button;
        public Query reg_pass_textView_ios;// iOS only
        public Query reg_confirm_pass_textView_ios;// iOS only
        //public Query reg_invalid_pass_textView;
        //public Query reg_invalid_passconfirm_textView;


        // вынести в отдельный класс 
        public Query alertTitle;
        public Query alrt_ok_button;
        public Query alrt_cancel_button;
        

        public RegistrationScreen(Platform platform, AppManager manager) : base(platform, manager)
        {

            if (OnAndroid)
            {


                    reg_enterName_textView = x => x.Marked("reg_enterName_textView");
                    regName_logo_imageView = x => x.Marked("regName_logo_imageView");
                    reg_name_editText = x => x.Marked("reg_name_editText");
                    reg_lastname_editText = x => x.Marked("reg_lastname_editText");
                    //reg_invalid_name_textView = x => x.Marked("reg_invalid_name_textView");
                    //reg_invalid_lastname_textView = x => x.Marked("reg_invalid_lastname_textView");
                    reg_follow_phone_button = x => x.Marked("reg_follow_phone_button");

                    regPhone_logo_imageView = x => x.Marked("regPhone_logo_imageView");
                    reg_enterPhone_textView = x => x.Marked("reg_enterPhone_textView");
                    reg_phoneCountry_editText = x => x.Marked("reg_phoneCountry_editText");
                    reg_phoneNumber_editText = x => x.Marked("reg_phoneNumber_editText");
                    reg_follow_email_button = x => x.Marked("reg_follow_email_button");
                    reg_skip_phone_button = x => x.Marked("reg_skip_phone_button");

                    regEmail_logo_imageView = x => x.Marked("regEmail_logo_imageView");
                    reg_enterEmail_textView = x => x.Marked("reg_enterEmail_textView");

                    reg_email_editText = x => x.Marked("reg_email_editText");
                    reg_follow_pass_button = x => x.Marked("reg_follow_pass_button");
                //reg_invalid_email_textView = x => x.Marked("reg_invalid_email_textView");

                    regPass_logo_imageView  = x => x.Marked("regPass_logo_imageView");
                    reg_enterPass_textView = x => x.Marked("reg_enterPass_textView");
                    reg_pass_editText = x => x.Marked("reg_pass_editText");
                    reg_confirm_pass_editText = x => x.Marked("reg_confirm_pass_editText");
                    reg_userAgreement_textView = x => x.Marked("reg_userAgreement_textView");
                    reg_follow_main_button = x => x.Marked("reg_follow_main_button");
                    //reg_invalid_pass_textView = x => x.Marked("reg_invalid_pass_textView");
                    //reg_invalid_passconfirm_textView = x => x.Marked("reg_invalid_passconfirm_textView");


                    alertTitle = x => x.Marked("alertTitle");
                    alrt_ok_button = x => x.Marked("button1");
                    alrt_cancel_button = x => x.Marked("button2");

            }
            if (OniOS)
                {

                reg_enterName_textView = x => x.Class("UILabel").Marked("reg_enterName_textView");
                //regName_back_imageButton = x => x.Marked("regName_back_imageButton");
                regName_logo_imageView = x => x.Class("UIImageView").Marked("regName_logo_imageView");
                reg_name_textView_ios = x => x.Class("UILabel").Marked("reg_name_textView_ios");
                reg_lastname_textView_ios = x => x.Class("UILabel").Marked("reg_lastname_textView_ios");
                reg_name_editText = x => x.Class("UITextField").Marked("reg_name_editText");
                reg_lastname_editText = x => x.Class("UITextField").Marked("reg_lastname_editText");
                reg_follow_phone_button = x => x.Class("UIButton").Marked("reg_follow_phone_button");

                
                regPhone_logo_imageView = x => x.Class("UIImageView").Marked("regPhone_logo_imageView");
                reg_enterPhone_textView = x => x.Class("UILabel").Marked("reg_enterPhone_textView");
                reg_phoneCountry_editText = x => x.Class("UITextField").Marked("reg_phoneCountry_editText");
                reg_phoneNumber_editText = x => x.Class("UITextField").Marked("reg_phoneNumber_editText");
                reg_follow_email_button = x => x.Class("UIButton").Marked("reg_follow_email_button");
                reg_skip_phone_button = x => x.Class("UIButton").Marked("reg_skip_phone_button");
                reg_phoneCountry_textView_ios = x => x.Class("UILabel").Marked("reg_phoneCountry_textView_ios");
                reg_phoneNumber_textView_ios = x => x.Class("UILabel").Marked("reg_phoneNumber_textView_ios");


                
                regEmail_logo_imageView = x => x.Class("UIImageView").Marked("regEmail_logo_imageView");
                reg_enterEmail_textView = x => x.Class("UILabel").Marked("reg_enterEmail_textView");

                reg_email_editText = x => x.Class("UITextField").Marked("reg_email_editText");
                reg_follow_pass_button = x => x.Class("UIButton").Marked("reg_follow_pass_button");
                reg_email_textView_ios = x => x.Class("UILabel").Marked("reg_email_textView_ios");
                //reg_invalid_email_textView = x => x.Marked("reg_invalid_email_textView");

                
                regPass_logo_imageView = x => x.Class("UIImageView").Marked("regPass_logo_imageView");
                reg_enterPass_textView = x => x.Class("UILabel").Marked("reg_enterPass_textView");
                reg_pass_editText = x => x.Class("UITextField").Marked("reg_pass_editText");
                reg_confirm_pass_editText = x => x.Class("UITextField").Marked("reg_confirm_pass_editText");
                reg_userAgreement_textView = x => x.Class("UIButton").Marked("reg_userAgreement_textView"); 
                reg_follow_main_button = x => x.Class("UIButton").Marked("reg_follow_main_button");
                reg_pass_textView_ios = x => x.Class("UILabel").Marked("reg_pass_textView_ios");
                reg_confirm_pass_textView_ios = x => x.Class("UILabel").Marked("reg_confirm_pass_textView_ios");
                //reg_invalid_pass_textView = x => x.Marked("reg_invalid_pass_textView");
                //reg_invalid_passconfirm_textView = x => x.Marked("reg_invalid_passconfirm_textView");


                alertTitle = x => x.Marked("alertTitle");
                alrt_ok_button = x => x.Marked("button1");
                alrt_cancel_button = x => x.Marked("button2");

            }
            
        }

        
    }
}

