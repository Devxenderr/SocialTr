using Moq;

using NUnit.Framework;

using SocialTrading.Service;
using SocialTrading.Vipers.Entity;
using SocialTrading.Locale.Modules;
using SocialTrading.DTO.Response.RA;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Registration.Password;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.Vipers.Registration.Password.Interfaces;
using SocialTrading.Vipers.Registration.Password.Implementation;

namespace MASTTests.Vipers.Reg.Presenter
{
    [TestFixture]
    public class PresenterRegPassTests
    {
        private Mock<IRouterRegPass> _routerMock;
        private Mock<IViewRegPass> _viewMock;
        private Mock<IInteractorRegPass> _interactorMock;
        private Mock<IRegPassStylesHolder> _stylesHolderMock;
        private IRegAuth _regLocaleStrings;

        [SetUp]
        public void SetUp()
        {
            _routerMock = new Mock<IRouterRegPass>(MockBehavior.Strict);
            _viewMock = new Mock<IViewRegPass>(MockBehavior.Strict);
            _interactorMock = new Mock<IInteractorRegPass>(MockBehavior.Strict);

            _viewMock.SetupSet(f => f.Presenter = It.IsAny<PresenterRegPass>());
            _viewMock.Setup(f => f.SetConfig());

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<PresenterRegPass>());
            
            _regLocaleStrings = DataService.RepositoryController.RepositoryRA.LangRA;

            _stylesHolderMock = new Mock<IRegPassStylesHolder>(MockBehavior.Strict);
        }

        [Test]
        public void PasswordInputTest()
        {
            _interactorMock.Setup(f => f.PasswordInput(It.IsAny<string>())).Returns(false);
            _viewMock.Setup(f => f.GetPassword()).Returns(string.Empty);

            var presenter = new PresenterRegPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);            

            presenter.PasswordInput();

            _interactorMock.Verify(f => f.PasswordInput(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ConfirmPasswordInputTest()
        {
            _interactorMock.Setup(f => f.PasswordConfirmInput(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            _viewMock.Setup(f => f.GetPassword()).Returns(string.Empty);
            _viewMock.Setup(f => f.GetConfirmPassword()).Returns(string.Empty);

            var presenter = new PresenterRegPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);

            presenter.PasswordConfirmInput();

            _interactorMock.Verify(f => f.PasswordConfirmInput(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void BackClickTest()
        {
            _routerMock.Setup(f => f.ToRegEmail());
            var presenter = new PresenterRegPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);

            presenter.BackClick();

            _routerMock.Verify(f => f.ToRegEmail());
        }

        [Test]
        public void RegisterClickTest()
        {
            _interactorMock.Setup(f => f.RegistrationClick(It.IsAny<RegistrationPasswordStrings>()));
            _viewMock.Setup(f => f.GetPassword()).Returns(string.Empty);
            _viewMock.Setup(f => f.GetConfirmPassword()).Returns(string.Empty);
          
            var presenter = new PresenterRegPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);

            presenter.RegisterClick();

            _interactorMock.Verify(f => f.RegistrationClick(It.IsAny<RegistrationPasswordStrings>()));
        }

        [Test]
        public void SaveDataTest()
        {
            _interactorMock.Setup(f => f.SaveData(It.IsAny<RegistrationPasswordStrings>()));
            _viewMock.Setup(f => f.GetPassword()).Returns(string.Empty);
            _viewMock.Setup(f => f.GetConfirmPassword()).Returns(string.Empty);
           
            var presenter = new PresenterRegPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);

            presenter.SaveData();

            _interactorMock.Verify(f => f.SaveData(It.IsAny<RegistrationPasswordStrings>()));
        }

        [Test]
        public void LoadDataTest()
        {
            _interactorMock.Setup(f => f.LoadData()).Returns(new RegistrationPasswordStrings(string.Empty, string.Empty));
            _viewMock.Setup(f => f.SetConfirmPass(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetPassword(It.IsAny<string>()));
        
            var presenter = new PresenterRegPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);

            presenter.LoadData();

            _interactorMock.Verify(f => f.LoadData());
        }

        [Test]
        public void UserAgreementClickTest()
        {
            _routerMock.Setup(f => f.ToUserAgreement());
            var presenter = new PresenterRegPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);

            presenter.UserAgreementClick();

            _routerMock.Verify(f => f.ToUserAgreement());
        }

        [Test]
        public void AlertOkClickTest()
        {
            _routerMock.Setup(f => f.ToAuth());
            _interactorMock.Setup(f => f.CleanRepositoryRA());
            var presenter = new PresenterRegPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);
            
            presenter.AlertOkClick();

            _routerMock.Verify(f => f.ToAuth());
        }

        [Test]
        public void SetPasswordConfirmStateSuccessTest()
        {
            _stylesHolderMock.SetupGet(f => f.PasswordConfirmStateSuccess).Returns(It.IsAny<IEditTextTheme>());
            _viewMock.Setup(f => f.SetConfirmPasswordEditTextTheme(null));
            var presenter = new PresenterRegPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);
            _viewMock.Setup(f => f.SetConfirmPasswordEditTextTheme(null));            

            presenter.SetPasswordConfirmState(EState.Success);

            _viewMock.Verify(f => f.SetConfirmPasswordEditTextTheme(null), Times.Once);
        }

        [Test]
        public void CheckPasswordConfirmStateFailTest()
        {
            _stylesHolderMock.SetupGet(f => f.PasswordConfirmStateFail).Returns(It.IsAny<IEditTextTheme>());
            _viewMock.Setup(f => f.SetConfirmPasswordEditTextTheme(null));
            var presenter = new PresenterRegPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);
            _viewMock.Setup(f => f.SetConfirmPasswordEditTextTheme(null));

            presenter.SetPasswordConfirmState(EState.Fail);

            _viewMock.Verify(f => f.SetConfirmPasswordEditTextTheme(null), Times.Once);
        }

        [Test]
        public void CheckPasswordConfirmStateNotMatchTest()
        {            _stylesHolderMock.SetupGet(f => f.PasswordConfirmStatePassNotMatch).Returns(It.IsAny<IEditTextTheme>());
            _viewMock.Setup(f => f.SetConfirmPasswordEditTextTheme(null));
            var presenter = new PresenterRegPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);
            
            _viewMock.Setup(f => f.SetConfirmPasswordEditTextTheme(null));

            presenter.SetPasswordConfirmState(EState.PassDoesNotMatch);

            _viewMock.Verify(f => f.SetConfirmPasswordEditTextTheme(null), Times.Once);
        }

        [TestCase(EState.None, Author = "Elena Pakhomova")]
        [TestCase(EState.UserAgreementNotChecked, Author = "Elena Pakhomova")]
        public void CheckPasswordConfirmStateAnotherTest(EState state)
        {
            var presenter = new PresenterRegPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);                     
            presenter.SetPasswordConfirmState(state);
        }

        [Test]
        public void SetPasswordStateSuccessTest()
        {
            _stylesHolderMock.SetupGet(f => f.PasswordStateSuccess).Returns(It.IsAny<IEditTextTheme>());
            _viewMock.Setup(f => f.SetPasswordEditTextTheme(null));
            var presenter = new PresenterRegPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);            
            _viewMock.Setup(f => f.SetPasswordEditTextTheme(null));

            presenter.SetPasswordState(EState.Success);

            _viewMock.Verify(f => f.SetPasswordEditTextTheme(null), Times.Once);
        }

        [Test]
        public void CheckPasswordStateFailTest()
        {
            _stylesHolderMock.SetupGet(f => f.PasswordStateFail).Returns(It.IsAny<IEditTextTheme>());
            _viewMock.Setup(f => f.SetPasswordEditTextTheme(null));
            var presenter = new PresenterRegPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);
            _viewMock.Setup(f => f.SetPasswordEditTextTheme(null));

            presenter.SetPasswordState(EState.Fail);

            _viewMock.Verify(f => f.SetPasswordEditTextTheme(null), Times.Once);
        }

        [TestCase(EState.None, Author = "Elena Pakhomova")]
        [TestCase(EState.PassDoesNotMatch, Author = "Elena Pakhomova")]
        [TestCase(EState.UserAgreementNotChecked, Author = "Elena Pakhomova")]
        public void CheckPasswordStateAnotherTest(EState state)
        {
            var presenter = new PresenterRegPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);
            presenter.SetPasswordState(state);
        }

        [Test(Author = "Vladimir Viktorov")]
        public void CheckRegStateSuccessTest()
        {
            _viewMock.Setup(f => f.ShowRegSuccess(It.IsAny<string>(), It.IsAny<string>()));
            _viewMock.Setup(f => f.SetInteractionAvailable());
            _interactorMock.Setup(f => f.GetRepository()).Returns(It.IsNotNull<IRepositoryRA>());
            _interactorMock.Setup(f => f.GetRepository().LangRA.RegSuccess).Returns(It.IsAny<string>());            
            _interactorMock.Object.GetRepository().ModelReg = new DataModelReg("","","","","","","","","","","", new string[]{});            
            var presenter = new PresenterRegPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);

            presenter.RegStateSuccess(It.IsAny<string>());
         
            _viewMock.Verify(f => f.ShowRegSuccess(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test(Author = "Elena Pakhomova")]
        public void CheckRegStateFailTest()
        {
            _viewMock.Setup(f => f.ShowRegFail(It.IsAny<string>(), It.IsAny<string>()));
            _viewMock.Setup(f => f.SetInteractionAvailable());
            _interactorMock.Setup(f => f.GetRepository().LangRA.UserDataError).Returns(It.IsAny<string>());
            var presenter = new PresenterRegPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);

            presenter.RegStateFail(ERegResponseStatus.Error);

            _viewMock.Verify(f => f.ShowRegFail(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [TestCase(EState.None, Author = "Elena Pakhomova")]
        [TestCase(EState.PassDoesNotMatch, Author = "Elena Pakhomova")]
        public void CheckRegStateAnotherTest(EState state)
        {
            var presenter = new PresenterRegPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);
            presenter.SetPasswordState(state);
        }

        [Test]
        public void ShowSpinnerTest()
        {
            _viewMock.Setup(f => f.ShowSpinner());

            var presenter = new PresenterRegPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);

            presenter.ShowHideSpinner(true);

            _viewMock.Verify(f => f.ShowSpinner(), Times.Once);
        }

        [Test]
        public void HideSpinnerTest()
        {
            _viewMock.Setup(f => f.HideSpinner());

            var presenter = new PresenterRegPass(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _regLocaleStrings);

            presenter.ShowHideSpinner(false);

            _viewMock.Verify(f => f.HideSpinner(), Times.Once);
        }
    } 
}
