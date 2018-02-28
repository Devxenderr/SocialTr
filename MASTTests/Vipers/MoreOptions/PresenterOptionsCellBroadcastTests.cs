using System;

using Moq;
using NUnit.Framework;

using SocialTrading.Tools.Enumerations;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.Vipers.MoreOptions.OptionsCell.Interfaces;
using SocialTrading.Vipers.MoreOptions.OptionsCell.Implementation;

namespace MASTTests.Vipers.MoreOptions
{
    [TestFixture, Author("Elena Pakhomova")]
    public class PresenterOptionsCellBroadcastTests
    {
        private Mock<IInteractorOptionsCell> _interactorMock;
        private Mock<IViewOptionsCell> _viewMock;
        private Mock<IRouterOptionsCell> _routerMock;
        private Mock<IOptionsCellStyleHolder> _styleHolder;

        private IPresenterOptionsCell _presenter;

        [SetUp]
        public void SetUp()
        {
            _interactorMock = new Mock<IInteractorOptionsCell>(MockBehavior.Strict);
            _viewMock = new Mock<IViewOptionsCell>(MockBehavior.Strict);
            _routerMock = new Mock<IRouterOptionsCell>(MockBehavior.Strict);
            _styleHolder = new Mock<IOptionsCellStyleHolder>(MockBehavior.Default);
        }

        [Test]
        public void CtorNullViewTest()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                _presenter = new PresenterOptionsCell(null, _interactorMock.Object, _routerMock.Object, _styleHolder.Object);
            });
        }

        [Test]
        public void CtorNullInteractorTest()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                _presenter = new PresenterOptionsCell(_viewMock.Object, null, _routerMock.Object, _styleHolder.Object);
            });
        }

        [Test]
        public void CtorNullRouterTest()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                _presenter = new PresenterOptionsCell(_viewMock.Object, _interactorMock.Object, null, _styleHolder.Object);
            });
        }

        [Test]
        public void CtorSuccessTest()
        {
            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterOptionsCellForInteractor>());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterOptionsCellForView>());

            _presenter = new PresenterOptionsCell(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _styleHolder.Object);

            _interactorMock.VerifySet(f => f.Presenter = It.IsAny<IPresenterOptionsCellForInteractor>(), Times.Once);
            _viewMock.VerifySet(f => f.Presenter = It.IsAny<IPresenterOptionsCellForView>(), Times.Once);
        }

        [Test]
        public void CellClickTest()
        {
            _interactorMock.Setup(f => f.CellClick());

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterOptionsCellForInteractor>());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterOptionsCellForView>());

            _presenter = new PresenterOptionsCell(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _styleHolder.Object);
            _presenter.CellClick();

            _interactorMock.Verify(f => f.CellClick(), Times.Once());
        }

        [Test]
        public void GoToTest()
        {
            _routerMock.Setup(f => f.GoTo(It.IsAny<EItemsOptions>()));

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterOptionsCellForInteractor>());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterOptionsCellForView>());

            _presenter = new PresenterOptionsCell(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _styleHolder.Object);
            _presenter.GoTo(It.IsAny<EItemsOptions>());

            _routerMock.Verify(f => f.GoTo(It.IsAny<EItemsOptions>()), Times.Once());
        }

        [Test]
        public void SetConfigTest()
        {
            _interactorMock.Setup(f => f.SetConfig());

            _viewMock.Setup(f => f.SetImageTheme(It.IsAny<IImageViewTheme>()));
            _viewMock.Setup(f => f.SetTextTheme(It.IsAny<ITextViewTheme>()));
            _viewMock.Setup(f => f.SetBackgroundTheme(It.IsAny<IViewTheme>()));

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterOptionsCellForInteractor>());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterOptionsCellForView>());

            _presenter = new PresenterOptionsCell(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _styleHolder.Object);
            _presenter.SetConfig();

            _interactorMock.Verify(f => f.SetConfig(), Times.Once());
        }

        [Test]
        public void SetImageTest()
        {
            _viewMock.Setup(f => f.SetImage(null));

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterOptionsCellForInteractor>());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterOptionsCellForView>());

            _presenter = new PresenterOptionsCell(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _styleHolder.Object);
            _presenter.SetImage(null);

            _viewMock.Verify(f => f.SetImage(null), Times.Once());
        }

        [Test]
        public void SetTextTest()
        {
            _viewMock.Setup(f => f.SetText(null));

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterOptionsCellForInteractor>());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterOptionsCellForView>());

            _presenter = new PresenterOptionsCell(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _styleHolder.Object);
            _presenter.SetText(null);

            _viewMock.Verify(f => f.SetText(null), Times.Once());
        }
    }
}
