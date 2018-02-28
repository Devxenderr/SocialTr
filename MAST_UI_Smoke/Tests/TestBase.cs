using NUnit.Framework;
using Xamarin.UITest;
using MAST_UI_Portable;

namespace MAST_UI_Smoke
{
    // For Local test

    //[TestFixture(Platform.iOS, "DED58D33-C585-43D2-A75F-27DCEC184961")] // se 10.3.1 on mikle mac
    //[TestFixture(Platform.iOS,"E7C8377C-0DA3-47EA-BFFD-D7A303D751A0")] // se 11.2 on mikle mac
    //[TestFixture(Platform.Android, "192.168.115.101:5555")]
    //[TestFixture(Platform.Android, "HJA2QSC9")] 
    //[TestFixture(Platform.Android, "5203d24ee8afc3fb")]
    //[TestFixture(Platform.Android, "K05TJ58110027906")]



    // For TC

    [TestFixture(Platform.iOS, "88AECE30-91BC-4B35-8174-BFB4B11255BA")]
    [TestFixture(Platform.Android, "emulator-5554")]

    public class TestBase : APomBase
    {
        //protected readonly bool OnAndroid;
        //protected readonly bool OniOS;
       // protected Platform _platform;
        //protected AppManager appManager;
        protected string _simulatorName;
        

        protected TestBase(Platform platform, string simulatorName, AppManager manager): base(platform, manager)
        {
            
            //_platform = platform;
            _simulatorName = simulatorName;
           // OnAndroid = platform == Platform.Android;
           // OniOS = platform == Platform.iOS;
        }
    

        [SetUp]
        public void BeforeEachTest()
        {

           
            //appManager = AppManager.GetInstance(Platform);
            appManager.Start(Platform, _simulatorName);
            appManager.App.WaitForElement(appManager.AuthScreen.auth_auth_button);

        }
    }
}

