using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace MAST_UI_Portable
{
    public class MoreOptionsScreens : ScreenBase
    {
        public Query moreOptions_profile_imageView = x => x.Marked("moreOptions_profile_imageView");
        public Query moreOptions_nameTitle_textView = x => x.Marked("moreOptions_nameTitle_textView");
        public Query moreOptions_yourProfileLabel_textView = x => x.Marked("moreOptions_yourProfileLabel_textView");
        public Query edit_profile;
        public Query contact_data;
        public Query log_out;

        public MoreOptionsScreens(Platform platform, AppManager manager) : base(platform, manager)
        {
            if (OnAndroid)
            {
                edit_profile = x => x.Marked("moreOptions_options_recyclerView").Child(1);
                contact_data = x => x.Marked("moreOptions_options_recyclerView").Child(2);
                log_out = x => x.Marked("moreOptions_options_recyclerView").Child(3);
            }
            else
            {
                edit_profile = x => x.Marked("Настройки профиля");
                contact_data = x => x.Marked("Контактные данные");
                log_out = x => x.Marked("Выйти");
            }
        }
    }
}
