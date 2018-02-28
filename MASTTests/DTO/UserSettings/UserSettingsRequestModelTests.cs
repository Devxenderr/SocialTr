using NUnit.Framework;

using SocialTrading.DTO.Request;
using SocialTrading.Connection.Enumerations;

namespace MASTTests.DTO.UserSettings
{
    [TestFixture]
    public class UserSettingsRequestModelTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("userId")]
        public void UserInfoObjectTest(string userId)
        {
            var modelAct = new UserInfoRequestModel(userId);

            var modelExp = new UserInfoRequestModel(userId)
            {
                ApiPath = "/api/v3/get_user_info/" + userId,
                Method = ERestCommands.GET
            };

            var result = modelExp.Equals(modelAct);

            Assert.IsTrue(result);
        }
    }
}
