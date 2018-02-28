using System;
using System.Collections.Generic;
using Xamarin.UITest.Queries;

namespace MAST_UI_Portable
{
    public static class CreatePostDictionary
    {
        public static Dictionary<string, Func<AppQuery, AppQuery>> Queries { get; private set; }
        public static Dictionary<string, Func<AppQuery, AppQuery>> QueriesAndroid { get; private set; }
        public static Dictionary<string, Func<AppQuery, AppQuery>> QueriesIos { get; private set; }


        public static void Init()
        {
            AppManager appManager = AppManager.GetInstance();

            Queries = new Dictionary<string, Func<AppQuery, AppQuery>>
            {
                {"toolbarOneButtonBack_back_relativeLayout", appManager.CreatePostScreen.toolbarOneButtonBack_back_imageButton},
                {"toolbarOneButtonBack_title_textView", appManager.CreatePostScreen.toolbarOneButtonBack_title_textView},
                {"toolbarOneButtonBack_button", appManager.CreatePostScreen.toolbarOneButtonBack_button},
                {"createPost_profilePhoto_imageView", appManager.CreatePostScreen.createPost_profilePhoto_imageView},
                {"createPost_profileName_textView", appManager.CreatePostScreen.createPost_profileName_textView},
                {"createPost_tools_textView", appManager.CreatePostScreen.createPost_tools_textView},
                {"createPost_price_textView", appManager.CreatePostScreen.createPost_price_textView},
                {"createPost_buySell_textView", appManager.CreatePostScreen.createPost_buySell_textView},
                {"createPost_time_textView", appManager.CreatePostScreen.createPost_time_textView},
                {"createPost_accessMode_textView", appManager.CreatePostScreen.createPost_accessMode_textView},
                {"createPost_comment_editText", appManager.CreatePostScreen.createPost_comment_editText},
                //{"createPost_attachment_textView", appManager.CreatePostScreen.createPost_attachment_textView},
                {"createPost_addImage_button", appManager.CreatePostScreen.createPost_addImage_button},
                //{"", appManager.CreatePostScreen.},
            };
            QueriesAndroid = new Dictionary<string, Func<AppQuery, AppQuery>>();
            foreach (var item in Queries)
            {
                QueriesAndroid.Add(item.Key, item.Value);
            }
            QueriesIos = new Dictionary<string, Func<AppQuery, AppQuery>>
            {
                {"createPost_done_picker", appManager.CreatePostScreen.createPost_done_picker},
                {"createPost_cancel_picker", appManager.CreatePostScreen.createPost_cancel_picker},
                {"createPost_label_picker", appManager.CreatePostScreen.createPost_label_picker},
            };
            foreach (var item in Queries)
            {
                QueriesIos.Add(item.Key, item.Value);
            }

        }
    }
}
