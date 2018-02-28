using Moq;

using NUnit.Framework;

using SocialTrading.Vipers.Entity;
using SocialTrading.Theme.ThemeStrings;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Registration.Name.Interfaces;
using SocialTrading.Vipers.Registration.Name.Implementation;
using SocialTrading.Service;
using SocialTrading.Locale.Modules;
using SocialTrading.ThemesStyles.Interfaces.EditText;

namespace MASTTests.Vipers.Reg.Presenter
{
    [TestFixture]
    public class PresenterRegNameTests
    {
        private Mock<IRouterRegName> _routerMock;
        private Mock<IViewRegName> _viewMock;
        private Mock<IInteractorRegName> _interactorMock;
        private Mock<IRegAuth> _regLocaleStrings;
        private Mock<IRegNameStylesHolder> _stylesHolderMock;

        [SetUp]
        public void SetUp()
        {
            _routerMock = new Mock<IRouterRegName>(MockBehavior.Strict);
            _viewMock = new Mock<IViewRegName>(MockBehavior.Strict);
            _interactorMock = new Mock<IInteractorRegName>(MockBehavior.Strict);

            _viewMock.SetupSet(f => f.Presenter = It.IsAny<PresenterRegName>());
            _viewMock.Setup(f => f.SetConfig());

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<PresenterRegName>());
            
            _regLocaleStrings = new Mock<IRegAuth>(MockBehavior.Strict);            
            _stylesHolderMock = new Mock<IRegNameStylesHolder>(MockBehavior.Strict);
        }

        [Test]
        public void NameInputTest()
        {
            _interactorMock.Setup(f => f.NameInput(It.IsAny<string>())).Returns(false);
            _viewMock.Setup(f => f.GetFirstName()).Returns(string.Empty);

            var presenter = new PresenterRegName(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings.Object);

            presenter.NameInput();

            _interactorMock.Verify(f => f.NameInput(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void LastNameInputTest()
        {
            _interactorMock.Setup(f => f.LastNameInput(It.IsAny<string>())).Returns(false);
            _viewMock.Setup(f => f.GetLastName()).Returns(string.Empty);

            var presenter = new PresenterRegName(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings.Object);

            presenter.LastNameInput();

            _interactorMock.Verify(f => f.LastNameInput(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void BackClickTest()
        {
            _routerMock.Setup(f => f.ToAuth());
            var presenter = new PresenterRegName(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings.Object);

            presenter.BackClick();

            _routerMock.Verify(f => f.ToAuth());
        }

        [Test]
        public void NextClickTest()
        {
            _routerMock.Setup(f => f.ToRegPhone());
            _interactorMock.Setup(f => f.NextClick(It.IsAny<RegistrationNamesStrings>())).Returns(true);
            _viewMock.Setup(f => f.GetFirstName()).Returns(string.Empty);
            _viewMock.Setup(f => f.GetLastName()).Returns(string.Empty);

            var presenter = new PresenterRegName(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings.Object);

            presenter.NextClick();

            _routerMock.Verify(f => f.ToRegPhone());
        }

        [Test]
        public void SaveDataTest()
        {
            _interactorMock.Setup(f => f.SaveData(It.IsAny<RegistrationNamesStrings>()));
            _viewMock.Setup(f => f.GetFirstName()).Returns(string.Empty);
            _viewMock.Setup(f => f.GetLastName()).Returns(string.Empty);
            var presenter = new PresenterRegName(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings.Object);

            presenter.SaveData();

            _interactorMock.Verify(f => f.SaveData(It.IsAny<RegistrationNamesStrings>()));
        }

        [Test]
        public void LoadDataTest()
        {
            _interactorMock.Setup(f => f.LoadData()).Returns(new RegistrationNamesStrings(string.Empty, string.Empty));
            _viewMock.Setup(f => f.SetFirstName(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetLastName(It.IsAny<string>()));

            var presenter = new PresenterRegName(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings.Object);

            presenter.LoadData();

            _interactorMock.Verify(f => f.LoadData());
        }

        [Test]
        public void CheckLastSuccessNameTest()
        {
            _viewMock.Setup(f => f.SetLastNameEditTextTheme(null));
            _stylesHolderMock.SetupGet(f => f.LastNameStateSuccess).Returns(It.IsAny<IEditTextTheme>());
            var presenter = new PresenterRegName(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings.Object);

            presenter.SetLastNameState(EState.Success);

            _viewMock.Verify(f => f.SetLastNameEditTextTheme(null), Times.Once);
        }

        [Test]
        public void CheckLastFailNameTest()
        {
            _viewMock.Setup(f => f.SetLastNameEditTextTheme(null));
            _stylesHolderMock.SetupGet(f => f.LastNameStateFail).Returns(It.IsAny<IEditTextTheme>());
            var presenter = new PresenterRegName(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings.Object);

            presenter.SetLastNameState(EState.Fail);

            _viewMock.Verify(f => f.SetLastNameEditTextTheme(null), Times.Once);
        }

        [TestCase(EState.None, Author = "Elena Pakhomova")]
        [TestCase(EState.PassDoesNotMatch, Author = "Elena Pakhomova")]
        [TestCase(EState.UserAgreementNotChecked, Author = "Elena Pakhomova")]
        public void CheckLastNameStateAnotherTest(EState state)
        {
            var presenter = new PresenterRegName(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings.Object);
            presenter.SetLastNameState(state);
        }
        
        [Test]
        public void CheckNameSuccessTest()
        {
            _viewMock.Setup(f => f.SetNameEditTextTheme(null));
            _stylesHolderMock.SetupGet(f => f.NameStateSuccess).Returns(It.IsAny<IEditTextTheme>());
            var presenter = new PresenterRegName(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings.Object);

            presenter.SetNameState(EState.Success);

            _viewMock.Verify(f => f.SetNameEditTextTheme(null), Times.Once);
        }

        [Test]
        public void CheckNameTest()
        {
            _viewMock.Setup(f => f.SetNameEditTextTheme(null));
            _stylesHolderMock.SetupGet(f => f.NameStateFail).Returns(It.IsAny<IEditTextTheme>());
            var presenter = new PresenterRegName(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings.Object);

            presenter.SetNameState(EState.Fail);

            _viewMock.Verify(f => f.SetNameEditTextTheme(null), Times.Once);
        }

        [TestCase(EState.None, Author = "Elena Pakhomova")]
        [TestCase(EState.PassDoesNotMatch, Author = "Elena Pakhomova")]
        [TestCase(EState.UserAgreementNotChecked, Author = "Elena Pakhomova")]
        public void CheckNameStateAnotherTest(EState state)
        {
            var presenter = new PresenterRegName(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings.Object);
            presenter.SetNameState(state);
        }
    }
}
