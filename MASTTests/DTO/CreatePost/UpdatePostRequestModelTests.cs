using System;

using Newtonsoft.Json.Linq;

using NUnit.Framework;

using SocialTrading.DTO.Request.Posts;
using SocialTrading.Tools.Enumerations;

namespace MASTTests.DTO.CreatePost
{
    [TestFixture(Author = Authors.Pakhomova)]
    public class UpdatePostRequestModelTests
    {
        [TestCase(null, EAccessMode.None, null, null, TestName = "All null")]
        [TestCase("id", EAccessMode.None, "123content", "123image", TestName = "AccessMode none")]
        [TestCase(null, EAccessMode.None, "123content", "123image", TestName = "PostId null")]
        [TestCase("", EAccessMode.None, "123content", "123image", TestName = "PostId empty")]
        [TestCase("id", EAccessMode.Private, null, "", TestName = "Content null")]
        [TestCase("id", EAccessMode.Private, "", "", TestName = "Content empty")]
        [TestCase("id", EAccessMode.Private, "", null, TestName = "Image null")]
        [TestCase("id", EAccessMode.Private, "", "", TestName = "Image empty")]
        public void CtorTestExceptions(string postId, EAccessMode access, string content, string file)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var model = new UpdatePostRequestModel(postId, access, content, file);
            });
        }
        
        [TestCase(EAccessMode.Private, "123content", "123image", TestName = "Content and image")]
        [TestCase(EAccessMode.Private, "123content", "", TestName = "Only content")]
        [TestCase(EAccessMode.Private, "123content", null, TestName = "Only content, image null")]
        [TestCase(EAccessMode.Private, "", "123image", TestName = "Only image")]
        [TestCase(EAccessMode.Private, null, "123image", TestName = "Only image, content null")]
        public void PerformQueryTest(EAccessMode access, string content, string image)
        {
            var model = new UpdatePostRequestModel("id", access, content, image);
            var actual = model.PerformQuery();
            
            var expected = new JObject
            {
                ["post"] = new JObject
                {
                    ["access"] = access == EAccessMode.None ? string.Empty : access.ToString(),
                    ["content"] = content,
                    ["image"] = !string.IsNullOrWhiteSpace(image) ? "data:image/gif;base64," + image : string.Empty
                }
            };

            Assert.IsTrue(JToken.DeepEquals(actual, expected));
        }
        
        [TestCase("id", EAccessMode.Private, null, "123image", "id", EAccessMode.Private, null, "123image")]
        [TestCase("id", EAccessMode.Public, "123content", null, "id", EAccessMode.Public, "123content", null)]
        [TestCase("id", EAccessMode.Public, "123content", "123image", "id", EAccessMode.Public, "123content", "123image")]
        public void EqualsSuccessTest(string postId, EAccessMode access, string content, string image, string postIdExpected, EAccessMode accessExpected, string contentExpected, string imageExpected)
        {
            var actual = new UpdatePostRequestModel(postId, access, content, image);
            var expected = new UpdatePostRequestModel(postIdExpected, accessExpected, contentExpected, imageExpected);
            Assert.IsTrue(actual.Equals(expected));
        }
        
        [TestCase("id", EAccessMode.Private, null, "123image", "id", EAccessMode.Public, null, "123image")]
        [TestCase("id", EAccessMode.Public, "123content", "", "id", EAccessMode.Public, "123content", "123image")]
        [TestCase("id", EAccessMode.Public, null, "123image", "id", EAccessMode.Public, "123content", "123image")]
        public void EqualsFailTest(string postId, EAccessMode access, string content, string image, string postIdExpected, EAccessMode accessExpected, string contentExpected, string imageExpected)
        {
            var actual = new UpdatePostRequestModel(postId, access, content, image);
            var expected = new UpdatePostRequestModel(postIdExpected, accessExpected, contentExpected, imageExpected);
            Assert.IsFalse(actual.Equals(expected));
        }
    }
}
