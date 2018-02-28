using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace MAST_UI_Portable
{

    public class ToolbarScreen : ScreenBase
    {

        public Query toolbarOneButton_moreOptions_imageButton = x => x.Marked("toolbarOneButton_moreOptions_imageButton"); // переход на сеттинги
        public Query toolbar_back_imageButton = x => x.Marked("toolbar_back_imageButton"); // назад  
        public Query toolbar_title_textView = x => x.Marked("toolbar_title_textView");


        public Query posts_createPost_floatingActionButton;

        public Query back_btn_on_iOS;


        public ToolbarScreen(Platform platform, AppManager manager) : base(platform, manager)
        {
            if (OnAndroid)
            {
               
                toolbar_back_imageButton = x => x.Marked("toolbar_back_imageButton");
                posts_createPost_floatingActionButton = x => x.Marked("posts_createPost_floatingActionButton");
                
            }
            if (OniOS)
            {
                back_btn_on_iOS = x => x.Marked("Back");
                toolbarOneButton_moreOptions_imageButton = x => x.Marked("Item");
                posts_createPost_floatingActionButton = x => x.Marked("Создать пост");
                
            }
        }
    }
}