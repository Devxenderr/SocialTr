using System;
using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace MAST_UI_Portable
{
    public class NavigationHelper : ScreenBase
    {
        public NavigationHelper(Platform platform, AppManager manager) : base(platform, manager)
        {

        }


        public NavigationHelper GoToEneterNameLastNameScreen()
        {
            appManager.App.Tap(appManager.AuthScreen.auth_reg_button);
            appManager.App.WaitForElement(appManager.RegistrScreen.reg_name_editText);
            return this;
        }

        public NavigationHelper GoToMoreOptions()
        {
            appManager.App.Tap(appManager.TolbarScreen.toolbarOneButton_moreOptions_imageButton);
            if (OnAndroid)
            {
                
                appManager.App.WaitForElement(appManager.TolbarScreen.toolbar_back_imageButton);
                return this;
            }
            else
            {
                appManager.App.WaitForElement(appManager.MoreOptionsScreens.moreOptions_nameTitle_textView);
                return this;
            }
        }

        public NavigationHelper GoToEneterPhoneNumber()
        {
            GoToEneterNameLastNameScreen();
            appManager.RegistrHelper.EnterValidNameLastName(user);
            appManager.App.DismissKeyboard();
            appManager.App.WaitForElement(appManager.RegistrScreen.reg_skip_phone_button);
            return this;
        }

        public NavigationHelper GoToEneterPhoneNumberFromName()
        {
            appManager.RegistrHelper.EnterValidNameLastName(user);
            appManager.App.DismissKeyboard();
            appManager.App.WaitForElement(appManager.RegistrScreen.reg_skip_phone_button);
            return this;
        }

        public NavigationHelper GoToEnterEmail()
        {
            GoToEneterPhoneNumber();
            appManager.App.Tap(appManager.RegistrScreen.reg_skip_phone_button);
            appManager.App.WaitForElement(appManager.RegistrScreen.reg_follow_pass_button);
            //ClosedAlertOnAddEmail();  нужно для девайсов с выриантом выбора эмейл
            return this;
        }

        public NavigationHelper GoToEnterEmailFromPhoneNumber()
        {
            appManager.App.Tap(appManager.RegistrScreen.reg_skip_phone_button);
            appManager.App.WaitForElement(appManager.RegistrScreen.reg_follow_pass_button);
            //ClosedAlertOnAddEmail();  нужно для девайсов с выриантом выбора эмейл
            return this;
        }

        public NavigationHelper ClosedAlertOnAddEmail()
        {
            appManager.App.WaitForElement(appManager.RegistrScreen.alertTitle);
            appManager.App.Tap(appManager.RegistrScreen.alrt_cancel_button);
            appManager.App.WaitForElement(appManager.RegistrScreen.reg_follow_pass_button);
            return this;

        }

        public NavigationHelper GoToEneterPass()
        {
            GoToEnterEmail();
            appManager.App.EnterText(appManager.RegistrScreen.reg_email_editText, user.Email);//"123@123.123");
            appManager.App.Tap(appManager.RegistrScreen.reg_follow_pass_button);
            appManager.App.WaitForElement(appManager.RegistrScreen.regPass_logo_imageView);
            appManager.App.DismissKeyboard();
            return this;
        }

        public NavigationHelper GoToEneterPassFromEmail()
        {
            appManager.App.EnterText(appManager.RegistrScreen.reg_email_editText, user.Email);//"123@123.123");
            appManager.App.Tap(appManager.RegistrScreen.reg_follow_pass_button);
            appManager.App.WaitForElement(appManager.RegistrScreen.regPass_logo_imageView);
            appManager.App.DismissKeyboard();
            return this;
        }
        
        public NavigationHelper GoToForgotPass()
        {
            appManager.App.Tap(appManager.AuthScreen.auth_forgot_textView);
            appManager.App.WaitForElement(appManager.AuthScreen.pass_retrive_button);
            return this;
        }

        public void GoToCreatePostOnNewsTab()
        {
            appManager.BaseHelper.TapAndWaitElement(appManager.TolbarScreen.posts_createPost_floatingActionButton, appManager.CreatePostScreen.createPost_profilePhoto_imageView);
        }

        public void GoToEditProfile()
        {
            GoToMoreOptions();
            appManager.BaseHelper.TapAndWaitElement(appManager.MoreOptionsScreens.edit_profile, appManager.EditProfileScreen.editProfile_name_editText);
        }

        public void GoToContactData()
        {
            GoToMoreOptions();
            appManager.BaseHelper.TapAndWaitElement(appManager.MoreOptionsScreens.contact_data, appManager.EditContactScreen.editContact_email_editText);

        }

        public void GoToSelectCountry()
        {
            appManager.BaseHelper.TapAndWaitElement(appManager.EditContactScreen.editContact_country_editText, appManager.ToolsCreatePostScreen.search_button);

        }
    }

}
