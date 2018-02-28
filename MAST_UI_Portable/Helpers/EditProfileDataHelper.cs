using System;
using System.Linq;
using Xamarin.UITest;
using System.Threading;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace MAST_UI_Portable
{
   public class EditContactDataHelper : ScreenBase
    {
        public EditContactDataHelper (Platform platform, AppManager manager) : base (platform, manager)
        {

        }

        public EditContactDataHelper EnterName()
        {
            appManager.App.ClearText(appManager.EditProfileScreen.editProfile_name_editText);
            appManager.App.EnterText(appManager.EditProfileScreen.editProfile_name_editText, user.Name);
            return this;
        }

        public EditContactDataHelper EnterLastName()
        {
            appManager.App.ClearText(appManager.EditProfileScreen.editProfile_lastname_editText);
            appManager.App.EnterText(appManager.EditProfileScreen.editProfile_lastname_editText, user.LastName);
            return this;
        }

        public EditContactDataHelper EnterStatus()
        {
            appManager.App.ClearText(appManager.EditProfileScreen.editProfile_status_editText);
            appManager.App.EnterText(appManager.EditProfileScreen.editProfile_status_editText, user.Status);
            return this;
        }

        public void SaveChangesOnProfile()
        {
            appManager.BaseHelper.TapAndWaitElement(appManager.EditProfileScreen.editProfile_save_button, appManager.AlertScreens.message_on_alert);
            appManager.BaseHelper.TapAndWaitElement(appManager.AlertScreens.ok_on_alert, appManager.MoreOptionsScreens.moreOptions_profile_imageView);
        }

        public void SaveChangeOnContact()
        {
            appManager.BaseHelper.TapAndWaitElement(appManager.EditContactScreen.editContact_save_button, appManager.AlertScreens.message_on_alert);
            appManager.BaseHelper.TapAndWaitElement(appManager.AlertScreens.ok_on_alert, appManager.MoreOptionsScreens.moreOptions_profile_imageView);
        }
     
        public EditContactDataHelper EnterSkype()
        {
            appManager.App.ClearText(appManager.EditContactScreen.editContact_skype_editText);
            appManager.App.EnterText(appManager.EditContactScreen.editContact_skype_editText, user.Skype);
            return this;
        }

        public EditContactDataHelper EnterCity()
        {
            appManager.App.ClearText(appManager.EditContactScreen.editContact_city_editText);
            appManager.App.EnterText(appManager.EditContactScreen.editContact_city_editText, user.City);
            return this;
        }

        public EditContactDataHelper SelectSecondCountryOnList()
        {
            appManager.NavigationHelper.GoToSelectCountry();
            appManager.App.Tap(appManager.ToolsCreatePostScreen.createPost_tools_firstTools);

            return this;
        }

        public EditContactDataHelper SelectCountryFromSearch()
        {
            appManager.NavigationHelper.GoToSelectCountry();
            appManager.App.EnterText(appManager.ToolsCreatePostScreen.search_button, user.Country);
            appManager.App.Tap(appManager.ToolsCreatePostScreen.createPost_tools_firstTools);
            return this;
        }


        public EditContactDataHelper EnterPhoneNumber()
        {
            appManager.App.ClearText(appManager.EditContactScreen.editContact_phone_editText);
            appManager.App.EnterText(appManager.EditContactScreen.editContact_phone_editText, user.PhoneNumber);
            return this;
        }

        public void CancelChangesContact()
        {
            appManager.BaseHelper.TapAndWaitElement(appManager.EditContactScreen.editContact_cancel_button, appManager.MoreOptionsScreens.moreOptions_profile_imageView);
        }
    }
}
