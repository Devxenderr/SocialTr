using Xamarin.UITest;
using NUnit.Framework;
using MAST_UI_Portable;

namespace MAST_UI_Smoke.Tests
{
    class SmokeRegistTest : TestBase
    {
        public SmokeRegistTest(Platform platform, string simulatorName) : base(platform, simulatorName, AppManager.GetInstance(platform))
        {

        }

        [Test]
        public void CheckBackOnAllRegScreensNativeBack()
        {
            if (OnAndroid)
            {
                appManager.RegistrHelper.SmokeBackFromEnterPassToAuthScreenNativeBack();
            }
            if (OniOS)
            {

            }

        }
        [Test]
        public void CheckBackOnAllRegScreensCustomBack()
        {
            appManager.RegistrHelper.SmokeBackFromEnterPassToAuthScreenCustomButton();
        }
        [Test]
        public void EnterValidPhoneOnReg()
        {
            appManager.NavigationHelper.GoToEneterPhoneNumber();
            appManager.RegistrHelper.EnterValidPhoneNubmer();
            appManager.SmokeHelper.CheсkAllelemOnEmailReg();
        }



    }
}
