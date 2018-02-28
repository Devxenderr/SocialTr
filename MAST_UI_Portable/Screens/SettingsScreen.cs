using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace MAST_UI_Portable
{
    public class SettingsScreen : ScreenBase
    {

        public Query toolbarBackButton_back_imageButton; // назад из настроек 

        public SettingsScreen(Platform platform, AppManager manager) : base(platform, manager)
        {
            

            if (OnAndroid)
            {
                toolbarBackButton_back_imageButton = x => x.Marked("toolbarBackButton_back_imageButton");
            }
            if (OniOS)
            {
                toolbarBackButton_back_imageButton = x => x.Marked("toolbarBackButton_back_imageButton"); // Проверить

            }
        }
    }
}
