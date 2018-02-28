using System;

using Moq;
using NUnit.Framework;

using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.Vipers.MoreOptions;
using SocialTrading.Vipers.MoreOptions.OptionsCell.Interfaces;
using SocialTrading.Vipers.MoreOptions.ToolBar.Interfaces;
using SocialTrading.Vipers.MoreOptions.ToolBar.Implementation;

namespace MASTTests.Vipers.MoreOptions
{
    [TestFixture, Author("Vladimir Viktorov")]
    public class PresenterToolBarBackTests
    {
        private Mock<IToolBarBackView> _viewMock;
        private Mock<IToolBarBackStylesHolder> _stylesHolderMock;
        private Mock<IRouterToolBarBack> _routerMock;

        [SetUp]
        public void SetUp()
        {
            _viewMock = new Mock<IToolBarBackView>(MockBehavior.Strict);
            _routerMock = new Mock<IRouterToolBarBack>(MockBehavior.Strict);
            _stylesHolderMock = new Mock<IToolBarBackStylesHolder>(MockBehavior.Strict);
        }

        [Test]
        public void ViewConstructorTest()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var presenterToolBarBack = new PresenterToolBarBack(null, _routerMock.Object, _stylesHolderMock.Object, "");
            });
        }
        [Test]
        public void RouterConstructorTest()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var presenterToolBarBack = new PresenterToolBarBack(_viewMock.Object, null, _stylesHolderMock.Object, "");
            });
        }

        [Test]
        public void TitleConstructorTest()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var presenterToolBarBack = new PresenterToolBarBack(_viewMock.Object, _routerMock.Object, _stylesHolderMock.Object, null);
            });
        }

        [Test(Author = "Elena Pakhomova")]
        public void ConstructorSuccessTest()
        {
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterToolBarBack>());

            var presenterToolBarBack = new PresenterToolBarBack(_viewMock.Object, _routerMock.Object, _stylesHolderMock.Object, "");

            _viewMock.VerifySet(f => f.Presenter = It.IsAny<IPresenterToolBarBack>(), Times.Once);
        }

        [Test]
        public void SetConfigTest()
        {
            var title = "settings";
            _viewMock.Setup(f => f.SetViewTheme(It.IsAny<IViewTheme>()));
            _viewMock.Setup(f => f.SetBackButtonTheme(It.IsAny<IImageButtonTheme>()));
            _viewMock.Setup(f => f.SetTitleTheme(It.IsAny<ITextViewTheme>()));
            _viewMock.Setup(f => f.SetTitle(title));

            _stylesHolderMock.SetupGet(f => f.ToolbarViewTheme).Returns(It.IsAny<IViewTheme>());
            _stylesHolderMock.SetupGet(f => f.BackButtonTheme).Returns(It.IsAny<IImageButtonTheme>());
            _stylesHolderMock.SetupGet(f => f.TitleTheme).Returns(It.IsAny<ITextViewTheme>());

            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterToolBarBack>());

            var presenterToolBarBack = new PresenterToolBarBack(_viewMock.Object, _routerMock.Object, _stylesHolderMock.Object, title);
            presenterToolBarBack.SetConfig();

            _viewMock.Verify(f => f.SetViewTheme(It.IsAny<IViewTheme>()), Times.Once);
            _viewMock.Verify(f => f.SetBackButtonTheme(It.IsAny<IImageButtonTheme>()), Times.Once);
            _viewMock.Verify(f => f.SetTitleTheme(It.IsAny<ITextViewTheme>()), Times.Once);
            _viewMock.Verify(f => f.SetTitle(title), Times.Once);

            _stylesHolderMock.VerifyGet(f => f.ToolbarViewTheme, Times.Once);
            _stylesHolderMock.VerifyGet(f => f.BackButtonTheme, Times.Once);
            _stylesHolderMock.VerifyGet(f => f.TitleTheme, Times.Once);
        }

        [Test(Author = "Elena Pakhomova")]
        public void SetConfigNullStyleHolderTest()
        {
            var title = "settings";
            _viewMock.Setup(f => f.SetTitle(title));
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterToolBarBack>());

            var presenterToolBarBack = new PresenterToolBarBack(_viewMock.Object, _routerMock.Object, null, title);
            presenterToolBarBack.SetConfig();
            
            _viewMock.Verify(f => f.SetTitle(title), Times.Once);
        }

        [Test]
        public void BackButtonClickTest()
        {
            _routerMock.Setup(f => f.GoBack());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterToolBarBack>());

            var presenterToolBarBack = new PresenterToolBarBack(_viewMock.Object, _routerMock.Object, _stylesHolderMock.Object, "");
            
            presenterToolBarBack.BackClick();

            _routerMock.Verify(f => f.GoBack(), Times.Once);
        }
    }
}