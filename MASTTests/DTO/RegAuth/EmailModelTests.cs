
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using SocialTrading.Connection.Enumerations;
using SocialTrading.Connection.Markers;
using SocialTrading.DTO.Request.RA;
using System;

namespace MASTTests.DTO.RegAuth
{
    [TestFixture, Author("Gerashchenko V.V.")]
    class EmailModelTests
    {
        [Test]
        public void Constructor_NegativeTest()
        {
            Assert.Throws<ArgumentNullException>(() => new EmailModel(null));
        }

        [Test]
        [TestCase("",                   TestName = "Constructor_PositiveTest_")]
        [TestCase("1",                  TestName = "Constructor_PositiveTest_1")]
        [TestCase("123",                TestName = "Constructor_PositiveTest_123")]
        [TestCase("TVMA@i.ua",          TestName = "Constructor_PositiveTest_4")]
        public void Constructor_PositiveTest(string email)
        {
            var emailModel = new EmailModel(email);

            Assert.AreEqual(email.ToLower(),                    emailModel.Email);
            Assert.AreEqual("/auth/password",                   emailModel.ApiPath);
            Assert.AreEqual(ERestCommands.POST,                 emailModel.Method);
            Assert.AreEqual(EResponseModule.RecoveryPassword,   emailModel.ResponseModule);
            Assert.AreEqual(typeof(RestRorMarker),              emailModel.TypeMarker);
        }

        [Test]
        [TestCase("",                   TestName = "PerformQuery_PositiveTest_")]
        [TestCase("1",                  TestName = "PerformQuery_PositiveTest_1")]
        [TestCase("123",                TestName = "PerformQuery_PositiveTest_123")]
        [TestCase("TVMA@i.ua",          TestName = "PerformQuery_PositiveTest_4")]
        public void PerformQuery_PositiveTest(string email)
        {
            var emailModel = new EmailModel(email);
            var actJObject = emailModel.PerformQuery();

            JObject expObj = new JObject
            {
                ["email"] = email.ToLower()
            };
                       
            Assert.IsTrue(JToken.DeepEquals(actJObject, expObj));
        }
    }
}
