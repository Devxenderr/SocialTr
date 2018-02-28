using System;

using NUnit.Framework;

using Newtonsoft.Json.Linq;

using SocialTrading.DTO.Request.Posts;
using SocialTrading.Tools.Enumerations;

namespace MASTTests.DTO.CreatePost
{
    [TestFixture, Author("Elena Pakhomova")]
    public class CreateSimplePostRequestModelTests
    {
        [TestCase(null, EAccessMode.None, null, null, TestName = "All null")]
        [TestCase("Simple", EAccessMode.None, "123content", "123image", TestName = "AccessMode none")]
        [TestCase("Simple", EAccessMode.Private, null, "", TestName = "Content null")]
        [TestCase("Simple", EAccessMode.Private, "", "", TestName = "Content empty")]
        [TestCase("Simple", EAccessMode.Private, "", null, TestName = "Image null")]
        [TestCase("Simple", EAccessMode.Private, "", "", TestName = "Image empty")]
        public void CtorTestExceptions(string market, EAccessMode access, string content, string file)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var model = new CreateSimplePostRequestModel(market, access, content, file);
            });
        }

        [TestCase("Simple", EAccessMode.Private, "123content", "123image", TestName = "All full")]
        [TestCase("Simple", EAccessMode.Private, "123content", "123image", TestName = "Content and image")]
        [TestCase("Simple", EAccessMode.Private, "123content", "", TestName = "Only content")]
        [TestCase("Simple", EAccessMode.Private, "123content", null, TestName = "Only content, image null")]
        [TestCase("Simple", EAccessMode.Private, "", "123image", TestName = "Only image")]
        [TestCase("Simple", EAccessMode.Private, null, "123image", TestName = "Only image, content null")]
        public void PerformQueryTest(string market, EAccessMode access, string content, string image)
        {
            var model = new CreateSimplePostRequestModel(market, access, content, image);
            var actual = model.PerformQuery();

            var expected = new JObject
            {
                ["market"] = market,
                ["access"] = access == EAccessMode.None ? string.Empty : access.ToString()
            };

            if (!string.IsNullOrWhiteSpace(image))
            {
                expected["image"] = "data:image/gif;base64," + image;
            }
            if (!string.IsNullOrWhiteSpace(content))
            {
                expected["content"] = content;
            }

            Assert.IsTrue(JToken.DeepEquals(actual, expected));
        }

        [TestCase("Simple", EAccessMode.Private, null, "123image", "Simple", EAccessMode.Private, null, "123image")]
        [TestCase("Simple", EAccessMode.Public, "123content", null, "Simple", EAccessMode.Public, "123content", null)]
        [TestCase("Simple", EAccessMode.Public, "123content", "123image", "Simple", EAccessMode.Public, "123content", "123image")]
        public void EqualsSuccessTest(string market, EAccessMode access, string content, string image, string marketExpected, EAccessMode accessExpected, string contentExpected, string imageExpected)
        {
            var actual = new CreateSimplePostRequestModel(market, access, content, image);
            var expected = new CreateSimplePostRequestModel(marketExpected, accessExpected, contentExpected, imageExpected);
            Assert.IsTrue(actual.Equals(expected));
        }

        [TestCase("", EAccessMode.Public, "123content", null, "Simple", EAccessMode.Public, "123content", null)]
        [TestCase("Simple", EAccessMode.Private, null, "123image", "Simple", EAccessMode.Public, null, "123image")]
        [TestCase("Simple", EAccessMode.Public, "123content", "", "Simple", EAccessMode.Public, "123content", "123image")]
        [TestCase("Simple", EAccessMode.Public, null, "123image", "Simple", EAccessMode.Public, "123content", "123image")]
        public void EqualsFailTest(string market, EAccessMode access, string content, string image, string marketExpected, EAccessMode accessExpected, string contentExpected, string imageExpected)
        {
            var actual = new CreateSimplePostRequestModel(market, access, content, image);
            var expected = new CreateSimplePostRequestModel(marketExpected, accessExpected, contentExpected, imageExpected);
            Assert.IsFalse(actual.Equals(expected));
        }
    }
}
