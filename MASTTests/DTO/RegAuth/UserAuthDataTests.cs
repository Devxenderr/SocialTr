using System.Reflection;

using NUnit.Framework;

using SocialTrading.DTO.Response.RA;
using SocialTrading.Tools.Exceptions;

namespace MASTTests.DTO.RegAuth
{
    [TestFixture, Author("Oleh Marchenko")]
    public class UserAuthDataTests
    {
        [TestCase(null, null, null)]
        [TestCase("Jon", "Snow", null)]
        [TestCase(null, null, "image")]
        public void UserAuthDataTestNotEqual(string name, string lastName, string image)
        {
            var actual = new UserAuthData(new DataModelAuth("111", "email", "tvma@i.ua", "tvma@i.ua", null, "2017-11-14T09:30:26.893Z", "image",
                null, "2017-11-17T08:43:17.669Z", name, lastName, null, "EN", false, 1510651826, 1510908197, 0, null));
            var expected = new UserAuthData(new DataModelAuth("111", "email", "tvma@i.ua", "tvma@i.ua", null, "2017-11-14T09:30:26.893Z", "image",
                null, "2017-11-17T08:43:17.669Z", name, lastName, null, "EN", false, 1510651826, 1510908197, 0, null));

            expected.GetType().GetRuntimeProperty("Name").SetValue(expected, name);
            expected.GetType().GetRuntimeProperty("Image").SetValue(expected, image);

            var result = actual.Equals(expected);

            Assert.IsFalse(result);
        }

        [TestCase("", "", "")]
        [TestCase("Jon", "Snow", "")]
        [TestCase("", "", "image")]
        public void UserAuthDataTestEqual(string name, string lastName, string image)
        {
            var actual = new UserAuthData(new DataModelAuth("111", "email", "tvma@i.ua", "tvma@i.ua", null, "2017-11-14T09:30:26.893Z", image,
                null, "2017-11-17T08:43:17.669Z", name, lastName, null, "EN", false, 1510651826, 1510908197, 0, null));
            var expected = new UserAuthData(new DataModelAuth("111", "email", "tvma@i.ua", "tvma@i.ua", null, "2017-11-14T09:30:26.893Z", image,
                null, "2017-11-17T08:43:17.669Z", name, lastName, null, "EN", false, 1510651826, 1510908197, 0, null));

            expected.GetType().GetRuntimeProperty("Name").SetValue(expected, name + " " + lastName);
            expected.GetType().GetRuntimeProperty("Image").SetValue(expected, image);

            var result = actual.Equals(expected);

            Assert.IsTrue(result);
        }

        [Test]
        public void UserAuthDataTestException()
        {
            Assert.Throws<DataModelAuthNullReferenceException>(() => new UserAuthData(null));
        }
    }
}