using Moq;

using NUnit.Framework;

using SocialTrading.Locale.Modules;
using SocialTrading.DTO.Response.Post;
using SocialTrading.Vipers.Post.Interfaces.Social;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.Vipers.Post.Implementation.Social;

namespace MASTTests.Vipers.Post.Presenter
{
    [TestFixture]
    public class PresenterPostSocialTests
    {
        private Mock<IPost> _localeStrings;
        private Mock<IViewPostSocial> _viewMock;
        private Mock<IRouterPostSocial> _routerMock;
        private Mock<IInteractorPostSocial> _interactorMock;
        private Mock<IPostSocialStylesHolder> _stylesHolderMock;

        [SetUp]
        public void SetUp()
        {
            _viewMock = new Mock<IViewPostSocial>(MockBehavior.Strict);
            _routerMock = new Mock<IRouterPostSocial>(MockBehavior.Strict);
            _interactorMock = new Mock<IInteractorPostSocial>(MockBehavior.Strict);


            _viewMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterPostSocial>());
            _viewMock.Setup(f => f.SetConfig());

            _interactorMock.SetupSet(f => f.Presenter = It.IsAny<IPresenterPostSocial>());

            _localeStrings = new Mock<IPost>(MockBehavior.Strict);
            _stylesHolderMock = new Mock<IPostSocialStylesHolder>(MockBehavior.Strict);

            //config locale for presenter constructor
            _viewMock.Setup(f => f.SetShareText(It.IsAny<string>()));
            _localeStrings.SetupGet(f => f.ShareWith).Returns(It.IsAny<string>());
        }


        [Test(Author = "Oleh Marchenko")]
        public void SetLocale()
        {
            var presenter = new PresenterPostSocial(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _localeStrings.Object, _stylesHolderMock.Object);

            _viewMock.Verify(f => f.SetShareText(It.IsAny<string>()), Times.Once);
        }

        [Test(Author = "Oleh Marchenko")]
        public void SetSocialIsLiked()
        {
            _viewMock.Setup(f => f.SetLikeDrawable(It.IsAny<IButtonTheme>()));
            _viewMock.Setup(f => f.SetLikeText(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetCommentText(It.IsAny<string>()));
            
            _localeStrings.SetupGet(f => f.Like).Returns(It.IsAny<string>());
            _localeStrings.SetupGet(f => f.Comments).Returns(It.IsAny<string>());

            _stylesHolderMock.SetupGet(f => f.LikeTheme).Returns(It.IsAny<IButtonTheme>());

            var presenter = new PresenterPostSocial(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _localeStrings.Object, _stylesHolderMock.Object);
            presenter.SetSocial(new DataModelPost(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<float>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), true));

            _stylesHolderMock.VerifyGet(f => f.LikeTheme, Times.Once);
            _viewMock.Verify(f => f.SetLikeDrawable(It.IsAny<IButtonTheme>()), Times.Once);
            _viewMock.Verify(f => f.SetLikeText(It.IsAny<string>()), Times.Once);
            _viewMock.Verify(f => f.SetCommentText(It.IsAny<string>()), Times.Once);
        }

        [Test(Author = "Oleh Marchenko")]
        public void SetSocialIsNotLiked()
        {
            _viewMock.Setup(f => f.SetLikeDrawable(It.IsAny<IButtonTheme>()));
            _viewMock.Setup(f => f.SetLikeText(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetCommentText(It.IsAny<string>()));

            _localeStrings.SetupGet(f => f.Like).Returns(It.IsAny<string>());
            _localeStrings.SetupGet(f => f.Comments).Returns(It.IsAny<string>());

            _stylesHolderMock.SetupGet(f => f.NotLikeTheme).Returns(It.IsAny<IButtonTheme>());

            var presenter = new PresenterPostSocial(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _localeStrings.Object, _stylesHolderMock.Object);
            presenter.SetSocial(new DataModelPost(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<float>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), false));

            _stylesHolderMock.VerifyGet(f => f.NotLikeTheme, Times.Once);
            _viewMock.Verify(f => f.SetLikeDrawable(It.IsAny<IButtonTheme>()), Times.Once);
            _viewMock.Verify(f => f.SetLikeText(It.IsAny<string>()), Times.Once);
            _viewMock.Verify(f => f.SetCommentText(It.IsAny<string>()), Times.Once);
        }

        [Test(Author = "Oleh Marchenko")]
        public void LikeClick()
        {
            _viewMock.Setup(f => f.SetLikeDrawable(It.IsAny<IButtonTheme>()));
            _interactorMock.Setup(f => f.LikeClick());
            _stylesHolderMock.SetupGet(f => f.LikeTheme).Returns(It.IsAny<IButtonTheme>());

            var presenter = new PresenterPostSocial(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _localeStrings.Object, _stylesHolderMock.Object);

            presenter.LikeClick();

            _interactorMock.Verify(f => f.LikeClick(), Times.Once);
        }

        [Test(Author = "Oleh Marchenko")]
        public void CommentClick()
        {
            _routerMock.Setup(f => f.ToComments());
            var presenter = new PresenterPostSocial(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _localeStrings.Object, _stylesHolderMock.Object);

            presenter.CommentClick();

            _routerMock.Verify(f => f.ToComments(), Times.Once);
        }

        [Test, Author("Gerashchenko V.V.")]
        [TestCase(EPostSocialResponseStatus.Error)]
        [TestCase(EPostSocialResponseStatus.Unauthorized)]
        public void CheckLikedState_Errors(EPostSocialResponseStatus responseState)
        {
            _viewMock.Setup(f => f.ShowAlert(It.IsAny<string>(), It.IsAny<string>()));
            _localeStrings.SetupGet(f => f.LikeError).Returns(It.IsAny<string>());
            var presenter = new PresenterPostSocial(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _localeStrings.Object, _stylesHolderMock.Object);

            presenter.CheckLikedState(responseState);

            _viewMock.Verify(f => f.ShowAlert(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test, Author("Gerashchenko V.V.")]
        [TestCase(EPostSocialResponseStatus.Success)]
        public void CheckLikedState_Success(EPostSocialResponseStatus responseState)
        {
            _viewMock.Setup(f => f.SetLikeText(It.IsAny<string>()));
            _localeStrings.SetupGet(f => f.Like).Returns(It.IsAny<string>());
            _interactorMock.Setup(f => f.GetLikeCount()).Returns(It.IsAny<int>());
            _interactorMock.Setup(f => f.GetIsLiked()).Returns(true);
            _stylesHolderMock.SetupGet(f => f.LikeTheme).Returns(It.IsAny<IButtonTheme>());
            _viewMock.Setup(f => f.SetLikeDrawable(It.IsAny<IButtonTheme>()));

            var presenter = new PresenterPostSocial(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _localeStrings.Object, _stylesHolderMock.Object);

            presenter.CheckLikedState(responseState);

            _viewMock.Verify(f => f.SetLikeText(It.IsAny<string>()), Times.Once);
            _interactorMock.Verify(f => f.GetIsLiked(), Times.Once);
            _stylesHolderMock.VerifyGet(f => f.LikeTheme, Times.Once);
            _viewMock.Verify(f => f.SetLikeDrawable(It.IsAny<IButtonTheme>()), Times.Once);
        }

        [Test, Author("Gerashchenko V.V.")]
        [TestCase(EPostSocialResponseStatus.Success)]
        public void CheckLikedStateLiked(EPostSocialResponseStatus responseState)
        {
            _viewMock.Setup(f => f.SetLikeText(It.IsAny<string>()));
            _viewMock.Setup(f => f.SetLikeDrawable(It.IsAny<IButtonTheme>()));
            _interactorMock.Setup(f => f.GetLikeCount()).Returns(It.IsAny<int>());
            _interactorMock.Setup(f => f.GetIsLiked()).Returns(true);
            _localeStrings.SetupGet(f => f.Like).Returns(It.IsAny<string>());
            _stylesHolderMock.SetupGet(f => f.LikeTheme).Returns(It.IsAny<IButtonTheme>());

            var presenter = new PresenterPostSocial(_viewMock.Object, _interactorMock.Object, _routerMock.Object, _localeStrings.Object, _stylesHolderMock.Object);
            presenter.CheckLikedState(responseState);

            _viewMock.Verify(f => f.SetLikeText(It.IsAny<string>()), Times.Once);
            _interactorMock.Verify(f => f.GetLikeCount(), Times.Once);
            _interactorMock.Verify(f => f.GetIsLiked(), Times.Once);
             _stylesHolderMock.VerifyGet(f => f.LikeTheme, Times.Once);
            _viewMock.Verify(f => f.SetLikeDrawable(It.IsAny<IButtonTheme>()), Times.Once);
        }
    }
}
