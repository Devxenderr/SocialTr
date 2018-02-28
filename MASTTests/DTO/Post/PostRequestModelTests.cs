using NUnit.Framework;

using SocialTrading.DTO.Request;
using SocialTrading.DTO.Request.Posts;
using SocialTrading.Connection.Enumerations;

namespace MASTTests.DTO.Post
{
    [TestFixture]
    public class PostRequestModelTests
    {
        [Test]
        public void PostsAllObjectTest()
        {
            var modelAct = new PostsRequestModel(SocialTrading.Tools.Enumerations.EPostsRequestType.InitialRequest);

            var modelExp = new PostsRequestModel(SocialTrading.Tools.Enumerations.EPostsRequestType.InitialRequest)
            {
                ApiPath = "/api/v3/posts",
                Method = ERestCommands.GET,               
            };

            var result = modelExp.Equals(modelAct);

            Assert.IsTrue(result);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("postId")]
        public void PostsDeleteObjectTest(string postId)
        {
            var modelAct = new DeletePostRequestModel(postId);

            var modelExp = new DeletePostRequestModel(postId)
            {
                ApiPath = "/api/v3/posts/" + postId,
                Method = ERestCommands.DELETE,
                ResponseModule = EResponseModule.PostDelete
            };

            var result = modelExp.Equals(modelAct);

            Assert.IsTrue(result);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("postId")]
        public void PostLikeObjectTest(string postId)
        {
            var modelAct = new PostLikeRequestModel(postId);

            var modelExp = new PostLikeRequestModel(postId)
            {
                ApiPath = "/api/v3/posts/" + postId + "/like",
                Method = ERestCommands.POST,
                ResponseModule = EResponseModule.PostLike
            };

            var result = modelExp.Equals(modelAct);

            Assert.IsTrue(result);
        }
    }
}
