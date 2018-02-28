using Xamarin.UITest;
using NUnit.Framework;
using MAST_UI_Portable;

namespace MAST_UI_Smoke.Tests
{
    class MoreOptionsTest : TestBase
    {
        public MoreOptionsTest(Platform platform, string simulatorName) : base(platform, simulatorName, AppManager.GetInstance(platform))
        {
        }
        [SetUp]
        public void BeforeMoreOptionsTests()
        {
            appManager.BaseHelper.Authorization();
            appManager.NavigationHelper.GoToMoreOptions();
        }
        [Test]
        public void CheckUserNameOnMoreOptions()
        {
            appManager.BaseHelper.ChekTextOnElement(appManager.MoreOptionsScreens.moreOptions_nameTitle_textView, user.Name + " " + user.LastName);
        }
        [Test]
        public void TapTolbarBackWithMoreOption()
        {
            appManager.BaseHelper.TapAndWaitElement(appManager.TolbarScreen.toolbar_back_imageButton, appManager.TolbarScreen.posts_createPost_floatingActionButton);
        }
        [Test]
        public void TapBackNativeWithMoreOption()
        {
            if (OnAndroid)
            {
                appManager.App.Back();
                appManager.App.WaitForElement(appManager.TolbarScreen.posts_createPost_floatingActionButton);
            }
            else
            {

            }
            
        }
        
    }
}
