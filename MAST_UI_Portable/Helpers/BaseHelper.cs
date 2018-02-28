using Xamarin.UITest;
using NUnit.Framework;
using Xamarin.UITest.Queries;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace MAST_UI_Portable
{
    public class BaseHelper : ScreenBase
    {
        public BaseHelper(Platform platform, AppManager manager) : base(platform, manager)
        {

        }

        public string TakeTextFromElement(Query element)
        {
            AppResult[] stringa = appManager.App.WaitForElement(element);
            return stringa[0].Text;
        }

        public BaseHelper ChekTextOnElement(Query element, string text)
        {
            
            Assert.AreEqual(text, TakeTextFromElement(element));
            return this;
        }

        /// <summary>
        /// Сравнение текста на 2х разных елементах
        /// </summary>
        /// <param name="element1"></param>
        /// <param name="element2"></param>
        /// <returns></returns>
        public BaseHelper CompareTextOnTwoElements(Query element1, Query element2)
        {
                       
            Assert.AreEqual(TakeTextFromElement(element1), TakeTextFromElement(element2));
            return this;
        }

  

        public BaseHelper Authorization(string email, string pass)
        {
            appManager.App.EnterText(appManager.AuthScreen.auth_email_editText, email);
            appManager.App.EnterText(appManager.AuthScreen.auth_pass_editText, pass);
            appManager.App.Tap(appManager.AuthScreen.auth_auth_button);
            return this;
        }
        public BaseHelper Authorization(UserData user)
        {
            appManager.App.EnterText(appManager.AuthScreen.auth_email_editText, user.Email);
            appManager.App.EnterText(appManager.AuthScreen.auth_pass_editText, user.Pass);
            appManager.App.Tap(appManager.AuthScreen.auth_auth_button);
            appManager.App.WaitForElement(appManager.TolbarScreen.posts_createPost_floatingActionButton);
            return this;
        }
        public BaseHelper Authorization()
        {
            appManager.App.EnterText(appManager.AuthScreen.auth_email_editText, user.Email);
            appManager.App.EnterText(appManager.AuthScreen.auth_pass_editText, user.Pass);
            appManager.App.Tap(appManager.AuthScreen.auth_auth_button);
            appManager.App.WaitForElement(appManager.TolbarScreen.posts_createPost_floatingActionButton);
            return this;
        }


        public void ScrollDownToElement(Query marked)
        {
            int loop = 0;
            while (appManager.App.Query(marked).Length == 0)
            {
                appManager.App.DragCoordinates(355, 1151, 366, 327);
                loop++;
                if (loop > 15) break;
            }
        }

        public void ScrollUpToElement(Query marked)
        {

            for (int loop = 0; loop > 15; loop++)
            {
               if (appManager.App.Query(marked).Length == 0)
                {
                    break;
                }
                appManager.App.DragCoordinates(366, 327, 355, 1151);

            }
        }
        /// <summary>
        /// нужен ЛИ?
        /// </summary>
        /// <param name="social"></param>
        /// <returns></returns>
        public BaseHelper TapOnElement(Query social)
        {
            appManager.App.Tap(social);
            return this;
        }

        public BaseHelper CheсkEnebled(Query element)
        {
            AppResult[] elementsProperties = appManager.App.WaitForElement(element);
            bool enabledStatus = elementsProperties[0].Enabled;
            Assert.AreEqual(true, enabledStatus);
            return this;

        }
        /// <summary>
        /// Костыль который будет работать только на андроид
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public BaseHelper ChekTextNull(Query element)
        {
            AppResult[] elementsProperties = appManager.App.WaitForElement(element);
            string id = elementsProperties[0].Id;
            string text = elementsProperties[0].Text;
            Assert.AreEqual(text, id);
            return this;
        }
       /// <summary>
       /// не работает, поправить
       /// </summary>
       /// <param name="element"></param>
       /// <returns></returns>
        public bool ChekAvailabilityElement(Query element)
        {
            
            AppResult[] elementsProperties = appManager.App.Query(element);
            string id = elementsProperties[0].Id;
            string text = elementsProperties[0].Text;
            
            if (text == id)
            {
                return true;
            }
            return false;
        }

        public BaseHelper EnterTextWithKeyOnRegistr(string key, string text)
        {
            appManager.App.EnterText(RegistrDictionary.Queries[key], text);
            return this;
        }

        public BaseHelper TapAndWaitElement(Query tapElement, Query waitElement)
        {
            appManager.App.Tap(tapElement);
            appManager.App.WaitForElement(waitElement);
            return this;
        }

        public void LogOut()
        {
            appManager.NavigationHelper.GoToMoreOptions();
            appManager.BaseHelper.TapAndWaitElement(appManager.MoreOptionsScreens.log_out, appManager.AlertScreens.ok_on_alert)
                .TapAndWaitElement(appManager.AlertScreens.ok_on_alert, appManager.AuthScreen.auth_auth_button);

        }




    }
}