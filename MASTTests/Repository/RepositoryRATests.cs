using System;
using System.Reflection;

using NUnit.Framework;

using SocialTrading.DTO.Response.RA;
using SocialTrading.Tools.Exceptions;
using SocialTrading.Service.Repositories;

namespace MASTTests.Repository
{
    [TestFixture, Author("Oleh Marchenko")]
    public class RepositoryRATests
    {
        private SocialTrading.Service.Repositories.Repository _repo;


        [Test]
        public void CtorRepositoryRaExceptionTest()
        {
            Assert.Throws<RepoUserAuthNullReferenceException>(() => _repo = new SocialTrading.Service.Repositories.Repository(null, null));
        }

        [Test]
        public void CtorRepositoryRaTest()
        {
            _repo = new SocialTrading.Service.Repositories.Repository(new RepositoryUserAuth(), new RepositoryUserSettings());
            Assert.IsInstanceOf<SocialTrading.Service.Repositories.Repository>(_repo);
        }

        [Test]
        public void RepositoryRaSetModelAuthNullTest()
        {
            Assert.Throws<DataModelAuthNullReferenceException>(() =>
            {
                _repo = new SocialTrading.Service.Repositories.Repository(new RepositoryUserAuth(), new RepositoryUserSettings())
                {
                    ModelAuth = null
                };
            });
        }

        [Test]
        public void RepositoryRaSetModelAuthTest()
        {
            var modelAuth = new DataModelAuth(
                "111", "email", "tvma@i.ua", "tvma@i.ua", null, "2017-11-14T09:30:26.893Z", "https://pbs.twimg.com/profile_images/901947348699545601/hqRMHITj.jpg",
                null, "2017-11-17T08:43:17.669Z", "Jon", "Snow", null, "EN", false, 1510651826, 1510908197, 0, null);
            var authData = new UserAuthData(modelAuth);

            _repo = new SocialTrading.Service.Repositories.Repository(new RepositoryUserAuth(), new RepositoryUserSettings())
            {
                ModelAuth = modelAuth
            };

            var result = true;

            var fields = _repo.GetType().GetRuntimeFields();
            foreach (var item in fields)
            {
                if (item.Name.Equals("_modelAuth"))
                {
                    result &= Equals((item.GetValue(_repo) as Lazy<DataModelAuth>)?.Value, modelAuth);
                }
                else if (item.Name.Equals("_repositoryUserAuth"))
                {
                    var repoUserAuth = item.GetValue(_repo) as RepositoryUserAuth;
                    result &= repoUserAuth.AuthData.Equals(authData) ? true : false;
                }
            }

            Assert.IsTrue(result);
        }

        [Test]
        public void RepositoryRaGetModelAuthNull()
        {
            _repo = new SocialTrading.Service.Repositories.Repository(new RepositoryUserAuth(), new RepositoryUserSettings());
            Assert.Throws<NullReferenceException>(() => { var res = _repo.ModelAuth; });
        }

        [Test]
        public void RepositoryRaGetModelAuth()
        {
            var modelAuth = new DataModelAuth(
                "111", "email", "tvma@i.ua", "tvma@i.ua", null, "2017-11-14T09:30:26.893Z", "https://pbs.twimg.com/profile_images/901947348699545601/hqRMHITj.jpg",
                null, "2017-11-17T08:43:17.669Z", "Jon", "Snow", null, "EN", false, 1510651826, 1510908197, 0, null);
            _repo = new SocialTrading.Service.Repositories.Repository(new RepositoryUserAuth(), new RepositoryUserSettings())
            {
                ModelAuth = modelAuth
            };

            Assert.AreEqual(modelAuth, _repo.ModelAuth);
        }
    }
}