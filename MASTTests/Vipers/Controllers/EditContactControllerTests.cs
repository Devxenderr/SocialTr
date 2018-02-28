using System;
using System.Linq;
using System.Threading;
using System.Reflection;

using Moq;

using NUnit.Framework;

using SocialTrading.DTO;
using SocialTrading.Vipers.Entity;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Service.Repositories;
using SocialTrading.Vipers.ModelCreators;
using SocialTrading.Connection.Interfaces;
using SocialTrading.DTO.Request.EditContact;
using SocialTrading.DTO.Response.UserSettings;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.Controllers.Interfaces;

namespace MASTTests.Vipers.Controllers
{
    [TestFixture, Author("Oleh Marchenko")]
    public class EditContactControllerTests
    {
        private IRepositoryEditContact _repo;
        private Mock<IContactCreator> _connectionMock;
        private IEditContactController _controller;
        private Func<string, DataModelUserInfo> _parseMethod;


        [SetUp]
        public void SetUp()
        {
            _parseMethod = s => null;
            _connectionMock = new Mock<IContactCreator>(MockBehavior.Strict);
            _repo = new RepositoryUserSettings
            {
                EditContactUserInfo = new DataModelUserInfo("", "", "", "", "", "", "", "", "", "", "", "", false, new string[]{})
            };
        }

        [Test]
        public void CtorTest()
        {
            var controller = new EditContactController(_connectionMock.Object, _repo, _parseMethod);

            Assert.IsInstanceOf<EditContactController>(controller);
            Assert.IsInstanceOf<IContactCreator>(controller.ContactCreator);
            Assert.IsInstanceOf<IRepositoryEditContact>(controller.GetType().GetRuntimeFields().First(f => f.Name.Equals("_repository")).GetValue(controller));
            Assert.IsInstanceOf<Func<string, DataModelUserInfo>>(controller.GetType().GetRuntimeFields().First(f => f.Name.Equals("_parseResponseUserInfo")).GetValue(controller));
        }

        [Test]
        public void CtorConnectionNegativeTest()
        {
            Assert.Throws<ArgumentNullException>(() => _controller = new EditContactController(null, _repo, _parseMethod));
        }

        [Test]
        public void CtorRepoNegativeTest()
        {
            Assert.Throws<ArgumentNullException>(() => _controller = new EditContactController(_connectionMock.Object, null, _parseMethod));
        }

        [Test]
        public void CtorParseMethodNegativeTest()
        {
            Assert.Throws<ArgumentNullException>(() => _controller = new EditContactController(_connectionMock.Object, _repo, null));
        }


        [Test]
        public void SendPositiveTest()
        {
            _connectionMock.Setup(f => f.CreateContact(It.IsAny<UserInfoDTO>())).Returns(new ContactMock());
            _controller = new EditContactController(_connectionMock.Object, _repo, _parseMethod);

            var result = false;
            _controller.OnRecieveModel += _ =>
            {
                result = true;
            };
            _controller.Send(new EditContactModelCreator(_repo).GetRequestModel(new EditContactEntity("", "", "", "", "")));

            Thread.Sleep(500);

            _connectionMock.Verify(f => f.CreateContact(It.IsAny<UserInfoDTO>()), Times.Once);
            Assert.IsTrue(result);
        }

        [Test]
        public void SendWhileProcessingTest()
        {
            _connectionMock.Setup(f => f.CreateContact(It.IsAny<UserInfoDTO>())).Returns(new ContactMock());
            _controller = new EditContactController(_connectionMock.Object, _repo, _parseMethod);
            _controller.GetType().GetRuntimeFields().First(f => f.Name.Equals("_currentRecieveStatus")).SetValue(_controller, EControllerStatus.Processing);

            var result = false;
            _controller.OnRecieveModel += _ =>
            {
                result = true;
            };
            _controller.Send(new EditContactModelCreator(_repo).GetRequestModel(new EditContactEntity("", "", "", "", "")));

            Thread.Sleep(500);

            _connectionMock.Verify(f => f.CreateContact(It.IsAny<UserInfoDTO>()), Times.Once);
            Assert.IsFalse(result);
        }


        private class ContactMock : IContact
        {
            public ContactMock()
            {
                var mock = new Mock<IConnectionSender>(MockBehavior.Strict);
                mock.Setup(f => f.Send(It.IsAny<IModelSend>()));
                Sender = mock.Object;
            }

            public void Dispose()
            {
            }

            public IConnectionSender Sender { get; }
            public IConnectionReciever Reciever { get; set; }
        }
    }
}