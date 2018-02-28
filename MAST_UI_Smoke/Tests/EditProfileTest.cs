using Xamarin.UITest;
using NUnit.Framework;
using MAST_UI_Portable;

namespace MAST_UI_Smoke
{
    
    public class EditProfileTest : TestBase
    {
        public EditProfileTest (Platform platform, string simulatorName) : base(platform, simulatorName, AppManager.GetInstance(platform))
        {

        }

        [SetUp]
        public void BeforeEditProfileTests()
        {
            appManager.BaseHelper.Authorization();
            appManager.NavigationHelper.GoToEditProfile();
        }

        [Test]
        public void ChangeUserName()
        {
            appManager.EditContactDataHelper.EnterName();
            appManager.EditContactDataHelper.SaveChangesOnProfile();
            ///проверка с результатом запроса
        }

        [Test]
        public void ChangeUserLastName()
        {
            appManager.EditContactDataHelper.EnterLastName();
            appManager.EditContactDataHelper.SaveChangesOnProfile();
            ///проверка с результатом запроса
        }

        [Test]
        public void ChangeUserStatus()
        {
            appManager.EditContactDataHelper.EnterStatus();
            appManager.EditContactDataHelper.SaveChangesOnProfile();
            ///проверка с результатом запроса
        }
        
        
        

    }
}
