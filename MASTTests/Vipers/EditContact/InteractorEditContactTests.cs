using System;
using System.Linq;
using System.Reflection;
using System.Collections;

using Moq;

using NUnit.Framework;

using SocialTrading.Vipers.Entity;
using SocialTrading.DTO.Interfaces;
using SocialTrading.DTO.Request.EditContact;
using SocialTrading.Tools.Validation.Interfaces;
using SocialTrading.Vipers.Controllers.Interfaces;
using SocialTrading.Vipers.EditContact.Interfaces;
using SocialTrading.Vipers.ModelCreators.Interfaces;
using SocialTrading.Vipers.EditContact.Implementation;

namespace MASTTests.Vipers.EditContact
{
    [TestFixture, Author(Authors.Marchenko)]
    public class InteractorEditContactTests
    {
        private Mock<IPresenterForInteractorEditContact> _presenterMock;
        private Mock<IEditContactModelCreator> _modelCreator;
        private Mock<IEditContactController> _controller;
        private Mock<IValidationEditContact> _validation;
        private IInteractorEditContact _interactor;


        [SetUp]
        public void SetUp()
        {
            _modelCreator = new Mock<IEditContactModelCreator>(MockBehavior.Strict);
            _validation = new Mock<IValidationEditContact>(MockBehavior.Strict);
            _controller = new Mock<IEditContactController>(MockBehavior.Strict);
            _interactor = new InteractorEditContact(_controller.Object, _modelCreator.Object, _validation.Object);
            _presenterMock = new Mock<IPresenterForInteractorEditContact>(MockBehavior.Strict);

            _interactor.Presenter = _presenterMock.Object;
        }


        [Test]
        public void CtorTest()
        {
            Assert.IsInstanceOf<IInteractorEditContact>(_interactor);
        }

        [Test(Author = Authors.Gerashchenko)]
        [TestCaseSource(typeof(DataTests), nameof(DataTests.DataForCtorNegative))]
        public void CtorTest_Negative(IEditContactController controller, IEditContactModelCreator modelCreator, IValidationEditContact validation, string testName)
        {
            Assert.Throws<ArgumentNullException>(() => new InteractorEditContact(controller, modelCreator, validation));
        }

        [Test(Author = Authors.Gerashchenko)]
        public void SetPresenterTest_Negative()
        {
            Assert.Throws<ArgumentNullException>(() => _interactor.Presenter = null);
        }

        [Test]
        public void SetPresenterForInteractorTest()
        {
            var presenter = _interactor.GetType().GetRuntimeProperties().First(f => f.Name.Equals("Presenter")).GetValue(_interactor);
            var result = _presenterMock.Object.Equals(presenter);

            Assert.IsTrue(result);
        }

        [Test]
        public void CancelClickTest()
        {
            _presenterMock.Setup(f => f.GoBack());

            _interactor.CancelClick();

            _presenterMock.Verify(f => f.GoBack(), Times.Once);
        }

        [Test]
        public void CountryClickTest()
        {
            _presenterMock.Setup(f => f.GoToCountrySelection());

            _interactor.CountryClick();

            _presenterMock.Verify(f => f.GoToCountrySelection(), Times.Once);
        }

        [Test]
        public void AlertOkClickTest()
        {
            _presenterMock.Setup(f => f.GoBack());

            _interactor.AlertOkClick();

            _presenterMock.Verify(f => f.GoBack(), Times.Once);
        }

        [Test]
        public void SaveClickValidationTrueTest()
        {
            var entityMock = new EditContactEntityMock();
            _modelCreator.Setup(f => f.GetRequestModel(entityMock)).Returns(new UserInfoDTO(entityMock));
            _controller.Setup(f => f.Send(It.IsAny<UserInfoDTO>()));
            _validation.Setup(f => f.CheckCity(It.IsAny<string>())).Returns(true);
            _validation.Setup(f => f.CheckPhone(It.IsAny<string>())).Returns(true);
            _validation.Setup(f => f.CheckSkype(It.IsAny<string>())).Returns(true);

            _interactor.SaveClick(entityMock);

            _modelCreator.Verify(f => f.GetRequestModel(entityMock), Times.Once);
            _controller.Verify(f => f.Send(It.IsAny<UserInfoDTO>()), Times.Once);
        }

        [Test]
        public void SaveClickValidationFalseTest()
        {
            var entityMock = new EditContactEntityMock();
            _modelCreator.Setup(f => f.GetRequestModel(entityMock)).Returns(new UserInfoDTO(entityMock));
            _controller.Setup(f => f.Send(It.IsAny<UserInfoDTO>()));
            _validation.Setup(f => f.CheckCity(It.IsAny<string>())).Returns(false);
            _validation.Setup(f => f.CheckPhone(It.IsAny<string>())).Returns(false);
            _validation.Setup(f => f.CheckSkype(It.IsAny<string>())).Returns(false);
            _presenterMock.Setup(f => f.InvalidCityInput());
            _presenterMock.Setup(f => f.InvalidPhoneInput());
            _presenterMock.Setup(f => f.InvalidSkypeInput());

            _interactor.SaveClick(entityMock);

            _presenterMock.Verify(f => f.InvalidCityInput(), Times.Once);
            _presenterMock.Verify(f => f.InvalidPhoneInput(), Times.Once);
            _presenterMock.Verify(f => f.InvalidSkypeInput(), Times.Once);
            _modelCreator.Verify(f => f.GetRequestModel(entityMock), Times.Never);
            _controller.Verify(f => f.Send(It.IsAny<UserInfoDTO>()), Times.Never);
        }

        [Test(Author = Authors.Gerashchenko)]
        public void SaveClickTest_NegativeNullArgument()
        {
            Assert.Throws<ArgumentNullException>(() => _interactor.SaveClick(null));
        }

        [Test]
        public void SetConfigTest()
        {
            _modelCreator.Setup(f => f.GetModel()).Returns(It.IsAny<EditContactEntity>());
            _presenterMock.Setup(f => f.SetData(It.IsAny<EditContactEntity>()));

            _interactor.SetConfig();

            _modelCreator.Verify(f => f.GetModel(), Times.Once());
            _presenterMock.Verify(f => f.SetData(It.IsAny<EditContactEntity>()), Times.Once);
        }

        [Test]
        public void SkypeTextChangedTest()
        {
            _validation.Setup(f => f.CheckSkype(It.IsAny<string>())).Returns(It.IsAny<bool>());

            _interactor.SkypeTextChanged("");

            _validation.Verify(f => f.CheckSkype(It.IsAny<string>()), Times.Once);
        }

        [Test(Author = Authors.Gerashchenko)]
        public void SkypeTextChangedTest_NegativeNullArgument()
        {
            Assert.Throws<ArgumentNullException>(() => _interactor.SkypeTextChanged(null));
        }

        [Test]
        public void CityTextChangedTest()
        {
            _validation.Setup(f => f.CheckCity(It.IsAny<string>())).Returns(It.IsAny<bool>());

            _interactor.CityTextChanged("");

            _validation.Verify(f => f.CheckCity(It.IsAny<string>()), Times.Once);
        }

        [Test(Author = Authors.Gerashchenko)]
        public void CityTextChangedTest_NegativeNullArgument()
        {
            Assert.Throws<ArgumentNullException>(() => _interactor.CityTextChanged(null));
        }

        [Test]
        public void PhoneTextChangedTest()
        {
            _validation.Setup(f => f.CheckPhone(It.IsAny<string>())).Returns(It.IsAny<bool>());

            _interactor.PhoneTextChanged("");

            _validation.Verify(f => f.CheckPhone(It.IsAny<string>()), Times.Once);
        }

        [Test(Author = Authors.Gerashchenko)]
        public void PhoneTextChangedTest_NegativeNullArgument()
        {
            Assert.Throws<ArgumentNullException>(() => _interactor.PhoneTextChanged(null));
        }

        private class DataTests
        {
            public static IEnumerable DataForCtorNegative
            {
                get
                {
                    yield return new TestCaseData(
                        null,
                        null,
                        null,                                                                                               "0");
                    yield return new TestCaseData(
                        null,
                        new Mock<IEditContactModelCreator>(MockBehavior.Strict).Object,
                        new Mock<IValidationEditContact>(MockBehavior.Strict).Object,                                       "1");
                    yield return new TestCaseData(
                        new Mock<IEditContactController>(MockBehavior.Strict).Object,
                        null,
                        new Mock<IValidationEditContact>(MockBehavior.Strict).Object,                                       "2");
                    yield return new TestCaseData(
                        new Mock<IEditContactController>(MockBehavior.Strict).Object,
                        new Mock<IEditContactModelCreator>(MockBehavior.Strict).Object,
                        null,                                                                                               "3");
                }
            }
        }

        private class EditContactEntityMock : IEditContactEntity
        {
            public string Email { get; set; } = "123@122.123";
            public string Skype { get; set;} = "skype";
            public string Country { get; set; } = "country";
            public string City { get; set; } = "city";
            public string Phone { get; set; } = "123154687878";
        }
    }
}