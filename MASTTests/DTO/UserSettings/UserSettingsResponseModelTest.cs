using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SocialTrading.DTO.Response.UserSettings;

namespace MASTTests.DTO.UserSettings
{
    [TestFixture, Author("Zaiets Katia")]
    public class UserSettingsResponseModelTest
    {

        [Test]
        [TestCaseSource(typeof(DataTests), nameof(DataTests.DataForConstructorPositive))]
        public void Constructor_PositiveTest(string id, string first_name, string last_name, string nickname, string image, string email, string phone,
            string phone_2, string skype, string country, string city, string userStatus, bool isNickName, string[] errors)
        {
            var actModel = new DataModelUserInfo(id, first_name, last_name, nickname, image, email, phone, phone_2, skype, country, city, userStatus, isNickName, errors);

            Assert.AreEqual(actModel.Id, id);
            Assert.AreEqual(actModel.FirstName, first_name);
            Assert.AreEqual(actModel.LastName, last_name);
            Assert.AreEqual(actModel.Nickname, nickname);
            Assert.AreEqual(actModel.Image, image);
            Assert.AreEqual(actModel.Email, email);
            Assert.AreEqual(actModel.Phone, phone);
            Assert.AreEqual(actModel.PhoneSecond, phone_2);
            Assert.AreEqual(actModel.Skype, skype);
            Assert.AreEqual(actModel.Country, country);
            Assert.AreEqual(actModel.City, city);
            Assert.AreEqual(actModel.UserStatus, userStatus);
            Assert.AreEqual(actModel.IsNickName, isNickName);
           
        }


        private class DataTests
        {
            public static IEnumerable DataForConstructorPositive
            {
                get
                {
                    yield return new TestCaseData("id", "first_name", "last_name", "nickname", "image", "email", "phone", "phone_2", "skype", "country", "city", "userStatus", false, null);
                    yield return new TestCaseData("", "", "", "", "", "", "", "", "", "", "", "", true, null);
                    yield return new TestCaseData("", "", "", "", "", "", "", "", "", "", "", "", true, new[] { "errors" });
                    yield return new TestCaseData(null, null, null, null, null, null, null, null, null, null, null, null, true, new[] { "errors" });
                }
            }
        }

    }
}
