using Moq;

using NUnit.Framework;

using SocialTrading.Locale;
using SocialTrading.Vipers.Entity;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.CreatePost;
using SocialTrading.Vipers.UpdatePost.Interfaces;
using SocialTrading.Vipers.UpdatePost.Implementation;

namespace MASTTests.Vipers.UpdatePost
{
    [TestFixture(Author = Authors.Pakhomova)]
    public class PresenterUpdatePostTests
    {
        private Mock<IRouterUpdatePost> _routerMock;
        private Mock<IViewUpdatePost> _viewMock;
        private Mock<IInteractorUpdatePost> _interactorMock;
        private Mock<IUpdatePostStylesHolder> _stylesHolderMock;

        [SetUp]
        public void SetUp()
        {
            _routerMock = new Mock<IRouterUpdatePost>(MockBehavior.Strict);
            _viewMock = new Mock<IViewUpdatePost>(MockBehavior.Strict);
            _interactorMock = new Mock<IInteractorUpdatePost>(MockBehavior.Strict);
            _stylesHolderMock = new Mock<IUpdatePostStylesHolder>(MockBehavior.Default);

            _viewMock.SetupSet(f => f.Presenter = It.IsAny<PresenterUpdatePost>());

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<PresenterUpdatePost>());
        }

        [Test]
        public void SetAvatarTest()
        {
            _viewMock.Setup(f => f.SetUserAvatar(It.IsAny<string>()));

            var presenter = new PresenterUpdatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.SetUserAvatar(It.IsAny<string>());

            _viewMock.Verify(f => f.SetUserAvatar(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void SetUserNameTest()
        {
            _viewMock.Setup(f => f.SetUserName(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetComment(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetCommentHint(It.IsAny<string>()));

            var presenter = new PresenterUpdatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.SetUserName(It.IsAny<string>());

            _viewMock.Verify(f => f.SetUserName(It.IsAny<string>()), Times.Once);
            _viewMock.Verify(f => f.SetCommentHint(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ImageSelectedTest()
        {
            _viewMock.Setup(f => f.SetImage(It.IsAny<string>()));

            var presenter = new PresenterUpdatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.ImageSelected(It.IsAny<string>());

            _viewMock.Verify(f => f.SetImage(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void AccessModeSelectedTest()
        {
            _interactorMock.Setup(f => f.AccessModeSelected(It.IsAny<EAccessMode>()));

            var presenter = new PresenterUpdatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.AccessModeSelected(It.IsAny<EAccessMode>());

            _interactorMock.Verify(f => f.AccessModeSelected(It.IsAny<EAccessMode>()), Times.Once);
        }

        [Test]
        public void CommentInputTest()
        {
            _interactorMock.Setup(f => f.CommentInput(It.IsAny<string>(), false));

            var presenter = new PresenterUpdatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.CommentInput(It.IsAny<string>());

            _interactorMock.Verify(f => f.CommentInput(It.IsAny<string>(), false), Times.Once);
        }

        [Test]
        public void GoToSelectingImageTest()
        {
            _routerMock.Setup(f => f.ToGallery());

            var presenter = new PresenterUpdatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.GoToSelectingImage();

            _routerMock.Verify(f => f.ToGallery(), Times.Once);
        }

        [Test]
        public void GoToMainTest()
        {
            _routerMock.Setup(f => f.ToPostsFeed());

            var presenter = new PresenterUpdatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.GoToMain();

            _routerMock.Verify(f => f.ToPostsFeed(), Times.Once);
        }

        [Test]
        public void SaveAttachedImageTest()
        {
            _interactorMock.Setup(f => f.SaveAttachedImage(It.IsAny<string>()));

            var presenter = new PresenterUpdatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.SaveAttachedImage(It.IsAny<string>());

            _interactorMock.Verify(f => f.SaveAttachedImage(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void LoadAttachedImageTest()
        {
            _interactorMock.Setup(f => f.LoadAttachedImage()).Returns(It.IsAny<string>());

            var presenter = new PresenterUpdatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.LoadAttachedImage();

            _interactorMock.Verify(f => f.LoadAttachedImage(), Times.Once);
        }

        [Test]
        public void DisposeTest()
        {
            _interactorMock.Setup(f => f.Dispose());

            var presenter = new PresenterUpdatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.Dispose();

            _interactorMock.Verify(f => f.Dispose(), Times.Once);
        }

        [Test]
        public void UpdateTest()
        {
            _interactorMock.Setup(f => f.UpdatePost(EAccessMode.Private, null, null));

            var presenter = new PresenterUpdatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.UpdatePost(EAccessMode.Private, null, null);

            _interactorMock.Verify(f => f.UpdatePost(EAccessMode.Private, null, null), Times.Once);
        }

        [TestCase(EState.None)]
        [TestCase(EState.Fail)]
        public void AccessModeStateTest(EState state)
        {
            _viewMock.Setup(f => f.SetAccessModeTheme(null));
            var presenter = new PresenterUpdatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.AccessModeState(state);

            _viewMock.Verify(f => f.SetAccessModeTheme(null), Times.Once);
        }

        [TestCase(EState.Success)]
        [TestCase(EState.PassDoesNotMatch)]
        [TestCase(EState.UserAgreementNotChecked)]
        public void AccessModeStateAnotherTest(EState state)
        {
            var presenter = new PresenterUpdatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);
            presenter.AccessModeState(state);
        }

        [Test]
        public void SetDataSimplePostTest()
        {
            _viewMock.Setup(f => f.SetImage(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetAccessMode(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetComment(It.IsAny<string>()));

            var presenter = new PresenterUpdatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.SetData(new UpdatePostModel(true, "111", null, null, null, null, "Публичный", "image", "content"));

            _viewMock.Verify(f => f.SetImage(It.IsAny<string>()), Times.Once);
            _viewMock.Verify(f => f.SetAccessMode(It.IsAny<string>()), Times.Once);
            _viewMock.Verify(f => f.SetComment(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void SetDataFullPostTest()
        {
            _viewMock.Setup(f => f.SetImage(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetAccessMode(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetComment(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetBuySell(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetForecastTime(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetPrice(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetTools(It.IsAny<string>()));

            var presenter = new PresenterUpdatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.SetData(new UpdatePostModel(false, "111", "AUDCAD", "12.12.2017 12.45", "12.23", "Продать", "Публичный", "image", "content"));

            _viewMock.Verify(f => f.SetImage(It.IsAny<string>()), Times.Once);
            _viewMock.Verify(f => f.SetAccessMode(It.IsAny<string>()), Times.Once);
            _viewMock.Verify(f => f.SetComment(It.IsAny<string>()), Times.Once);
            _viewMock.Verify(f => f.SetBuySell(It.IsAny<string>()), Times.Once);
            _viewMock.Verify(f => f.SetForecastTime(It.IsAny<string>()), Times.Once);
            _viewMock.Verify(f => f.SetPrice(It.IsAny<string>()), Times.Once);
            _viewMock.Verify(f => f.SetTools(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ShowSpinnerTest()
        {
            _viewMock.Setup(f => f.ShowSpinner());

            var presenter = new PresenterUpdatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.ShowHideSpinner(true);
            
            _viewMock.Verify(f => f.ShowSpinner(), Times.Once);
        }

        [Test]
        public void HideSpinnerTest()
        {
            _viewMock.Setup(f => f.HideSpinner());

            var presenter = new PresenterUpdatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.ShowHideSpinner(false);

            _viewMock.Verify(f => f.HideSpinner(), Times.Once);
        }

        [Test]
        public void NeedToSaveDataTest()
        {
            _viewMock.Setup(f => f.NeedToSaveData());

            var presenter = new PresenterUpdatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.NeedToSaveData();

            _viewMock.Verify(f => f.NeedToSaveData(), Times.Once);
        }

        [Test]
        public void AccessModeClickTest()
        {
            _viewMock.Setup(f => f.AccessModeSelection(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));

            var presenter = new PresenterUpdatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.AccessModeClick();

            _viewMock.Verify(f => f.AccessModeSelection(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void UpdatePostStateSuccessTest()
        {
            _routerMock.Setup(f => f.ToPostsFeed());
            _viewMock.Setup(f => f.ShowSuccessAlert(It.IsAny<string>(), It.IsAny<string>()));

            var presenter = new PresenterUpdatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.UpdatePostState(EPostResponseStatus.Success);

            _viewMock.Verify(f => f.ShowSuccessAlert(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [TestCase(EPostResponseStatus.Error)]
        [TestCase(EPostResponseStatus.Unauthorized)]
        [TestCase(EPostResponseStatus.UnprocessableEntity)]
        [TestCase(EPostResponseStatus.BadRequest)]
        public void UpdatePostStateFailTest(EPostResponseStatus state)
        {
            _viewMock.Setup(f => f.ShowFailAlert(It.IsAny<string>(), It.IsAny<string>()));
            var presenter = new PresenterUpdatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.UpdatePostState(state);

            _viewMock.Verify(f => f.ShowFailAlert(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
