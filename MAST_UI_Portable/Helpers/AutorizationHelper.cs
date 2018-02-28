using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace MAST_UI_Portable
{
    public class AutorizationHelper : ScreenBase
    {
        public AutorizationHelper(Platform platform, AppManager manager) : base(platform, manager)
        {
            
        }
        public AutorizationHelper EnterNameAndLastName(string email, string pass)
        {
            appManager.App.EnterText(appManager.AuthScreen.auth_email_editText, email);
            appManager.App.EnterText(appManager.AuthScreen.auth_pass_editText, pass);

            return this;
        }
        public AutorizationHelper EnterNameAndLastName(UserData Auth)
        {
            appManager.App.EnterText(appManager.AuthScreen.auth_email_editText, Auth.Email);
            appManager.App.EnterText(appManager.AuthScreen.auth_pass_editText, Auth.Pass);
            return this;
        }
        public AutorizationHelper Testtest(UserData Auth)
        {
            appManager.App.EnterText(appManager.AuthScreen.auth_email_editText, Auth.Email);
            appManager.App.EnterText(appManager.AuthScreen.auth_pass_editText, Auth.Pass);
            return this;
        }
        







        //public AutorizationHelper InvalidMasageOnAuth(Query textBox, string text, Query otherTextBox, Query invalidTextView, string invalidMasage)
        //{
        //    appManager.App.EnterText(textBox, text);
        //    appManager.App.Tap(otherTextBox);
        //    appManager.BaseHelper.ChekTextOnElement(appManager.AuthScreen.auth_invalid_email_textView, invalidMasage);
        //    return this;
        //}
        //public AutorizationHelper AutorizatoinValid(string email, string pass)
        //{
        //    EnterNameAndLastName(email, pass);
        //    appManager.BaseHelper.ChekTextNull(appManager.AuthScreen.auth_invalid_email_textView)
        //                         .ChekTextNull(appManager.AuthScreen.auth_invalid_pass_textView);
        //    appManager.App.Tap(appManager.AuthScreen.auth_auth_button);
        //    appManager.App.WaitForElement(appManager.HederScreen.tabNews);

        //    return this;
        //}

        //public AutorizationHelper AutorizatoinNoValidEmail(string email, string pass, string invalidEmail)
        //{
        //    EnterNameAndLastName(email, pass);
        //    appManager.BaseHelper.ChekTextOnElement(appManager.AuthScreen.auth_invalid_email_textView, invalidEmail);
        //    appManager.App.Tap(appManager.AuthScreen.auth_email_editText);
        //    appManager.BaseHelper.ChekTextNull(appManager.AuthScreen.auth_invalid_pass_textView);
        //    appManager.App.Tap(appManager.AuthScreen.auth_auth_button);
        //    appManager.App.WaitForNoElement(appManager.HederScreen.tabNews);

        //    return this;
        //}

        //public AutorizationHelper AutorizatoinNoValidPass(string email, string pass, string invalidPass)
        //{
        //    EnterNameAndLastName(email, pass);
        //    appManager.App.Tap(appManager.AuthScreen.auth_email_editText);
        //    appManager.BaseHelper.ChekTextOnElement(appManager.AuthScreen.auth_invalid_pass_textView, invalidPass);
        //    appManager.BaseHelper.ChekTextNull(appManager.AuthScreen.auth_invalid_email_textView);
        //    appManager.App.Tap(appManager.AuthScreen.auth_auth_button);
        //    appManager.App.WaitForElement(appManager.HederScreen.tabNews);
        //    return this;

        //}



    }
}
