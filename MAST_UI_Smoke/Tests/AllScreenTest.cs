using Xamarin.UITest;
using NUnit.Framework;
using MAST_UI_Portable;



namespace MAST_UI_Smoke
{
    public class AllScreenTest : TestBase
    {
        public AllScreenTest(Platform platform, string simulatorName) : base(platform, simulatorName, AppManager.GetInstance(platform))
        {
        }
        //[Test]
        //ublic void Repl()
        //{

            //appManager.App.Repl();
        //}
        [Test]
        public void CheсkAuthScreen()
        {
            
            appManager.SmokeHelper.CheckAllElemOnAuthScreen();
        }

        [Test]
        public void CheсkRegNameScreen()
        {
            appManager.NavigationHelper.GoToEneterNameLastNameScreen();
            appManager.SmokeHelper.CheсkAllelemOnNameReg();
        }
        [Test]
        public void CheckPhoneNumberScreen()
        {
            appManager.NavigationHelper.GoToEneterPhoneNumber();
            appManager.SmokeHelper.CheсkAllelemOnPhoneReg();
        }
        [Test]
        public void CheсkRegEmailScreen()
        {
            appManager.NavigationHelper.GoToEnterEmail();
            appManager.SmokeHelper.CheсkAllelemOnEmailReg();
        }
        [Test]
        public void CheсkPassScreen()
        {
            appManager.NavigationHelper.GoToEneterPass();
            appManager.SmokeHelper.CheсkAllelemOnPassReg();
        }
        [Test]
        public void CheckCreatPostScreen()
        {
            if (OnAndroid)
            {
				appManager.BaseHelper.Authorization();
				appManager.NavigationHelper.GoToCreatePostOnNewsTab();
				appManager.SmokeHelper.CheсkAllelemOnCreatPost();
            }
            if (OniOS)
            {

            }

        }
     
    }
}