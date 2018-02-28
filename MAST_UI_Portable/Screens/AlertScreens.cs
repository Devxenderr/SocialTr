using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace MAST_UI_Portable
{
    public class AlertScreens : ScreenBase
    {
        public Query title_on_alert; 
        public Query ok_on_alert;   // Does not match id
        public Query cancel_on_alert; // Does not match id
        public Query message_on_alert;
        // all button on alert
        
        public Query button1_on_alert; // 15 min, buy, public
        public Query button2_on_alert; // 30min, sell, private
        public Query button3_on_alert; 
        public Query button4_on_alert;
        public Query button5_on_alert;
        public Query button6_on_alert;
        public Query button7_on_alert;
        public Query button8_on_alert; // other

        
        public AlertScreens(Platform platform, AppManager manager) : base(platform, manager)
        {
            
            if (OnAndroid)
            {
                title_on_alert = x => x.Marked("alertTitle");
                message_on_alert = x => x.Marked("message");
                ok_on_alert = x => x.Marked("button1");
                cancel_on_alert = x => x.Marked("button2");

                button1_on_alert = x => x.Marked("ll_alert").Child(0);
                button2_on_alert = x => x.Marked("ll_alert").Child(1);
                button3_on_alert = x => x.Marked("ll_alert").Child(2);
                button4_on_alert = x => x.Marked("ll_alert").Child(3);
                button5_on_alert = x => x.Marked("ll_alert").Child(4);
                button6_on_alert = x => x.Marked("ll_alert").Child(5);
                button7_on_alert = x => x.Marked("ll_alert").Child(6);
                button8_on_alert = x => x.Marked("ll_alert").Child(7);
                

            }
            if (OniOS)
            {

                ok_on_alert = x => x.Marked("createPost_done_picker");
                cancel_on_alert = x => x.Marked("createPost_done_picker");
                title_on_alert = x => x.Marked("createPost_done_picker");
                //auth_logo_imageView = x => x.Marked("auth_logo_imageView");
            }
        }

    }
}
