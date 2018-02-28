using System;
using System.Threading;

using NUnit.Framework;

using SocialTrading.DTO.Request;
using SocialTrading.DTO.Response.RA;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Service.Repositories;
using SocialTrading.Service.Interfaces.Repository;

namespace MASTTests.Vipers.Controllers
{
    [TestFixture]
    public class OptionsProfileControllerTest
    {
        private IRepositoryUserAuth _repo;
        private OptionsProfileController _controller;

        [SetUp]
        public void SetUp()
        {
            _repo = new RepositoryUserAuth
            {
                AuthData = new UserAuthData(new DataModelAuth("", "", "", "", "", "", "", "", "", "", "", "", "", false,
                    0, 0, 0, null))
            };
            _controller = new OptionsProfileController(_repo);
        }

        [Test, Author("Zaiets Katia")]
        public void CtorTest()
        {                      
            Assert.IsInstanceOf<OptionsProfileController>(_controller);
        }

        [Test, Author("Zaiets Katia")]
        public void CtorNegativeTest()
        {
            Assert.Throws<ArgumentNullException>(() => _controller = new OptionsProfileController(null));
        }

        [Test]
        public void SendPositiveTest()
        {
            var result = false;
            _controller.OnRecieveModel += _ =>
            {
                result = true;
            };
            _controller.Send(new UserInfoRequestModel(""));

            Thread.Sleep(500);

            Assert.IsTrue(result);
        }

        [Test]
        public void SendNegativeTest()
        {
            var result = false;
            _controller.OnRecieveModel += _ =>
            {
                result = true;
            };
            _controller.Send(null);

            Thread.Sleep(500);

            Assert.IsFalse(result);
        }
    }
}

