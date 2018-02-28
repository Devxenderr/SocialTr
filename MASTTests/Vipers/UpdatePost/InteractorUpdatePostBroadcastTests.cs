using Moq;

using NUnit.Framework;

using SocialTrading.Vipers.Entity;
using SocialTrading.DTO.Response.RA;
using SocialTrading.DTO.Request.Posts;
using SocialTrading.DTO.Response.Post;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.UpdatePost.Interfaces;
using SocialTrading.Vipers.Controllers.Interfaces;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.UpdatePost.Implementation;

namespace MASTTests.Vipers.UpdatePost
{
    [TestFixture(Author = Authors.Pakhomova)]
    public class InteractorUpdatePostBroadcastTests
    {
        private IInteractorUpdatePost _interactor;
        private Mock<IUpdatePostController> _controllerMock;
        private Mock<IPresenterUpdatePost> _presenterMock;
        private Mock<IRepositoryUpdatePost> _repositoryMock;
        private Mock<IRepositoryPost> _repositoryPostMock;
        private Mock<IRepositoryUserAuth> _repositoryUserMock;

        [SetUp]
        public void SetUp()
        {
            _presenterMock = new Mock<IPresenterUpdatePost>(MockBehavior.Strict);
            _controllerMock = new Mock<IUpdatePostController>(MockBehavior.Strict);

            _repositoryMock = new Mock<IRepositoryUpdatePost>(MockBehavior.Strict);
            _repositoryMock.SetupGet(f => f.UpdatePostModel).Returns(new UpdatePostModel(false, "111", null, null, null, null, null, null, null));

            _repositoryUserMock = new Mock<IRepositoryUserAuth>(MockBehavior.Strict);

            _repositoryPostMock = new Mock<IRepositoryPost>(MockBehavior.Strict);
            _repositoryPostMock.Setup(f => f.GetPostById("111")).Returns(new DataModelPost("111", "user123", "AUDCAD", "Currency", "Buy", 0.0f,
                "Private", null, "123 content", "2017-11-17T08:43:17.669Z", "2017-11-17T08:43:17.669Z", "2017-11-17T08:43:17.669Z", "Ivan", "ivan.png", 45, 5, true));

            _interactor = new InteractorUpdatePost("111", _controllerMock.Object, _repositoryMock.Object, _repositoryPostMock.Object, _repositoryUserMock.Object)
            {
                Presenter = _presenterMock.Object
            };
        }


        [Test]
        public void UpdatePostSuccessTest()
        {
            _controllerMock.Setup(f => f.Send(It.IsAny<UpdatePostRequestModel>()));

            _interactor.UpdatePost(EAccessMode.Private, "123comment", "123image");

            _controllerMock.Verify(f => f.Send(It.IsAny<UpdatePostRequestModel>()), Times.Once);
        }

        [Test]
        public void UpdatePostNoAccessTest()
        {
            _presenterMock.Setup(f => f.AccessModeState(EState.Fail));

            _interactor.UpdatePost(EAccessMode.None, "123comment", "123image");

            _presenterMock.Verify(f => f.AccessModeState(EState.Fail), Times.Once);
        }

        [Test]
        public void UpdatePostNoImageNoCommentTest()
        {
            _presenterMock.Setup(f => f.CommentState(EState.Fail));

            _interactor.UpdatePost(EAccessMode.Private, null, null);

            _presenterMock.Verify(f => f.CommentState(EState.Fail), Times.Once);
        }

        [Test]
        public void AccessModeSelectedTest()
        {
            _presenterMock.Setup(f => f.AccessModeState(It.IsAny<EState>()));

            _interactor.AccessModeSelected(It.IsAny<EAccessMode>());

            _presenterMock.Verify(f => f.AccessModeState(It.IsAny<EState>()), Times.Once);
        }

        [Test]
        public void CommentInputTest()
        {
            _presenterMock.Setup(f => f.CommentState(It.IsAny<EState>()));

            _interactor.CommentInput("123comment");

            _presenterMock.Verify(f => f.CommentState(It.IsAny<EState>()), Times.Once);
        }

        [Test]
        public void SetConfigTest()
        {
            _repositoryUserMock.SetupGet(f => f.AuthData).Returns(new UserAuthData(new DataModelAuth(
                "111", "email", "tvma@i.ua", "tvma@i.ua", null, "2017-11-14T09:30:26.893Z", "https://pbs.twimg.com/profile_images/901947348699545601/hqRMHITj.jpg",
                null, "2017-11-17T08:43:17.669Z", "Jon", "Snow", null, "EN", false, 1510651826, 1510908197, 0, null)));

            _presenterMock.Setup(f => f.SetUserAvatar(It.IsAny<string>()));
            _presenterMock.Setup(f => f.SetUserName(It.IsAny<string>()));
            _presenterMock.Setup(f => f.SetData(It.IsAny<UpdatePostModel>()));

            _interactor.SetConfig();

            _presenterMock.Verify(f => f.SetUserAvatar(It.IsAny<string>()), Times.Once);
            _presenterMock.Verify(f => f.SetUserName(It.IsAny<string>()), Times.Once);
            _presenterMock.Verify(f => f.SetData(It.IsAny<UpdatePostModel>()), Times.Once);
        }
        

        [Test]
        public void DisposeTest()
        {
            _repositoryMock.SetupSet(f => f.UpdatePostModel = null);

            _interactor.Dispose();

            _repositoryMock.VerifySet(f => f.UpdatePostModel = null, Times.Once);
        }
        
        [Test]
        public void SelectImageClickTest()
        {
            _presenterMock.Setup(f => f.GoToSelectingImage());

            _interactor.SelectImageClick();

            _presenterMock.Verify(f => f.GoToSelectingImage(), Times.Once);
        }

        [Test]
        public void DeleteImageClickTest()
        {
            _presenterMock.Setup(f => f.DeleteImage());

            _interactor.DeleteImageClick();

            _presenterMock.Verify(f => f.DeleteImage(), Times.Once);
        }

        [Test]
        public void BackClickTest()
        {
            _presenterMock.Setup(f => f.GoToMain());

            _interactor.BackClick();

            _presenterMock.Verify(f => f.GoToMain(), Times.Once);
        }
    }
}
