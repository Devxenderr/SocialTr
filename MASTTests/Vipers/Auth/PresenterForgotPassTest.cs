using NUnit.Framework;

using Moq;

using SocialTrading.Service;
using SocialTrading.Vipers.ForgotPass;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Theme.ThemeStrings;
using SocialTrading.Vipers.ForgotPass.Interfaces;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.Vipers.ForgotPass.Implementation;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;

namespace MASTTests.Vipers.Auth
{
    [TestFixture]
    public class PresenterForgotPassTest
    {
        private Mock<IRouterForgotPass> _routerMock;
        private Mock<IViewForgotPass> _viewMock;
        private Mock<IInteractorForgotPass> _interactorMock;
        private AuthThemeStrings _authThemeStrings;
        private Mock<IForgotPassStylesHolder> _stylesHolderMock;

        [SetUp]
        public void SetUp()
        {
            _routerMock = new Mock<IRouterForgotPass>(MockBehavior.Strict);
            _viewMock = new Mock<IViewForgotPass>(MockBehavior.Strict);
            _interactorMock = new Mock<IInteractorForgotPass>(MockBehavior.Strict);

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

            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForgotPass>());
            _viewMock.Setup(f => f.SetConfig());

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForgotPass>());
            _stylesHolderMock = new Mock<IForgotPassStylesHolder>(MockBehavior.Strict);
        }

        [Test]
        public void EmailInputTest()
        {
            _interactorMock.Setup(f => f.EmailInput(It.IsAny<string>())).Returns(false);
            var presenter = new PresenterForgotPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, 
                DataService.RepositoryController.RepositoryRA.LangRA, _stylesHolderMock.Object);

            presenter.EmailInput(It.IsAny<string>());

            _interactorMock.Verify(f => f.EmailInput(It.IsAny<string>()), Times.Once);
        }


        [Test]
        public void EmailRetrieveClickTest()
        {
            _interactorMock.Setup(f => f.PassRecoveryClick(It.IsAny<string>()));

            var presenter = new PresenterForgotPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, 
                DataService.RepositoryController.RepositoryRA.LangRA, _stylesHolderMock.Object);

            presenter.PassRecoveryClick(It.IsAny<string>());

            _interactorMock.Verify(f => f.PassRecoveryClick(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ShowAlertEmailRedirectTest()
        {
            _viewMock.Setup(f => f.ShowAlertEmailRedirect(It.IsAny<string>(), It.IsAny<string>()));
            //_interactorMock.Setup(f => f.GetRepository().LangRA.AuthError).Returns(It.IsAny<string>());
            var presenter = new PresenterForgotPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, 
                DataService.RepositoryController.RepositoryRA.LangRA, _stylesHolderMock.Object);

            presenter.ShowAlertEmailRedirect(It.IsAny<EForgotPassStatus>());

            _viewMock.Verify(f => f.ShowAlertEmailRedirect(It.IsAny<string>(), It.IsAny<string>()), Times.Once);

        }

        [Test]
        public void SetEmailStateSuccessTest()
        {
            var theme = "AuthEditTextSuccessStyle";
            _viewMock.Setup(f => f.SetEmailEditTextTheme(It.IsAny<IEditTextTheme>()));
            _stylesHolderMock.SetupGet(f => f.EmailStateSuccess).Returns(It.IsAny<IEditTextTheme>());
            var presenter = new PresenterForgotPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, 
                DataService.RepositoryController.RepositoryRA.LangRA, _stylesHolderMock.Object);

            presenter.SetEmailState(EState.Success);

            _viewMock.Verify(f => f.SetEmailEditTextTheme(It.IsAny<IEditTextTheme>()));
        }

        [Test]
        public void SetEmailStateFailTest()
        {
            var theme = "AuthEditTextFailStyle";
            _viewMock.Setup(f => f.SetEmailEditTextTheme(It.IsAny<IEditTextTheme>()));
            _stylesHolderMock.SetupGet(f => f.EmailStateFail).Returns(It.IsAny<IEditTextTheme>());
            var presenter = new PresenterForgotPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, 
                DataService.RepositoryController.RepositoryRA.LangRA, _stylesHolderMock.Object);

            presenter.SetEmailState(EState.Fail);

            _viewMock.Verify(f => f.SetEmailEditTextTheme(It.IsAny<IEditTextTheme>()));
        }

        [Test]
        public void AlertButtonClickTest()
        {
            _routerMock.Setup(f => f.ToAuth());
            _viewMock.Setup(f => f.ShowAlertEmailRedirect(It.IsAny<string>(), It.IsAny<string>()));

            var presenter = new PresenterForgotPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, 
                DataService.RepositoryController.RepositoryRA.LangRA, _stylesHolderMock.Object);
            presenter.ShowAlertEmailRedirect(EForgotPassStatus.RecoverySuccess);
            presenter.AlertButtonClick();

            _routerMock.Verify(f => f.ToAuth(), Times.Once);
        }

        [Test]
        public void PresenterSetConfigTest()
        {
            _viewMock.Setup(f => f.SetEmailEditTextTheme(It.IsAny<IEditTextTheme>()));
            _stylesHolderMock.SetupGet(f => f.EmailEditTextTheme).Returns(It.IsAny<IEditTextTheme>());
            _viewMock.Setup(f => f.SetHeaderLabelTheme(It.IsAny<ITextViewTheme>()));
            _stylesHolderMock.SetupGet(f => f.HeaderLabelTheme).Returns(It.IsAny<ITextViewTheme>());
            _viewMock.Setup(f => f.SetRecoveryButtonTheme( It.IsAny<IButtonTheme>()));
            _stylesHolderMock.SetupGet(f => f.RecoveryButtonTheme).Returns(It.IsAny<IButtonTheme>());
            _viewMock.Setup(f => f.SetLogoImageViewTheme(It.IsAny<IImageViewTheme>()));
            _stylesHolderMock.SetupGet(f => f.LogoImageViewTheme).Returns(It.IsAny<IImageViewTheme>());
            _viewMock.Setup(f => f.SetViewTheme(It.IsAny<IImageViewTheme>()));
            _stylesHolderMock.SetupGet(f => f.ViewTheme).Returns(It.IsAny<IImageViewTheme>());
            _viewMock.Setup(f => f.SetBackButtonTheme(It.IsAny<IImageButtonTheme>()));
            _stylesHolderMock.SetupGet(f => f.BackButtonTheme).Returns(It.IsAny<IImageButtonTheme>());
            _viewMock.Setup(f => f.SetEmailLabelTheme(It.IsAny<ITextViewTheme>()));
            _stylesHolderMock.SetupGet(f => f.EmailLabelTheme).Returns(It.IsAny<ITextViewTheme>());

            var presenter = new PresenterForgotPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, 
                DataService.RepositoryController.RepositoryRA.LangRA, _stylesHolderMock.Object);

            presenter.SetConfig();

            _viewMock.Verify(f => f.SetEmailEditTextTheme(It.IsAny<IEditTextTheme>()), Times.AtLeastOnce);
            _viewMock.Verify(f => f.SetHeaderLabelTheme(It.IsAny<ITextViewTheme>()), Times.Once);
            _viewMock.Verify(f => f.SetRecoveryButtonTheme(It.IsAny<IButtonTheme>()), Times.Once);
            _viewMock.Verify(f => f.SetLogoImageViewTheme(It.IsAny<IImageViewTheme>()), Times.Once);
            _viewMock.Verify(f => f.SetViewTheme(It.IsAny<IImageViewTheme>()), Times.Once);
            _viewMock.Verify(f => f.SetBackButtonTheme(It.IsAny<IImageButtonTheme>()));
            _viewMock.Verify(f => f.SetEmailLabelTheme(It.IsAny<ITextViewTheme>()));
        }

        [Test]
        public void PresenterSetLocaleTest()
        {
            _viewMock.Setup(f => f.SetButtonLocale(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetHintLocale(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetHeaderLabelLocale(It.IsAny<string>()));

            //_interactorMock.Setup(f => f.GetRepository().LangRA.AuthError).Returns(It.IsAny<string>());
            var presenter = new PresenterForgotPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, 
                DataService.RepositoryController.RepositoryRA.LangRA, _stylesHolderMock.Object);

            presenter.SetLocale();

            _viewMock.Verify(f => f.SetButtonLocale(It.IsAny<string>()));
            _viewMock.Verify(f => f.SetHintLocale(It.IsAny<string>()));
            _viewMock.Verify(f => f.SetHeaderLabelLocale(It.IsAny<string>()));
        }

        [Test]
        public void BackButtonClickTest()
        {
            _routerMock.Setup(f => f.ToAuth());

            var presenter = new PresenterForgotPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, 
                DataService.RepositoryController.RepositoryRA.LangRA, _stylesHolderMock.Object);

            presenter.BackButtonClick();

            _routerMock.Verify(f => f.ToAuth(), Times.Once);
        }

        [Test]
        public void ShowSpinnerTest()
        {
            _viewMock.Setup(f => f.ShowSpinner());

            var presenter = new PresenterForgotPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object,
                DataService.RepositoryController.RepositoryRA.LangRA, _stylesHolderMock.Object);

            presenter.ShowHideSpinner(true);

            _viewMock.Verify(f => f.ShowSpinner(), Times.Once);
        }

        [Test]
        public void HideSpinnerTest()
        {
            _viewMock.Setup(f => f.HideSpinner());

            var presenter = new PresenterForgotPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object,
                DataService.RepositoryController.RepositoryRA.LangRA, _stylesHolderMock.Object);

            presenter.ShowHideSpinner(false);

            _viewMock.Verify(f => f.HideSpinner(), Times.Once);
        }
    }
}
