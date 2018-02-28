using Moq;

using NUnit.Framework;

using SocialTrading.Service;
using SocialTrading.Vipers.Entity;
using SocialTrading.Locale.Modules;
using SocialTrading.Theme.ThemeStrings;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Registration.Phone.Interfaces;
using SocialTrading.Vipers.Registration.Phone.Implementation;

namespace MASTTests.Vipers.Reg.Presenter
{
    [TestFixture]
    public class PresenterRegPhoneTests
    {
        private Mock<IRouterRegPhone> _routerMock;
        private Mock<IViewRegPhone> _viewMock;
        private Mock<IInteractorRegPhone> _interactorMock;
        private Mock<IRegPhoneStylesHolder> _stylesHolderMock;
        private IRegAuth _regLocaleStrings;

        [SetUp]
        public void SetUp()
        {
            _routerMock = new Mock<IRouterRegPhone>(MockBehavior.Strict);
            _viewMock = new Mock<IViewRegPhone>(MockBehavior.Strict);
            _interactorMock = new Mock<IInteractorRegPhone>(MockBehavior.Strict);

            _viewMock.SetupSet(f => f.Presenter = It.IsAny<PresenterRegPhone>());
            _viewMock.Setup(f => f.SetConfig());
            
            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<PresenterRegPhone>());
            
            _stylesHolderMock = new Mock<IRegPhoneStylesHolder>(MockBehavior.Strict);

            _regLocaleStrings = DataService.RepositoryController.RepositoryRA.LangRA;
        }

       [Test]
        public void PhoneNumberTest()
        {
            _interactorMock.Setup(f => f.PhoneNumberInput(It.IsAny<string>())).Returns(false);
            _viewMock.Setup(f => f.GetPhoneNumber()).Returns(string.Empty);

            var presenter = new PresenterRegPhone(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);

            presenter.PhoneNumberInput();

            _interactorMock.Verify(f => f.PhoneNumberInput(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void PhoneCountryInputTest()
        {
            _interactorMock.Setup(f => f.PhoneCountryInput(It.IsAny<string>())).Returns(false);
            _viewMock.Setup(f => f.GetPhoneCountry()).Returns(string.Empty);

            var presenter = new PresenterRegPhone(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);

            presenter.PhoneCountryInput();

            _interactorMock.Verify(f => f.PhoneCountryInput(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void BackClickTest()
        {
            _routerMock.Setup(f => f.ToRegName());
            var presenter = new PresenterRegPhone(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);

            presenter.BackClick();

            _routerMock.Verify(f => f.ToRegName());
        }

        [Test]
        public void SkipClickTest()
        {
            _routerMock.Setup(f => f.ToRegEmail());
            var presenter = new PresenterRegPhone(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);

            presenter.SkipClick();

            _routerMock.Verify(f => f.ToRegEmail());
        }


        [Test]
        public void NextClickTest()
        {
            _routerMock.Setup(f => f.ToRegEmail());
            _interactorMock.Setup(f => f.NextClick(It.IsAny<RegistrationPhoneStrings>())).Returns(true);
            _viewMock.Setup(f => f.GetPhoneCountry()).Returns(string.Empty);
            _viewMock.Setup(f => f.GetPhoneNumber()).Returns(string.Empty);

            var presenter = new PresenterRegPhone(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);

            presenter.NextClick();

            _routerMock.Verify(f => f.ToRegEmail());
        }

        [Test]
        public void SaveDataTest()
        {
            _interactorMock.Setup(f => f.SaveData(It.IsAny<RegistrationPhoneStrings>()));
            _viewMock.Setup(f => f.GetPhoneCountry()).Returns(string.Empty);
            _viewMock.Setup(f => f.GetPhoneNumber()).Returns(string.Empty);
            var presenter = new PresenterRegPhone(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);

            presenter.SaveData();

            _interactorMock.Verify(f => f.SaveData(It.IsAny<RegistrationPhoneStrings>()));
        }

        [Test]
        public void LoadDataTest()
        {
            _interactorMock.Setup(f => f.LoadData()).Returns(new RegistrationPhoneStrings(string.Empty, string.Empty));
            _viewMock.Setup(f => f.SetPhoneCountry(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetPhoneNumber(It.IsAny<string>()));

            var presenter = new PresenterRegPhone(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);

            presenter.LoadData();

            _interactorMock.Verify(f => f.LoadData());
        }

        [Test]
        public void SetPhoneCountryStateSuccessTest()
        {
            _stylesHolderMock.SetupGet(f => f.PhoneCountryStateSuccess).Returns(It.IsAny<IEditTextTheme>());
            _viewMock.Setup(f => f.SetPhoneCountryEditTextTheme(null));
            var presenter = new PresenterRegPhone(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);
            _viewMock.Setup(f => f.SetPhoneNumberEditTextTheme(null));

            presenter.SetPhoneCountryState(EState.Success);

            _viewMock.Verify(f => f.SetPhoneCountryEditTextTheme(null), Times.Once);
        }

        [Test]
        public void SetPhoneCountryStateFailTest()
        {
            _stylesHolderMock.SetupGet(f => f.PhoneCountryStateFail).Returns(It.IsAny<IEditTextTheme>());
            _viewMock.Setup(f => f.SetPhoneCountryEditTextTheme(null));
            var presenter = new PresenterRegPhone(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);
            _viewMock.Setup(f => f.SetPhoneNumberEditTextTheme(null));

            presenter.SetPhoneCountryState(EState.Fail);

            _viewMock.Verify(f => f.SetPhoneCountryEditTextTheme(null), Times.Once);
        }

        [TestCase(EState.None, Author = "Elena Pakhomova")]
        [TestCase(EState.PassDoesNotMatch, Author = "Elena Pakhomova")]
        [TestCase(EState.UserAgreementNotChecked, Author = "Elena Pakhomova")]
        public void SetPhoneCountryStateAnotherTest(EState state)
        {
            var presenter = new PresenterRegPhone(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);
            presenter.SetPhoneCountryState(state);
        }

        [Test]
        public void SetPhoneNumberStateSuccessTest()
        {
            _stylesHolderMock.SetupGet(f => f.PhoneNumberStateSuccess).Returns(It.IsAny<IEditTextTheme>());
            _viewMock.Setup(f => f.SetPhoneNumberEditTextTheme(null));
            var presenter = new PresenterRegPhone(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);
            _viewMock.Setup(f => f.SetPhoneCountryEditTextTheme(null));

            presenter.SetPhoneNumberState(EState.Success);

            _viewMock.Verify(f => f.SetPhoneNumberEditTextTheme(null), Times.Once);
        }

        [Test]
        public void SetPhoneNumberStateFailTest()
        {
            _stylesHolderMock.SetupGet(f => f.PhoneNumberStateFail).Returns(It.IsAny<IEditTextTheme>());
            _viewMock.Setup(f => f.SetPhoneNumberEditTextTheme(null));
            var presenter = new PresenterRegPhone(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);
            _viewMock.Setup(f => f.SetPhoneCountryEditTextTheme(null));

            presenter.SetPhoneNumberState(EState.Fail);

            _viewMock.Verify(f => f.SetPhoneNumberEditTextTheme(null), Times.Once);
        }

        [TestCase(EState.None, Author = "Elena Pakhomova")]
        [TestCase(EState.PassDoesNotMatch, Author = "Elena Pakhomova")]
        [TestCase(EState.UserAgreementNotChecked, Author = "Elena Pakhomova")]
        public void SetPhoneNumberStateAnotherTest(EState state)
        {
            var presenter = new PresenterRegPhone(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);
            presenter.SetPhoneCountryState(state);
        }
    }
}
