using Moq;
using NUnit.Framework;

using System;

using SocialTrading.Tools;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.MoreOptions.OptionsCell.Interfaces;
using SocialTrading.Vipers.MoreOptions.OptionsCell.Implementation;

namespace MASTTests.Vipers.MoreOptions
{
    [TestFixture, Author("Elena Pakhomova")]
    public class InteractorOptionsCellBroadcastTests
    {
        private Mock<IPresenterOptionsCellForInteractor> _presenterMock;

        private IInteractorOptionsCell _interactor;

        [SetUp]
        public void SetUp()
        {
            _presenterMock = new Mock<IPresenterOptionsCellForInteractor>(MockBehavior.Strict);
        }


        [Test]
        public void CtorNullDictionaryForOptionsTest()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                _interactor = new InteractorOptionsCell(null, EItemsOptions.EditContactCell);
            });
        }

        [Test]
        public void CtorNoneOptionTest()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                _interactor = new InteractorOptionsCell(new DictionaryForOptions(), EItemsOptions.None);
            });
        }
        
        [Test]
        public void CellClickTest()
        {
            _presenterMock.Setup(f => f.GoTo(It.IsAny<EItemsOptions>()));

            _interactor = new InteractorOptionsCell(new DictionaryForOptions(), EItemsOptions.EditContactCell);
            _interactor.Presenter = _presenterMock.Object;
            _interactor.CellClick();

            _presenterMock.Verify(f => f.GoTo(It.IsAny<EItemsOptions>()), Times.Once());
        }

        [Test]
        public void SetConfigSetImageTest()
        {
            _presenterMock.Setup(f => f.SetImage(It.IsAny<string>()));
            _presenterMock.Setup(f => f.SetText(It.IsAny<string>()));

            _interactor = new InteractorOptionsCell(new DictionaryForOptions(), EItemsOptions.EditContactCell);
            _interactor.Presenter = _presenterMock.Object;
            _interactor.SetConfig();

            _presenterMock.Verify(f => f.SetImage(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void SetConfigSetTextTest()
        {
            _presenterMock.Setup(f => f.SetImage(It.IsAny<string>()));
            _presenterMock.Setup(f => f.SetText(It.IsAny<string>()));

            _interactor = new InteractorOptionsCell(new DictionaryForOptions(), EItemsOptions.EditContactCell);
            _interactor.Presenter = _presenterMock.Object;
            _interactor.SetConfig();

            _presenterMock.Verify(f => f.SetText(It.IsAny<string>()), Times.Once());
        }

    }
}
