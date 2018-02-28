using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace MAST_UI_Portable
{
    public class EditProfileScreen : ScreenBase
    {
        public Query editProfile_name_textView = x => x.Marked("editProfile_name_textView");
        public Query editProfile_name_editText = x => x.Marked("editProfile_name_editText");
        public Query editProfile_lastname_textView = x => x.Marked("editProfile_lastname_textView");
        public Query editProfile_lastname_editText = x => x.Marked("editProfile_lastname_editText");
        public Query editProfile_status_textView = x => x.Marked("editProfile_status_textView");
        public Query editProfile_status_editText = x => x.Marked("editProfile_status_editText");
        public Query editProfile_save_button = x => x.Marked("editProfile_save_button");
        public Query editProfile_cancel_button = x => x.Marked("editProfile_cancel_button");

        public EditProfileScreen(Platform platform, AppManager manager) : base(platform, manager)
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