using System;
using System.Linq;
using System.Reflection;

using NUnit.Framework;

using SocialTrading.Service;
using SocialTrading.Vipers.Entity;
using SocialTrading.Vipers.ModelCreators;
using SocialTrading.DTO.Response.UserSettings;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.ModelCreators.Interfaces;

namespace MASTTests.Vipers.ModelCreators
{
    [TestFixture, Author(Authors.Marchenko)]
    public class EditContactModelCreatorTests
    {
        private IEditContactModelCreator _modelCreator;
        private IRepositoryEditContact _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = DataService.RepositoryController.RepositoryUserSettings;
            _modelCreator = new EditContactModelCreator(_repository);
        }


        [Test]
        public void CtorTest()
        {
            Assert.IsInstanceOf<EditContactModelCreator>(new EditContactModelCreator(_repository));
        }

        [Test]
        public void CtorExceptionTest()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new EditContactModelCreator(null);
            });
        }

        [Test]
        public void GetModelNoParams()
        {
            var modelExp = new EditContactEntity("email", "skype", "country", "city", "phone");
            _repository.EditContactUserInfo = new DataModelUserInfo("", "", "", "", "", "email", "phone", "", "skype", "country", "city", 
                "", false, new string[]{});

            var modelAct = _modelCreator.GetModel();

            Assert.AreEqual(modelExp, modelAct);
        }

        [Test(Author = Authors.Gerashchenko)]
        [TestCase(null, null, null, null, null, TestName = "0")]
        [TestCase(null, "skype", "country", "city", "phone", TestName = "1")]
        [TestCase("email", null, "country", "city", "phone", TestName = "2")]
        [TestCase("email", "skype", null, "city", "phone", TestName = "3")]
        [TestCase("email", "skype", "country", null, "phone", TestName = "4")]
        [TestCase("email", "skype", "country", "city", null, TestName = "5")]
        public void GetModelTest_NullParams(string email, string skype, string country, string city, string phone)
        {
            var modelExp = new EditContactEntity(email: email, skype: skype, country: country, city: city, phone: phone);
            _repository.EditContactUserInfo = new DataModelUserInfo(
                id : "",
                first_name: "",
                last_name: "",
                nickname: "",
                image: "",
                email: email,
                phone: phone,
                phone_2: "",
                skype: skype,
                country: country,
                city: city,
                status: "",
                isNickName: false,
                errors: new string[] { });

            var modelAct = _modelCreator.GetModel();

            Assert.AreEqual(modelExp, modelAct);
        }

        [Test]
        public void GetModelOneParam()
        {
            var entity = new EditContactEntity("email", "skype", "country", "city", "phone");
            var modelDTO = _modelCreator.GetRequestModel(entity);

            var modelAct = modelDTO.GetType().GetRuntimeFields().First(f => f.Name.Equals("_entity")).GetValue(modelDTO);
            
            Assert.AreEqual(entity, modelAct);
        }
    }
}