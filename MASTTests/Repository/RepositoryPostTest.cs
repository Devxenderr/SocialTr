using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using Moq;

using NUnit.Framework;

using SocialTrading.DTO.Response.Post;
using SocialTrading.Service.Repositories;
using SocialTrading.Service.Interfaces.Timer;
using SocialTrading.Service.Interfaces.Repository;

namespace MASTTests.Repository
{
    [TestFixture]
    public class RepositoryPostTest
    {

        [Test]
        public void CallConvertTimeTest()
        {
            Mock<IDateTimeConverter> dateTimeConverterMock = new Mock<IDateTimeConverter>(MockBehavior.Strict);

            dateTimeConverterMock.Setup(f => f.Convert("123")).Returns(It.IsAny<DateTime>());
            IRepositoryPost repositoryPost = new SocialTrading.Service.Repositories.Repository(new RepositoryUserAuth(), new RepositoryUserSettings());

            var fields = repositoryPost.GetType().GetRuntimeFields().ToList();
            foreach (var item in fields)
            {
                if (item.Name.Equals("_converter"))
                {
                    item.SetValue(repositoryPost, dateTimeConverterMock.Object);
                    break;
                }
            }

            var posts = new Dictionary<string, DataModelPost>
            {
                {
                    "123", new DataModelPost("123", "123", "123", "123", "123", 123.123f, "123", "123",
                    "123", "123", "123", "123", "123", "123", 12, 123, true)
                }
            };

            repositoryPost.SetPosts(posts);

            repositoryPost.GetPostHeaderModelById("123");

            dateTimeConverterMock.Verify(f => f.Convert("123"), Times.AtLeastOnce);
        }

        [Test]
        public void CallConvertTimeTestNever()
        {
            Mock<IDateTimeConverter> dateTimeConverterMock = new Mock<IDateTimeConverter>(MockBehavior.Strict);

            dateTimeConverterMock.Setup(f => f.Convert(It.IsAny<string>()));
            IRepositoryPost repositoryPost = new SocialTrading.Service.Repositories.Repository(new RepositoryUserAuth(), new RepositoryUserSettings());


            var posts = new Dictionary<string, DataModelPost>
            {
                {
                    "123", new DataModelPost("123", "123", "123", "123", "123", 123.123f, "123", "123",
                        "123", "123", "123", "123", "123", "123", 12, 123, true)
                }
            };

            repositoryPost.SetPosts(posts);

            repositoryPost.GetPostHeaderModelById("321");

            dateTimeConverterMock.Verify(f => f.Convert(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void UpdatePostDoesntContainsTest()
        {
            IRepositoryPost repository = new SocialTrading.Service.Repositories.Repository(new RepositoryUserAuth(), new RepositoryUserSettings());

            var posts = new Dictionary<string, DataModelPost>
            {
                {
                    "123", new DataModelPost("123", "123", "123", "123", "123", 123.123f, "123", "123",
                        "123", "123", "123", "123", "123", "123", 12, 123, true)
                }
            };

            repository.SetPosts(posts);

            repository.UpdatePost(new DataModelPost("00000", "123", "123", "123", "123", 123.123f, "123", "123",
                "123", "123", "123", "123", "123", "123", 12, 123, true));

            CollectionAssert.AreEqual((Dictionary<string, DataModelPost>)repository.GetType().GetRuntimeFields().First(f => f.Name.Equals("_posts")).GetValue(repository), posts);
        }

        [Test]
        public void UpdatePostContainsTest()
        {
            IRepositoryPost repository = new SocialTrading.Service.Repositories.Repository(new RepositoryUserAuth(), new RepositoryUserSettings());

            var posts = new Dictionary<string, DataModelPost>
            {
                {
                    "123", new DataModelPost("123", "123", "123", "123", "123", 123.123f, "123", "123",
                        "123", "123", "123", "123", "123", "123", 12, 123, true)
                }
            };

            repository.SetPosts(posts);

            var expected = new DataModelPost("123", "123", "123", "123", "12121212121212121", 123.123f, "123", "123",
                "123", "123", "123", "123", "123", "123", 12, 123, true);

            repository.UpdatePost(expected);

            Assert.AreEqual(repository.GetPostBodyModelById("123"), expected);
        }
    }
}
