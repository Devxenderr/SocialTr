using Xamarin.UITest;
using NUnit.Framework;
using MAST_UI_Portable;

namespace MAST_UI_Smoke
{
    class SmokeCreatePostTest : TestBase
    {
       
        public SmokeCreatePostTest(Platform platform, string simulatorName) : base(platform, simulatorName, AppManager.GetInstance(platform))
        {

        }

        [SetUp]
        public void BeforeCreatPostTests()
        {
            appManager.BaseHelper.Authorization();
        }

        [Test]
        public void TapAllElementOnCreatPost()
        { 
                appManager.NavigationHelper.GoToCreatePostOnNewsTab();
				appManager.CreatePostHelper.SmokeTapAllElement();
            
        }
        [Test]
        public void GoBackOnCreatPost()
        {
				appManager.NavigationHelper.GoToCreatePostOnNewsTab();
				appManager.CreatePostHelper.GoBackOnCreatePost();
        }

        [Test]
        [TestCase(EBuySell.Buy, EForecastTime.Minute15, EAccess.Private, "Text for CI 15")]
        [TestCase(EBuySell.Sell, EForecastTime.Minute30, EAccess.Private, "Text for CI 30")]
        public void CreateValidPost(EBuySell buySellCancel, EForecastTime forecastTime, EAccess eAccess, string text)
        {

            appManager.NavigationHelper.GoToCreatePostOnNewsTab();
            appManager.CreatePostHelper.SelectOneTools().
                SelectInformationForCreatePost(buySellCancel, forecastTime, eAccess, text).
                CreatePostOnCreatePostScreen().
                ChekCreationsPosts(text);

        }
        [Test]
        [TestCase(EBuySell.Buy, EForecastTime.Minute15, EAccess.Cancel, "invalid post")]
        [TestCase(EBuySell.Sell, EForecastTime.Cancel, EAccess.Private, "invalid post")]
        [TestCase(EBuySell.Cancel, EForecastTime.Hour8, EAccess.Private, "invalid post")]
        [TestCase(EBuySell.Sell, EForecastTime.Hour8, EAccess.Private, "")]
        public void CreateInvalidPost(EBuySell buySellCancel, EForecastTime forecastTime, EAccess eAccess, string text)
        {
            appManager.NavigationHelper.GoToCreatePostOnNewsTab();
            appManager.CreatePostHelper.SelectOneTools().
                SelectInformationForCreatePost(buySellCancel, forecastTime, eAccess, text).
                CreatePostOnCreatePostScreen().
                ChekNoCreationsPosts();
        }
        [Test]
        [TestCase(EBuySell.Buy, EForecastTime.Minute15, EAccess.Private, "invalid post")]
        public void CreateInvalidPostWithoutTools(EBuySell buySellCancel, EForecastTime forecastTime, EAccess eAccess, string text)
        {
            appManager.NavigationHelper.GoToCreatePostOnNewsTab();
            appManager.CreatePostHelper.SelectInformationForCreatePost(buySellCancel, forecastTime, eAccess, text).
                CreatePostOnCreatePostScreen().
                ChekNoCreationsPosts();
        }



    }
}
