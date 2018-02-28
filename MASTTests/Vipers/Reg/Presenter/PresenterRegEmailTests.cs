using Moq;

using NUnit.Framework;

using SocialTrading.Locale.Modules;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Registration.Email.Interfaces;
using SocialTrading.Vipers.Registration.Email.Implementation;
using SocialTrading.ThemesStyles.Interfaces.EditText;

namespace MASTTests.Vipers.Reg.Presenter
{
    [TestFixture]
    public class PresenterRegEmailTests
    {
        private Mock<IRouterRegEmail> _routerMock;
        private Mock<IViewRegEmail> _viewMock;
        private Mock<IInteractorRegEmail> _interactorMock;
        private Mock<IRegAuth> _regLocaleStrings;
        private Mock<IRegEmailStylesHolder> _stylesHolderMock;

        [SetUp]
        public void SetUp()
        {
            _routerMock = new Mock<IRouterRegEmail>(MockBehavior.Strict);
            _viewMock = new Mock<IViewRegEmail>(MockBehavior.Strict);
            _interactorMock = new Mock<IInteractorRegEmail>(MockBehavior.Strict);

            _viewMock.SetupSet(f => f.Presenter = It.IsAny<PresenterRegEmail>());
            _viewMock.Setup(f => f.SetConfig());

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<PresenterRegEmail>());
            
            _regLocaleStrings = new Mock<IRegAuth>(MockBehavior.Strict);
            _stylesHolderMock = new Mock<IRegEmailStylesHolder>(MockBehavior.Strict);
        }

        [Test]
        public void EmailInputTest()
        {
            _interactorMock.Setup(f => f.EmailInput(It.IsAny<string>())).Returns(false);
            _viewMock.Setup(f => f.GetEmail()).Returns(string.Empty);

            var presenter = new PresenterRegEmail(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings.Object);

            presenter.EmailInput();

            _interactorMock.Verify(f => f.EmailInput(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void BackClickTest()
        {
            _routerMock.Setup(f => f.ToRegPhone());
            var presenter = new PresenterRegEmail(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings.Object);

            presenter.BackClick();

            _routerMock.Verify(f => f.ToRegPhone());
        }

        [Test]
        public void NextClickTest()
        {
            _routerMock.Setup(f => f.ToRegPassword());
            _interactorMock.Setup(f => f.NextClick(It.IsAny<string>())).Returns(true);
            _viewMock.Setup(f => f.GetEmail()).Returns(string.Empty);

            var presenter = new PresenterRegEmail(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings.Object);

            presenter.NextClick();

            _routerMock.Verify(f => f.ToRegPassword());
        }

        [Test]
        public void SaveDataTest()
        {
            _interactorMock.Setup(f => f.SaveData(It.IsAny<string>()));
            _viewMock.Setup(f => f.GetEmail()).Returns(string.Empty);
            var presenter = new PresenterRegEmail(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings.Object);

            presenter.SaveData();

            _interactorMock.Verify(f => f.SaveData(It.IsAny<string>()));
        }

        [Test]
        public void LoadDataTest()
        {
            _interactorMock.Setup(f => f.LoadData()).Returns(string.Empty);
            _viewMock.Setup(f => f.SetEmail(It.IsAny<string>()));

            var presenter = new PresenterRegEmail(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings.Object);

            presenter.LoadData();

            _interactorMock.Verify(f => f.LoadData());
        }

        [Test]
        public void CheckEmailStateSuccessTest()
        {
            _viewMock.Setup(f => f.SetEmailEditTextTheme(null));
            _stylesHolderMock.SetupGet(f => f.EmailStateSuccess).Returns(It.IsAny<IEditTextTheme>());
            var presenter = new PresenterRegEmail(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings.Object);

            presenter.SetEmailState(EState.Success);

            _viewMock.Verify(f => f.SetEmailEditTextTheme(null), Times.Once);
        }

        [Test]
        public void CheckNameStateFailTest()
        {
            _viewMock.Setup(f => f.SetEmailEditTextTheme(null));
            _stylesHolderMock.SetupGet(f => f.EmailStateFail).Returns(It.IsAny<IEditTextTheme>());
            var presenter = new PresenterRegEmail(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings.Object);

            presenter.SetEmailState(EState.Fail);

            _viewMock.Verify(f => f.SetEmailEditTextTheme(null), Times.Once);
        }

        [TestCase(EState.None, Author = "Elena Pakhomova")]
        [TestCase(EState.PassDoesNotMatch, Author = "Elena Pakhomova")]
        [TestCase(EState.UserAgreementNotChecked, Author = "Elena Pakhomova")]
        public void CheckNameStateAnotherTest(EState state)
        {
            var presenter = new PresenterRegEmail(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings.Object);
            presenter.SetEmailState(state);
        }
    }
}
