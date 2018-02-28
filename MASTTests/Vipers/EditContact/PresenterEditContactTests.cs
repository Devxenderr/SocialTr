using System;

using Moq;

using NUnit.Framework;

using SocialTrading.Locale;
using SocialTrading.Vipers.Entity;
using SocialTrading.DTO.Response.UserSettings;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.Vipers.EditContact.Interfaces;
using SocialTrading.Vipers.EditContact.Implementation;

namespace MASTTests.Vipers.EditContact
{
    [TestFixture, Author(Authors.Pakhomova)]
    public class PresenterEditContactTests
    {
        private Mock<IInteractorEditContact> _interactorMock;
        private Mock<IViewEditContact> _viewMock;
        private Mock<IRouterEditContact> _routerMock;
        private Mock<IEditContactStyleHolder> _styleHolder;

        private IPresenterEditContact _presenter;

        [SetUp]
        public void SetUp()
        {
            _interactorMock = new Mock<IInteractorEditContact>(MockBehavior.Strict);
            _viewMock = new Mock<IViewEditContact>(MockBehavior.Strict);
            _routerMock = new Mock<IRouterEditContact>(MockBehavior.Strict);
            _styleHolder = new Mock<IEditContactStyleHolder>(MockBehavior.Default);
        }

        [Test]
        public void CtorNullViewTest()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                _presenter = new PresenterEditContact(null, _interactorMock.Object, _routerMock.Object);
            });
        }

        [Test]
        public void CtorNullInteractorTest()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                _presenter = new PresenterEditContact(_viewMock.Object, null, _routerMock.Object);
            });
        }

        [Test]
        public void CtorNullRouterTest()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                _presenter = new PresenterEditContact(_viewMock.Object, _interactorMock.Object, null);
            });
        }

        [Test]
        public void CtorSuccessTest()
        {
            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForInteractorEditContact>());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForViewEditContact>());

            _presenter = new PresenterEditContact(_viewMock.Object, _interactorMock.Object, _routerMock.Object);

            _interactorMock.VerifySet(f => f.Presenter = It.IsAny<IPresenterForInteractorEditContact>(), Times.Once);
            _viewMock.VerifySet(f => f.Presenter = It.IsAny<IPresenterForViewEditContact>(), Times.Once);
        }


        [Test]
        public void SaveClickTest()
        {
            _interactorMock.Setup(f => f.SaveClick(It.IsAny<EditContactEntity>()));

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForInteractorEditContact>());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForViewEditContact>());

            _presenter = new PresenterEditContact(_viewMock.Object, _interactorMock.Object, _routerMock.Object);
            _presenter.SaveClick(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            _interactorMock.Verify(f => f.SaveClick(It.IsAny<EditContactEntity>()), Times.Once());
        }

        [Test]
        public void CancelClickTest()
        {
            _interactorMock.Setup(f => f.CancelClick());

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForInteractorEditContact>());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForViewEditContact>());

            _presenter = new PresenterEditContact(_viewMock.Object, _interactorMock.Object, _routerMock.Object);
            _presenter.CancelClick();

            _interactorMock.Verify(f => f.CancelClick(), Times.Once());
        }

        [Test]
        public void CountryClickTest()
        {
            _interactorMock.Setup(f => f.CountryClick());

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForInteractorEditContact>());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForViewEditContact>());

            _presenter = new PresenterEditContact(_viewMock.Object, _interactorMock.Object, _routerMock.Object);
            _presenter.CountryClick();

            _interactorMock.Verify(f => f.CountryClick(), Times.Once());
        }

        [Test]
        public void GoBackTest()
        {
            _routerMock.Setup(f => f.GoBack());

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForInteractorEditContact>());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForViewEditContact>());

            _presenter = new PresenterEditContact(_viewMock.Object, _interactorMock.Object, _routerMock.Object);
            _presenter.GoBack();

            _routerMock.Verify(f => f.GoBack(), Times.Once());
        }

        [Test]
        public void ToCountrySelectionTest()
        {
            _routerMock.Setup(f => f.ToCountrySelection());

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForInteractorEditContact>());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForViewEditContact>());

            _presenter = new PresenterEditContact(_viewMock.Object, _interactorMock.Object, _routerMock.Object);
            _presenter.GoToCountrySelection();

            _routerMock.Verify(f => f.ToCountrySelection(), Times.Once());
        }

        [Test]
        public void AlertOkClickTest()
        {
            _interactorMock.Setup(f => f.AlertOkClick());

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForInteractorEditContact>());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForViewEditContact>());

            _presenter = new PresenterEditContact(_viewMock.Object, _interactorMock.Object, _routerMock.Object);
            _presenter.AlertOkClick();

            _interactorMock.Verify(f => f.AlertOkClick(), Times.Once());
        }
        

        [Test]
        public void SkypeTextChangedTest()
        {
            _interactorMock.Setup(f => f.SkypeTextChanged(It.IsAny<string>())).Returns(true);

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForInteractorEditContact>());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForViewEditContact>());

            _presenter = new PresenterEditContact(_viewMock.Object, _interactorMock.Object, _routerMock.Object);
            _presenter.SkypeTextChanged(It.IsAny<string>());

            _interactorMock.Verify(f => f.SkypeTextChanged(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void PhoneTextChangedTest()
        {
            _interactorMock.Setup(f => f.PhoneTextChanged(It.IsAny<string>())).Returns(true);

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForInteractorEditContact>());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForViewEditContact>());

            _presenter = new PresenterEditContact(_viewMock.Object, _interactorMock.Object, _routerMock.Object);
            _presenter.PhoneTextChanged(It.IsAny<string>());

            _interactorMock.Verify(f => f.PhoneTextChanged(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void CityTextChangedTest()
        {
            _interactorMock.Setup(f => f.CityTextChanged(It.IsAny<string>())).Returns(true);

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForInteractorEditContact>());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForViewEditContact>());

            _presenter = new PresenterEditContact(_viewMock.Object, _interactorMock.Object, _routerMock.Object);
            _presenter.CityTextChanged(It.IsAny<string>());

            _interactorMock.Verify(f => f.CityTextChanged(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void SetConfigTest()
        {
            _interactorMock.Setup(f => f.SetConfig());

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForInteractorEditContact>());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForViewEditContact>());

            _presenter = new PresenterEditContact(_viewMock.Object, _interactorMock.Object, _routerMock.Object);
            _presenter.SetConfig();

            _interactorMock.Verify(f => f.SetConfig(), Times.Once());
        }

        [Test]
        public void SetThemeTest()
        {
            _viewMock.Setup(f => f.SetCancelButtonTheme(null));
            _viewMock.Setup(f => f.SetSaveButtonTheme(null));
            _viewMock.Setup(f => f.SetCountryTextViewTheme(null));
            _viewMock.Setup(f => f.SetCityTextViewTheme(null));
            _viewMock.Setup(f => f.SetEmailTextViewTheme(null));
            _viewMock.Setup(f => f.SetPhoneTextViewTheme(null));
            _viewMock.Setup(f => f.SetSkypeTextViewTheme(null));
            _viewMock.Setup(f => f.SetEmailEditTextTheme(null));
            _viewMock.Setup(f => f.SetSkypeEditTextTheme(null));
            _viewMock.Setup(f => f.SetCityEditTextTheme(null));
            _viewMock.Setup(f => f.SetCountryEditTextTheme(null));
            _viewMock.Setup(f => f.SetPhoneEditTextTheme(null));

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForInteractorEditContact>());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForViewEditContact>());

            _presenter = new PresenterEditContact(_viewMock.Object, _interactorMock.Object, _routerMock.Object);

            _presenter.SetTheme(new Mock<IEditContactStyleHolder>(MockBehavior.Default).Object);

            _viewMock.Verify(f => f.SetCancelButtonTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetSaveButtonTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetCountryTextViewTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetCityTextViewTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetEmailTextViewTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetPhoneTextViewTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetSkypeTextViewTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetEmailEditTextTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetSkypeEditTextTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetCityEditTextTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetCountryEditTextTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetPhoneEditTextTheme(null), Times.Once());
        }

        [Test]
        public void SetThemeNullTest()
        {
            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForInteractorEditContact>());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForViewEditContact>());

            _presenter = new PresenterEditContact(_viewMock.Object, _interactorMock.Object, _routerMock.Object);
            _presenter.SetTheme(null);
        }

        [Test]
        public void SetDataTest()
        {
            _viewMock.Setup(f => f.SetCity(null));
            _viewMock.Setup(f => f.SetCountry(null));
            _viewMock.Setup(f => f.SetEmail(null));
            _viewMock.Setup(f => f.SetSkype(null));
            _viewMock.Setup(f => f.SetPhone(null));

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForInteractorEditContact>());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForViewEditContact>());

            _presenter = new PresenterEditContact(_viewMock.Object, _interactorMock.Object, _routerMock.Object);
            _presenter.SetData(new EditContactEntity(null, null, null, null, null));

            _viewMock.Verify(f => f.SetCity(null), Times.Once());
            _viewMock.Verify(f => f.SetCountry(null), Times.Once());
            _viewMock.Verify(f => f.SetEmail(null), Times.Once());
            _viewMock.Verify(f => f.SetSkype(null), Times.Once());
            _viewMock.Verify(f => f.SetPhone(null), Times.Once());
        }
        
        [TestCase(EUserSettingsResponseState.Success)]
        public void EditContactSuccessState(EUserSettingsResponseState state)
        {
            _viewMock.Setup(f => f.SetCityLabelLocale(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetCountryLabelLocale(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetEmailLabelLocale(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetSkypeLabelLocale(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetPhoneLabelLocale(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetCancelButtonLocale(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetSaveButtonLocale(It.IsAny<string>()));
            
            _viewMock.Setup(f => f.ShowSuccessAlert(It.IsAny<string>(), It.IsAny<string>()));

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForInteractorEditContact>());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForViewEditContact>());

            _presenter = new PresenterEditContact(_viewMock.Object, _interactorMock.Object, _routerMock.Object);
            _presenter.SetLocale(Localization.Lang);
            _presenter.EditContactState(state);

            _viewMock.Verify(f => f.ShowSuccessAlert(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        }

        [TestCase(EUserSettingsResponseState.Error)]
        public void EditContactFailState(EUserSettingsResponseState state)
        {
            _viewMock.Setup(f => f.SetCityLabelLocale(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetCountryLabelLocale(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetEmailLabelLocale(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetSkypeLabelLocale(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetPhoneLabelLocale(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetCancelButtonLocale(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetSaveButtonLocale(It.IsAny<string>()));

            _viewMock.Setup(f => f.ShowFailAlert(It.IsAny<string>(), It.IsAny<string>()));

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForInteractorEditContact>());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForViewEditContact>());

            _presenter = new PresenterEditContact(_viewMock.Object, _interactorMock.Object, _routerMock.Object);
            _presenter.SetLocale(Localization.Lang);
            _presenter.EditContactState(state);

            _viewMock.Verify(f => f.ShowFailAlert(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void SetLocaleNullTest()
        {
            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForInteractorEditContact>());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForViewEditContact>());

            _presenter = new PresenterEditContact(_viewMock.Object, _interactorMock.Object, _routerMock.Object);
            _presenter.SetLocale(null);
        }

        [Test]
        public void SetLocaleTest()
        {
            _viewMock.Setup(f => f.SetCityLabelLocale(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetCountryLabelLocale(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetEmailLabelLocale(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetSkypeLabelLocale(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetPhoneLabelLocale(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetCancelButtonLocale(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetSaveButtonLocale(It.IsAny<string>()));

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForInteractorEditContact>());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForViewEditContact>());

            _presenter = new PresenterEditContact(_viewMock.Object, _interactorMock.Object, _routerMock.Object);
            _presenter.SetLocale(Localization.Lang);

            _viewMock.Verify(f => f.SetCityLabelLocale(It.IsAny<string>()), Times.Once());
            _viewMock.Verify(f => f.SetCountryLabelLocale(It.IsAny<string>()), Times.Once());
            _viewMock.Verify(f => f.SetEmailLabelLocale(It.IsAny<string>()), Times.Once());
            _viewMock.Verify(f => f.SetSkypeLabelLocale(It.IsAny<string>()), Times.Once());
            _viewMock.Verify(f => f.SetPhoneLabelLocale(It.IsAny<string>()), Times.Once());
            _viewMock.Verify(f => f.SetCancelButtonLocale(It.IsAny<string>()), Times.Once());
            _viewMock.Verify(f => f.SetSaveButtonLocale(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void EditContactDefaultState()
        {
            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForInteractorEditContact>());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForViewEditContact>());

            _presenter = new PresenterEditContact(_viewMock.Object, _interactorMock.Object, _routerMock.Object);
            _presenter.EditContactState(EUserSettingsResponseState.UserNotFound);
        }

        [Test]
        public void InvalidPhoneInputTest()
        {
            _viewMock.Setup(f => f.SetCancelButtonTheme(null));
            _viewMock.Setup(f => f.SetSaveButtonTheme(null));
            _viewMock.Setup(f => f.SetCountryTextViewTheme(null));
            _viewMock.Setup(f => f.SetCityTextViewTheme(null));
            _viewMock.Setup(f => f.SetEmailTextViewTheme(null));
            _viewMock.Setup(f => f.SetPhoneTextViewTheme(null));
            _viewMock.Setup(f => f.SetSkypeTextViewTheme(null));
            _viewMock.Setup(f => f.SetEmailEditTextTheme(null));
            _viewMock.Setup(f => f.SetSkypeEditTextTheme(null));
            _viewMock.Setup(f => f.SetCityEditTextTheme(null));
            _viewMock.Setup(f => f.SetCountryEditTextTheme(null));
            _viewMock.Setup(f => f.SetPhoneEditTextTheme(null));

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForInteractorEditContact>());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForViewEditContact>());
            _styleHolder.SetupGet(f => f.EditTextFailTheme).Returns(It.IsAny<IEditTextTheme>());

            _presenter = new PresenterEditContact(_viewMock.Object, _interactorMock.Object, _routerMock.Object);
            _presenter.SetTheme(_styleHolder.Object);
            _presenter.InvalidPhoneInput();

            _styleHolder.VerifyGet(f => f.EditTextFailTheme, Times.Once);

            _viewMock.Verify(f => f.SetCancelButtonTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetSaveButtonTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetCountryTextViewTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetCityTextViewTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetEmailTextViewTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetPhoneTextViewTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetSkypeTextViewTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetEmailEditTextTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetSkypeEditTextTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetCityEditTextTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetCountryEditTextTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetPhoneEditTextTheme(null), Times.AtMost(2));
        }

        [Test]
        public void InvalidSkypeInputTest()
        {
            _viewMock.Setup(f => f.SetCancelButtonTheme(null));
            _viewMock.Setup(f => f.SetSaveButtonTheme(null));
            _viewMock.Setup(f => f.SetCountryTextViewTheme(null));
            _viewMock.Setup(f => f.SetCityTextViewTheme(null));
            _viewMock.Setup(f => f.SetEmailTextViewTheme(null));
            _viewMock.Setup(f => f.SetPhoneTextViewTheme(null));
            _viewMock.Setup(f => f.SetSkypeTextViewTheme(null));
            _viewMock.Setup(f => f.SetEmailEditTextTheme(null));
            _viewMock.Setup(f => f.SetSkypeEditTextTheme(null));
            _viewMock.Setup(f => f.SetCityEditTextTheme(null));
            _viewMock.Setup(f => f.SetCountryEditTextTheme(null));
            _viewMock.Setup(f => f.SetPhoneEditTextTheme(null));

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForInteractorEditContact>());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForViewEditContact>());
            _viewMock.Setup(f => f.SetSkypeEditTextTheme(It.IsAny<IEditTextTheme>()));
            _styleHolder.SetupGet(f => f.EditTextFailTheme).Returns(It.IsAny<IEditTextTheme>());

            _presenter = new PresenterEditContact(_viewMock.Object, _interactorMock.Object, _routerMock.Object);
            _presenter.SetTheme(_styleHolder.Object);
            _presenter.InvalidSkypeInput();

            _styleHolder.VerifyGet(f => f.EditTextFailTheme, Times.Once);

            _viewMock.Verify(f => f.SetCancelButtonTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetSaveButtonTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetCountryTextViewTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetCityTextViewTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetEmailTextViewTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetPhoneTextViewTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetSkypeTextViewTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetEmailEditTextTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetSkypeEditTextTheme(null), Times.AtMost(2));
            _viewMock.Verify(f => f.SetCityEditTextTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetCountryEditTextTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetPhoneEditTextTheme(null), Times.Once());
        }

        [Test]
        public void InvalidCityInputTest()
        {
            _viewMock.Setup(f => f.SetCancelButtonTheme(null));
            _viewMock.Setup(f => f.SetSaveButtonTheme(null));
            _viewMock.Setup(f => f.SetCountryTextViewTheme(null));
            _viewMock.Setup(f => f.SetCityTextViewTheme(null));
            _viewMock.Setup(f => f.SetEmailTextViewTheme(null));
            _viewMock.Setup(f => f.SetPhoneTextViewTheme(null));
            _viewMock.Setup(f => f.SetSkypeTextViewTheme(null));
            _viewMock.Setup(f => f.SetEmailEditTextTheme(null));
            _viewMock.Setup(f => f.SetSkypeEditTextTheme(null));
            _viewMock.Setup(f => f.SetCityEditTextTheme(null));
            _viewMock.Setup(f => f.SetCountryEditTextTheme(null));
            _viewMock.Setup(f => f.SetPhoneEditTextTheme(null));

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForInteractorEditContact>());
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterForViewEditContact>());
            _viewMock.Setup(f => f.SetCityEditTextTheme(It.IsAny<IEditTextTheme>()));
            _styleHolder.SetupGet(f => f.EditTextFailTheme).Returns(It.IsAny<IEditTextTheme>());

            _presenter = new PresenterEditContact(_viewMock.Object, _interactorMock.Object, _routerMock.Object);
            _presenter.SetTheme(_styleHolder.Object);
            _presenter.InvalidCityInput();

            _styleHolder.VerifyGet(f => f.EditTextFailTheme, Times.Once);

            _viewMock.Verify(f => f.SetCancelButtonTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetSaveButtonTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetCountryTextViewTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetCityTextViewTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetEmailTextViewTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetPhoneTextViewTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetSkypeTextViewTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetEmailEditTextTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetSkypeEditTextTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetCityEditTextTheme(null), Times.AtMost(2));
            _viewMock.Verify(f => f.SetCountryEditTextTheme(null), Times.Once());
            _viewMock.Verify(f => f.SetPhoneEditTextTheme(null), Times.Once);
        }
    }
}
