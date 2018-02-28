using Newtonsoft.Json.Linq;

using NUnit.Framework;

using SocialTrading.DTO.Request.RA;

namespace MASTTests.DTO.RegAuth
{
    [TestFixture]
    class RegAuthModelsTest
    {
        [Test, Author("Oleh Marchenko")]
        [TestCase("", "")]
        [TestCase(null, null)]
        [TestCase("123", "1")]
        [TestCase("qwe", "11")]
        [TestCase("123@123.123", "111")]
        [TestCase("123qwe", "111qqq")]
        [TestCase("123qwe@.1", "")]
        [TestCase("", "111qqq")]
        [TestCase("qwe@qwe.qwe", "123")]
        public void AuthPerformQuery(string email, string pass)
        {
            var expected = new JObject
            {
                ["email"] = email ?? string.Empty,
                ["password"] = pass ?? string.Empty
            };
            UserAuth ueserAuth = new UserAuth(email, pass);
            var actual = ueserAuth.PerformQuery();
            Assert.IsTrue(JToken.DeepEquals(expected, actual));
        }

        [Test, Author("Oleh Marchenko")]
        [TestCase(null, null, null, null, null, null)]
        [TestCase("123", null, null, null, null, null)]
        [TestCase(null, "123", null, null, null, null)]
        [TestCase(null, null, "123", null, null, null)]
        [TestCase(null, null, null, "123", null, null)]
        [TestCase(null, null, null, null, "123", "123")]
        [TestCase("123", "123", "123", "123", null, null)]
        [TestCase("", "", "","", "","")]
        [TestCase("123", "", "", "", "", "")]
        [TestCase("", "123", "", "", "", "")]
        [TestCase("", "", "123", "", "", "")]
        [TestCase("", "", "", "123", "", "")]
        [TestCase("", "", "", "", "123", "123")]
        [TestCase("123", "123", "123", "123", "", "")]
        public void RegPerformQuery(string name, string lastName, string email, string pass, string phoneCountry = "", string phoneNumber = "")
        {
            var expected = new JObject
            {
                ["email"] = email ?? string.Empty,
                ["password"] = pass ?? string.Empty,
                ["password_confirmation"] = pass ?? string.Empty,
                ["first_name"] = name ?? string.Empty,
                ["last_name"] = lastName ?? string.Empty,
                ["country"] = phoneCountry ?? string.Empty,
                ["phone"] = phoneNumber ?? string.Empty
            };
            UserReg userReg = new UserReg(name, lastName, email, pass, phoneCountry, phoneNumber);
            var actual = userReg.PerformQuery();
            Assert.IsTrue(JToken.DeepEquals(expected, actual));
        }
    }
}
