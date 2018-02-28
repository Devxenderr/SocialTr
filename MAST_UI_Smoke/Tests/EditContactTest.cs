using Xamarin.UITest;
using NUnit.Framework;
using MAST_UI_Portable;

namespace MAST_UI_Smoke
{
    public class EditContactTest : TestBase
    {
        public EditContactTest (Platform platform, string simulatorName) : base (platform, simulatorName, AppManager.GetInstance(platform))
        {

        }

        [SetUp]
        public void BeforeEditContactTest()
        {
            appManager.BaseHelper.Authorization();
            appManager.NavigationHelper.GoToContactData();
        }

        [Test]
        public void ChangeUserSkype()
        {
            appManager.EditContactDataHelper.EnterSkype();
            appManager.EditContactDataHelper.SaveChangeOnContact();
            //check
        }
        [Test]
        public void ChangeUserCity()
        {
            appManager.EditContactDataHelper.EnterCity();
            appManager.EditContactDataHelper.SaveChangeOnContact();
            //check
        }

        [Test]
        public void ChangeUserPhoneNumber()
        {
            appManager.EditContactDataHelper.EnterPhoneNumber();
            appManager.EditContactDataHelper.SaveChangeOnContact();
            //check
        }

        [Test]
        public void ChangeUserCountryFromList()
        {
            appManager.EditContactDataHelper.SelectSecondCountryOnList();
            appManager.EditContactDataHelper.SaveChangeOnContact();
            //check
        }

        [Test]
        public void ChangeUserCountryWithSearch()
        {
            appManager.EditContactDataHelper.SelectCountryFromSearch();
            appManager.EditContactDataHelper.SaveChangeOnContact();
            //check
        }

        [Test] 
        public void CancelWithoutChanges()
        {
            appManager.EditContactDataHelper.CancelChangesContact();
        }

        [Test]
        public void CancelChages()
        {
            appManager.EditContactDataHelper.EnterCity();
            appManager.EditContactDataHelper.CancelChangesContact();
            //check
        }
    }
}
