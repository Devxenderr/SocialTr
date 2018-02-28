using System;

using Moq;

using NUnit.Framework;

using SocialTrading.DTO.Interfaces;
using SocialTrading.DTO.Request.EditContact;
using SocialTrading.Tools.Validation.Interfaces;
using SocialTrading.Vipers.Controllers.Interfaces;
using SocialTrading.Vipers.ModelCreators.Interfaces;
using SocialTrading.Vipers.MoreOptions.EditProfile.Interfaces;
using SocialTrading.Vipers.MoreOptions.EditProfile.Implementation;

namespace MASTTests.Vipers.EditProfile
{
    [TestFixture, Author(Authors.Viktorov)]
    public class InteractorEditProfileTests
    {
        private Mock<IValidationEditProfile> _validationMock;

        private Mock<IEditProfileController> _controllerMock;
        private Mock<IEditProfileModelCreator> _modelCreatorMock;

        private IInteractorEditProfile _interactor;

        [SetUp]
        public void SetUp()
        {
            _validationMock = new Mock<IValidationEditProfile>(MockBehavior.Strict);
            _controllerMock = new Mock<IEditProfileController>(MockBehavior.Strict);
            _modelCreatorMock = new Mock<IEditProfileModelCreator>(MockBehavior.Strict);

            _interactor = new InteractorEditProfile(_validationMock.Object, _controllerMock.Object,
                _modelCreatorMock.Object);
        }

        [Test(Author = Authors.Viktorov)]
        public void CtorTestNullParams()
        {
            Assert.Throws<ArgumentNullException>(() => new InteractorEditProfile(null, null, null));
        }

        [Test(Author = Authors.Viktorov)]
        public void CtorTestNullValidation()
        {
            Assert.Throws<ArgumentNullException>(
                () => new InteractorEditProfile(null, _controllerMock.Object, _modelCreatorMock.Object));
        }

        [Test(Author = Authors.Viktorov)]
        public void CtorTestNullController()
        {
            Assert.Throws<ArgumentNullException>(
                () => new InteractorEditProfile(_validationMock.Object, null, _modelCreatorMock.Object));
        }

        [Test(Author = Authors.Viktorov)]
        public void CtorTestNullModelCreator()
        {
            Assert.Throws<ArgumentNullException>(
                () => new InteractorEditProfile(_validationMock.Object, _controllerMock.Object, null));
        }

        [Test(Author = Authors.Viktorov)]
        public void SendRequestForUserDataTest()
        {
            Tuple<bool, int> checkTuple = null;
            _modelCreatorMock.Setup(f => f.GetModel()).Returns(It.IsAny<IEditProfileEntity>());
            _interactor.ReceiveUserData += model => checkTuple = new Tuple<bool, int>(true, 1);

            _interactor.SendRequestForUserData();

            _modelCreatorMock.Verify(f => f.GetModel(), Times.Once);

            Assert.IsTrue(checkTuple.Item1);
            Assert.AreEqual(1, checkTuple.Item2);
        }

        [TestCase(true, true, true, Author = Authors.Viktorov, Description = "name is valid, status is valid")]
        public void SaveButtonClickTest(bool validName, bool validStatus, bool expFlag)
        {
            _modelCreatorMock.Setup(f => f.GetRequestModel(It.IsAny<IEditProfileEntity>()))
                .Returns(It.IsAny<UserInfoDTO>());
            _controllerMock.Setup(f => f.Send(It.IsAny<UserInfoDTO>()));

            var entity = new Mock<IEditProfileEntity>();
            entity.SetupGet(f => f.FirstName).Returns("FirstName");
            entity.SetupGet(f => f.LastName).Returns("LastName");
            entity.SetupGet(f => f.UserStatus).Returns("UserStatus");

            _validationMock.Setup(f => f.CheckName(It.IsAny<string>())).Returns(validName);
            _validationMock.Setup(f => f.CheckStatus(It.IsAny<string>())).Returns(validStatus);

            var flag = !expFlag;
            _interactor.ValidationFieldResponse += (fields, b) => { flag = b; };

            _interactor.SaveButtonClick(entity.Object);

            Assert.AreEqual(expFlag, flag);

            _modelCreatorMock.Verify(f => f.GetRequestModel(It.IsAny<IEditProfileEntity>()), Times.Once);
            _controllerMock.Verify(f => f.Send(It.IsAny<UserInfoDTO>()), Times.Once);

            entity.VerifyGet(f => f.FirstName, Times.AtLeastOnce);
            entity.VerifyGet(f => f.LastName, Times.AtLeastOnce);
            entity.VerifyGet(f => f.UserStatus, Times.AtLeastOnce);

            _validationMock.Verify(f => f.CheckName(It.IsAny<string>()), Times.AtLeastOnce);
            _validationMock.Verify(f => f.CheckStatus(It.IsAny<string>()), Times.Once);
        }

        [TestCase(false, true, false, Author = Authors.Viktorov, Description = "name is invalid, status is valid")]
        [TestCase(true, false, false, Author = Authors.Viktorov, Description = "name is valid, status is invalid")]
        [TestCase(false, false, false, Author = Authors.Viktorov, Description = "name is invalid, status is invalid")]
        public void SaveButtonClickFalseValidationTest(bool validName, bool validStatus, bool expFlag)
        {
            _modelCreatorMock.Setup(f => f.GetRequestModel(It.IsAny<IEditProfileEntity>()))
                .Returns(It.IsAny<UserInfoDTO>());
            _controllerMock.Setup(f => f.Send(It.IsAny<UserInfoDTO>()));

            var entity = new Mock<IEditProfileEntity>();
            entity.SetupGet(f => f.FirstName).Returns("FirstName");
            entity.SetupGet(f => f.LastName).Returns("LastName");
            entity.SetupGet(f => f.UserStatus).Returns("UserStatus");

            _validationMock.Setup(f => f.CheckName(It.IsAny<string>())).Returns(validName);
            _validationMock.Setup(f => f.CheckStatus(It.IsAny<string>())).Returns(validStatus);

            var flag = !expFlag;
            _interactor.ValidationFieldResponse += (fields, b) => { flag = b; };

            _interactor.SaveButtonClick(entity.Object);

            Assert.AreEqual(expFlag, flag);

            _modelCreatorMock.Verify(f => f.GetRequestModel(It.IsAny<IEditProfileEntity>()), Times.Never);
            _controllerMock.Verify(f => f.Send(It.IsAny<UserInfoDTO>()), Times.Never);

            _validationMock.Verify(f => f.CheckName(It.IsAny<string>()), Times.AtMost(2));
            _validationMock.Verify(f => f.CheckStatus(It.IsAny<string>()), Times.AtMostOnce);
        }

        [Test(Author = Authors.Viktorov)]
        public void SaveButtonClickuserDataNullTest()
        {
            Assert.Throws<ArgumentNullException>(() => _interactor.SaveButtonClick(null) );
        }

        [Test(Author = Authors.Viktorov)]
        public void NameWasInputTest()
        {
            var retValue = "Name";
            _validationMock.Setup(f => f.CheckName(retValue)).Returns(true);

            _interactor.NameWasInput(retValue);

            _validationMock.Verify(f => f.CheckName(retValue), Times.Once);
        }

        [Test(Author = Authors.Viktorov)]
        public void NameWasInputNullTest()
        {
            Assert.Throws<ArgumentNullException>(() => _interactor.NameWasInput(null));
        }

        [Test(Author = Authors.Viktorov)]
        public void LastnameWasInputTest()
        {
            var retValue = "LastName";
            _validationMock.Setup(f => f.CheckName(retValue)).Returns(true);

            _interactor.LastnameWasInput(retValue);

            _validationMock.Verify(f => f.CheckName(retValue), Times.Once);
        }

        [Test(Author = Authors.Viktorov)]
        public void LastnameWasInputNullTest()
        {
            Assert.Throws<ArgumentNullException>(() => _interactor.LastnameWasInput(null));
        }

        [Test(Author = Authors.Viktorov)]
        public void StatusWasInputTest()
        {
            var retValue = "Status";
            _validationMock.Setup(f => f.CheckStatus(retValue)).Returns(true);

            _interactor.StatusWasInput(retValue);

            _validationMock.Verify(f => f.CheckStatus(retValue), Times.Once);
        }

        [Test(Author = Authors.Viktorov)]
        public void StatusWasInputNullTest()
        {
            Assert.Throws<ArgumentNullException>(() => _interactor.StatusWasInput(null));
        }
    }
}