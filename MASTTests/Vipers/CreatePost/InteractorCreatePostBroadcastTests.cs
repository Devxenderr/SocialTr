using Moq;

using System.Reflection;

using NUnit.Framework;

using SocialTrading.DTO.Request;
using SocialTrading.Vipers.Entity;
using SocialTrading.DTO.Response.RA;
using SocialTrading.DTO.Request.Posts;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.CreatePost.Interfaces;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.Controllers.Interfaces;
using SocialTrading.Vipers.CreatePost.Implementation;

namespace MASTTests.Vipers.CreatePost
{
    [TestFixture, Author("Elena Pakhomova")]
    public class InteractorCreatePostBroadcastTests
    {
        private Mock<IPresenterCreatePost> _presenterMock;
        private Mock<ICreatePostController> _connectionSenderMock;
        private Mock<IRepositoryCreatePost> _repositoryMock;
        private Mock<IRepositoryUserAuth> _repositoryUserMock;

        private IInteractorCreatePost _interactor;

        [SetUp]
        public void SetUp()
        {
            _presenterMock = new Mock<IPresenterCreatePost>(MockBehavior.Strict);
            _connectionSenderMock = new Mock<ICreatePostController>(MockBehavior.Strict);
            _repositoryMock = new Mock<IRepositoryCreatePost>(MockBehavior.Strict);
            _repositoryUserMock = new Mock<IRepositoryUserAuth>(MockBehavior.Strict);

            _interactor = new InteractorCreatePost(_connectionSenderMock.Object, _repositoryMock.Object, _repositoryUserMock.Object)
            {
                Presenter = _presenterMock.Object
            };
        }

        [Test]
        public void ForecastTimeSelectedEnumTest()
        {
            _presenterMock.Setup(f => f.ForecastTimeState(It.IsAny<EState>()));

            _interactor.ForecastTimeSelected(It.IsAny<EForecastTime>());

            _presenterMock.Verify(f => f.ForecastTimeState(It.IsAny<EState>()), Times.Once);
        }

        [Test]
        public void ForecastTimeSelectedStringTest()
        {
            _presenterMock.Setup(f => f.ForecastTimeState(It.IsAny<EState>()));

            _interactor.ForecastTimeSelected(It.IsAny<string>());

            _presenterMock.Verify(f => f.ForecastTimeState(It.IsAny<EState>()), Times.Once);
        }

        [Test]
        public void ToolSelectedTest()
        {
            _presenterMock.Setup(f => f.ToolState(It.IsAny<EState>()));

            _interactor.ToolSelected(It.IsAny<string>());

            _presenterMock.Verify(f => f.ToolState(It.IsAny<EState>()), Times.Once);
        }

        [Test]
        public void AccessModeSelectedTest()
        {
            _presenterMock.Setup(f => f.AccessModeState(It.IsAny<EState>()));

            _interactor.AccessModeSelected(It.IsAny<EAccessMode>());

            _presenterMock.Verify(f => f.AccessModeState(It.IsAny<EState>()), Times.Once);
        }

        [Test]
        public void BuySellSelectedTest()
        {
            _presenterMock.Setup(f => f.BuySellState(It.IsAny<EState>()));

            _interactor.BuySellSelected(It.IsAny<EBuySell>());

            _presenterMock.Verify(f => f.BuySellState(It.IsAny<EState>()), Times.Once);
        }

        [Test]
        public void SetConfigSetAvatarTest()
        {
            _repositoryUserMock.SetupGet(f => f.AuthData).Returns(new UserAuthData(new DataModelAuth(
                "111", "email", "tvma@i.ua", "tvma@i.ua", null, "2017-11-14T09:30:26.893Z", "https://pbs.twimg.com/profile_images/901947348699545601/hqRMHITj.jpg",
                null, "2017-11-17T08:43:17.669Z", "Jon", "Snow", null, "EN", false, 1510651826, 1510908197, 0, null)));

            _presenterMock.Setup(f => f.SetUserAvatar(It.IsAny<string>()));
            _presenterMock.Setup(f => f.SetUserName(It.IsAny<string>()));

            _interactor.SetConfig();

            _presenterMock.Verify(f => f.SetUserAvatar(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void SetConfigSetNameTest()
        {
            _repositoryUserMock.SetupGet(f => f.AuthData).Returns(new UserAuthData(new DataModelAuth(
                "111", "email", "tvma@i.ua", "tvma@i.ua", null, "2017-11-14T09:30:26.893Z", "https://pbs.twimg.com/profile_images/901947348699545601/hqRMHITj.jpg",
                null, "2017-11-17T08:43:17.669Z", "Jon", "Snow", null, "EN", false, 1510651826, 1510908197, 0, null)));

            _presenterMock.Setup(f => f.SetUserAvatar(It.IsAny<string>()));
            _presenterMock.Setup(f => f.SetUserName(It.IsAny<string>()));

            _interactor.SetConfig();

            _presenterMock.Verify(f => f.SetUserName(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void CommentInputTest()
        {
            _presenterMock.Setup(f => f.CommentState(It.IsAny<EState>()));

            _interactor.CommentInput(It.IsAny<bool>());

            _presenterMock.Verify(f => f.CommentState(It.IsAny<EState>()), Times.Once);
        }

        [TestCase(null, EBuySell.None, TestName = "Returns default string")]
        [TestCase("AUD/CAD", EBuySell.Buy, TestName = "Returns price")]
        public void ReadyToSetPriceTest(string tool, EBuySell recommend)
        {
            _presenterMock.Setup(f => f.SetPrice(It.IsAny<string>()));
            _repositoryMock.Setup(f => f.LangCreatePost.PriceLabel).Returns(It.IsAny<string>());

            _interactor.ReadyToSetPrice(It.IsAny<string>(), It.IsAny<EBuySell>());

            _presenterMock.Verify(f => f.SetPrice(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void SaveAttachedImageTest()
        {
            _repositoryMock.SetupSet(f => f.AttachmentImage = It.IsAny<string>());

            _interactor.SaveAttachedImage("some image");

            _repositoryMock.VerifySet(f => f.AttachmentImage = It.IsAny<string>(), Times.Once);
        }

        [Test]
        public void LoadAttachedImageTest()
        {
            _repositoryMock.SetupGet(f => f.AttachmentImage).Returns(It.IsAny<string>());

            _interactor.LoadAttachedImage();

            _repositoryMock.VerifyGet(f => f.AttachmentImage, Times.Once);
        }

        [TestCase(null)]
        [TestCase("")]
        public void SaveSelectedToolNullOrEmptyTest(string tool)
        {
            _interactor.SaveSelectedTool(It.IsAny<string>());
        }

        [Test]
        public void SaveSelectedToolTest()
        {
            _repositoryMock.SetupSet(f => f.SelectedTool = It.IsAny<string>());

            _interactor.SaveSelectedTool("AUD/CAD");

            _repositoryMock.VerifySet(f => f.SelectedTool = It.IsAny<string>(), Times.Once);
        }

        [Test]
        public void DisposeRepositoryCreatePostTest()
        {
            _repositoryMock.Setup(f => f.ConfigRepositoryCreatePost());

            _interactor.DisposeRepositoryCreatePost();

            _repositoryMock.Verify(f => f.ConfigRepositoryCreatePost(), Times.Once);
        }

        [Test]
        public void SaveDataTest()
        {
            _repositoryMock.SetupSet(f => f.CreatePostStrings = It.IsAny<CreatePostStrings>());

            _interactor.SaveData(It.IsAny<CreatePostStrings>());

            _repositoryMock.VerifySet(f => f.CreatePostStrings = It.IsAny<CreatePostStrings>(), Times.Once);
        }

        [Test]
        public void LoadDataTest()
        {
            _repositoryMock.SetupGet(f => f.CreatePostStrings).Returns(It.IsAny<CreatePostStrings>());

            _interactor.LoadData();

            _repositoryMock.VerifyGet(f => f.CreatePostStrings, Times.Once);
        }

        [TestCase(null, EBuySell.None, EAccessMode.None, null, null, null, null)]
        [TestCase("", EBuySell.None, EAccessMode.None, "", "", "", "")]
        [TestCase(null, EBuySell.Buy, EAccessMode.Private, "AUD/CAD", "20-05-2017 22:41", "cool content", "image123")]
        [TestCase("", EBuySell.Buy, EAccessMode.Private, "AUD/CAD", "20-05-2017 22:41", "cool content", "image123")]
        [TestCase("12.3", EBuySell.None, EAccessMode.Private, "AUD/CAD", "20-05-2017 22:41", "cool content", "image123")]
        [TestCase("12.3", EBuySell.Buy, EAccessMode.None, "AUD/CAD", "20-05-2017 22:41", "cool content", "image123")]
        [TestCase("12.3", EBuySell.Buy, EAccessMode.Private, null, "20-05-2017 22:41", "cool content", "image123")]
        [TestCase("12.3", EBuySell.Buy, EAccessMode.Private, "", "20-05-2017 22:41", "cool content", "image123")]
        [TestCase("12.3", EBuySell.Buy, EAccessMode.Private, "AUD/CAD", null, "cool content", "image123")]
        [TestCase("12.3", EBuySell.Buy, EAccessMode.Private, "AUD/CAD", "", "cool content", "image123")]
        public void AddPostForecastStringNegativeTest(string price, EBuySell recommend, EAccessMode access, string tool, string forecast, string comment, string img)
        {
            _presenterMock.Setup(f => f.AccessModeState(It.IsAny<EState>()));
            _presenterMock.Setup(f => f.ForecastTimeState(It.IsAny<EState>()));
            _presenterMock.Setup(f => f.ToolState(It.IsAny<EState>()));
            _presenterMock.Setup(f => f.CommentState(It.IsAny<EState>()));
            _presenterMock.Setup(f => f.BuySellState(It.IsAny<EState>()));
            _repositoryMock.Setup(f => f.LangCreatePost.PriceLabel).Returns(It.IsAny<string>());
            _repositoryMock.Setup(f => f.LangCreatePost.ToolsButton).Returns(It.IsAny<string>());

            _interactor.AddPost(price, recommend, access, tool, forecast, comment, img);
        }

        [TestCase("12.3", EBuySell.Buy, EAccessMode.Private, "AUD/CAD", "2017-05-20 22:41", "cool content", null)]
        [TestCase("12.3", EBuySell.Buy, EAccessMode.Private, "AUD/CAD", "2017-05-20 22:41", "cool content", "")]
        [TestCase("12.3", EBuySell.Buy, EAccessMode.Private, "AUD/CAD", "2017-05-20 22:41", "cool content", "image123")]
        public void AddPostForecastStringPositiveTest(string price, EBuySell recommend, EAccessMode access, string tool, string forecast, string comment, string img)
        {
            _presenterMock.Setup(f => f.AccessModeState(It.IsAny<EState>()));
            _presenterMock.Setup(f => f.ForecastTimeState(It.IsAny<EState>()));
            _presenterMock.Setup(f => f.ToolState(It.IsAny<EState>()));
            _presenterMock.Setup(f => f.CommentState(It.IsAny<EState>()));
            _presenterMock.Setup(f => f.BuySellState(It.IsAny<EState>()));
            _repositoryMock.Setup(f => f.LangCreatePost.PriceLabel).Returns(It.IsAny<string>());
            _repositoryMock.Setup(f => f.LangCreatePost.ToolsButton).Returns(It.IsAny<string>());

            foreach (var item in typeof(InteractorCreatePost).GetRuntimeFields())
            {
                if (item.Name.Equals("_selectedTool"))
                {
                    item.SetValue(_interactor, "AUD/CAD");
                }
            }

            _connectionSenderMock.Setup(f => f.Send(It.IsAny<CreatePostRequestModel>()));

            _interactor.AddPost(price, recommend, access, tool, forecast, comment, img);
            _connectionSenderMock.Verify(f => f.Send(It.IsAny<CreatePostRequestModel>()));
        }

        [TestCase("", EBuySell.None, EAccessMode.Private, "", "", "cool content", null)]
        [TestCase("", EBuySell.None, EAccessMode.Private, "", "", "cool content", "")]
        [TestCase("", EBuySell.None, EAccessMode.Private, "", "", "cool content", null)]
        [TestCase("", EBuySell.None, EAccessMode.Private, "", "", "cool content", "")]
        [TestCase("", EBuySell.None, EAccessMode.Private, "", "", "cool content", "image123")]
        public void AddSimplePostPositiveTest(string price, EBuySell recommend, EAccessMode access, string tool, string forecast, string comment, string img)
        {
            _repositoryMock.Setup(f => f.LangCreatePost.PriceLabel).Returns(It.IsAny<string>());
            _repositoryMock.Setup(f => f.LangCreatePost.ToolsButton).Returns(It.IsAny<string>());
            
            _connectionSenderMock.Setup(f => f.Send(It.IsAny<CreateSimplePostRequestModel>()));

            _interactor.AddPost(price, recommend, access, tool, forecast, comment, img);
        }

        [TestCase("", EBuySell.None, EAccessMode.Private, "", "", "", "")]
        [TestCase("", EBuySell.None, EAccessMode.Private, "", "", null, "")]
        [TestCase("", EBuySell.None, EAccessMode.Private, "", "", "", null)]
        [TestCase("", EBuySell.None, EAccessMode.Private, "", "", null, null)]
        public void AddSimplePostNegativeTest(string price, EBuySell recommend, EAccessMode access, string tool, string forecast, string comment, string img)
        {
            _repositoryMock.Setup(f => f.LangCreatePost.PriceLabel).Returns(It.IsAny<string>());
            _repositoryMock.Setup(f => f.LangCreatePost.ToolsButton).Returns(It.IsAny<string>());
            _presenterMock.Setup(f => f.CommentState(It.IsAny<EState>()));

            _connectionSenderMock.Setup(f => f.Send(It.IsAny<CreateSimplePostRequestModel>()));

            _interactor.AddPost(price, recommend, access, tool, forecast, comment, img);
        }
    }
}
