using System;

using Moq;

using NUnit.Framework;
using SocialTrading.Locale;
using SocialTrading.Vipers.Entity;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.CreatePost.Interfaces;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.CreatePost;
using SocialTrading.Vipers.CreatePost.Implementation;

namespace MASTTests.Vipers.CreatePost
{
    [TestFixture]
    public class PresenterCreatePostTests
    {
        private Mock<IRouterCreatePost> _routerMock;
        private Mock<IViewCreatePost> _viewMock;
        private Mock<IInteractorCreatePost> _interactorMock;
        private Mock<ICreatePostStylesHolder> _stylesHolderMock;

        [SetUp]
        public void SetUp()
        {
            _routerMock = new Mock<IRouterCreatePost>(MockBehavior.Strict);
            _viewMock = new Mock<IViewCreatePost>(MockBehavior.Strict);
            _interactorMock = new Mock<IInteractorCreatePost>(MockBehavior.Strict);
            _stylesHolderMock = new Mock<ICreatePostStylesHolder>(MockBehavior.Default);

            _viewMock.SetupSet(f => f.Presenter = It.IsAny<PresenterCreatePost>());
            _viewMock.Setup(f => f.SetConfig());

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<PresenterCreatePost>());
        }

        [Test]
        public void ImageSelectedTest()
        {
            _viewMock.Setup(f => f.SetAttachment());

            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.ImageSelected();

            _viewMock.Verify(f => f.SetAttachment(), Times.Once);
        }

        [Test]
        public void ReadyToSetPriceTest()
        {
            _interactorMock.Setup(f => f.ReadyToSetPrice("AUD/CAD", EBuySell.Buy));

            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.ReadyToSetPrice("AUD/CAD", EBuySell.Buy);

            _interactorMock.Verify(f => f.ReadyToSetPrice("AUD/CAD", EBuySell.Buy), Times.Once);
        }

        [Test]
        public void AddPostTest()
        {
            _interactorMock.Setup(f => f.AddPost(It.IsAny<string>(), It.IsAny<EBuySell>(), It.IsAny<EAccessMode>(), It.IsAny<string>(), It.IsAny<EForecastTime>(), It.IsAny<string>(), It.IsAny<string>()));

            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.AddPost(It.IsAny<string>(), It.IsAny<EBuySell>(), It.IsAny<EAccessMode>(), It.IsAny<string>(), It.IsAny<EForecastTime>(), It.IsAny<string>(), It.IsAny<string>());

            _interactorMock.Verify(f => f.AddPost(It.IsAny<string>(), It.IsAny<EBuySell>(), It.IsAny<EAccessMode>(), It.IsAny<string>(), It.IsAny<EForecastTime>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void DeleteAttachmentImageTest()
        {
            _viewMock.Setup(f => f.ImageDeleted());

            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.DeleteAttachmentImage();

            _viewMock.Verify(f => f.ImageDeleted(), Times.Once);
        }

        [Test]
        public void SetAvatarTest()
        {
            _viewMock.Setup(f => f.SetUserAvatar(It.IsAny<string>()));

            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.SetUserAvatar(It.IsAny<string>());

            _viewMock.Verify(f => f.SetUserAvatar(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void SetUserNameTest()
        {
            _viewMock.Setup(f => f.SetUserName(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetCommentLocale(It.IsAny<string>()));
            _interactorMock.SetupGet(f => f.GetRepository().LangCreatePost.EnterCommentLabel).Returns(It.IsAny<string>());

            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.SetUserName(It.IsAny<string>());

            _viewMock.Verify(f => f.SetUserName(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void AccessModeSelectedTest()
        {
            _interactorMock.Setup(f => f.AccessModeSelected(It.IsAny<EAccessMode>()));

            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.AccessModeSelected(It.IsAny<EAccessMode>());

            _interactorMock.Verify(f => f.AccessModeSelected(It.IsAny<EAccessMode>()), Times.Once);
        }

        [Test]
        public void BuySellSelectedTest()
        {
            _interactorMock.Setup(f => f.BuySellSelected(It.IsAny<EBuySell>()));

            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.BuySellSelected(It.IsAny<EBuySell>());

            _interactorMock.Verify(f => f.BuySellSelected(It.IsAny<EBuySell>()), Times.Once);
        }

        [Test]
        public void ForecastTimeSelectedTest()
        {
            _interactorMock.Setup(f => f.ForecastTimeSelected(It.IsAny<EForecastTime>()));

            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.ForecastTimeSelected(It.IsAny<EForecastTime>());

            _interactorMock.Verify(f => f.ForecastTimeSelected(It.IsAny<EForecastTime>()), Times.Once);
        }

        [Test]
        public void ToolSelectedTest()
        {
            _interactorMock.Setup(f => f.ToolSelected(It.IsAny<string>()));

            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.ToolSelected(It.IsAny<string>());

            _interactorMock.Verify(f => f.ToolSelected(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void CommentInputTest()
        {
            _interactorMock.Setup(f => f.CommentInput(It.IsAny<bool>(), false));

            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.CommentInput(It.IsAny<bool>());

            _interactorMock.Verify(f => f.CommentInput(It.IsAny<bool>(), false), Times.Once);
        }

        [Test]
        public void GoToSelectingImageTest()
        {
            _routerMock.Setup(f => f.ToGallery());

            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.GoToSelectingImage();

            _routerMock.Verify(f => f.ToGallery(), Times.Once);
        }

        [Test]
        public void GoToSelectingToolTest()
        {
            _routerMock.Setup(f => f.ToToolSelection());

            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.GoToSelectingTool();

            _routerMock.Verify(f => f.ToToolSelection(), Times.Once);
        }

        [Test]
        public void GoToMainTest()
        {
            _routerMock.Setup(f => f.ToPostsFeed());

            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.GoToMain();

            _routerMock.Verify(f => f.ToPostsFeed(), Times.Once);
        }

        [Test]
        public void SaveAttachedImageTest()
        {
            _interactorMock.Setup(f => f.SaveAttachedImage(It.IsAny<string>()));

            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.SaveAttachedImage(It.IsAny<string>());

            _interactorMock.Verify(f => f.SaveAttachedImage(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void LoadAttachedImageTest()
        {
            _interactorMock.Setup(f => f.LoadAttachedImage()).Returns(It.IsAny<string>());

            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.LoadAttachedImage();

            _interactorMock.Verify(f => f.LoadAttachedImage(), Times.Once);
        }

        [Test]
        public void SaveSelectedToolTest()
        {
            _interactorMock.Setup(f => f.SaveSelectedTool(It.IsAny<string>()));

            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.SaveSelectedTool(It.IsAny<string>());

            _interactorMock.Verify(f => f.SaveSelectedTool(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void LoadSelectedToolTest()
        {
            _interactorMock.Setup(f => f.LoadSelectedTool()).Returns("123");;
            _viewMock.Setup(f => f.SetSelectedTool(It.IsAny<string>()));

            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.LoadSelectedTool();

            _interactorMock.Verify(f => f.LoadSelectedTool(), Times.Once);
        }

        [Test]
        public void GetForecastTimeModelTest()
        {
            _interactorMock.Setup(f => f.GetForecastTimeModel()).Returns(It.IsAny<ForecastTimeModel>());

            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.GetForecastTimeModel();

            _interactorMock.Verify(f => f.GetForecastTimeModel(), Times.Once);
        }

        [Test]
        public void GetRepositoryTest()
        {
            _interactorMock.Setup(f => f.GetRepository()).Returns(It.IsAny<IRepositoryCreatePost>());

            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.GetRepository();

            _interactorMock.Verify(f => f.GetRepository(), Times.Once);
        }

        [Test]
        public void DisposeRepositoryCreatePostTest()
        {
            _interactorMock.Setup(f => f.DisposeRepositoryCreatePost());

            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.DisposeRepositoryCreatePost();

            _interactorMock.Verify(f => f.DisposeRepositoryCreatePost(), Times.Once);
        }

        [TestCase(EState.None)]
        [TestCase(EState.Fail)]
        public void AccessModeStateTest(EState state)
        {
            _viewMock.Setup(f => f.SetAccessModeTheme(null));
            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.AccessModeState(state);

            _viewMock.Verify(f => f.SetAccessModeTheme(null), Times.Once);
        }

        [TestCase(EState.Success, Author = "Elena Pakhomova")]
        [TestCase(EState.PassDoesNotMatch, Author = "Elena Pakhomova")]
        [TestCase(EState.UserAgreementNotChecked, Author = "Elena Pakhomova")]
        public void AccessModeStateAnotherTest(EState state)
        {
            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);
            presenter.AccessModeState(state);
        }

        [TestCase(EState.None)]
        [TestCase(EState.Fail)]
        public void ForecastTimeTest(EState state)
        {
            _viewMock.Setup(f => f.SetForecastTimeTheme(null));
            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.ForecastTimeState(state);

            _viewMock.Verify(f => f.SetForecastTimeTheme(null), Times.Once);
        }
        
        [TestCase(EState.Success, Author = "Elena Pakhomova")]
        [TestCase(EState.PassDoesNotMatch, Author = "Elena Pakhomova")]
        [TestCase(EState.UserAgreementNotChecked, Author = "Elena Pakhomova")]
        public void ForecastTimeStateAnotherTest(EState state)
        {
            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);
            presenter.ForecastTimeState(state);
        }

        [TestCase(EState.None)]
        [TestCase(EState.Fail)]
        public void BuySellTest(EState state)
        {
            _viewMock.Setup(f => f.SetBuySellTheme(null));
            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.BuySellState(state);

            _viewMock.Verify(f => f.SetBuySellTheme(null), Times.Once);
        }

        [TestCase(EState.Success, Author = "Elena Pakhomova")]
        [TestCase(EState.PassDoesNotMatch, Author = "Elena Pakhomova")]
        [TestCase(EState.UserAgreementNotChecked, Author = "Elena Pakhomova")]
        public void BuySellStateAnotherTest(EState state)
        {
            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);
            presenter.BuySellState(state);
        }

        [TestCase(EState.None)]
        [TestCase(EState.Fail)]
        public void ToolsTest(EState state)
        {
            _viewMock.Setup(f => f.SetToolsTheme(null));
            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.ToolState(state);

            _viewMock.Verify(f => f.SetToolsTheme(null), Times.Once);
        }

        [TestCase(EState.Success, Author = "Elena Pakhomova")]
        [TestCase(EState.PassDoesNotMatch, Author = "Elena Pakhomova")]
        [TestCase(EState.UserAgreementNotChecked, Author = "Elena Pakhomova")]
        public void ToolStateAnotherTest(EState state)
        {
            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);
            presenter.ToolState(state);
        }

        [TestCase(EState.None)]
        [TestCase(EState.Fail)]
        public void CommentTest(EState state)
        {
            _viewMock.Setup(f => f.SetCommentTheme(null));
            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.CommentState(state);

            _viewMock.Verify(f => f.SetCommentTheme(null), Times.Once);
        }

        [TestCase(EState.Success, Author = "Elena Pakhomova")]
        [TestCase(EState.PassDoesNotMatch, Author = "Elena Pakhomova")]
        [TestCase(EState.UserAgreementNotChecked, Author = "Elena Pakhomova")]
        public void CommentStateAnotherTest(EState state)
        {
            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);
            presenter.CommentState(state);
        }

        [Test]
        public void AddPostStateSuccessTest()
        {
            _viewMock.Setup(f => f.AddPostSuccess());
            _viewMock.Setup(f => f.SetInteractionAvailable());
            _routerMock.Setup(f => f.ToPostsFeed());
            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.AddPostState(EPostResponseStatus.Success);

            _viewMock.Verify(f => f.AddPostSuccess(), Times.Once);
        }

        [TestCase(EPostResponseStatus.Error, Author = "Elena Pakhomova")]
        [TestCase(EPostResponseStatus.Unauthorized, Author = "Elena Pakhomova")]
        [TestCase(EPostResponseStatus.UnprocessableEntity, Author = "Elena Pakhomova")]
        [TestCase(EPostResponseStatus.BadRequest, Author = "Elena Pakhomova")]
        public void AddPostStateFailTest(EPostResponseStatus state)
        {
            _viewMock.Setup(f => f.ShowErrorAlert(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetInteractionAvailable());
            _interactorMock.Setup(f => f.GetRepository().LangCreatePost.CreatePostBadRequest).Returns(It.IsAny<Func<string, string>>());
            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.AddPostState(state);

            _viewMock.Verify(f => f.ShowErrorAlert(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ShowSpinnerTest()
        {
            _viewMock.Setup(f => f.ShowSpinner());

            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.ShowHideSpinner(true);

            _viewMock.Verify(f => f.ShowSpinner(), Times.Once);
        }

        [Test]
        public void HideSpinnerTest()
        {
            _viewMock.Setup(f => f.HideSpinner());

            var presenter = new PresenterCreatePost(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, Localization.Lang);

            presenter.ShowHideSpinner(false);

            _viewMock.Verify(f => f.HideSpinner(), Times.Once);
        }
    }
}
