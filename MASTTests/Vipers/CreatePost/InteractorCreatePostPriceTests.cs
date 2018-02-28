using Moq;

using System.Reflection;

using NUnit.Framework;

using SocialTrading.DTO;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.CreatePost.Interfaces;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.Controllers.Interfaces;
using SocialTrading.Vipers.CreatePost.Implementation;

namespace MASTTests.Vipers.CreatePost
{
    [TestFixture, Author("Elena Pakhomova")]
    public class InteractorCreatePostPriceTests
    {
        private Mock<IRepositoryCreatePost> _repositoryMock;
        private Mock<IRepositoryUserAuth> _repositoryUserMock;
        private Mock<ICreatePostController> _createPostControllerMock;
        private IInteractorCreatePost _interactor;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<IRepositoryCreatePost>(MockBehavior.Strict);
            _repositoryUserMock = new Mock<IRepositoryUserAuth>(MockBehavior.Strict);
            _createPostControllerMock = new Mock<ICreatePostController>(MockBehavior.Strict);

            _interactor = new InteractorCreatePost(_createPostControllerMock.Object, _repositoryMock.Object, _repositoryUserMock.Object);
        }

        [TestCase(EBuySell.Sell, "123", "AUD/CAD", "321", "123", TestName = "Positive Sell")]
        [TestCase(EBuySell.Buy, "321", "AUD/CAD", "321", "123", TestName = "Positive Buy")]
        public void PreparePriceTestPositive(EBuySell recommend, string price, string qcName, string qcAsk, string qcBid)
        {
            var actualPrice = string.Empty;

            foreach (var item in typeof(InteractorCreatePost).GetRuntimeFields())
            {
                if (item.Name.Equals("_qcBidAsk"))
                {
                    item.SetValue(_interactor, new QcBidAsk(qcName, qcBid, qcAsk));
                    break;
                }
            }

            foreach (var item in typeof(InteractorCreatePost).GetRuntimeMethods())
            {
                if (item.Name.Equals("PreparePrice"))
                {
                    actualPrice = item.Invoke(_interactor, new object[] { recommend }) as string;
                    break;
                }
            }

            Assert.AreEqual(actualPrice, price);
        }

        [TestCase("", EBuySell.Buy,TestName = "Negative repo doesn't contain such tool")]
        public void PreparePriceTestNegative(string quote, EBuySell recommend)
        {
            _repositoryMock.Setup(f => f.LangCreatePost.PriceLabel).Returns("Цена");
            var actualPrice = string.Empty;

            foreach (var item in typeof(InteractorCreatePost).GetRuntimeMethods())
            {
                if (item.Name.Equals("PreparePrice"))
                {
                    actualPrice = item.Invoke(_interactor, new object[] { recommend }) as string;
                    break;
                }
            }

            Assert.AreEqual("Цена", actualPrice);
        }
    }
}
