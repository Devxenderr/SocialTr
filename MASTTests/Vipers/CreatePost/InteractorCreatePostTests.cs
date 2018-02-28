using Moq;

using NUnit.Framework;

using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.CreatePost.Interfaces;
using SocialTrading.Vipers.Controllers.Interfaces;
using SocialTrading.Vipers.CreatePost.Implementation;

namespace MASTTests.Vipers.CreatePost
{
    [TestFixture(Author = Authors.Pakhomova)]
    public class InteractorCreatePostTests
    {
        private IInteractorCreatePost _interactor;
        private Mock<ICreatePostController> _controllerMock;
        private Mock<IPresenterCreatePost> _presenterMock;

        [SetUp]
        public void SetUp()
        {
            _controllerMock = new Mock<ICreatePostController>(MockBehavior.Strict);
            _interactor = new InteractorCreatePost(_controllerMock.Object, null, null);
            _presenterMock = new Mock<IPresenterCreatePost>(MockBehavior.Strict);
            _interactor.Presenter = _presenterMock.Object;
        }

        [Test]
        public void CommentInputStateFailTest()
        {
            _presenterMock.Setup(f => f.CommentState(EState.Fail));

            _interactor.CommentInput(false, true);

            _presenterMock.Verify(f => f.CommentState(EState.Fail));
        }

        [Test]
        public void CommentInputStateSuccessTest()
        {
            _presenterMock.Setup(f => f.CommentState(EState.None));

            _interactor.CommentInput(true, true);

            _presenterMock.Verify(f => f.CommentState(EState.None));
        }

        [TestCase(EBuySell.Sell, TestName = "BuySellSelectedSellTest")]
        [TestCase(EBuySell.Buy, TestName = "BuySellSelectedBuyTest")]
        public void BuySellSelectedSuccessTest(EBuySell buySell)
        {
            _presenterMock.Setup(f => f.BuySellState(EState.None));

            _interactor.BuySellSelected(buySell);

            _presenterMock.Verify(f => f.BuySellState(EState.None));
        }

        [TestCase(EBuySell.None, TestName = "BuySellSelectedNoneTest")]
        public void BuySellSelectedFailTest(EBuySell buySell)
        {
            _presenterMock.Setup(f => f.BuySellState(EState.Fail));

            _interactor.BuySellSelected(buySell);

            _presenterMock.Verify(f => f.BuySellState(EState.Fail));
        }

        [TestCase(null, TestName = "ForecastStringNullTest")]
        [TestCase("", TestName = "ForecastStringEmptyTest")]
        [TestCase(" ", TestName = "ForecastStringSpaceTest")]
        public void ForecastTimeSelectedStringFailTest(string time)
        {
            _presenterMock.Setup(f => f.ForecastTimeState(EState.Fail));

            _interactor.ForecastTimeSelected(time);

            _presenterMock.Verify(f => f.ForecastTimeState(EState.Fail));
        }

        [TestCase("20-05-2017 22:41", TestName = "ForecastStringSuccessTest")]
        public void ForecastTimeSelectedStringSuccessTest(string time)
        {
            _presenterMock.Setup(f => f.ForecastTimeState(EState.None));

            _interactor.ForecastTimeSelected(time);

            _presenterMock.Verify(f => f.ForecastTimeState(EState.None));
        }

        [TestCase(EForecastTime.Minute15, TestName = "ForecastStringMinute15Test")]
        [TestCase(EForecastTime.Minute30, TestName = "ForecastStringMinute30Test")]
        [TestCase(EForecastTime.Hour1, TestName = "ForecastStringHour1Test")]
        [TestCase(EForecastTime.Hour4, TestName = "ForecastStringHour4Test")]
        [TestCase(EForecastTime.Hour8, TestName = "ForecastStringHour8Test")]
        [TestCase(EForecastTime.Hour24, TestName = "ForecastStringHour24Test")]
        [TestCase(EForecastTime.Week1, TestName = "ForecastStringWeek1Test")]
        [TestCase(EForecastTime.Other, TestName = "ForecastStringOtherTest")]
        public void ForecastTimeSelectedEnumSuccessTest(EForecastTime time)
        {
            _presenterMock.Setup(f => f.ForecastTimeState(EState.None));

            _interactor.ForecastTimeSelected(time);

            _presenterMock.Verify(f => f.ForecastTimeState(EState.None));
        }

        [TestCase(EForecastTime.None, TestName = "ForecastStringNoneTest")]
        public void ForecastTimeSelectedEnumFailTest(EForecastTime time)
        {
            _presenterMock.Setup(f => f.ForecastTimeState(EState.Fail));

            _interactor.ForecastTimeSelected(time);

            _presenterMock.Verify(f => f.ForecastTimeState(EState.Fail));
        }

        [TestCase("AUDHUF", TestName = "ToolSelectedSuccessTest")]
        public void ToolSelectedSuccessTest(string tool)
        {
            _presenterMock.Setup(f => f.ToolState(EState.None));

            _interactor.ToolSelected(tool);

            _presenterMock.Verify(f => f.ToolState(EState.None));
        }

        [TestCase("", TestName = "ToolSelectedEmptyTest")]
        [TestCase(" ", TestName = "ToolSelectedSpaceTest")]
        [TestCase(null, TestName = "ToolSelectedNullTest")]
        public void ToolSelectedFailTest(string tool)
        {
            _presenterMock.Setup(f => f.ToolState(EState.Fail));

            _interactor.ToolSelected(tool);

            _presenterMock.Verify(f => f.ToolState(EState.Fail));
        }

        [TestCase(EAccessMode.Private, TestName = "AccessModeSelectedPrivateTest")]
        [TestCase(EAccessMode.Public, TestName = "AccessModeSelectedPublicTest")]
        public void AccessModeSelectedSuccessTest(EAccessMode access)
        {
            _presenterMock.Setup(f => f.AccessModeState(EState.None));

            _interactor.AccessModeSelected(access);

            _presenterMock.Verify(f => f.AccessModeState(EState.None));
        }

        [TestCase(EAccessMode.None, TestName = "AccessModeSelectedNoneTest")]
        public void AccessModeSelectedFailTest(EAccessMode access)
        {
            _presenterMock.Setup(f => f.AccessModeState(EState.Fail));

            _interactor.AccessModeSelected(access);

            _presenterMock.Setup(f => f.AccessModeState(EState.Fail));
        }
    }
}

