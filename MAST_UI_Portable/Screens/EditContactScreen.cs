using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace MAST_UI_Portable
{
    public class EditContactScreen : ScreenBase
    {
        public Query editContact_email_textView = x => x.Marked("editContact_email_textView");
        public Query editContact_email_editText = x => x.Marked("editContact_email_editText");
        public Query editContact_skype_textView = x => x.Marked("editContact_skype_textView");
        public Query editContact_skype_editText = x => x.Marked("editContact_skype_editText");
        public Query editContact_country_textView = x => x.Marked("editContact_country_textView");
        public Query editContact_country_editText = x => x.Marked("editContact_country_editText");
        public Query editContact_city_textView = x => x.Marked("editContact_city_textView");
        public Query editContact_city_editText = x => x.Marked("editContact_city_editText");
        public Query editContact_phone_textView = x => x.Marked("editContact_phone_textView");
        public Query editContact_phone_editText = x => x.Marked("editContact_phone_editText");
        public Query editContact_save_button = x => x.Marked("editContact_save_button");
        public Query editContact_cancel_button = x => x.Marked("editContact_cancel_button");
       

        public EditContactScreen(Platform platform, AppManager manager) : base(platform, manager)
        {
            if (OnAndroid)
            {

            }
            if (OniOS)
            {
            }
        }
    }
}