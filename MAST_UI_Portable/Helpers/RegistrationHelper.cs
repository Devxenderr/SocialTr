using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;



namespace MAST_UI_Portable
{
    public class RegistrationHelper : ScreenBase
    {
        public RegistrationHelper(Platform platform, AppManager manager) : base(platform, manager)
        {

        }
        public RegistrationHelper GoBackOnAllRegistrScreensCustomButton(Query backCastomButton, Query elementForCheckOnNewScreen)
        {
                appManager.App.Tap(backCastomButton);
				appManager.App.WaitForElement(elementForCheckOnNewScreen);
                return this;
        }
        public RegistrationHelper GoBackOnAllRegistrScreensNativeBack(Query elementForCheckOnNewScreen)
        {
            appManager.App.Back();
            appManager.App.WaitForElement(elementForCheckOnNewScreen);
            return this;
        }

        /// <summary>
        /// Проверить работу на iOS
        /// </summary>
        /// <returns></returns>
        public RegistrationHelper SmokeBackFromEnterPassToAuthScreenCustomButton()
        {
            appManager.NavigationHelper.GoToEneterPass();
            GoBackOnAllRegistrScreensCustomButton(appManager.RegistrScreen.regPass_back_imageButton, appManager.RegistrScreen.regEmail_back_imageButton);
            GoBackOnAllRegistrScreensCustomButton(appManager.RegistrScreen.regEmail_back_imageButton, appManager.RegistrScreen.regPhone_back_imageButton);
            GoBackOnAllRegistrScreensCustomButton(appManager.RegistrScreen.regPhone_back_imageButton, appManager.RegistrScreen.regName_back_imageButton);
            GoBackOnAllRegistrScreensCustomButton(appManager.RegistrScreen.regName_back_imageButton, appManager.AuthScreen.auth_auth_button);
            return this;
        }
        public RegistrationHelper SmokeBackFromEnterPassToAuthScreenNativeBack()
        {
            appManager.NavigationHelper.GoToEneterPass();
            GoBackOnAllRegistrScreensNativeBack(appManager.RegistrScreen.regEmail_back_imageButton);
            GoBackOnAllRegistrScreensNativeBack(appManager.RegistrScreen.regPhone_back_imageButton);
            GoBackOnAllRegistrScreensNativeBack(appManager.RegistrScreen.regName_back_imageButton);
            GoBackOnAllRegistrScreensNativeBack(appManager.AuthScreen.auth_auth_button);
            return this;

        }


        // переделать
        public RegistrationHelper EnterValidPhoneNubmer(string code, string number)
        {
            appManager.App.EnterText(appManager.RegistrScreen.reg_phoneCountry_editText, code);
            appManager.App.EnterText(appManager.RegistrScreen.reg_phoneNumber_editText, number);
            appManager.App.Tap(appManager.RegistrScreen.reg_follow_email_button);
            return this;
        }
        public RegistrationHelper EnterValidPhoneNubmer(UserData User)
        {
            return EnterValidPhoneNubmer(User.CodeCount, User.PhoneNumber);
        }
        /// <summary>
        /// Возможно удалить
        /// </summary>
        /// <returns></returns>
        public RegistrationHelper EnterValidPhoneNubmer()
        {
            return EnterValidPhoneNubmer(user.CodeCount, user.PhoneNumber);
        }


        public RegistrationHelper EnterValidNameLastName(string name, string lastName)
        {
            appManager.App.EnterText(appManager.RegistrScreen.reg_name_editText, name);
            appManager.App.EnterText(appManager.RegistrScreen.reg_lastname_editText, lastName);
            appManager.App.DismissKeyboard();
            appManager.App.Tap(appManager.RegistrScreen.reg_follow_phone_button);
            return this;
        }
        public RegistrationHelper EnterValidNameLastName(UserData User)
        {
            appManager.App.EnterText(appManager.RegistrScreen.reg_name_editText, User.Name);
            appManager.App.EnterText(appManager.RegistrScreen.reg_lastname_editText, User.LastName);
            appManager.App.DismissKeyboard();
            appManager.App.Tap(appManager.RegistrScreen.reg_follow_phone_button);
            return this;
        }
    }
}