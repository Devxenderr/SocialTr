using Moq;

using NUnit.Framework;
using SocialTrading.Locale.Modules;
using SocialTrading.Theme.ThemeStrings;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Authorization;
using SocialTrading.Vipers.Authorization.Interfaces;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.Vipers.Authorization.Implementation;

namespace MASTTests.Vipers.Auth
{
    [TestFixture]
    public class PresenterAuthTests
    {
        private Mock<IRouterAuth> _routerMock;
        private Mock<IViewAuth> _viewMock;
        private Mock<IInteractorAuth> _interactorMock;
        private Mock<IAuthStylesHolder> _styleHolderMock;
        private Mock<IRegAuth> _authLocaleStrings;
        private AuthThemeStrings _authThemeStrings;

        [SetUp]
        public void SetUp()
        {
            _routerMock = new Mock<IRouterAuth>(MockBehavior.Strict);
            _viewMock = new Mock<IViewAuth>(MockBehavior.Strict);
            _interactorMock = new Mock<IInteractorAuth>(MockBehavior.Strict);

            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterAuth>());
            _viewMock.Setup(f => f.SetConfig());

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterAuth>());

            _authThemeStrings = new AuthThemeStrings(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            _styleHolderMock = new Mock<IAuthStylesHolder>(MockBehavior.Strict);
            _authLocaleStrings = new Mock<IRegAuth>(MockBehavior.Strict);
        }

        [Test]
        public void EmailInputTest()
        {
            _interactorMock.Setup(f => f.EmailInput(It.IsAny<string>())).Returns(false);
            var presenter = new PresenterAuth(_viewMock.Object, _interactorMock.Object, _routerMock.Object, null, null, null, null, _styleHolderMock.Object, _authLocaleStrings.Object);

            presenter.EmailInput(string.Empty);

            _interactorMock.Verify(f => f.EmailInput(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void PasswordInputTest()
        {
            _interactorMock.Setup(f => f.PasswordInput(It.IsAny<string>())).Returns(false);
            var presenter = new PresenterAuth(_viewMock.Object, _interactorMock.Object, _routerMock.Object, null, null, null, null, _styleHolderMock.Object, _authLocaleStrings.Object);

            presenter.PasswordInput(string.Empty);

            _interactorMock.Verify(f => f.PasswordInput(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void RegistrationClickTest()
        {
            _routerMock.Setup(f => f.ToRegistration());
            var presenter = new PresenterAuth(_viewMock.Object, _interactorMock.Object, _routerMock.Object, null, null, null, null, _styleHolderMock.Object, _authLocaleStrings.Object);

            presenter.RegistrationClick();

            _routerMock.Verify(f => f.ToRegistration(), Times.Once);
        }

        [Test]
        public void ForgotPasswordClickTest()
        {
            _routerMock.Setup(f => f.ToForgotPass());
            var presenter = new PresenterAuth(_viewMock.Object, _interactorMock.Object, _routerMock.Object, null, null, null, null, _styleHolderMock.Object, _authLocaleStrings.Object);

            presenter.ForgotPasswordClick();

            _routerMock.Verify(f => f.ToForgotPass(), Times.Once);
        }

        [Test]
        public void LoginClickTest()
        {
            _interactorMock.Setup(f => f.LoginClick(It.IsAny<string>(), It.IsAny<string>()));
            var presenter = new PresenterAuth(_viewMock.Object, _interactorMock.Object, _routerMock.Object, null, null, null, null, _styleHolderMock.Object, _authLocaleStrings.Object);

            presenter.LoginClick(string.Empty, string.Empty);

            _interactorMock.Verify(f => f.LoginClick(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void DisposeRepositoryRATest()
        {
            _interactorMock.Setup(f => f.DisposeRepositoryRA());
            var presenter = new PresenterAuth(_viewMock.Object, _interactorMock.Object, _routerMock.Object,  null, null, null, null, _styleHolderMock.Object, _authLocaleStrings.Object);

            presenter.DisposeRepositoryRA();

            _interactorMock.Verify(f => f.DisposeRepositoryRA(), Times.Once);
        }

        [Test]
        public void CheckAuthStateSuccessTest()
        {
            _routerMock.Setup(f => f.ToPostsFeed());
            var presenter = new PresenterAuth(_viewMock.Object, _interactorMock.Object, _routerMock.Object, null, null, null, null, _styleHolderMock.Object, _authLocaleStrings.Object);

            presenter.CheckAuthState(EAuthResponseStatus.Success);

            _routerMock.Verify(f => f.ToPostsFeed(), Times.Once);
        }
        
        [Test, Author("Gerashchenko V.V.")]
        [TestCase(EAuthResponseStatus.Error)]
        [TestCase(EAuthResponseStatus.Unauthorized)]
        public void CheckAuthStateFailTest(EAuthResponseStatus status)
        {
            _viewMock.Setup(f => f.ShowAlert(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            _viewMock.Setup(f => f.SetInteractionAvailable());

            _authLocaleStrings.SetupGet(f => f.AuthError).Returns(It.IsAny<string>());
            _authLocaleStrings.SetupGet(f => f.OK).Returns(It.IsAny<string>());


            _interactorMock.Setup(f => f.GetRepository().LangRA.AuthError).Returns(It.IsAny<string>());
            var presenter = new PresenterAuth(_viewMock.Object, _interactorMock.Object, _routerMock.Object, null, null, null, null, _styleHolderMock.Object, _authLocaleStrings.Object);

            presenter.CheckAuthState(status);

            _viewMock.Verify(f => f.ShowAlert(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
        }

        [Test]
        public void SetPasswordStateSuccessTest()
        {
            _viewMock.Setup(f => f.SetPasswordEditTextTheme(It.IsAny<IEditTextTheme>()));
            _styleHolderMock.SetupGet(f => f.PasswordStateSuccess).Returns(It.IsAny<IEditTextTheme>());
            var presenter = new PresenterAuth(_viewMock.Object, _interactorMock.Object, _routerMock.Object, null, null, null, null, _styleHolderMock.Object, _authLocaleStrings.Object);

            presenter.SetPasswordState(EState.Success);

            _viewMock.Verify(f => f.SetPasswordEditTextTheme(It.IsAny<IEditTextTheme>()), Times.Once);
        }

        [Test]
        public void SetPasswordStateFailTest()
        {
            _viewMock.Setup(f => f.SetPasswordEditTextTheme(It.IsAny<IEditTextTheme>()));
            _styleHolderMock.SetupGet(f => f.PasswordStateFail).Returns(It.IsAny<IEditTextTheme>());
            var presenter = new PresenterAuth(_viewMock.Object, _interactorMock.Object, _routerMock.Object, null, null, null, null, _styleHolderMock.Object, _authLocaleStrings.Object);

            presenter.SetPasswordState(EState.Fail);

            _viewMock.Verify(f => f.SetPasswordEditTextTheme(It.IsAny<IEditTextTheme>()), Times.Once);
        }

        [TestCase(EState.None)]
        [TestCase(EState.PassDoesNotMatch)]
        [TestCase(EState.UserAgreementNotChecked)]
        public void SetPasswordStateAnotherTest(EState state)
        {
            var presenter = new PresenterAuth(_viewMock.Object, _interactorMock.Object, _routerMock.Object, null, null, null, null, _styleHolderMock.Object, _authLocaleStrings.Object);
            presenter.SetPasswordState(state);
        }

        [Test]
        public void SetEmailStateSuccessTest()
        {
            _viewMock.Setup(f => f.SetEmailEditTextTheme(It.IsAny<IEditTextTheme>()));
            _styleHolderMock.SetupGet(f => f.EmailStateSuccess).Returns(It.IsAny<IEditTextTheme>());
            var presenter = new PresenterAuth(_viewMock.Object, _interactorMock.Object, _routerMock.Object,  null, null, null, null, _styleHolderMock.Object, _authLocaleStrings.Object);

            presenter.SetEmailState(EState.Success);

            _viewMock.Verify(f => f.SetEmailEditTextTheme(It.IsAny<IEditTextTheme>()), Times.Once);
        }

        [Test]
        public void SetEmailStateFailTest()
        {
            _viewMock.Setup(f => f.SetEmailEditTextTheme(It.IsAny<IEditTextTheme>()));
            _styleHolderMock.SetupGet(f => f.EmailStateFail).Returns(It.IsAny<IEditTextTheme>());

            var presenter = new PresenterAuth(_viewMock.Object, _interactorMock.Object, _routerMock.Object, null, null, null, null, _styleHolderMock.Object, _authLocaleStrings.Object);

            presenter.SetEmailState(EState.Fail);

            _viewMock.Verify(f => f.SetEmailEditTextTheme(It.IsAny<IEditTextTheme>()), Times.Once);
        }

        [TestCase(EState.None)]
        [TestCase(EState.PassDoesNotMatch)]
        [TestCase(EState.UserAgreementNotChecked)]
        public void SetEmailStateAnotherTest(EState state)
        {
            var presenter = new PresenterAuth(_viewMock.Object, _interactorMock.Object, _routerMock.Object, null, null, null, null, _styleHolderMock.Object, _authLocaleStrings.Object);
            presenter.SetEmailState(state);
        }
        [Test]
        public void FacebookLoginClickTest()
        {
            _interactorMock.Setup(f => f.SocialLoginPerform(ESocialType.Facebook, null));
            var presenter = new PresenterAuth(_viewMock.Object, _interactorMock.Object, _routerMock.Object,  null, null, null, null, _styleHolderMock.Object, _authLocaleStrings.Object);

            presenter.FacebookLoginClick();

            _interactorMock.Verify(f => f.SocialLoginPerform(ESocialType.Facebook, null), Times.Once);
        }

        [Test]
        public void GoogleLoginClickTest()
        {
            _interactorMock.Setup(f => f.SocialLoginPerform(ESocialType.Google, null));
            var presenter = new PresenterAuth(_viewMock.Object, _interactorMock.Object, _routerMock.Object, null, null, null, null, _styleHolderMock.Object, _authLocaleStrings.Object);

            presenter.GoogleLoginClick();

            _interactorMock.Verify(f => f.SocialLoginPerform(ESocialType.Google, null), Times.Once);
        }
        [Test]
        public void VkLoginClickTest()
        {
            _interactorMock.Setup(f => f.SocialLoginPerform(ESocialType.Vk, null));
            var presenter = new PresenterAuth(_viewMock.Object, _interactorMock.Object, _routerMock.Object, null, null, null, null, _styleHolderMock.Object, _authLocaleStrings.Object);

            presenter.VkLoginClick();

            _interactorMock.Verify(f => f.SocialLoginPerform(ESocialType.Vk, null), Times.Once);
        }
        [Test]
        public void OkLoginClickTest()
        {
            _interactorMock.Setup(f => f.SocialLoginPerform(ESocialType.Ok, null));
            var presenter = new PresenterAuth(_viewMock.Object, _interactorMock.Object, _routerMock.Object, null, null, null, null, _styleHolderMock.Object, _authLocaleStrings.Object);

            presenter.OkLoginClick();

            _interactorMock.Verify(f => f.SocialLoginPerform(ESocialType.Ok, null), Times.Once);
        }

        [Test]
        public void ShowSpinnerTest()
        {
            _viewMock.Setup(f => f.ShowSpinner());

            var presenter = new PresenterAuth(_viewMock.Object, _interactorMock.Object, _routerMock.Object, null, null, null, null, _styleHolderMock.Object, _authLocaleStrings.Object);

            presenter.ShowHideSpinner(true);

            _viewMock.Verify(f => f.ShowSpinner(), Times.Once);
        }

        [Test]
        public void HideSpinnerTest()
        {
            _viewMock.Setup(f => f.HideSpinner());

            var presenter = new PresenterAuth(_viewMock.Object, _interactorMock.Object, _routerMock.Object, null, null, null, null, _styleHolderMock.Object, _authLocaleStrings.Object);

            presenter.ShowHideSpinner(false);

            _viewMock.Verify(f => f.HideSpinner(), Times.Once);
        }
    }
}
