using System;

using Moq;
using NUnit.Framework;

using SocialTrading.Locale;
using SocialTrading.Vipers.Post.ToolBar.Intarfaces;
using SocialTrading.Vipers.Post.ToolBar.Implementation;

namespace MASTTests.Vipers.Post
{
    [TestFixture, Author("Elena Pakhomova")]
    public class ToolBarPostsBroadcastTests
    {
        private Mock<IViewToolBarPosts> _viewMock;
        private Mock<IRouterToolBarPosts> _routerMock;
        private Mock<IToolBarPostsStylesHolder> _styleHolder;

        private IPresenterToolBarPosts _presenter;

        [SetUp]
        public void SetUp()
        {
            _viewMock = new Mock<IViewToolBarPosts>(MockBehavior.Strict);
            _routerMock = new Mock<IRouterToolBarPosts>(MockBehavior.Strict);
            _styleHolder = new Mock<IToolBarPostsStylesHolder>(MockBehavior.Default);
        }

        [Test]
        public void CtorNullViewTest()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _presenter = new PresenterToolBarPosts(null, _routerMock.Object, _styleHolder.Object, Localization.Lang);
            });
        }

        [Test]
        public void CtorNullRouterTest()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _presenter = new PresenterToolBarPosts(_viewMock.Object, null, _styleHolder.Object, Localization.Lang);
            });
        }

        [Test]
        public void CtorNullLocaleTest()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _presenter = new PresenterToolBarPosts(_viewMock.Object, _routerMock.Object, _styleHolder.Object, null);
            });
        }

        [Test]
        public void CtorSuccessTest()
        {
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterToolBarPosts>());

            _presenter = new PresenterToolBarPosts(_viewMock.Object, _routerMock.Object, _styleHolder.Object, Localization.Lang);

            _viewMock.VerifySet(f => f.Presenter = It.IsAny<IPresenterToolBarPosts>(), Times.Once);
        }

        [Test]
        public void CreatePostClickTest()
        {
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterToolBarPosts>());
            _routerMock.Setup(f => f.GoToCreatePost());

            _presenter = new PresenterToolBarPosts(_viewMock.Object, _routerMock.Object, _styleHolder.Object, Localization.Lang);
            _presenter.CreatePostClick();

            _routerMock.Verify(f => f.GoToCreatePost(), Times.Once());
        }

        [Test]
        public void MoreOptionsClickTest()
        {
            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterToolBarPosts>());
            _routerMock.Setup(f => f.GoToMoreOptions());

            _presenter = new PresenterToolBarPosts(_viewMock.Object, _routerMock.Object, _styleHolder.Object, Localization.Lang);
            _presenter.MoreClick();

            _routerMock.Verify(f => f.GoToMoreOptions(), Times.Once());
        }
    }
}
