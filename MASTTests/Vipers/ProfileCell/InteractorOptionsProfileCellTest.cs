using System; 

using Moq;
using NUnit.Framework;
using SocialTrading.DTO.Response.RA;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Service.Repositories;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.ProfileCell.Interfaces;
using SocialTrading.Vipers.ProfileCell.Implementation;

namespace MASTTests.Vipers.ProfileCell
{
    [TestFixture]
    public class InteractorOptionsProfileCellTest
    {

        private Mock<IPresenterProfileCellForInteractor> _presenterMock;
        private IRepositoryUserAuth _repo;
        private OptionsProfileController _controller;

        private IInteractorProfileCell _interactor;

        [SetUp]
        public void SetUp()
        {
            _repo = new RepositoryUserAuth
            {
                AuthData = new UserAuthData(new DataModelAuth("", "", "", "", "", "", "", "", "", "", "", "", "", false,
                    0, 0, 0, null))
            };
            _controller = new OptionsProfileController(_repo);

            _presenterMock = new Mock<IPresenterProfileCellForInteractor>(MockBehavior.Default);
        }

        [Test]
        public void CtorNullTest()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                _interactor = new InteractorProfileCell("id", null);
            });
        }

        [Test]
        public void CtorTest()
        {
            _interactor = new InteractorProfileCell("id", _controller);         
        }

        [Test]
        public void FillUserDataTest()
        {
            _presenterMock.Setup(f => f.SetAvatar(It.IsAny<string>()));
            _presenterMock.Setup(f => f.SetName(It.IsAny<string>()));

            _interactor = new InteractorProfileCell("id", new OptionsProfileController(_repo))
            {
                Presenter = _presenterMock.Object
            };
            _interactor.SendRequestForUserData();

            _presenterMock.Verify(f => f.SetAvatar(It.IsAny<string>()), Times.Once);
            _presenterMock.Verify(f => f.SetName(It.IsAny<string>()), Times.Once);
        }

    }
}
