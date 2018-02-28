using Moq;

using NUnit.Framework;

using SocialTrading.Service;
using SocialTrading.Vipers.Entity;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.UpdatePost.Interfaces;
using SocialTrading.Vipers.Controllers.Interfaces;
using SocialTrading.Vipers.UpdatePost.Implementation;

namespace MASTTests.Vipers.UpdatePost
{
    [TestFixture(Author = Authors.Pakhomova)]
    public class InteractorUpdatePostTests
    {
        private IInteractorUpdatePost _interactor;
        private Mock<IUpdatePostController> _controllerMock;
        private Mock<IPresenterUpdatePost> _presenterMock;
        private RepositoryController _repo;

        [SetUp]
        public void SetUp()
        {
            _repo = RepositoryController.GetInstance();

            _controllerMock = new Mock<IUpdatePostController>();
            _repo.RepositoryUpdatePost.UpdatePostModel = new UpdatePostModel(false, "123", null, null, null, null, null, null, null);
            _interactor = new InteractorUpdatePost("postId", _controllerMock.Object, _repo.RepositoryUpdatePost, _repo.RepositoryPost, _repo.RepositoryUserAuth);
            _presenterMock = new Mock<IPresenterUpdatePost>(MockBehavior.Strict);
            _interactor.Presenter = _presenterMock.Object;
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void CommentInputStateFailTest(string comment)
        {
            _presenterMock.Setup(f => f.CommentState(EState.Fail));

            _interactor.CommentInput(comment, true);

            _presenterMock.Verify(f => f.CommentState(EState.Fail));
        }

        [Test]
        public void CommentInputStateSuccessTest()
        {
            _presenterMock.Setup(f => f.CommentState(EState.None));

            _interactor.CommentInput("comment!", true);

            _presenterMock.Verify(f => f.CommentState(EState.None));
        }

        [TestCase(EAccessMode.Private, TestName = "AccessModeSelectedPrivateTest")]
        [TestCase(EAccessMode.Public, TestName = "AccessModeSelectedPublicTest")]
        public void AccessModeSelectedSuccessTest(EAccessMode access)
        {
            _presenterMock.Setup(f => f.AccessModeState(EState.None));

            _interactor.AccessModeSelected(access);

            _presenterMock.Verify(f => f.AccessModeState(EState.None));
        }

        [TestCase(EAccessMode.None, TestName = "AccessModeSelectedNoneTest")]
        public void AccessModeSelectedFailTest(EAccessMode access)
        {
            _presenterMock.Setup(f => f.AccessModeState(EState.Fail));

            _interactor.AccessModeSelected(access);

            _presenterMock.Setup(f => f.AccessModeState(EState.Fail));
        }

        [Test]
        public void SaveDataTest()
        {
            _repo.RepositoryUpdatePost.UpdatePostModel = new UpdatePostModel(true, "id", null, null, "0.0", null, "Public", "123image", "123content");
            _interactor.SaveData(EAccessMode.Private, "comment", "img");

            Assert.AreEqual(_repo.RepositoryUpdatePost.UpdatePostModel.Access, EAccessMode.Private);
            Assert.AreEqual(_repo.RepositoryUpdatePost.UpdatePostModel.Image, "img");
            Assert.AreEqual(_repo.RepositoryUpdatePost.UpdatePostModel.Content, "comment");
        }

        [Test]
        public void SaveAttachedImage()
        {
            _repo.RepositoryUpdatePost.UpdatePostModel = new UpdatePostModel(true, "id", null, null, "0.0", null, "Public", null, "123content");
            _interactor.SaveAttachedImage("image123");
            
            Assert.AreEqual(_repo.RepositoryUpdatePost.UpdatePostModel.Image, "image123");
        }

        [Test]
        public void LoadAttachedImageTest()
        {
            _repo.RepositoryUpdatePost.UpdatePostModel = new UpdatePostModel(true, "id", null, null, "0.0", null, "Public", "image123", "123content");
            var expected = _interactor.LoadAttachedImage();
            Assert.AreEqual(expected, "image123");
        }
    }
}
