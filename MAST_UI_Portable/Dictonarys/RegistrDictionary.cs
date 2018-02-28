using System;
using System.Collections.Generic;
using Xamarin.UITest.Queries;


namespace MAST_UI_Portable
{
    public static class RegistrDictionary
    {
        public static Dictionary<string, Func<AppQuery, AppQuery>> Queries { get; private set; }
        public static Dictionary<string, Func<AppQuery, AppQuery>> QueriesName { get; private set; }
        public static Dictionary<string, Func<AppQuery, AppQuery>> QueriesPhone { get; private set; }
        public static Dictionary<string, Func<AppQuery, AppQuery>> QueriesEmail { get; private set; }
        public static Dictionary<string, Func<AppQuery, AppQuery>> QueriesPass { get; private set; }
        public static Dictionary<string, Func<AppQuery, AppQuery>> QueriesTest { get; private set; }

        public static Dictionary<string, Func<AppQuery, AppQuery>> QueriesNameAndroid { get; private set; }
        public static Dictionary<string, Func<AppQuery, AppQuery>> QueriesNameIos { get; private set; }
        public static Dictionary<string, Func<AppQuery, AppQuery>> QueriesPhoneAndroid { get; private set; }
        public static Dictionary<string, Func<AppQuery, AppQuery>> QueriesPhoneIos { get; private set; }
        public static Dictionary<string, Func<AppQuery, AppQuery>> QueriesEmailAndriod { get; private set; }
        public static Dictionary<string, Func<AppQuery, AppQuery>> QueriesEmailIos { get; private set; }
        public static Dictionary<string, Func<AppQuery, AppQuery>> QueriesPassAndroid { get; private set; }
        public static Dictionary<string, Func<AppQuery, AppQuery>> QueriesPassIos { get; private set; }

        public static void Init()
        {
            AppManager appManager = AppManager.GetInstance();

           
            // screen add name lastname 
            QueriesName = new Dictionary<string, Func<AppQuery, AppQuery>>
            {
                
                
                {"regName_logo_imageView", appManager.RegistrScreen.regName_logo_imageView},
                {"reg_enterName_textView", appManager.RegistrScreen.reg_enterName_textView},
                {"reg_name_editText", appManager.RegistrScreen.reg_name_editText},
                {"reg_lastname_editText", appManager.RegistrScreen.reg_lastname_editText},
                //{"reg_invalid_name_textView", appManager.RegistrScreen.reg_invalid_name_textView},
                //{"reg_invalid_lastname_textView", appManager.RegistrScreen.reg_invalid_lastname_textView},
                {"reg_follow_phone_button", appManager.RegistrScreen.reg_follow_phone_button}
            };

            QueriesNameAndroid = new Dictionary<string, Func<AppQuery, AppQuery>>
            {
                {"regName_back_imageButton", appManager.RegistrScreen.regName_back_imageButton},
            };
            foreach (var item in QueriesName)
            {
                QueriesNameAndroid.Add(item.Key, item.Value);
            }

            QueriesNameIos = new Dictionary<string, Func<AppQuery, AppQuery>>
            {
                { "reg_name_textView_ios", appManager.RegistrScreen.reg_name_textView_ios},
                { "reg_lastname_textView_ios", appManager.RegistrScreen.reg_lastname_textView_ios},
            };
            foreach (var item in QueriesName)
            {
                QueriesNameIos.Add(item.Key, item.Value);
            }
            // screen add ADD PHONE
            QueriesPhone = new Dictionary<string, Func<AppQuery, AppQuery>>
            {
                {"regPhone_logo_imageView", appManager.RegistrScreen.regPhone_logo_imageView},
                {"reg_enterPhone_textView", appManager.RegistrScreen.reg_enterPhone_textView},
                {"reg_phoneCountry_editText", appManager.RegistrScreen.reg_phoneCountry_editText},
                {"reg_phoneNumber_editText", appManager.RegistrScreen.reg_phoneNumber_editText},
                {"reg_follow_email_button", appManager.RegistrScreen.reg_follow_email_button},
                {"reg_skip_phone_button", appManager.RegistrScreen.reg_skip_phone_button},
            };
            QueriesPhoneAndroid = new Dictionary<string, Func<AppQuery, AppQuery>>
            {
                {"regPhone_back_imageButton", appManager.RegistrScreen.regPhone_back_imageButton},
            };
            foreach (var item in QueriesPhone)
            {
                QueriesPhoneAndroid.Add(item.Key, item.Value);
            }
            QueriesPhoneIos = new Dictionary<string, Func<AppQuery, AppQuery>>
            {
                {"reg_phoneCountry_textView_ios", appManager.RegistrScreen.reg_phoneCountry_textView_ios},
                {"reg_phoneNumber_textView_ios", appManager.RegistrScreen.reg_phoneNumber_textView_ios},
            };
            foreach (var item in QueriesPhone)
            {
                QueriesPhoneIos.Add(item.Key, item.Value);
            }



            // screen add ADD EMAIL
            QueriesEmail = new Dictionary<string, Func<AppQuery, AppQuery>>
            {
                {"regEmail_logo_imageView", appManager.RegistrScreen.regEmail_logo_imageView},
                {"reg_enterEmail_textView", appManager.RegistrScreen.reg_enterEmail_textView},
                {"reg_email_editText", appManager.RegistrScreen.reg_email_editText},
                {"reg_follow_pass_button", appManager.RegistrScreen.reg_follow_pass_button},
                //{"reg_invalid_email_textView", appManager.RegistrScreen.reg_invalid_email_textView},
            };
            QueriesEmailAndriod = new Dictionary<string, Func<AppQuery, AppQuery>>
            {
                {"regEmail_back_imageButton", appManager.RegistrScreen.regEmail_back_imageButton},
            };
            foreach (var item in QueriesEmail)
            {
                QueriesEmailAndriod.Add(item.Key, item.Value);
            }
            QueriesEmailIos = new Dictionary<string, Func<AppQuery, AppQuery>>
            {
                {"reg_email_textView_ios", appManager.RegistrScreen.reg_email_textView_ios},
                
            };
            foreach (var item in QueriesEmail)
            {
                QueriesEmailIos.Add(item.Key, item.Value);
            }


            QueriesPass = new Dictionary<string, Func<AppQuery, AppQuery>>
            {
                
                {"regPass_logo_imageView", appManager.RegistrScreen.regPass_logo_imageView},
                {"reg_enterPass_textView", appManager.RegistrScreen.reg_enterPass_textView},
                {"reg_pass_editText", appManager.RegistrScreen.reg_pass_editText},
                {"reg_confirm_pass_editText", appManager.RegistrScreen.reg_confirm_pass_editText},
                {"reg_user_agreement_textView", appManager.RegistrScreen.reg_userAgreement_textView},
                {"reg_follow_main_button", appManager.RegistrScreen.reg_follow_main_button},
                //{"reg_invalid_pass_textView", appManager.RegistrScreen.reg_invalid_pass_textView},
                //{"reg_invalid_passconfirm_textView", appManager.RegistrScreen.reg_invalid_passconfirm_textView},
            };
            QueriesPassAndroid = new Dictionary<string, Func<AppQuery, AppQuery>>
            {
                {"regPass_back_imageButton", appManager.RegistrScreen.regPass_back_imageButton},

            };
            foreach (var item in QueriesPass)
            {
                QueriesPassAndroid.Add(item.Key, item.Value);
            }
            QueriesPassIos = new Dictionary<string, Func<AppQuery, AppQuery>>
            {
                {"reg_pass_textView_ios", appManager.RegistrScreen.reg_pass_textView_ios},
                {"reg_confirm_pass_textView_ios", appManager.RegistrScreen.reg_confirm_pass_textView_ios},

            };
            foreach (var item in QueriesPass)
            {
                QueriesPassIos.Add(item.Key, item.Value);
            }

            Queries = new Dictionary<string, Func<AppQuery, AppQuery>>(); // Доделать сбор всех колекций
            //name
            foreach (var item in QueriesNameAndroid)
            {
                if (!Queries.ContainsKey(item.Key))
                {
                    Queries.Add(item.Key, item.Value);
                }
            }
            foreach (var item in QueriesNameIos)
            {
                if (!Queries.ContainsKey(item.Key))
                {
                    Queries.Add(item.Key, item.Value);
                }
            }
            //phone
            foreach (var item in QueriesPhoneAndroid)
            {
                if (!Queries.ContainsKey(item.Key))
                {
                    Queries.Add(item.Key, item.Value);
                }
            }
            foreach (var item in QueriesPhoneIos)
            {
                if (!Queries.ContainsKey(item.Key))
                {
                    Queries.Add(item.Key, item.Value);
                }
            }
            //email
            foreach (var item in QueriesEmailAndriod)
            {
                if (!Queries.ContainsKey(item.Key))
                {
                    Queries.Add(item.Key, item.Value);
                }
            }
            foreach (var item in QueriesEmailIos)
            {
                if (!Queries.ContainsKey(item.Key))
                {
                    Queries.Add(item.Key, item.Value);
                }
            }
            //pass
            foreach (var item in QueriesPassAndroid)
            {
                if (!Queries.ContainsKey(item.Key))
                {
                    Queries.Add(item.Key, item.Value);
                }
            }
            foreach (var item in QueriesPassIos)
            {
                if (!Queries.ContainsKey(item.Key))
                {
                    Queries.Add(item.Key, item.Value);
                }
            }
            
        }
    }
}