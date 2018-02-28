using System.Linq;
using System.Collections;

using NUnit.Framework;

using SocialTrading.DTO.Response.RA;
using SocialTrading.Connection.Dispatcher;
using SocialTrading.Tools.Exceptions.Parse;

namespace MASTTests.Connection.ParseDTO
{
    [TestFixture]
    public class ParseResponseRecoveryPasswordTests
    {
        [Test]
        [TestCaseSource(typeof(DataTests), nameof(DataTests.ParsePositive))]
        public void ParseResponseRecoveryPassword_Positive(string data, bool expSuccess, string expMessage, string[] expErrors, string testName)
        {
            DataRecoveryPasswordResponse actResponse = WebMsgParser.ParseResponseRecoveryPassword(data);

            Assert.AreEqual(expSuccess, actResponse.Success);
            Assert.AreEqual(expMessage, actResponse.Message);
            CollectionAssert.AreEqual(expErrors.ToList(), actResponse.Errors);
        }

        [Test]
        [TestCaseSource(typeof(DataTests), nameof(DataTests.ParseNegative))]
        public void ParseResponseRecoveryPassword_Negative(string data, string testName)
        {
            Assert.Throws<ParseException>(() => WebMsgParser.ParseResponseRecoveryPassword(data));
        }

        private class DataTests
        {
            public static IEnumerable ParsePositive
            {
                get
                {
                    yield return new TestCaseData(  "{\"success\":true,\"message\":\"An email has been sent to 'tvma@i.ua' containing instructions for resetting your password.\"}",     
                                                    true, 
                                                    "An email has been sent to 'tvma@i.ua' containing instructions for resetting your password.", 
                                                    new string[0],                                                                                                                      "0");
                    yield return new TestCaseData("{\"success\":false,\"errors\":[\"Unable to find user with email '123@123.ru'.\"]}",     
                                                    false, 
                                                    "", 
                                                    new string[] { "Unable to find user with email '123@123.ru'." },                                                                    "1");
                    yield return new TestCaseData("{\"success\":true,\"message\":\"An email has been sent to 'tvma@i.ua' containing instructions for resetting your password.\", \"errors\":[\"Unable to find user with email '123@123.ru'.\"]}",     
                                                    true, 
                                                    "An email has been sent to 'tvma@i.ua' containing instructions for resetting your password.",
                                                    new string[] { "Unable to find user with email '123@123.ru'." },                                                                    "2");
                    yield return new TestCaseData("{\"success\":false,\"message\":\"An email has been sent to 'tvma@i.ua' containing instructions for resetting your password.\",\"errors\":[\"Unable to find user with email '123@123.ru'.\"]}",     
                                                    false,
                                                    "An email has been sent to 'tvma@i.ua' containing instructions for resetting your password.", 
                                                    new string[] { "Unable to find user with email '123@123.ru'." },                                                                    "3");

                }
            }

            public static IEnumerable ParseNegative
            {
                get
                {
                    yield return new TestCaseData("{\"success\":false,\"message\":\"An email has been sent to 'tvma@i.ua' containing instructions for resetting your password.\"}",    
                                                                                                                                                                                        "0");
                    yield return new TestCaseData("{\"success\":true,\"errors\":[\"Unable to find user with email '123@123.ru'.\"]}",                                                    
                                                                                                                                                                                        "1");
                    yield return new TestCaseData(null,     
                                                                                                                                                                                        "2");
                    yield return new TestCaseData("",
                                                                                                                                                                                        "3");
                    yield return new TestCaseData("{\"Uccess\":false,\"message\":\"An email has been sent to 'tvma@i.ua' containing instructions for resetting your password.\",\"errors\":[\"Unable to find user with email '123@123.ru'.\"]}",     
                                                                                                                                                                                        "4");
                }
            }
        }
    }
}
