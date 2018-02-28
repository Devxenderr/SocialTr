using System;
using System.Linq;
using System.Reflection;

using NUnit.Framework;

using SocialTrading.Service;
using SocialTrading.DTO.Interfaces;
using SocialTrading.DTO.Response.UserSettings;

namespace MASTTests.Repository
{
    [TestFixture, Author("Oleh Marchenko")]
    public class RepositoryEditContactTests
    {
        [Test]
        public void SetDataModelUserInfoTest()
        {
            var model = new DataModelUserInfo("", "", "", "", "", "", "", "", "", "", "", "", false, new string[]{});
            DataService.RepositoryController.RepositoryUserSettings.EditContactUserInfo = model;

            var result = (DataService.RepositoryController.RepositoryUserSettings.GetType().GetRuntimeFields()
                .First(f => f.Name.Equals("_editContactUserInfo"))
                .GetValue(DataService.RepositoryController.RepositoryUserSettings) as Lazy<IEditContactEntity>)?.Value;

            Assert.AreEqual(model, result);
        }

        [Test]
        public void SetDataModelUserInfoNullTest()
        {
            DataService.RepositoryController.RepositoryUserSettings.EditContactUserInfo = null;

            var result = (DataService.RepositoryController.RepositoryUserSettings.GetType().GetRuntimeFields()
                .First(f => f.Name.Equals("_editContactUserInfo"))
                .GetValue(DataService.RepositoryController.RepositoryUserSettings) as Lazy<IEditContactEntity>)?.Value;

            Assert.IsNull(result);
        }

        [Test]
        public void GetDataModelUserInfoTest()
        {
            var model = new DataModelUserInfo("", "", "", "", "", "", "", "", "", "", "", "", false, new string[] { });

            DataService.RepositoryController.RepositoryUserSettings.GetType().GetRuntimeFields()
                .First(f => f.Name.Equals("_editContactUserInfo"))
                .SetValue(DataService.RepositoryController.RepositoryUserSettings, new Lazy<IEditContactEntity>(() => model));

            Assert.AreEqual(model, DataService.RepositoryController.RepositoryUserSettings.EditContactUserInfo);
        }
    }
}