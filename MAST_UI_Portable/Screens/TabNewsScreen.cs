using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace MAST_UI_Portable
{
    public class TabNewsScreen : ScreenBase
    {
        //public Query news_createPost_floatingActionButton;
        
        
        
           

        public TabNewsScreen(Platform platform, AppManager manager) : base(platform, manager)
        {
           

            if (OnAndroid)
            {

                //news_createPost_floatingActionButton = x => x.Marked("posts_createPost_floatingActionButton");
                
                

            }
            if (OniOS)
            {
                //news_createPost_floatingActionButton = x => x.Class("").Marked("posts_createPost_floatingActionButton");
            }
        }
    }

}
