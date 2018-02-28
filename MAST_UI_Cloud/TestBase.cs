using NUnit.Framework;
using Xamarin.UITest;
using MAST_UI_Portable;

namespace MAST_UI_Cloud
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class TestBase : APomBase
    {
        
        public TestBase(Platform platform, AppManager appManager) : base(platform, appManager)
        {
          
        }

        [SetUp]
        public void BeforeEachTest()
        {
            user = new UserData();
            //appManager = AppManager.GetInstance(Platform);
            appManager.Start(Platform);
            appManager.App.WaitForElement(appManager.AuthScreen.auth_auth_button);
        }
    }
}

