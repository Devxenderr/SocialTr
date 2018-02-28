using System;
using NUnit.Framework;
using SocialTrading.DTO.Response.Post;
using SocialTrading.DTO.Response.Post.Interfaces;
using SocialTrading.DTO.Response.UserSettings;
using SocialTrading.Vipers.Post.Implementation.Header;

namespace MASTTests.Vipers.Post
{
    public class PostHeaderUserModelCreatorTest
    {
        private static readonly DataModelPost DataModelPost = new DataModelPost("id", "user_id","quote", "market", "recommend", 
            (float?) 12.6, "access", "file", "content", "forecast","created_at", "updated_at", "author_first_name",
           "author_last_name", "author_avatar", 3, 3, true);

        private static readonly IPostHeaderModel DataModelUserInfo = DataModelPost;

        [Test]
        public void ModelCreatorInitNullTest()
        {
            Assert.Throws(typeof(ArgumentNullException), () =>
            {
                var creator = new HeaderUserModelCreator(null);
            });
        }

        [Test]
        public void GetModelTest()
        {
            var creator = new HeaderUserModelCreator(DataModelUserInfo);
            var model = creator.GetModel();

            var actual = DataModelUserInfo.AuthorFirstName.Equals(model.FirstName) &&
                         DataModelUserInfo.AuthorLastName.Equals(model.LastName);

            Assert.AreEqual(true, actual);
        }

        /*[TestCase("", false)]
        [TestCase(null, false)]
        [TestCase("van0", true)]
        public void NicknameTest(string nickname, bool expected)
        {
            var userInfo = new DataModelUserInfo("35356bb2-21e3-48c3-8b9b-5a0d6cdd3072", "Ivan", "Ivanov", nickname,
                "https://link-to-file.com", "vasya@pupkin.com", "380671234567",
                "null", "vasya_man", "Surinam", "Paramaribo ", "I am cool");

            var creator = new HeaderUserModelCreator(userInfo);
            var model = creator.GetModel();

            Assert.AreEqual(expected, model.IsNickname);
        }*/ 
    }
}
