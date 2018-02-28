using System;
using System.Linq;
using System.Reflection;

using NUnit.Framework;

using SocialTrading.Vipers.Entity;
using SocialTrading.Service.Repositories;
using SocialTrading.Service.Interfaces.Repository;

namespace MASTTests.Repository
{
    [TestFixture]
    public class RepositoryUpdatePostTests
    {
        private RepositoryUpdatePost _repo;

        [SetUp]
        public void SetUp()
        {
            _repo = new RepositoryUpdatePost();
        }


        [Test]
        public void CtorTest()
        {
            var model = _repo.GetType().GetRuntimeFields().First(f => f.Name.Equals("_updatePostModel")).GetValue(_repo) as Lazy<UpdatePostModel>;
            Assert.IsNull(model.Value);
            Assert.IsInstanceOf<IRepositoryUpdatePost>(_repo);
        }

        [Test]
        public void GetUpdatePostModelNegativeTest()
        {
            Assert.IsNull(_repo.UpdatePostModel);
        }


        [Test]
        public void GetUpdatePostModelPositiveTest()
        {
            var model = new UpdatePostModel(false, "id", "quote", "forecast", "123", "Купить", "Публичный", "image", "content");

            _repo.GetType().GetRuntimeFields().First(f => f.Name.Equals("_updatePostModel")).SetValue(_repo, new Lazy<UpdatePostModel>(() => model));

            var result = _repo.UpdatePostModel.Equals(model);

            Assert.IsTrue(result);
        }


        [Test]
        public void SetUpdatePostModelNullTest()
        {
            _repo.UpdatePostModel = null;

            var modelAct = _repo.GetType().GetRuntimeFields().First(f => f.Name.Equals("_updatePostModel")).GetValue(_repo) as Lazy<UpdatePostModel>;

            Assert.IsNull(modelAct.Value);
        }


        [Test]
        public void SetUpdatePostModelTest()
        {
            var model = new UpdatePostModel(false, "id", "quote", "forecast", "123", "Продать", "Публичный", "image", "content");
            _repo.UpdatePostModel = model;

            var modelAct = _repo.GetType().GetRuntimeFields().First(f => f.Name.Equals("_updatePostModel")).GetValue(_repo) as Lazy<UpdatePostModel>;

            var result = modelAct?.Value.Equals(model);

            Assert.IsTrue(result);
        }
    }
}