using NUnit.Framework;

using SocialTrading.Service;
using SocialTrading.Service.Interfaces.Repository;

namespace MASTTests.Repository
{
    [TestFixture]
    public class RepositoryControllerTests
    {
        [Test]
        public void CtorTest()
        {
            var repositoryController = RepositoryController.GetInstance();
            Assert.IsInstanceOf<RepositoryController>(repositoryController);
        }

        [Test]
        public void RepositoryQcTest()
        {
            var repositoryController = RepositoryController.GetInstance();
            Assert.IsInstanceOf<IRepositoryQc>(repositoryController.RepoQc);
        }

        [Test]
        public void RepositoryThemesTest()
        {
            var repositoryController = RepositoryController.GetInstance();
            Assert.IsInstanceOf<IRepositoryThemes>(repositoryController.RepositoryThemes);
        }

        [Test]
        public void RepositoryUserAuthTest()
        {
            var repositoryController = RepositoryController.GetInstance();
            Assert.IsInstanceOf<IRepositoryUserAuth>(repositoryController.RepositoryUserAuth);
        }

        [Test]
        public void RepositoryRATest()
        {
            var repositoryController = RepositoryController.GetInstance();
            Assert.IsInstanceOf<IRepositoryRA>(repositoryController.RepositoryRA);
        }

        [Test]
        public void RepositoryCreatePostTest()
        {
            var repositoryController = RepositoryController.GetInstance();
            Assert.IsInstanceOf<IRepositoryCreatePost>(repositoryController.RepositoryCreatePost);
        }

        [Test]
        public void RepositoryPostTest()
        {
            var repositoryController = RepositoryController.GetInstance();
            Assert.IsInstanceOf<IRepositoryPost>(repositoryController.RepositoryPost);
        }

        [Test]
        public void RepositoryUserSettingsTest()
        {
            var repositoryController = RepositoryController.GetInstance();
            Assert.IsInstanceOf<IRepositoryUserSettings>(repositoryController.RepositoryUserSettings);
        }

        [Test]
        public void RepositoryRestHeaderTest()
        {
            var repositoryController = RepositoryController.GetInstance();
            Assert.IsInstanceOf<IRepositoryRestHeader>(repositoryController.RepositoryRestHeader);
        }
    }
}