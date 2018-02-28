using Moq;

using NUnit.Framework;

using System;
using System.Collections;
using System.Collections.Generic;

using SocialTrading.Theme.Interfaces;
using SocialTrading.Theme.ThemeStrings;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.Vipers.Tools.Interfaces.View;
using SocialTrading.Vipers.Tools.Interfaces.Router;
using SocialTrading.Vipers.Tools.Interfaces.Presenter;
using SocialTrading.Vipers.Tools.Interfaces.Interactor;
using SocialTrading.Vipers.Tools.Implementation.Presenter;

namespace MASTTests.Vipers.SearchTools.Presenter
{
    #region PresenterTools_BridgesTests
    [TestFixture, Author("Gerashchenko V.V."), Category("PresenterTools_BridgesTests")]
    public class PresenterTools_BridgesTests
    {
        private Mock<IRouterTools> _routerMock;
        private Mock<IViewTools> _viewMock;
        private Mock<IInteractorTools> _interactorMock;
        private Mock<IToolsStylesHolder> _stylesHolderMock;

        private IPresenterTools _presenter;

        [SetUp]
        public void SetUp()
        {
            _routerMock = new Mock<IRouterTools>(MockBehavior.Strict);
            _viewMock = new Mock<IViewTools>(MockBehavior.Strict);
            _interactorMock = new Mock<IInteractorTools>(MockBehavior.Strict);
            _viewMock.SetupSet(p => p.Presenter = It.IsAny<IPresenterToolsForView>());
            _interactorMock.SetupSet(p => p.Presenter = It.IsAny<IPresenterToolsForInteractor>());
            _stylesHolderMock = new Mock<IToolsStylesHolder>(MockBehavior.Strict);

            _presenter = new PresenterTools(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object);
        }

        [Test]
        [TestCase(int.MinValue, TestName = "CellClickTest_MinValue")]
        [TestCase(-50, TestName = "CellClickTest_-50")]
        [TestCase(-1, TestName = "CellClickTest_-1")]
        [TestCase(0, TestName = "CellClickTest_0")]
        [TestCase(1, TestName = "CellClickTest_1")]
        [TestCase(50, TestName = "CellClickTest_50")]
        [TestCase(int.MaxValue, TestName = "CellClickTest_MaxValue")]
        public void CellClickTest(int index)
        {
            _interactorMock.Setup(s => s.CellClick(index));

            _presenter.CellClick(index);

            _interactorMock.Verify(o => o.CellClick(index), Times.Once);
        }

        [Test]
        [TestCase("", TestName = "SearchEditTest_")]
        [TestCase("123", TestName = "SearchEditTest_123")]
        [TestCase("zaqwertyuiop", TestName = "SearchEditTest_zaqwertyuiop")]
        [TestCase(null, TestName = "SearchEditTest_null")]
        public void SearchEditTest(string searchStr)
        {
            _interactorMock.Setup(s => s.SearchEdit(searchStr));

            _presenter.SearchEdit(searchStr);

            _interactorMock.Verify(o => o.SearchEdit(searchStr), Times.Once);
        }

        [Test]
        [TestCase("", TestName = "GoBack_WithArgsTest_")]
        [TestCase("123", TestName = "GoBack_WithArgsTest_123")]
        [TestCase("zaqwertyuiop", TestName = "GoBack_WithArgsTest_zaqwertyuiop")]
        [TestCase(null, TestName = "GoBack_WithArgsTest_null")]
        public void GoBack_WithArgsTest(string selectedKey)
        {
            _routerMock.Setup(s => s.GoBack(selectedKey));

            _presenter.GoBack(selectedKey);

            _routerMock.Verify(o => o.GoBack(selectedKey), Times.Once);
        }

        [Test]
        [TestCase(int.MinValue, TestName = "SetScrollTest_MinValue")]
        [TestCase(-50, TestName = "SetScrollTest_-50")]
        [TestCase(-1, TestName = "SetScrollTest_-1")]
        [TestCase(0, TestName = "SetScrollTest_0")]
        [TestCase(1, TestName = "SetScrollTest_1")]
        [TestCase(50, TestName = "SetScrollTest_50")]
        [TestCase(int.MaxValue, TestName = "SetScrollTest_MaxValue")]
        public void SetScrollTest(int index)
        {
            _viewMock.Setup(s => s.Scroll(index));

            _presenter.SetScroll(index);

            _viewMock.Verify(v => v.Scroll(index));
        }

        [Test]
        [TestCase(-50, true, TestName = "SetEnableCellTest_-50")]
        [TestCase(0, true, TestName = "SetEnableCellTest_0")]
        [TestCase(50, true, TestName = "SetEnableCellTest_50")]
        public void SetEnableCellTest(int index, bool isEnable)
        {
            _stylesHolderMock.SetupGet(f => f.SelectedCellTheme).Returns(It.IsAny<IViewTheme>());
            _stylesHolderMock.SetupGet(f => f.ToolNameTheme).Returns(It.IsAny<ITextViewTheme>());
            _viewMock.Setup(s => s.SetEnableCell(index, It.IsAny<IViewTheme>(), It.IsAny<ITextViewTheme>()));

            _presenter.SetEnableCell(index, isEnable);

            _viewMock.Verify(v => v.SetEnableCell(index, It.IsAny<IViewTheme>(), It.IsAny<ITextViewTheme>()));
            _stylesHolderMock.VerifyGet(f => f.SelectedCellTheme, Times.Once);
            _stylesHolderMock.VerifyGet(f => f.ToolNameTheme, Times.Once);
        }

        [Test]
        [TestCase(int.MinValue, false, TestName = "SetEnableCellTest_MinValue")]
        [TestCase(-1, false, TestName = "SetEnableCellTest_-1")]
        [TestCase(1, false, TestName = "SetEnableCellTest_1")]
        [TestCase(int.MaxValue, false, TestName = "SetEnableCellTest_MaxValue")]
        public void SetUnEnableCellTest(int index, bool isEnable)
        {
            _stylesHolderMock.SetupGet(f => f.UnselectedCellTheme).Returns(It.IsAny<IViewTheme>());
            _stylesHolderMock.SetupGet(f => f.ToolNameTheme).Returns(It.IsAny<ITextViewTheme>());
            _viewMock.Setup(s => s.SetEnableCell(index, It.IsAny<IViewTheme>(), It.IsAny<ITextViewTheme>()));

            _presenter.SetEnableCell(index, isEnable);

            _viewMock.Verify(v => v.SetEnableCell(index, It.IsAny<IViewTheme>(), It.IsAny<ITextViewTheme>()));
            _stylesHolderMock.VerifyGet(f => f.UnselectedCellTheme, Times.Once);
            _stylesHolderMock.VerifyGet(f => f.ToolNameTheme, Times.Once);
        }

        [Test, TestCaseSource(typeof(DataForBridgesTests), nameof(DataForBridgesTests.SetDataSourceData))]
        public void SetDataSourceTest(List<string> tooList, string testName)
        {
            _viewMock.Setup(s => s.SetDataSource(tooList, _stylesHolderMock.Object));

            _presenter.SetDataSource(tooList);

            _viewMock.Verify(v => v.SetDataSource(tooList, _stylesHolderMock.Object));
        }

        private class DataForBridgesTests
        {
            public static IEnumerable SetDataSourceData
            {
                get
                {
                    yield return new TestCaseData(null, "null");
                    yield return new TestCaseData(new List<string>(), "0");
                    yield return new TestCaseData(new List<string> { "" }, "1");
                    yield return new TestCaseData(new List<string> { "123", "321" }, "2");
                    yield return new TestCaseData(new List<string> { "123", "321", "555" }, "3");
                }
            }
        }
    }
    #endregion

    #region PresenterTools_FunctionalTests
    [TestFixture, Author("Gerashchenko V.V."), Category("PresenterTools_FunctionalTests")]
    public class PresenterTools_FunctionalTests
    {
        private Mock<IRouterTools> _routerMock;
        private Mock<IViewTools> _viewMock;
        private Mock<IInteractorTools> _interactorMock;

        private IPresenterTools _presenter;
        private Mock<IToolsStylesHolder> _stylesHolderMock;

        [SetUp]
        public void SetUp()
        {
            _routerMock = new Mock<IRouterTools>(MockBehavior.Strict);
            _viewMock = new Mock<IViewTools>(MockBehavior.Strict);
            _interactorMock = new Mock<IInteractorTools>(MockBehavior.Strict);
            _viewMock.SetupSet(p => p.Presenter = It.IsAny<IPresenterToolsForView>());
            _interactorMock.SetupSet(p => p.Presenter = It.IsAny<IPresenterToolsForInteractor>());
            _stylesHolderMock = new Mock<IToolsStylesHolder>(MockBehavior.Strict);

            _presenter = new PresenterTools(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object);
        }

        [Test, TestCaseSource(typeof(DataForFunctionalTests), nameof(DataForFunctionalTests.SetThemeData))]
        public void SetTheme_PositiveTests(IThemeKeyStringsTools theme, string testName)
        {
            _viewMock.Setup(s => s.SetCollectionViewTheme(theme.DividingLineColorKey, theme.DividingLineSizeKey, theme.DividingLineTypeKey));
            _viewMock.Setup(s => s.SetSearchTheme(theme.SearchBacgroundColorKey, theme.SearchTextColorKey, theme.SearchTextSizeKey, theme.SearchTextFontStyleKey));
            
            _presenter.SetTheme(theme);

            _viewMock.Verify(s => s.SetCollectionViewTheme(theme.DividingLineColorKey, theme.DividingLineSizeKey, theme.DividingLineTypeKey));
            _viewMock.Verify(s => s.SetSearchTheme(theme.SearchBacgroundColorKey, theme.SearchTextColorKey, theme.SearchTextSizeKey, theme.SearchTextFontStyleKey));
            
        }

        [Test]
        public void SetTheme_NegativeTests()
        {
            _presenter.SetTheme(null);
        }

        [Test]
        public void PresenterConstructor_PositiveTest()
        {
            IPresenterTools Presenter = new PresenterTools(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _stylesHolderMock.Object);

            _viewMock.SetupSet(p => p.Presenter = Presenter);
            _viewMock.VerifySet(p => p.Presenter = Presenter);

            _interactorMock.SetupSet(p => p.Presenter = Presenter);
            _interactorMock.VerifySet(p => p.Presenter = Presenter);
        }

        [Test, TestCaseSource(typeof(DataForFunctionalTests), nameof(DataForFunctionalTests.ConstructorDataSource))]
        public void PresetnterConstructor_NegativeTest(IViewTools view, IInteractorTools interacotor, IRouterTools router)
        {
            Assert.Throws<ArgumentNullException>(() => new PresenterTools(view, interacotor, router, _stylesHolderMock.Object));
        }

        private class DataForFunctionalTests
        {
            public static IEnumerable SetThemeData
            {
                get
                {
                    yield return new TestCaseData(new ToolsThemeStrings()
                    {
                        ArrowBackImageKey = "",
                        DividingLineColorKey = "",
                        DividingLineSizeKey = "",
                        DividingLineTypeKey = "",
                        SearchBacgroundColorKey = "",
                        SearchTextColorKey = "",
                        SearchTextFontStyleKey = "",
                        SearchTextSizeKey = "",
                        SelectedCellColorKey = "",
                        SelectedCellTextColorKey = "",
                        SelectedCellTextFontStyleKey = "",
                        SelectedCellTextSizeKey = "",
                        ToolBarBackgoundColorKey = "",
                        ToolBarTextColorKey = "",
                        ToolBarTextFontStyleKey = "",
                        ToolBarTextSizeKey = "",
                        CellColorKey = "",
                        CellTextColorKey = "",
                        CellTextFontStyleKey = "",
                        CellTextSizeKey = ""
                    }, "Test_0");

                    yield return new TestCaseData(new ToolsThemeStrings()
                    {
                        ArrowBackImageKey = null,
                        DividingLineColorKey = null,
                        DividingLineSizeKey = null,
                        DividingLineTypeKey = null,
                        SearchBacgroundColorKey = null,
                        SearchTextColorKey = null,
                        SearchTextFontStyleKey = null,
                        SearchTextSizeKey = null,
                        SelectedCellColorKey = null,
                        SelectedCellTextColorKey = null,
                        SelectedCellTextFontStyleKey = null,
                        SelectedCellTextSizeKey = null,
                        ToolBarBackgoundColorKey = null,
                        ToolBarTextColorKey = null,
                        ToolBarTextFontStyleKey = null,
                        ToolBarTextSizeKey = null,
                        CellColorKey = null,
                        CellTextColorKey = null,
                        CellTextFontStyleKey = null,
                        CellTextSizeKey = null
                    }, "Test_1");

                    yield return new TestCaseData(new ToolsThemeStrings()
                    {
                        ArrowBackImageKey = "1",
                        DividingLineColorKey = "2",
                        DividingLineSizeKey = "3",
                        DividingLineTypeKey = "4",
                        SearchBacgroundColorKey = "5",
                        SearchTextColorKey = "6",
                        SearchTextFontStyleKey = "7",
                        SearchTextSizeKey = "8",
                        SelectedCellColorKey = "9",
                        SelectedCellTextColorKey = "10",
                        SelectedCellTextFontStyleKey = "11",
                        SelectedCellTextSizeKey = "12",
                        ToolBarBackgoundColorKey = "13",
                        ToolBarTextColorKey = "14",
                        ToolBarTextFontStyleKey = "15",
                        ToolBarTextSizeKey = "16",
                        CellColorKey = "17",
                        CellTextColorKey = "18",
                        CellTextFontStyleKey = "19",
                        CellTextSizeKey = "20"
                    }, "Test_2");

                    yield return new TestCaseData(new ToolsThemeStrings()
                    {
                        ArrowBackImageKey = "1",
                        DividingLineColorKey = "2",
                        DividingLineSizeKey = null,
                        DividingLineTypeKey = "4",
                        SearchBacgroundColorKey = "5",
                        SearchTextColorKey = "6",
                        SearchTextFontStyleKey = "7",
                        SearchTextSizeKey = "8",
                        SelectedCellColorKey = "9",
                        SelectedCellTextColorKey = null,
                        SelectedCellTextFontStyleKey = "",
                        SelectedCellTextSizeKey = "12",
                        ToolBarBackgoundColorKey = "13",
                        ToolBarTextColorKey = "14",
                        ToolBarTextFontStyleKey = "15",
                        ToolBarTextSizeKey = "",
                        CellColorKey = null,
                        CellTextColorKey = "18",
                        CellTextFontStyleKey = "19",
                        CellTextSizeKey = "20"
                    }, "Test_3");
                }
            }

            public static IEnumerable ConstructorDataSource
            {
                get
                {
                    yield return new TestCaseData(  null,
                                                    null,
                                                    null);

                    yield return new TestCaseData(  null, 
                                                    new Mock<IInteractorTools>(MockBehavior.Strict).Object,
                                                    new Mock<IRouterTools>(MockBehavior.Strict).Object);

                    yield return new TestCaseData(  new Mock<IViewTools>(MockBehavior.Strict).Object,                                                    
                                                    new Mock<IInteractorTools>(MockBehavior.Strict).Object, 
                                                    null);

                    yield return new TestCaseData(  new Mock<IViewTools>(MockBehavior.Strict).Object,                                                    
                                                    null,
                                                    new Mock<IRouterTools>(MockBehavior.Strict).Object);
                }
            }
        }
    }
    #endregion
}