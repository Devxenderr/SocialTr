using Moq;

using NUnit.Framework;

using System;
using System.Collections;

using SocialTrading.Locale.Modules;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.Vipers.ProfileCell.Interfaces;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.Vipers.ProfileCell.Implementation;
using SocialTrading.ThemesStyles.Interfaces.ImageView;

namespace MASTTests.Vipers.ProfileCell
{
    [TestFixture, Author("Gerashchenko V.V.")]
    public class PresenterProfileCellTests
    {
        private Mock<IProfileCellView> _viewMock;
        private Mock<IInteractorProfileCell> _interactorMock;
        private Mock<IProfileCellLocale> _profileCellLocale;
        private Mock<IProfileCellStylesHolder> _stylesHolderMock;

        [SetUp]
        public void SetUp()
        {
            _viewMock = new Mock<IProfileCellView>(MockBehavior.Strict);
            _interactorMock = new Mock<IInteractorProfileCell>(MockBehavior.Strict);

            _profileCellLocale = new Mock<IProfileCellLocale>(MockBehavior.Strict);

            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterProfileCell>());

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterProfileCell>());

            _stylesHolderMock = new Mock<IProfileCellStylesHolder>(MockBehavior.Strict);

            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterProfileCellForView>());
            _viewMock.Setup(f => f.SetConfig());
            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterProfileCellForInteractor>());
        }

        [Test]
        [TestCaseSource(typeof(DataTests), nameof(DataTests.ConstructorNegative))]
        public void ConstructorNegativeTest(IProfileCellView view, IInteractorProfileCell interactor, IProfileCellStylesHolder themes, IProfileCellLocale locale, string testName)
        {
            Assert.Throws(typeof(ArgumentNullException), () =>
            {
                var presenter = new PresenterProfileCell(view, interactor, themes, locale);
            });
        }

        [Test]
        [TestCaseSource(typeof(DataTests), nameof(DataTests.ConstructorPosive))]
        public void ConstructorPositiveTest(IProfileCellView view, IInteractorProfileCell interactor, IProfileCellStylesHolder themes, IProfileCellLocale locale, string testName)
        {
            var presenter = new PresenterProfileCell(view, interactor, themes, locale);
        }

        [Test]       
        public void SetConfigTest()
        {
            _stylesHolderMock.SetupGet(f => f.AvatarImageViewTheme).Returns(It.IsAny<IImageViewTheme>());
            _stylesHolderMock.SetupGet(f => f.CellBackgroundTheme).Returns(It.IsAny<IViewTheme>());
            _stylesHolderMock.SetupGet(f => f.NameLabelTheme).Returns(It.IsAny<ITextViewTheme>());
            _stylesHolderMock.SetupGet(f => f.YourProfileLabelTheme).Returns(It.IsAny<ITextViewTheme>());
            _profileCellLocale.SetupGet(f => f.YourProfile).Returns(It.IsAny<string>());

            _viewMock.Setup(f => f.SetAvatarTheme(It.IsAny<IImageViewTheme>()));
            _viewMock.Setup(f => f.SetBackgroundTheme(It.IsAny<IViewTheme>()));
            _viewMock.Setup(f => f.SetNameTheme(It.IsAny<ITextViewTheme>()));
            _viewMock.Setup(f => f.SetProfileLabelTheme(It.IsAny<ITextViewTheme>()));
            _viewMock.Setup(f => f.SetProfileLabel(It.IsAny<string>()));

            var presenter = new PresenterProfileCell(_viewMock.Object, _interactorMock.Object, _stylesHolderMock.Object, _profileCellLocale.Object);
            presenter.SetConfig();

            _viewMock.Verify(f => f.SetConfig(), Times.Once);

            _viewMock.Verify(f => f.SetAvatarTheme(It.IsAny<IImageViewTheme>()), Times.Once);
            _viewMock.Verify(f => f.SetBackgroundTheme(It.IsAny<IViewTheme>()), Times.Once);
            _viewMock.Verify(f => f.SetNameTheme(It.IsAny<ITextViewTheme>()), Times.Once);
            _viewMock.Verify(f => f.SetProfileLabelTheme(It.IsAny<ITextViewTheme>()), Times.Once);
            _viewMock.Verify(f => f.SetProfileLabel(It.IsAny<string>()), Times.Once);
        }

        [Test]
        [TestCase(null, TestName = "SetNameTest_null")]
        [TestCase("", TestName = "SetNameTest_")]
        [TestCase("123", TestName = "SetNameTest_123")]
        public void SetNameTest(string name)
        {
            _viewMock.Setup(f => f.SetName(name));

            var presenter = new PresenterProfileCell(_viewMock.Object, _interactorMock.Object, _stylesHolderMock.Object, _profileCellLocale.Object);
            presenter.SetName(name);

            _viewMock.Verify(f => f.SetName(name), Times.Once); 
        }

        [Test]
        [TestCase(null, TestName = "SetAvaterTest_null")]
        [TestCase("", TestName = "SetAvaterTest_")]
        [TestCase("123", TestName = "SetAvaterTest_123")]
        [TestCase("https://avatars3.githubusercontent.com/u/19308174?s=460&v=4", TestName = "URL")]
        public void SetAvaterTest(string url)
        {
            _viewMock.Setup(f => f.SetAvatar(url));

            var presenter = new PresenterProfileCell(_viewMock.Object, _interactorMock.Object, _stylesHolderMock.Object, _profileCellLocale.Object);
            presenter.SetAvatar(url);

            _viewMock.Verify(f => f.SetAvatar(url), Times.Once);
        }

        private class DataTests
        {
            public static IEnumerable ConstructorNegative
            {
                get
                {
                    yield return new TestCaseData(
                        null, 
                        new Mock<IInteractorProfileCell>(MockBehavior.Strict).Object, 
                        new Mock<IProfileCellStylesHolder>(MockBehavior.Strict).Object, 
                        new Mock<IProfileCellLocale>(MockBehavior.Strict).Object, 
                        "View = null");

                    yield return new TestCaseData(
                        new Mock<IProfileCellView>(MockBehavior.Strict).Object, 
                        null, 
                        new Mock<IProfileCellStylesHolder>(MockBehavior.Strict).Object, 
                        new Mock<IProfileCellLocale>(MockBehavior.Strict).Object, 
                        "Interactor = null");

                    yield return new TestCaseData(
                        null, 
                        null, 
                        new Mock<IProfileCellStylesHolder>(MockBehavior.Strict).Object, 
                        new Mock<IProfileCellLocale>(MockBehavior.Strict).Object, 
                        "View and Interactor = null");
                }
            }

            public static IEnumerable ConstructorPosive
            {
                get
                {
                    yield return new TestCaseData(
                        new Mock<IProfileCellView>(MockBehavior.Strict).Object, 
                        new Mock<IInteractorProfileCell>(MockBehavior.Strict).Object, 
                        new Mock<IProfileCellStylesHolder>(MockBehavior.Strict).Object, 
                        new Mock<IProfileCellLocale>(MockBehavior.Strict).Object, 
                        "1");

                    yield return new TestCaseData(
                        new Mock<IProfileCellView>(MockBehavior.Strict).Object, 
                        new Mock<IInteractorProfileCell>(MockBehavior.Strict).Object, 
                        null, 
                        new Mock<IProfileCellLocale>(MockBehavior.Strict).Object, 
                        "2");

                    yield return new TestCaseData(
                        new Mock<IProfileCellView>(MockBehavior.Strict).Object, 
                        new Mock<IInteractorProfileCell>(MockBehavior.Strict).Object, 
                        new Mock<IProfileCellStylesHolder>(MockBehavior.Strict).Object, 
                        null, 
                        "3");

                    yield return new TestCaseData(
                        new Mock<IProfileCellView>(MockBehavior.Strict).Object, 
                        new Mock<IInteractorProfileCell>(MockBehavior.Strict).Object, 
                        null, 
                        null, 
                        "4");
                }
            }
        }
    }
}
