using System;
using System.Reflection;
using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using SocialTrading.Tools.Interfaces;
using SocialTrading.Vipers.Tools.Implementation;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.Tools.Interfaces.Interactor;
using SocialTrading.Vipers.Tools.Interfaces.Presenter;

namespace MASTTests.Vipers.CreatePost
{
    [TestFixture, Author("Elena Pakhomova")]
    public class InteractorToolsTests
    {
        private Mock<IPresenterToolsForInteractor> _presenterMock;
        private Mock<IRepositoryNames> _repositoryMock;
        private Mock<ISearchHelper<string>> _searchMock;
        private IInteractorTools _interactor;

        [SetUp]
        public void SetUp()
        {
            _presenterMock = new Mock<IPresenterToolsForInteractor>(MockBehavior.Default);
            _repositoryMock = new Mock<IRepositoryNames>(MockBehavior.Default);
            _searchMock = new Mock<ISearchHelper<string>>(MockBehavior.Default);
        }
        [Test]
        public void CtorTestSettingSelectedTool()
        {
            string key = "AUDCAD";
            string value = "AUD/CAD";
            var listFromRepo = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("123key", "123value"),
                new Tuple<string, string>(key, value)
            };

            _repositoryMock.Setup(f => f.GetNames()).Returns(listFromRepo);

            _interactor = new InteractorTools(_repositoryMock.Object, _searchMock.Object, key);
            _interactor.Presenter = _presenterMock.Object;

            int selectedCell = -1;

            foreach (var item in typeof(InteractorTools).GetRuntimeFields())
            {
                if (item.Name.Equals("_selectedCell"))
                {
                    selectedCell = (int)item.GetValue(_interactor);
                }
            }

            Assert.AreEqual(listFromRepo.IndexOf(new Tuple<string, string>(key, value)), selectedCell);
        }

        [Test]
        public void CtorTestNullSelectedTool()
        {
            _repositoryMock.Setup(f => f.GetNames()).Returns(It.IsAny<List<Tuple<string, string>>>());

            _interactor = new InteractorTools( _repositoryMock.Object,_searchMock.Object);

            int selectedCell = -1;

            foreach (var item in typeof(InteractorTools).GetRuntimeFields())
            {
                if (item.Name.Equals("_selectedCell"))
                {
                    selectedCell = (int)item.GetValue(_interactor);
                }
            }

            Assert.AreEqual(-1, selectedCell);
        }

        [Test]
        public void CtorTestToolsDoesntContainKey()
        {
            var listFromRepo = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("123key", "123value"),

            };

            _repositoryMock.Setup(f => f.GetNames()).Returns(listFromRepo);

            _interactor = new InteractorTools(_repositoryMock.Object, _searchMock.Object, "AUDJPY");

            int selectedCell = -1;

            foreach (var item in typeof(InteractorTools).GetRuntimeFields())
            {
                if (item.Name.Equals("_selectedCell"))
                {
                    selectedCell = (int)item.GetValue(_interactor);
                }
            }

            Assert.AreEqual(-1, selectedCell);
        }
        
        [TestCase(-1, TestName = "Index -1")]
        [TestCase(10, TestName = "Index out of range")]
        public void CellClickOutOfRange(int index)
        {
            var listFromRepo = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("123key", "123value"),

            };

            _repositoryMock.Setup(f => f.GetNames()).Returns(listFromRepo);

            _interactor = new InteractorTools(_repositoryMock.Object, _searchMock.Object);

            _interactor.CellClick(index);

            int selectedCell = -1;

            foreach (var item in typeof(InteractorTools).GetRuntimeFields())
            {
                if (item.Name.Equals("_selectedCell"))
                {
                    selectedCell = (int)item.GetValue(_interactor);
                }
            }

            Assert.AreEqual(-1, selectedCell);
        }
        
        [Test]
        public void CellClickPositiveTest()
        {
            var listFromRepo = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("1key", "1value"),
                new Tuple<string, string>("2key", "2value"),
                new Tuple<string, string>("3key", "3value")

            };
            _repositoryMock.Setup(f => f.GetNames()).Returns(listFromRepo);

            _interactor = new InteractorTools(_repositoryMock.Object, _searchMock.Object);
            _interactor.Presenter = _presenterMock.Object;

            _interactor.CellClick(2);

            int selectedCell = -1;

            foreach (var item in typeof(InteractorTools).GetRuntimeFields())
            {
                if (item.Name.Equals("_selectedCell"))
                {
                    selectedCell = (int)item.GetValue(_interactor);
                }
            }

            Assert.AreEqual(2, selectedCell);
        }
    }
}
