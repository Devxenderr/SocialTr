using System;

using Moq;

using NUnit.Framework;

using SocialTrading.Tools;
using SocialTrading.Locale.Modules;
using SocialTrading.DTO.Response.Post;
using SocialTrading.Tools.Enumerations;
using SocialTrading.DTO.Response.Post.Interfaces;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.Post.Interfaces.Header;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.Vipers.Post.Implementation.Header;
using SocialTrading.DTO.Response.Post.ConstituentParts;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;

namespace MASTTests.Vipers.Post.Presenter
{
    [TestFixture]
    class PresenterHeaderTest
    {
        private IPostHeaderModel _postHeaderModel;

        private Mock<IPost> _postLocaleStrings;
        private Mock<IViewPostHeader> _viewMock;
        private Mock<IRouterPostHeader> _routerMock;
        private Mock<IInteractorPostHeader> _interactorMock;
        private Mock<IPostHeaderStylesHolder> _stylesHolderMock;
        private PostHeaderBrokerModel _postHeaderBrokerModel;

        [SetUp]
        public void SetUp()
        {
            _routerMock = new Mock<IRouterPostHeader>(MockBehavior.Strict);
            _viewMock = new Mock<IViewPostHeader>(MockBehavior.Strict);
            _interactorMock = new Mock<IInteractorPostHeader>(MockBehavior.Strict);
            _postHeaderModel = new DataModelPost(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<float>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<bool>());

            _postHeaderBrokerModel = new PostHeaderBrokerModel();

            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterPostHeader>());
            _viewMock.Setup(f => f.SetConfig());

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterPostHeader>());

            _postLocaleStrings = new Mock<IPost>(MockBehavior.Strict);
            _stylesHolderMock = new Mock<IPostHeaderStylesHolder>(MockBehavior.Strict);
        }

        [Test]
        public void PresenterInitNullViewTest()
        {
            Assert.Throws(typeof(ArgumentNullException), () =>
            {
                var presenter = new PresenterPostHeader(null, _interactorMock.Object, _routerMock.Object, _postLocaleStrings.Object, _stylesHolderMock.Object);
            });
        }

        [Test]
        public void PresenterInitNullInteractorTest()
        {
            Assert.Throws(typeof(ArgumentNullException), () =>
            {
                var presenter = new PresenterPostHeader(null, _interactorMock.Object, _routerMock.Object, _postLocaleStrings.Object, _stylesHolderMock.Object);
            });
        }

        [Test]
        public void PresenterInitNullRouterTest()
        {
            Assert.Throws(typeof(ArgumentNullException), () =>
            {
                var presenter = new PresenterPostHeader(null, _interactorMock.Object, _routerMock.Object, _postLocaleStrings.Object, _stylesHolderMock.Object);
            });
        }

        [Test]
        public void PresenterInitNullThemeStringsTest()
        {
            Assert.Throws(typeof(ArgumentNullException), () =>
            {
                var presenter = new PresenterPostHeader(null, _interactorMock.Object, _routerMock.Object, _postLocaleStrings.Object, _stylesHolderMock.Object);
            });
        }

        [Test]
        public void PostSetHeaderNoneWithAvatarTest()
        {
            _viewMock.Setup(f => f.SetName(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetAvatar(It.IsAny<string>()));
            _interactorMock.Setup(f => f.UpdateCreatedTime(It.IsAny<DateTime>()));

            _stylesHolderMock.SetupGet(f => f.FavoriteStateNone).Returns(It.IsAny<IImageButtonTheme>());

            var presenter = new PresenterPostHeader(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _postLocaleStrings.Object, _stylesHolderMock.Object);
        
            _postHeaderModel.CreatedAt = "123";
            _postHeaderModel.AuthorAvatar = "http://lorempixel.com/100/100";
            presenter.SetUserHeader(_postHeaderModel);

            _viewMock.Verify(f => f.SetName(It.IsAny<string>()), Times.Once);
            _viewMock.Verify(f => f.SetAvatar(It.IsAny<string>()), Times.Once);

            _interactorMock.Verify(f => f.UpdateCreatedTime(It.IsAny<DateTime>()), Times.Once);
        }

        [Test]
        public void PostSetHeaderWithoutAvatarTest()
        {            
            _viewMock.Setup(f => f.SetName(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetAvatar(It.IsAny<string>()));
            _interactorMock.Setup(f => f.UpdateCreatedTime(It.IsAny<DateTime>()));

            _stylesHolderMock.SetupGet(f => f.FavoriteStateNone).Returns(It.IsAny<IImageButtonTheme>());

            var presenter = new PresenterPostHeader(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _postLocaleStrings.Object, _stylesHolderMock.Object);

            _postHeaderModel.CreatedAt = "123";
            presenter.SetUserHeader(_postHeaderModel);

            _viewMock.Verify(f => f.SetName(It.IsAny<string>()), Times.Once);
            _viewMock.Verify(f => f.SetAvatar(It.IsAny<string>()), Times.Never);

            _interactorMock.Verify(f => f.UpdateCreatedTime(It.IsAny<DateTime>()), Times.Once);
        }

        [Test]
        public void PostSetBrokerFieldsDownNegativeTest()
        {
            _viewMock.Setup(f => f.SetDifference(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetCurrentPrice(It.IsAny<string>(), It.IsAny<int>()));
            _viewMock.Setup(f => f.SetCurrentPriceImg(It.IsAny<IImageViewTheme>()));
            _viewMock.Setup(f => f.SetDifferenceValue(It.IsAny<ITextViewTheme>()));
            _postLocaleStrings.SetupGet(f => f.Pips).Returns(It.IsAny<string>());
            _stylesHolderMock.SetupGet(f => f.CurrentPriceImgDown).Returns(It.IsAny<IImageViewTheme>());
            _stylesHolderMock.SetupGet(f => f.DifferenceValueNegative).Returns(It.IsAny<ITextViewTheme>());

            _interactorMock.Setup(f => f.GetRepository().LangPost.OptionsHeader).Returns(It.IsAny<Func<string, string, string>>());

            var presenter = new PresenterPostHeader(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _postLocaleStrings.Object, _stylesHolderMock.Object);

            _postHeaderBrokerModel.IsCurrentPriceIncreasing = false;
            _postHeaderBrokerModel.IsDifferencePositive = false;
            presenter.SetBrokerFields(_postHeaderBrokerModel, It.IsAny<int>());

            _viewMock.Verify(f => f.SetDifference(It.IsAny<string>()), Times.Once);
            _viewMock.Verify(f => f.SetCurrentPrice(It.IsAny<string>(), It.IsAny<int>()), Times.Once);
            _viewMock.Verify(f => f.SetCurrentPriceImg(It.IsAny<IImageViewTheme>()), Times.Once);
            _viewMock.Verify(f => f.SetDifferenceValue(It.IsAny<ITextViewTheme>()), Times.Once);
            _stylesHolderMock.VerifyGet(f => f.CurrentPriceImgDown, Times.Once);
            _stylesHolderMock.VerifyGet(f => f.DifferenceValueNegative, Times.Once);
        }

        [Test]
        public void PostSetBrokerFieldsUpPositiveTest()
        {
            _viewMock.Setup(f => f.SetDifference(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetCurrentPrice(It.IsAny<string>(), It.IsAny<int>()));
            _viewMock.Setup(f => f.SetCurrentPriceImg(It.IsAny<IImageViewTheme>()));
            _viewMock.Setup(f => f.SetDifferenceValue(It.IsAny<ITextViewTheme>()));
            _postLocaleStrings.SetupGet(f => f.Pips).Returns(It.IsAny<string>());
            _stylesHolderMock.SetupGet(f => f.CurrentPriceImgUp).Returns(It.IsAny<IImageViewTheme>());
            _stylesHolderMock.SetupGet(f => f.DifferenceValuePositive).Returns(It.IsAny<ITextViewTheme>());

            _interactorMock.Setup(f => f.GetRepository().LangPost.OptionsHeader).Returns(It.IsAny<Func<string, string, string>>());
            var presenter = new PresenterPostHeader(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _postLocaleStrings.Object, _stylesHolderMock.Object);
            _postHeaderBrokerModel.IsCurrentPriceIncreasing = true;
            _postHeaderBrokerModel.IsDifferencePositive = true;
            presenter.SetBrokerFields(_postHeaderBrokerModel, It.IsAny<int>());

            _viewMock.Verify(f => f.SetDifference(It.IsAny<string>()), Times.Once);
            _viewMock.Verify(f => f.SetCurrentPrice(It.IsAny<string>(), It.IsAny<int>()), Times.Once);

            _viewMock.Verify(f => f.SetCurrentPriceImg(It.IsAny<IImageViewTheme>()), Times.Once);
            _viewMock.Verify(f => f.SetDifferenceValue(It.IsAny<ITextViewTheme>()), Times.Once);
            _stylesHolderMock.VerifyGet(f => f.CurrentPriceImgUp, Times.Once);
            _stylesHolderMock.VerifyGet(f => f.DifferenceValuePositive, Times.Once);
        }

        [Test]
        public void PostSetBrokerFieldsDownPositiveTest()
        {
            _viewMock.Setup(f => f.SetDifference(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetCurrentPrice(It.IsAny<string>(), It.IsAny<int>()));
            _viewMock.Setup(f => f.SetCurrentPriceImg(It.IsAny<IImageViewTheme>()));
            _viewMock.Setup(f => f.SetDifferenceValue(It.IsAny<ITextViewTheme>()));
            _postLocaleStrings.SetupGet(f => f.Pips).Returns(It.IsAny<string>());
            _stylesHolderMock.SetupGet(f => f.CurrentPriceImgDown).Returns(It.IsAny<IImageViewTheme>());
            _stylesHolderMock.SetupGet(f => f.DifferenceValuePositive).Returns(It.IsAny<ITextViewTheme>());

            _interactorMock.Setup(f => f.GetRepository().LangPost.OptionsHeader).Returns(It.IsAny<Func<string, string, string>>());
            var presenter = new PresenterPostHeader(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _postLocaleStrings.Object, _stylesHolderMock.Object);
            _postHeaderBrokerModel.IsCurrentPriceIncreasing = false;
            _postHeaderBrokerModel.IsDifferencePositive = true;
            presenter.SetBrokerFields(_postHeaderBrokerModel, It.IsAny<int>());

            _viewMock.Verify(f => f.SetDifference(It.IsAny<string>()), Times.Once);
            _viewMock.Verify(f => f.SetCurrentPrice(It.IsAny<string>(), It.IsAny<int>()), Times.Once);

            _viewMock.Verify(f => f.SetCurrentPriceImg(It.IsAny<IImageViewTheme>()), Times.Once);
            _viewMock.Verify(f => f.SetDifferenceValue(It.IsAny<ITextViewTheme>()), Times.Once);
            _stylesHolderMock.VerifyGet(f => f.CurrentPriceImgDown, Times.Once);
            _stylesHolderMock.VerifyGet(f => f.DifferenceValuePositive, Times.Once);
        }

        [Test]
        public void PostSetBrokerFieldsUpNegativeTest()
        {
            _viewMock.Setup(f => f.SetDifference(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetCurrentPrice(It.IsAny<string>(), It.IsAny<int>()));
            _viewMock.Setup(f => f.SetCurrentPriceImg(It.IsAny<IImageViewTheme>()));
            _viewMock.Setup(f => f.SetDifferenceValue(It.IsAny<ITextViewTheme>()));
            _postLocaleStrings.SetupGet(f => f.Pips).Returns(It.IsAny<string>());
            _stylesHolderMock.SetupGet(f => f.CurrentPriceImgUp).Returns(It.IsAny<IImageViewTheme>());
            _stylesHolderMock.SetupGet(f => f.DifferenceValueNegative).Returns(It.IsAny<ITextViewTheme>());

            _interactorMock.Setup(f => f.GetRepository().LangPost.OptionsHeader).Returns(It.IsAny<Func<string, string, string>>());
            var presenter = new PresenterPostHeader(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _postLocaleStrings.Object, _stylesHolderMock.Object);
            _postHeaderBrokerModel.IsCurrentPriceIncreasing = true;
            _postHeaderBrokerModel.IsDifferencePositive = false;
            presenter.SetBrokerFields(_postHeaderBrokerModel, It.IsAny<int>());

            _viewMock.Verify(f => f.SetDifference(It.IsAny<string>()), Times.Once);
            _viewMock.Verify(f => f.SetCurrentPrice(It.IsAny<string>(), It.IsAny<int>()), Times.Once);
            _viewMock.Verify(f => f.SetCurrentPriceImg(It.IsAny<IImageViewTheme>()), Times.Once);
            _viewMock.Verify(f => f.SetDifferenceValue(It.IsAny<ITextViewTheme>()), Times.Once);
            _stylesHolderMock.VerifyGet(f => f.CurrentPriceImgUp, Times.Once);
            _stylesHolderMock.VerifyGet(f => f.DifferenceValueNegative, Times.Once);
        }

        [Test]
        public void PostProfileClickTest()
        {
            _routerMock.Setup(f => f.ToProfile());

            var presenter = new PresenterPostHeader(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _postLocaleStrings.Object, _stylesHolderMock.Object);
            presenter.ProfileClick();

            _routerMock.Verify(f => f.ToProfile(), Times.Once);
        }


        [Test]
        public void PostFavoriteNoneClickTest()
        {
            _interactorMock.Setup(f => f.FavoriteClick());
            _viewMock.Setup(f => f.SetFavoriteState(false, It.IsAny<IImageButtonTheme>()));

            _stylesHolderMock.SetupGet(f => f.FavoriteStateNone).Returns(It.IsAny<IImageButtonTheme>());

            var presenter = new PresenterPostHeader(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _postLocaleStrings.Object, _stylesHolderMock.Object);
            presenter.FavoriteClick(false);

            _interactorMock.Verify(f => f.FavoriteClick(), Times.Once);
            _viewMock.Verify(f => f.SetFavoriteState(false, It.IsAny<IImageButtonTheme>()), Times.Once);

            _stylesHolderMock.VerifyGet(f => f.FavoriteStateNone, Times.Once);
        }

        [Test]
        public void PostFavoriteActiveClickTest()
        {
            _interactorMock.Setup(f => f.FavoriteClick());
            _viewMock.Setup(f => f.SetFavoriteState(true, It.IsAny<IImageButtonTheme>()));

            _stylesHolderMock.SetupGet(f => f.FavoriteStateActive).Returns(It.IsAny<IImageButtonTheme>());

            var presenter = new PresenterPostHeader(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _postLocaleStrings.Object, _stylesHolderMock.Object);
            presenter.FavoriteClick(true);

            _interactorMock.Verify(f => f.FavoriteClick(), Times.Once);
            _viewMock.Verify(f => f.SetFavoriteState(true, It.IsAny<IImageButtonTheme>()), Times.Once);
            _stylesHolderMock.VerifyGet(f => f.FavoriteStateActive, Times.Once);
        }

        [Test]
        public void PostOptionsClickTest()
        {
            _viewMock.Setup(f => f.OptionsDialogShow(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));

            _postLocaleStrings.SetupGet(f => f.OptionsHeader).Returns(It.IsAny<string>());
            _postLocaleStrings.SetupGet(f => f.DeletePost).Returns(It.IsAny<string>());
            _postLocaleStrings.SetupGet(f => f.Edit).Returns(It.IsAny<string>());

            _interactorMock.Setup(f => f.GetRepository().LangPost.OptionsHeader).Returns(It.IsAny<Func<string, string, string>>());
            var presenter = new PresenterPostHeader(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _postLocaleStrings.Object, _stylesHolderMock.Object);
            presenter.OptionsClick();

            _viewMock.Verify(f => f.OptionsDialogShow(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void PostDeleteClickTest()
        {
            _viewMock.Setup(f => f.ShowDeletingDialog(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));

            _postLocaleStrings.SetupGet(f => f.DeletePostMessage).Returns(It.IsAny<string>());
            _postLocaleStrings.SetupGet(f => f.DeletePostTitle).Returns(It.IsAny<string>());
            _postLocaleStrings.SetupGet(f => f.Yes).Returns(It.IsAny<string>());
            _postLocaleStrings.SetupGet(f => f.No).Returns(It.IsAny<string>());

            _interactorMock.Setup(f => f.GetRepository().LangPost.DeletePostMessage).Returns(It.IsAny<Func<string, string>>());
            var presenter = new PresenterPostHeader(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _postLocaleStrings.Object, _stylesHolderMock.Object);
            presenter.DeleteClick();

            _viewMock.Verify(f => f.ShowDeletingDialog(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void PostConfirmDeleteClickTest()
        {
            _interactorMock.Setup(f => f.DeletePostClick());

            var presenter = new PresenterPostHeader(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _postLocaleStrings.Object, _stylesHolderMock.Object);
            presenter.ConfirmDeleteClick();

            _interactorMock.Verify(f => f.DeletePostClick(), Times.Once);
        }

        [Test]
        public void GetRepositoryTest()
        {
            _interactorMock.Setup(f => f.GetRepository()).Returns(It.IsAny<IRepositoryPost>());

            var presenter = new PresenterPostHeader(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _postLocaleStrings.Object, _stylesHolderMock.Object);

            presenter.GetRepository();

            _interactorMock.Verify(f => f.GetRepository(), Times.Once);
        }

        [Test]
        public void PostSetFavoriteStateActiveTest()
        {
            _viewMock.Setup(f => f.SetFavoriteState(true, It.IsAny<IImageButtonTheme>()));
            _stylesHolderMock.SetupGet(f => f.FavoriteStateActive).Returns(It.IsAny<IImageButtonTheme>());

            var presenter = new PresenterPostHeader(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _postLocaleStrings.Object, _stylesHolderMock.Object);
            presenter.SetQuoteFavoriteState(true);

            _viewMock.Verify(f => f.SetFavoriteState(true, It.IsAny<IImageButtonTheme>()), Times.Once);
            _stylesHolderMock.VerifyGet(f => f.FavoriteStateActive, Times.Once);
        }


        [Test]
        public void PostSetFavoriteStateNoneTest()
        {
            _viewMock.Setup(f => f.SetFavoriteState(false, It.IsAny<IImageButtonTheme>()));
            _stylesHolderMock.SetupGet(f => f.FavoriteStateNone).Returns(It.IsAny<IImageButtonTheme>());

            var presenter = new PresenterPostHeader(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _postLocaleStrings.Object, _stylesHolderMock.Object);
            presenter.SetQuoteFavoriteState(false);

            _viewMock.Verify(f => f.SetFavoriteState(false, It.IsAny<IImageButtonTheme>()), Times.Once);
            _stylesHolderMock.VerifyGet(f => f.FavoriteStateNone, Times.Once);
        }
    }
}
