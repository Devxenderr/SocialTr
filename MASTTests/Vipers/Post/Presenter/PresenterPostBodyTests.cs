using Moq;

using NUnit.Framework;

using SocialTrading.DTO.Response.Post;
using SocialTrading.Service.Repositories;
using SocialTrading.Vipers.Post.Interfaces.Body;
using SocialTrading.Vipers.Post.Implementation.Body;
using SocialTrading.ThemesStyles.Interfaces.TextView;

namespace MASTTests.Vipers.Post.Presenter
{
    [TestFixture]
    public class PresenterPostBodyTests
    {
        private Mock<IViewPostBody> _viewMock;
        private Mock<IRouterPostBody> _routerMock;
        private Mock<IInteractorPostBody> _interactorMock;
        private Mock<IPostBodyStylesHolder> _stylesHolderMock;

        [SetUp]
        public void SetUp()
        {
            _viewMock = new Mock<IViewPostBody>(MockBehavior.Strict);
            _routerMock = new Mock<IRouterPostBody>(MockBehavior.Strict);
            _interactorMock = new Mock<IInteractorPostBody>(MockBehavior.Strict);

            _viewMock.SetupSet(f => f.Presenter = It.IsAny<PresenterPostBody>());
            _viewMock.Setup(f => f.SetConfig());

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<PresenterPostBody>());
            _interactorMock.SetupSet(f => f.IsPostDetailed = It.IsAny<bool>());
            _stylesHolderMock = new Mock<IPostBodyStylesHolder>(MockBehavior.Strict);
        }

        [Test(Author = "Elena Pakhomova")]
        public void ReadMoreClickTest()
        {
            _routerMock.Setup(f => f.ToDetailedPost(It.IsAny<string>()));
            _interactorMock.SetupGet(f => f.PostId).Returns(It.IsAny<string>());

            var presenter = new PresenterPostBody(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, false);

            presenter.ReadMoreClick();

            _routerMock.Verify(f => f.ToDetailedPost(It.IsAny<string>()), Times.Once);
        }

        [Test(Author = "Elena Pakhomova")]
        public void SetBodySmallTextTest()
        {
            _viewMock.Setup(f => f.SetContent("content", It.IsAny<ITextViewTheme>()));
            _viewMock.Setup(f => f.SetImage(""));

            _interactorMock.SetupGet(f => f.PostId).Returns(It.IsAny<string>());
            _interactorMock.SetupGet(f => f.IsPostDetailed).Returns(It.IsAny<bool>());
            _interactorMock.Setup(f => f.GetRepository()).Returns(new SocialTrading.Service.Repositories.Repository(new RepositoryUserAuth(), new RepositoryUserSettings()));

            _stylesHolderMock.SetupGet(f => f.ContentTheme).Returns(It.IsAny<ITextViewTheme>());

            var presenter = new PresenterPostBody(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, false);

            presenter.SetBody(new DataModelPost(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<float>(),
                It.IsAny<string>(), "", "content", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(),
                It.IsAny<int>(), It.IsAny<bool>())
            { CachedImage = "" });

            _viewMock.Verify(f => f.SetContent("content", It.IsAny<ITextViewTheme>()), Times.Once);
            _viewMock.Verify(f => f.SetImage(""), Times.Once);

            _stylesHolderMock.VerifyGet(f => f.ContentTheme, Times.Once);
        }

        [Test(Author = "Oleh Marchenko")]
        public void SetBodyLargeTextTest()
        {
            _viewMock.Setup(f => f.SetContent("content content content content content content content content content content content content" +
                                              "content content content content content content content content content content content content" +
                                              "content co...",
                                              "Читать дальше", It.IsAny<ITextViewTheme>(), It.IsAny<ITextViewTheme>(), It.IsAny<int>()));
            _viewMock.Setup(f => f.SetImage(""));

            _interactorMock.Setup(f => f.GetRepository()).Returns(new SocialTrading.Service.Repositories.Repository(new RepositoryUserAuth(), new RepositoryUserSettings()));
            _interactorMock.SetupGet(f => f.PostId).Returns(It.IsAny<string>());
            _interactorMock.SetupGet(f => f.IsPostDetailed).Returns(It.IsAny<bool>());

            _stylesHolderMock.SetupGet(f => f.ContentTheme).Returns(It.IsAny<ITextViewTheme>());
            _stylesHolderMock.SetupGet(f => f.MoreTextTheme).Returns(It.IsAny<ITextViewTheme>());

            var presenter = new PresenterPostBody(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, false);

            presenter.SetBody(new DataModelPost(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<float>(), It.IsAny<string>(), "",
                "content content content content content content content content content content content content" +
                "content content content content content content content content content content content content" +
                "content content content content content content content content content content content content",
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<bool>())
            { CachedImage = "" }, 200);

            _viewMock.Verify(f => f.SetContent("content content content content content content content content content content content content" +
                                               "content content content content content content content content content content content content" +
                                               "content co...",
                                               "Читать дальше", It.IsAny<ITextViewTheme>(), It.IsAny<ITextViewTheme>(), It.IsAny<int>()), Times.Once);
            _viewMock.Verify(f => f.SetImage(""), Times.Once);

            _stylesHolderMock.VerifyGet(f => f.ContentTheme, Times.Once);
            _stylesHolderMock.VerifyGet(f => f.MoreTextTheme, Times.Once);
        }
    }
}
