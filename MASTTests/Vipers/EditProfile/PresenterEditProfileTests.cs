using System;

using Moq;

using NUnit.Framework;

using SocialTrading.Locale.Modules;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.Vipers.MoreOptions.EditProfile.Interfaces;
using SocialTrading.Vipers.MoreOptions.EditProfile.Implementation;

namespace MASTTests.Vipers.EditProfile
{
    [TestFixture, Author(Authors.Viktorov)]
    public class PresenterEditProfileTests
    {
        private Mock<IInteractorEditProfile> _interactorMock;
        private Mock<IViewEditProfile> _viewMock;
        private Mock<IEditProfileStylesHolder> _stylesHolderMock;
        private Mock<IEditProfile> _localeStringsMock;
        private Mock<IRouterEditProfile> _routerMock;

        private IPresenterEditProfile _presenter;

        [SetUp]
        public void SetUp()
        {
            _interactorMock = new Mock<IInteractorEditProfile>(MockBehavior.Strict);
            _viewMock = new Mock<IViewEditProfile>(MockBehavior.Strict);
            _routerMock = new Mock<IRouterEditProfile>(MockBehavior.Strict);
            _stylesHolderMock = new Mock<IEditProfileStylesHolder>(MockBehavior.Strict);
            _localeStringsMock = new Mock<IEditProfile>(MockBehavior.Strict);

            //_presenter = new PresenterEditProfile(_viewMock.Object, _interactorMock.Object, _stylesHolderMock.Object, _localeStringsMock.Object);
        }

        [Test(Author = Authors.Viktorov)]
        public void CtorNullParamsTest()
        {
            Assert.Throws<ArgumentNullException>(() => new PresenterEditProfile(null, null, null, null, null));
        }
        [Test(Author = Authors.Viktorov)]
        public void CtorNullViewTest()
        {
            Assert.Throws<ArgumentNullException>(() => new PresenterEditProfile(null, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _localeStringsMock.Object));
        }
        [Test(Author = Authors.Viktorov)]
        public void CtorNullInteractorTest()
        {
            Assert.Throws<ArgumentNullException>(() => new PresenterEditProfile(_viewMock.Object, null, _routerMock.Object, _stylesHolderMock.Object, _localeStringsMock.Object));
        }
        [Test(Author = Authors.Viktorov)]
        public void CtorNullRouterTest()
        {
            Assert.Throws<ArgumentNullException>(() => new PresenterEditProfile(_viewMock.Object, _interactorMock.Object, null, _stylesHolderMock.Object, _localeStringsMock.Object));
        }
        [Test(Author = Authors.Viktorov)]
        public void CtorSetConfigTest()
        {
            _interactorMock.Setup(f => f.SendRequestForUserData());

            _stylesHolderMock.SetupGet(f => f.LabelsTheme).Returns(It.IsAny<ITextViewTheme>());
            _stylesHolderMock.SetupGet(f => f.EditTextsTheme).Returns(It.IsAny<IEditTextTheme>());
            _stylesHolderMock.SetupGet(f => f.SaveButtonTheme).Returns(It.IsAny<IButtonTheme>());
            _stylesHolderMock.SetupGet(f => f.CancelButtonTheme).Returns(It.IsAny<IButtonTheme>());

            _viewMock.Setup(f => f.SetLabelsTheme(It.IsAny<ITextViewTheme>()));
            _viewMock.Setup(f => f.SetNameEditTextTheme(It.IsAny<IEditTextTheme>()));
            _viewMock.Setup(f => f.SetLastnameEditTextTheme(It.IsAny<IEditTextTheme>()));
            _viewMock.Setup(f => f.SetStatusEditTextTheme(It.IsAny<IEditTextTheme>()));
            _viewMock.Setup(f => f.SetSaveButtonTheme(It.IsAny<IButtonTheme>()));
            _viewMock.Setup(f => f.SetCancelButtonTheme(It.IsAny<IButtonTheme>()));

            _localeStringsMock.SetupGet(f => f.EditProfileNameTitle).Returns(It.IsAny<string>());
            _localeStringsMock.SetupGet(f => f.EditProfileLastnameTitle).Returns(It.IsAny<string>());
            _localeStringsMock.SetupGet(f => f.EditProfileStatusTitle).Returns(It.IsAny<string>());
            _localeStringsMock.SetupGet(f => f.EditProfileSaveButtonTitle).Returns(It.IsAny<string>());
            _localeStringsMock.SetupGet(f => f.EditProfileCancelButtonTitle).Returns(It.IsAny<string>());

            _viewMock.Setup(f => f.SetNameLabel(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetLastnameLabel(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetStatusLabel(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetSaveButtonTitle(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetCancelButtonTitle(It.IsAny<string>()));

            new PresenterEditProfile(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object, _localeStringsMock.Object);

            _interactorMock.Verify(f => f.SendRequestForUserData());

            _stylesHolderMock.VerifyGet(f => f.LabelsTheme, Times.Once);
            _stylesHolderMock.VerifyGet(f => f.EditTextsTheme, Times.Exactly(3));
            _stylesHolderMock.VerifyGet(f => f.SaveButtonTheme, Times.Once);
            _stylesHolderMock.VerifyGet(f => f.CancelButtonTheme, Times.Once);

            _viewMock.Verify(f => f.SetLabelsTheme(It.IsAny<ITextViewTheme>()), Times.Once);
            _viewMock.Verify(f => f.SetNameEditTextTheme(It.IsAny<IEditTextTheme>()), Times.Once);
            _viewMock.Verify(f => f.SetLastnameEditTextTheme(It.IsAny<IEditTextTheme>()), Times.Once);
            _viewMock.Verify(f => f.SetStatusEditTextTheme(It.IsAny<IEditTextTheme>()), Times.Once);
            _viewMock.Verify(f => f.SetSaveButtonTheme(It.IsAny<IButtonTheme>()), Times.Once);
            _viewMock.Verify(f => f.SetCancelButtonTheme(It.IsAny<IButtonTheme>()), Times.Once);

            _localeStringsMock.VerifyGet(f => f.EditProfileNameTitle, Times.Once);
            _localeStringsMock.VerifyGet(f => f.EditProfileLastnameTitle, Times.Once);
            _localeStringsMock.VerifyGet(f => f.EditProfileStatusTitle, Times.Once);
            _localeStringsMock.VerifyGet(f => f.EditProfileSaveButtonTitle, Times.Once);
            _localeStringsMock.VerifyGet(f => f.EditProfileCancelButtonTitle, Times.Once);

            _viewMock.Verify(f => f.SetNameLabel(It.IsAny<string>()), Times.Once);
            _viewMock.Verify(f => f.SetLastnameLabel(It.IsAny<string>()), Times.Once);
            _viewMock.Verify(f => f.SetStatusLabel(It.IsAny<string>()), Times.Once);
            _viewMock.Verify(f => f.SetSaveButtonTitle(It.IsAny<string>()), Times.Once);
            _viewMock.Verify(f => f.SetCancelButtonTitle(It.IsAny<string>()), Times.Once);
        }
    }
}