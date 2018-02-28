using System;
using System.Collections.Generic;
using Xamarin.UITest.Queries;

namespace MAST_UI_Portable
{
    public static class AuthDictionary
    {
        public static Dictionary<string, Func<AppQuery, AppQuery>> Queries { get; private set; }
        public static Dictionary<string, Func<AppQuery, AppQuery>> QueriesAndroid { get; private set; }
        public static Dictionary<string, Func<AppQuery, AppQuery>> QueriesIos { get; private set; }

        public static void Init()
        {
            AppManager appManager = AppManager.GetInstance();

            Queries = new Dictionary<string, Func<AppQuery, AppQuery>>
            {
                {"auth_logo_imageView", appManager.AuthScreen.auth_logo_imageView},
                {"auth_slogan_textViewView", appManager.AuthScreen.auth_slogan_textViewView},
                {"auth_email_editText", appManager.AuthScreen.auth_email_editText},
                //{"auth_invalid_email_textView", appManager.AuthScreen.auth_invalid_email_textView},
                {"auth_pass_editText", appManager.AuthScreen.auth_pass_editText},
                //{"auth_invalid_pass_textView", appManager.AuthScreen.auth_invalid_pass_textView},
                {"auth_auth_button", appManager.AuthScreen.auth_auth_button},
                {"auth_forgot_textView", appManager.AuthScreen.auth_forgot_textView},
                //{"auth_socialEnter_textView", appManager.AuthScreen.auth_socialEnter_textView},
                //{"auth_vk_imageButton", appManager.AuthScreen.auth_vk_imageButton},
                //{"auth_odnokl_imageButton", appManager.AuthScreen.auth_odnokl_imageButton},
                //{"auth_google_imageButton", appManager.AuthScreen.auth_google_imageButton},
                {"auth_facebook_imageButton", appManager.AuthScreen.newauth_facebook_imageButton},
                {"auth_noAccount_textView", appManager.AuthScreen.auth_noAccount_textView},
                {"auth_reg_button", appManager.AuthScreen.auth_reg_button},
                
                //{"", appManager.AuthScreen.},

            };
            QueriesAndroid = new Dictionary<string, Func<AppQuery, AppQuery>>();
            foreach (var item in Queries)
            {
                QueriesAndroid.Add(item.Key, item.Value);
            }
            QueriesIos = new Dictionary<string, Func<AppQuery, AppQuery>>
            {
                {"auth_email_textView_iOS", appManager.AuthScreen.auth_email_textView_iOS},
                {"auth_pass_textView_iOS", appManager.AuthScreen.auth_pass_textView_iOS},
            };
            foreach (var item in Queries)
            {
                QueriesIos.Add(item.Key, item.Value);
            }
        }
    }
}