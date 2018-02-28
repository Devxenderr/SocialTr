using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace MAST_UI_Portable
{
    public class ToolsCreatePostScreen : ScreenBase
    {
        public Query toolbarBackButtonTitle_back_imageButton;
        public Query toolbarBackButtonTitle_title_textView;
        public Query createPost_tools_secondTools; // временное решение ( выброр second котироваки )
        public Query createPost_tools_firstTools;  // временное решение ( выброр first котироваки )
        public Query search_button;
        public Query search_close_btn;
        public Query search_src_text; // для ввода текста
        
        

        public ToolsCreatePostScreen(Platform platform, AppManager manager) : base(platform, manager)
        {
            if (OnAndroid)
            {
                createPost_tools_firstTools = x => x.Marked("createPost_tools_recyclerView").Child(0).Child(0);
                createPost_tools_secondTools = x => x.Marked("createPost_tools_recyclerView").Child(1).Child(0);
                search_close_btn = x => x.Marked("search_close_btn");
                search_src_text = x => x.Marked("search_src_text");
                search_button = x => x.Marked("search_button"); 
            }
            if (OniOS)
            {
                toolbarBackButtonTitle_title_textView = x => x.Marked("Инструменты");
                toolbarBackButtonTitle_back_imageButton = x => x.Marked("arrowBackWhite36");
                createPost_tools_secondTools = x => x.Marked("AUDCAD");
                search_button = x => x.Class("UISearchBar");
                search_close_btn = x => x.Marked("Clear text");

            }
        }
    }
}
