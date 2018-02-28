using System;
using System.Linq;
using Xamarin.UITest;
using System.Threading;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace MAST_UI_Portable
{
    public class CreatePostHelper : ScreenBase
    {
        public CreatePostHelper(Platform platform, AppManager manager) : base(platform, manager)
        {

        }

        public CreatePostHelper ChekAllElementOnCreatePost()
        {
            if (OnAndroid)
            {
                for (int col = 0; col < CreatePostDictionary.QueriesAndroid.Count; col++)
                {

                    appManager.App.WaitForElement(CreatePostDictionary.QueriesAndroid.ElementAt(col).Value);
                }
            }
            else
            { 
                for (int col = 0; col < CreatePostDictionary.QueriesIos.Count; col++)
                {

                    appManager.App.WaitForElement(CreatePostDictionary.QueriesIos.ElementAt(col).Value);
                }
            }
            return this;

        }

        public CreatePostHelper GoBackOnCreatePost()
        {
            appManager.App.Tap(appManager.CreatePostScreen.toolbarOneButtonBack_back_imageButton);
            appManager.App.WaitForElement(appManager.TolbarScreen.posts_createPost_floatingActionButton);
            return this;
        }

        public CreatePostHelper SmokeTapAllElement()
        {
            appManager.App.Tap(appManager.CreatePostScreen.toolbarOneButtonBack_button);
            appManager.App.WaitForElement(appManager.CreatePostScreen.createPost_tools_textView);
            appManager.App.Tap(appManager.CreatePostScreen.createPost_tools_textView);
            appManager.App.WaitForElement(appManager.ToolsCreatePostScreen.toolbarBackButtonTitle_title_textView);
            if (OnAndroid)
            {
                appManager.App.Back();
            }
            else
            {
                appManager.App.Tap(appManager.ToolsCreatePostScreen.toolbarBackButtonTitle_back_imageButton);
            }
            appManager.App.Tap(appManager.CreatePostScreen.createPost_buySell_textView);
            appManager.App.Tap(appManager.AlertScreens.cancel_on_alert);
            appManager.App.Tap(appManager.CreatePostScreen.createPost_time_textView);
            appManager.App.Tap(appManager.AlertScreens.cancel_on_alert);
            appManager.App.Tap(appManager.CreatePostScreen.createPost_accessMode_textView);
            appManager.App.Tap(appManager.AlertScreens.cancel_on_alert);

            return this;
        }
        // Проверить нужен данныей метод или нет
        public CreatePostHelper SelectInformationForCreatePost(EBuySell buySellCancel, EForecastTime forecastTime, EAccess eAccess, string text)
        {
            SelectBuySell(buySellCancel);
            SelectTime(forecastTime);
            SelectAccess(eAccess);
            appManager.App.EnterText(appManager.CreatePostScreen.createPost_comment_editText, text);
            return this;
        }

        private CreatePostHelper SelectBuySell(EBuySell buySellCancel)
        {

            appManager.App.Tap(appManager.CreatePostScreen.createPost_buySell_textView);
            switch (buySellCancel)
            {
                case EBuySell.Buy:
                    if (OnAndroid)
                    {
                        appManager.App.Tap(appManager.AlertScreens.button1_on_alert);
                    }
                    else
                    {
                        appManager.App.Tap(appManager.CreatePostScreen.createPost_recommend_buy_ios);
                        appManager.App.Tap(appManager.AlertScreens.ok_on_alert);
                    }
                    break;
                case EBuySell.Sell:
                    if (OnAndroid)
                    {
                        appManager.App.Tap(appManager.AlertScreens.button2_on_alert);
                    }
                    else
                    {
                        appManager.App.Tap(appManager.CreatePostScreen.createPost_recommend_sell_ios);
                        appManager.App.Tap(appManager.AlertScreens.ok_on_alert);
                    }
                    break;
                case EBuySell.Cancel:
                    appManager.App.Tap(appManager.AlertScreens.cancel_on_alert);
                    break;
            }
            return this;
        }
        public CreatePostHelper CreatePostOnCreatePostScreen() 
        {
            appManager.App.Tap(appManager.CreatePostScreen.toolbarOneButtonBack_button);
            return this;
        }

        public CreatePostHelper ChekCreationsPosts(string text) 
        {
            //appManager.App.WaitForElement(appManager.PostScreen.postBody_comment_textView);
            //appManager.BaseHelper.ChekTextOnElement(appManager.PostScreen.postBody_comment_textView, text);
            appManager.App.WaitForElement(appManager.TolbarScreen.posts_createPost_floatingActionButton);
            appManager.App.WaitForElement("Text for CI 15");
            return this;
        }
        /// <summary>
        /// проверка со слипом (заменить)
        /// </summary>
        /// <returns></returns>
        public CreatePostHelper ChekNoCreationsPosts()
        {
            Thread.Sleep(5000);
            appManager.App.WaitForNoElement(appManager.TolbarScreen.posts_createPost_floatingActionButton);
            return this;
        }

        private CreatePostHelper SelectAccess(EAccess access)
        {
            appManager.App.Tap(appManager.CreatePostScreen.createPost_accessMode_textView);
            switch (access)
            {
                case EAccess.Public:
                    if (OnAndroid)
                    {
                        appManager.App.Tap(appManager.AlertScreens.button1_on_alert);
                    }
                    else
                    {
                        appManager.App.Tap(appManager.CreatePostScreen.createPost_access_public_ios);
                        appManager.App.Tap(appManager.AlertScreens.ok_on_alert);
                    }
                    break;
                case EAccess.Private:
                    if (OnAndroid)
                    {
                        appManager.App.Tap(appManager.AlertScreens.button2_on_alert);
                    }
                    else
                    {
                        appManager.App.Tap(appManager.CreatePostScreen.createPost_access_private_ios);
                        appManager.App.Tap(appManager.AlertScreens.ok_on_alert);
                    }
                    break;
                case EAccess.Cancel:
                    appManager.App.Tap(appManager.AlertScreens.cancel_on_alert);
                    break;
            }
        return this;
        }
        
        private CreatePostHelper SelectTime(EForecastTime forecastTime) // прости меня за этот код
        {
            appManager.App.Tap(appManager.CreatePostScreen.createPost_time_textView);
            switch (forecastTime)
            {
                case EForecastTime.Minute15:
                    if (OnAndroid)
                    {
                        appManager.App.Tap(appManager.AlertScreens.button1_on_alert);
                    }
                    else
                    {
                        appManager.App.Tap(appManager.CreatePostScreen.createPost_forecastTime_15m_ios);
                        appManager.App.Tap(appManager.AlertScreens.ok_on_alert);
                    }
                    break;
                case EForecastTime.Minute30:
                    if (OnAndroid)
                    {
                        appManager.App.Tap(appManager.AlertScreens.button2_on_alert);
                    }
                    else
                    {
                        appManager.App.Tap(appManager.CreatePostScreen.createPost_forecastTime_30m_ios);
                        appManager.App.Tap(appManager.AlertScreens.ok_on_alert);
                    }
                    break;
                case EForecastTime.Hour1:
                    if (OnAndroid)
                    {
                        appManager.App.Tap(appManager.AlertScreens.button3_on_alert);
                    }
                    else
                    {
                        appManager.App.Tap(appManager.CreatePostScreen.createPost_forecastTime_1h_ios);
                        appManager.App.Tap(appManager.AlertScreens.ok_on_alert);
                    }
                    break;
                case EForecastTime.Hour4:
                    if (OnAndroid)
                    {
                        appManager.App.Tap(appManager.AlertScreens.button4_on_alert);
                    }
                    else
                    {
                        appManager.App.Tap(appManager.CreatePostScreen.createPost_forecastTime_4h_ios);
                        appManager.App.Tap(appManager.AlertScreens.ok_on_alert);
                    }
                    break;
                case EForecastTime.Hour8:
                    if (OnAndroid)
                    {
                        appManager.App.Tap(appManager.AlertScreens.button5_on_alert);
                    }
                    else
                    {
                        appManager.App.Tap(appManager.CreatePostScreen.createPost_forecastTime_8h_ios);
                        appManager.App.Tap(appManager.AlertScreens.ok_on_alert);
                    }
                    break;
                case EForecastTime.Hour24:
                    if (OnAndroid)
                    {
                        appManager.App.Tap(appManager.AlertScreens.button6_on_alert);
                    }
                    else
                    {
                        appManager.App.Tap(appManager.CreatePostScreen.createPost_forecastTime_24h_ios);
                        appManager.App.Tap(appManager.AlertScreens.ok_on_alert);
                    }
                    break;
                case EForecastTime.Week1:
                    if (OnAndroid)
                    {
                        appManager.App.Tap(appManager.AlertScreens.button7_on_alert);
                    }
                    else
                    {
                        appManager.App.Tap(appManager.CreatePostScreen.createPost_forecastTime_1w_ios);
                        appManager.App.Tap(appManager.AlertScreens.ok_on_alert);
                    }
                    break;
                case EForecastTime.Other:
                    if (OnAndroid)
                    {
                        appManager.App.Tap(appManager.AlertScreens.button8_on_alert);
                    }
                    else
                    {
                        appManager.App.Tap(appManager.CreatePostScreen.createPost_forecastTime_ather_ios);
                        appManager.App.Tap(appManager.AlertScreens.ok_on_alert);
                    }
                    break;
                case EForecastTime.Cancel:
                    appManager.App.Tap(appManager.AlertScreens.cancel_on_alert);
                    break;
            }
            return this;
   
        }
        /// <summary>
        /// Пееределать с учетом возможности выбора инструмента
        /// </summary>
        /// <returns></returns>
        public CreatePostHelper SelectOneTools() 
        {
            appManager.App.Tap(appManager.CreatePostScreen.createPost_tools_textView);
            appManager.App.WaitForElement(appManager.ToolsCreatePostScreen.createPost_tools_secondTools);
            appManager.App.Tap(appManager.ToolsCreatePostScreen.createPost_tools_secondTools);
            return this;
        }
        

    }

}