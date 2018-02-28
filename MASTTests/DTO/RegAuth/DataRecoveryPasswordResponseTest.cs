using System;
using System.Collections;
using NUnit.Framework;
using SocialTrading.DTO.Response.RA;

namespace MASTTests.DTO.RegAuth
{
    [TestFixture, Author("Gerashchenko V.V.")]
    public class DataRecoveryPasswordResponseTest
    {
        [Test]
        [TestCaseSource(typeof(DataTests), nameof(DataTests.DataForConstructorPositive))]
        public void Constructor_PositiveTest(bool success, string message, string[] errors, string expMessage, string testName)
        {
            var actModel = new DataRecoveryPasswordResponse(success, message, errors);
            
            Assert.AreEqual(actModel.Success, success);
            Assert.AreEqual(actModel.Message, expMessage);
        }

        [Test]
        [TestCaseSource(typeof(DataTests), nameof(DataTests.DataForConstructorNegative))]
        public void Constructor_NegativeTest(bool? success, string message, string[] errors, string testName)
        {
            Assert.Throws<ArgumentException>(() => new DataRecoveryPasswordResponse(success, message, errors));
        }

        [Test]
        [TestCaseSource(typeof(DataTests), nameof(DataTests.DataForEqualsPositive))]
        public void DataRecoveryPasswordResponse_EqualsTest(    bool success1, string message1, string[] errors1,
                                                                bool success2, string message2, string[] errors2, 
                                                                string testName)
        {
            var actModel1 = new DataRecoveryPasswordResponse(success1, message1, errors1);
            var actModel2 = new DataRecoveryPasswordResponse(success2, message2, errors2);

            Assert.AreEqual(actModel1, actModel2);
        }

        [Test]
        [TestCaseSource(typeof(DataTests), nameof(DataTests.DataForEqualsNegative))]
        public void DataRecoveryPasswordResponse_NotEqualsSameModelsTest(   bool success1, string message1, string[] errors1,
                                                                            bool success2, string message2, string[] errors2,
                                                                            string testName)
        {
            var actModel1 = new DataRecoveryPasswordResponse(success1, message1, errors1);
            var actModel2 = new DataRecoveryPasswordResponse(success2, message2, errors2);

            Assert.AreNotEqual(actModel1, actModel2);
        }

        [Test]
        public void DataRecoveryPasswordResponse_NotEqualsDifferentModelsTest()
        {
            var actModel = new DataRecoveryPasswordResponse(true, "message", new[] { "error"});

            Assert.AreNotEqual(actModel, new object());
            Assert.AreNotEqual(actModel, "message");
            Assert.AreNotEqual(actModel, true);
            Assert.AreNotEqual(actModel, int.MaxValue);
        }

        private class DataTests
        {
            public static IEnumerable DataForConstructorPositive
            {
                get
                {
                    yield return new TestCaseData(true, "message", null, "message",                              "0");
                    yield return new TestCaseData(true, "", null, "",                                            "1");
                    yield return new TestCaseData(true, "message", new[] { "errors" }, "message",                "2");
                    yield return new TestCaseData(false, null, new[] { "" }, "",                                 "3");
                    yield return new TestCaseData(false, null, new[] { "errors" }, "",                           "4");
                    yield return new TestCaseData(false, "message", new[] { "errors" }, "message",               "5");
                    yield return new TestCaseData(false, "message", new[] { "error1", "error2" }, "message",     "6");
                }
            }

            public static IEnumerable DataForConstructorNegative
            {
                get
                {
                    yield return new TestCaseData(false, null, null,                            "0");
                    yield return new TestCaseData(false, "message", null,                       "1");
                    yield return new TestCaseData(true, null, new[] { "error" },                "2");
                    yield return new TestCaseData(null, null, null,                             "3");
                    yield return new TestCaseData(null, "message", new[] { "error" },           "4");
                }
            }

            public static IEnumerable DataForEqualsPositive
            {
                get
                {
                    yield return new TestCaseData(  true, "message", null, 
                                                    true, "message", null,                           "0");
                    yield return new TestCaseData(  true, "message", new[] { "error" },
                                                    true, "message", new[] { "error" },              "1");
                    yield return new TestCaseData(  true, "", null, 
                                                    true, "", null,                                  "2");
                    yield return new TestCaseData(  false, null, new[] { "" },
                                                    false, null, new[] { "" },                       "3");
                    yield return new TestCaseData(  false, "message", new[] { "error" },
                                                    false, "message", new[] { "error" },             "4");   
                    yield return new TestCaseData(  false, "message", new[] { "error1", "error2" },
                                                    false, "message", new[] { "error1", "error2" },  "5");   
                }
            }

            public static IEnumerable DataForEqualsNegative
            {
                get
                {
                   yield return new TestCaseData(   true, "message", null, 
                                                    true, "message1", null,                          "0");
                    yield return new TestCaseData(  true, "message", new[] { "error1" },
                                                    true, "message", new[] { "error" },              "1");
                    yield return new TestCaseData(  true, "", null, 
                                                    true, "message", null,                           "2");
                    yield return new TestCaseData(  false, null, new[] { "error" },
                                                    false, null, new[] { "" },                       "3");
                    yield return new TestCaseData(  false, "message", new[] { "error" },
                                                    false, "message1", new[] { "error" },            "4");   
                    yield return new TestCaseData(  false, "message", new[] { "error1", "error2" },
                                                    false, "message", new[] { "error2" },            "5");   
                }
            }
        }
    }
}
