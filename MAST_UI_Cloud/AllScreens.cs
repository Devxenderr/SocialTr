using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Xamarin.UITest;
using MAST_UI_Portable;

namespace MAST_UI_Cloud
{
    public class AllScreens : TestBase
    {
        public AllScreens(Platform platform, AppManager manager) : base(platform, manager)
        {

        }
        [Test]
        public void ScreenNewPostHeder()
        {
            appManager.BaseHelper.Authorization();
            appManager.App.Screenshot("News");
        }
        //[Test]
        //public void ScreenForgotPass()
        //{
        //    appManager.App.Screenshot("AuthScreen");
        //    appManager.NavigationHelper.GoToForgotPass();
        //    appManager.App.Screenshot("ForgotPass");
        //}

        //[Test]
        //public void ScreenForgotPass()
        //{
        //    appManager.App.Screenshot("AuthScreen");
        //    appManager.NavigationHelper.GoToForgotPass();
        //    appManager.App.Screenshot("ForgotPass");
        //}

        //[Test]
        //public void ScreenAuth()
        //{
        //    appManager.App.Screenshot("AuthScreen");
        //    appManager.App.Tap(appManager.AuthScreen.auth_auth_button);
        //    appManager.App.Screenshot("AuthWithInvalidMessage");
        //}
        //[Test]
        //public void ScreenAllReg()
        //{
        //    appManager.NavigationHelper.GoToEneterNameLastNameScreen();
        //    appManager.App.Screenshot("RegNameClean");
        //    appManager.App.Tap(appManager.RegistrScreen.reg_follow_phone_button);
        //    appManager.App.Screenshot("RegNameWithInvalidMessage");
        //    appManager.NavigationHelper.GoToEneterPhoneNumberFromName();
        //    appManager.App.Screenshot("RegPhoneNumberClean");
        //    appManager.App.Tap(appManager.RegistrScreen.reg_follow_email_button);
        //    appManager.App.Screenshot("RegPhoneNumberWithInvalidMessage");
        //    appManager.NavigationHelper.GoToEnterEmailFromPhoneNumber();
        //    appManager.App.Screenshot("RegEmailClean");
        //    appManager.App.Tap(appManager.RegistrScreen.reg_follow_pass_button);
        //    appManager.App.Screenshot("RegEmailWithInvalidMessage");
        //    appManager.NavigationHelper.GoToEneterPassFromEmail();
        //    appManager.App.Screenshot("RegEneterPassClean");
        //    appManager.App.Tap(appManager.RegistrScreen.reg_follow_main_button);
        //    appManager.App.Screenshot("RegEneterPassWithInvalidMessage");
        //}
        //[Test]
        //public void ScreenCreartePost()
        //{
        //    appManager.BaseHelper.Authorization();
        //    appManager.NavigationHelper.GoToCreatePostOnNewsTab();
        //    appManager.App.Screenshot("CreatePostClean");
        //    appManager.App.Tap(appManager.CreatePostScreen.toolbarOneButtonBack_button);
        //    appManager.App.Screenshot("GreatePostWithInvalidMessage");
        //}
        //[Test]
        //public void ScreenSettings()
        //{
        //    if (onAndroid)
        //    {
        //        appManager.BaseHelper.Authorization();
        //        appManager.NavigationHelper.GoToSettings();
        //        appManager.App.Screenshot("Settings");
        //    }
        //    if (oniOS)
        //    {

        //    }
            
        //}
    }
}
