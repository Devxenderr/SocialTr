using System;
using System.Reflection;

using NUnit.Framework;

using SocialTrading.DTO.Response.RA;
using SocialTrading.Tools.Exceptions;
using SocialTrading.Service.Repositories;

namespace MASTTests.Repository
{
    [TestFixture]
    public class RepositoryUserAuthTests
    {
        private RepositoryUserAuth _repo;


        [Test]
        public void CtorTest()
        {
            _repo = new RepositoryUserAuth();
            Assert.IsInstanceOf<RepositoryUserAuth>(_repo);
        }

        [Test]
        public void GetAuthDataTestNullException()
        {
            _repo = new RepositoryUserAuth();
            
            Assert.Throws<NullReferenceException>(() =>
            {
                var repoAuthData = _repo.AuthData;
            });
        }

        [Test]
        public void GetAuthDataTestNull()
        {
            _repo = new RepositoryUserAuth
            {
                AuthData = null
            };

            Assert.IsNull(_repo.AuthData);
        }

        [Test]
        public void GetAuthDataTest()
        {
            var model = new UserAuthData(new DataModelAuth("111", "email", "tvma@i.ua", "tvma@i.ua", null, "2017-11-14T09:30:26.893Z", "image",
                null, "2017-11-17T08:43:17.669Z", "Jon", "Snow", null, "EN", false, 1510651826, 1510908197, 0, null));

            _repo = new RepositoryUserAuth
            {
                AuthData = model
            };

            Assert.AreEqual(model, _repo.AuthData);
        }

        [Test]
        public void AuthDataCastTestNull()
        {
            UserAuthData actual = null;
            var methods = typeof(UserAuthData).GetMethods();
            foreach (var item in methods)
            {
                if (item.Name.Contains("op_Implicit"))
                {
                    Assert.Throws<LazyUserAuthDataInvalidCastException>(() =>
                    {
                        try
                        {
                            actual = item.Invoke(typeof(UserAuthData), new object[] { null }) as UserAuthData;
                        }
                        catch (TargetInvocationException e)
                        {
                            if (e.InnerException is LazyUserAuthDataInvalidCastException ex)
                            {
                                throw ex;
                            }
                        }
                    });
                    return;
                }
            }

            Assert.Fail();
        }

        [Test]
        public void AuthDataCastTest()
        {
            var expected = new UserAuthData(new DataModelAuth("111", "email", "tvma@i.ua", "tvma@i.ua", null, "2017-11-14T09:30:26.893Z", "image",
                null, "2017-11-17T08:43:17.669Z", "Jon", "Snow", null, "EN", false, 1510651826, 1510908197, 0, null));

            UserAuthData actual = null;
            var methods = typeof(UserAuthData).GetMethods();
            foreach (var item in methods)
            {
                if (item.Name.Contains("op_Implicit"))
                {
                    actual = item.Invoke(typeof(UserAuthData), new object[] { new Lazy<UserAuthData>(() => expected) }) as UserAuthData;
                }
            }

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetAuthDataTest()
        {
            var model = new UserAuthData(new DataModelAuth("111", "email", "tvma@i.ua", "tvma@i.ua", null, "2017-11-14T09:30:26.893Z", "image",
                null, "2017-11-17T08:43:17.669Z", "Jon", "Snow", null, "EN", false, 1510651826, 1510908197, 0, null));

            _repo = new RepositoryUserAuth
            {
                AuthData = model
            };

            UserAuthData actual = null;
            foreach (var item in _repo.GetType().GetRuntimeFields())
            {
                if (item.Name.Equals("_authData"))
                {
                    actual = item.GetValue(_repo) as Lazy<UserAuthData>;
                    break;
                }
            }

            Assert.AreEqual(model, actual);
        }

        [Test]
        public void SetAuthDataTestNull()
        {
            _repo = new RepositoryUserAuth
            {
                AuthData = null
            };

            UserAuthData actual = null;
            foreach (var item in _repo.GetType().GetRuntimeFields())
            {
                if (item.Name.Equals("_authData"))
                {
                    actual = item.GetValue(_repo) as Lazy<UserAuthData>;
                    break;
                }
            }

            Assert.IsNull(actual);
        }
    }
}