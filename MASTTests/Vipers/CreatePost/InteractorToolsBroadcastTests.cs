using System;
using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using SocialTrading.Tools.Interfaces;
using SocialTrading.Vipers.Tools.Implementation;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.Tools.Interfaces.Presenter;
using SocialTrading.Vipers.Tools.Interfaces.Interactor;

namespace MASTTests.Vipers.CreatePost
{
    [TestFixture, Author("Elena Pakhomova")]
    public class InteractorToolsBroadcastTests
    {
        private Mock<IPresenterToolsForInteractor> _presenterMock;
        private Mock<IRepositoryNames> _repositoryMock;
        private Mock<ISearchHelper<string>> _searchMock;
        private IInteractorTools _interactor;

        [SetUp]
        public void SetUp()
        {
            _presenterMock = new Mock<IPresenterToolsForInteractor>(MockBehavior.Strict);
            _repositoryMock = new Mock<IRepositoryNames>(MockBehavior.Strict);
            _searchMock = new Mock<ISearchHelper<string>>(MockBehavior.Strict);
        }

        [Test]
        public void CtorNullRepoTest()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                _interactor = new InteractorTools(null, _searchMock.Object);
            });
        }

        [Test]
        public void CtorNullPresenterTest()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                _repositoryMock.Setup(r => r.GetNames()).Returns(It.IsAny<List<Tuple<string, string>>>());
                _interactor = new InteractorTools(_repositoryMock.Object, _searchMock.Object);
                _interactor.Presenter = null;
            });
        }

        [Test]
        public void CtorNullSearchHelperTest()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                _interactor = new InteractorTools( _repositoryMock.Object, null);
            });
        }

        [Test]
        public void CtorPositiveTestSelectedKeyNull()
        {
            _presenterMock.Setup(f => f.SetDataSource(It.IsAny<List<string>>()));
            _repositoryMock.Setup(f => f.GetNames()).Returns(It.IsAny<List<Tuple<string, string>>>());

            _interactor = new InteractorTools( _repositoryMock.Object, _searchMock.Object);

            _presenterMock.Verify(f => f.SetEnableCell(It.IsAny<int>(), It.IsAny<bool>()), Times.Never());
        }

        [Test]
        public void CtorPositiveTestSelectedKeyUnexisted()
        {
            var listFromRepo = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("1key", "1value"),
                new Tuple<string, string>("2key", "2value"),
            };
            _presenterMock.Setup(f => f.SetDataSource(It.IsAny<List<string>>()));
            _repositoryMock.Setup(f => f.GetNames()).Returns(listFromRepo);

            _interactor = new InteractorTools( _repositoryMock.Object, _searchMock.Object, "key55");

            _presenterMock.Verify(f => f.SetEnableCell(It.IsAny<int>(), It.IsAny<bool>()), Times.Never());
        }

        [Test]
        public void CtorPositiveTestSelectedKeyExist()
        {
            var listFromRepo = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("1key", "1value"),
                new Tuple<string, string>("2key", "2value"),
            };
            _presenterMock.Setup(f => f.SetDataSource(It.IsAny<List<string>>()));
            _repositoryMock.Setup(f => f.GetNames()).Returns(listFromRepo);

            _presenterMock.Setup(f => f.SetEnableCell(It.IsAny<int>(), It.IsAny<bool>()));

            _interactor = new InteractorTools( _repositoryMock.Object, _searchMock.Object, "1key");
            _interactor.Presenter = _presenterMock.Object;

            _presenterMock.Verify(f => f.SetEnableCell(It.IsAny<int>(), It.IsAny<bool>()), Times.Once());
        }

        [Test]
        public void CellClickPositiveTest()
        {
            var listFromRepo = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("1key", "1value"),
                new Tuple<string, string>("2key", "2value"),
            };

            _repositoryMock.Setup(f => f.GetNames()).Returns(listFromRepo);
            _presenterMock.Setup(f => f.SetDataSource(It.IsAny<List<string>>()));
            _presenterMock.Setup(f => f.GoBack(It.IsAny<string>()));

            _presenterMock.Setup(f => f.SetEnableCell(It.IsAny<int>(), It.IsAny<bool>()));

            _interactor = new InteractorTools( _repositoryMock.Object, _searchMock.Object);
            _interactor.Presenter = _presenterMock.Object;

            _interactor.CellClick(0);

            _presenterMock.Verify(f => f.SetEnableCell(It.IsAny<int>(), It.IsAny<bool>()), Times.Exactly(2));
        }

        [TestCase(-1, TestName = "Index -1")]
        [TestCase(10, TestName = "Index out of range")]
        public void CellClickNegativeTest(int index)
        {
            var listFromRepo = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("1key", "1value"),
                new Tuple<string, string>("2key", "2value"),
            };

            _repositoryMock.Setup(f => f.GetNames()).Returns(listFromRepo);
            _presenterMock.Setup(f => f.SetDataSource(It.IsAny<List<string>>()));

            _interactor = new InteractorTools(_repositoryMock.Object, _searchMock.Object);
            _interactor.Presenter = _presenterMock.Object;
            _interactor.CellClick(index);

            _presenterMock.Verify(f => f.SetEnableCell(It.IsAny<int>(), It.IsAny<bool>()), Times.Never);
        }
        
        [Test]
        public void SearchEditSetDataSourceTest()
        {
            var listFromRepo = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("1key", "1value"),
                new Tuple<string, string>("2key", "2value"),
            };

            _repositoryMock.Setup(f => f.GetNames()).Returns(It.IsAny<List<Tuple<string, string>>>());
            _presenterMock.Setup(f => f.SetDataSource(It.IsAny<List<string>>()));
            _searchMock.Setup(f => f.Search(It.IsAny<List<Tuple<string, string>>>(), It.IsAny<string>())).Returns(listFromRepo);

            _interactor = new InteractorTools(_repositoryMock.Object, _searchMock.Object);
            _interactor.Presenter = _presenterMock.Object;
            _interactor.SearchEdit("key");
            
            _presenterMock.Verify(f => f.SetDataSource(It.IsAny<List<string>>()), Times.Exactly(2));
        }

        [Test]
        public void SearchEditSearchTest()
        {
            var listFromRepo = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("1key", "1value"),
                new Tuple<string, string>("2key", "2value"),
            };

            _repositoryMock.Setup(f => f.GetNames()).Returns(It.IsAny<List<Tuple<string, string>>>());
            _presenterMock.Setup(f => f.SetDataSource(It.IsAny<List<string>>()));
            _searchMock.Setup(f => f.Search(It.IsAny<List<Tuple<string, string>>>(), It.IsAny<string>())).Returns(listFromRepo);

            _interactor = new InteractorTools(_repositoryMock.Object, _searchMock.Object);
            _interactor.Presenter = _presenterMock.Object;
            _interactor.SearchEdit("key");

            _searchMock.Verify(f => f.Search(It.IsAny<List<Tuple<string, string>>>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void SearchEditStrNullTest()
        {
            var listFromRepo = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("1key", "1value"),
                new Tuple<string, string>("2key", "2value"),
            };

            _repositoryMock.Setup(f => f.GetNames()).Returns(listFromRepo);
            _presenterMock.Setup(f => f.SetDataSource(It.IsAny<List<string>>()));
            _searchMock.Setup(f => f.Search(It.IsAny<List<Tuple<string, string>>>(), It.IsAny<string>())).Returns(listFromRepo);

            _interactor = new InteractorTools(_repositoryMock.Object, _searchMock.Object);
            _interactor.Presenter = _presenterMock.Object;
            _interactor.SearchEdit(It.IsAny<string>());

            _searchMock.Verify(f => f.Search(It.IsAny<List<Tuple<string, string>>>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void SearchEditFoundNullTest()
        {
            _repositoryMock.Setup(f => f.GetNames()).Returns(It.IsAny<List<Tuple<string, string>>>());
            _presenterMock.Setup(f => f.SetDataSource(It.IsAny<List<string>>()));
            _searchMock.Setup(f => f.Search(It.IsAny<List<Tuple<string, string>>>(), It.IsAny<string>())).Returns(It.IsAny<List<Tuple<string, string>>>());

            _interactor = new InteractorTools(_repositoryMock.Object, _searchMock.Object);
            _interactor.Presenter = _presenterMock.Object;
            _interactor.SearchEdit("key");
            
            _presenterMock.Verify(f => f.SetDataSource(It.IsAny<List<string>>()), Times.Once);
        }
    }
}
