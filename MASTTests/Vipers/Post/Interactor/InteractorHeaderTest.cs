using System;
using System.Globalization;
using System.Reflection;

using Moq;

using NUnit.Framework;

using SocialTrading.Service;
using SocialTrading.DTO.Response.Qc;
using SocialTrading.DTO.Response.Post;
using SocialTrading.Tools.Enumerations;
using SocialTrading.DTO.Response.Post.Interfaces;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.Post.Interfaces.Header;
using SocialTrading.Vipers.Controllers.Interfaces;
using SocialTrading.Vipers.Post.Implementation.Header;
using SocialTrading.DTO.Response.Post.ConstituentParts;

namespace MASTTests.Vipers.Post.Interactor
{
    [TestFixture]
    class InteractorHeaderTest
    {
        private Mock<IPostHeaderController> _connection;
        private Mock<IRepositoryPost> _repository;
        private Mock<IPresenterPostHeader> _presenterPostHeaderMock;


        [SetUp]
        public void InitInteractor()
        {
            _connection = new Mock<IPostHeaderController>(MockBehavior.Strict);
            _repository = new Mock<IRepositoryPost>(MockBehavior.Strict);
            _presenterPostHeaderMock = new Mock<IPresenterPostHeader>(MockBehavior.Strict);
        }

        [TestCase("0.00001", "0.00002", true, 0)]
        [TestCase("0.00029", "0.00010", true, 1)]
        [TestCase("0.01000", "0.00010", true, 99)]
        [TestCase("0.01016", "0.00010", true, 100)]
        [TestCase("0.10009", "0.00010", true, 999)]
        [TestCase("0.10010", "0.00010", true, 1000)]
        [TestCase("0.001", "0.001", true, 0)]
        [TestCase("45.159", "45.009", true, 15)]
        [TestCase("0.011", "0.050", true, -4)]
        [TestCase("0.001", "0.012", true, -1)]
        [TestCase("1.156", "1.256", true, -10)]
        [TestCase("9.156", "1.256", true, 790)]
        [TestCase("18.564", "90.560", true, -7200)]
        [TestCase("8.68", "8.69", true, -1)]
        [TestCase("86.789", "12.230", true, 7455)]
        [TestCase("1.11", "1.99", true, -88)]
        [TestCase("15.68", "15.96", true, -28)]
        [TestCase("99.68", "95.56", true, 412)]
        [TestCase("100.56", "89.15", true, 1141)]
        [TestCase("1245.6", "1587.0", true, -342)]
        [TestCase("9999.9", "1111.1", true, 8888)]
        [TestCase("99.999", "100.59", true, -60)]
        [TestCase("100.59", "99.948", true, 65)]
        [TestCase("0.00001", "0.00002", false, 0)]
        [TestCase("0.00029", "0.00010", false, -1)]
        [TestCase("0.01000", "0.00010", false, -99)]
        [TestCase("0.01016", "0.00010", false, -100)]
        [TestCase("0.10009", "0.00010", false, -999)]
        [TestCase("0.10010", "0.00010", false, -1000)]
        [TestCase("0.001", "0.001", false, 0)]
        [TestCase("45.159", "45.009", false, -15)]
        [TestCase("0.011", "0.050", false, 4)]
        [TestCase("0.001", "0.012", false, 1)]
        [TestCase("1.156", "1.256", false, 10)]
        [TestCase("9.156", "1.256", false, -790)]
        [TestCase("18.564", "90.560", false, 7200)]
        [TestCase("8.68", "8.69", false, 1)]
        [TestCase("86.789", "12.230", false, -7455)]
        [TestCase("1.11", "1.99", false, 88)]
        [TestCase("15.68", "15.96", false, 28)]
        [TestCase("99.68", "95.56", false, -412)]
        [TestCase("100.56", "89.15", false, -1141)]
        [TestCase("1245.6", "1587.0", false, 342)]
        [TestCase("9999.9", "1111.1", false, -8888)]
        [TestCase("99.999", "100.59", false, 60)]
        [TestCase("100.59", "99.948", false, -65)]
        [TestCase("100,59", "99,948", false, -65)]
        [TestCase("100,59", "99,948", true, 65)]
        [TestCase("0,001", "0,001", true, 0)]
        [TestCase("6614,21", "6638,65", true, -2444)]
        public void PostSetDifferenceAmmountTest(string price, string currentPrice, bool isSell, int expected)
        {
            var interactor = new InteractorPostHeader(string.Empty, _connection.Object, _repository.Object);
            var camelPosPrice = interactor.GetCamelPos(price);
            var camelPosCurrentPrice = interactor.GetCamelPos(currentPrice);
            var actual = interactor.SetDifferenceAmmount(price, currentPrice, isSell, camelPosPrice, camelPosCurrentPrice);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1.33, 2.44, true)]
        public void PostSetPriceStatusTest(double price, double currentPrice, bool expected)
        {
            var interactor = new InteractorPostHeader(string.Empty, _connection.Object, _repository.Object);
            bool actual = interactor.SetPriceStatus(price, currentPrice);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2017, 07, 24, 00, 00, 00, 000, "24 Июля 00:00")]
        [TestCase(2017, 07, 25, 00, 00, 00, 000, "Сейчас")]
        [TestCase(2017, 07, 24, 23, 59, 30, 000, "Сейчас")]
        [TestCase(2017, 07, 24, 23, 59, 01, 000, "Сейчас")]
        [TestCase(2017, 07, 24, 23, 59, 00, 000, "1 мин")]
        [TestCase(2017, 07, 24, 23, 55, 10, 000, "4 мин")]
        [TestCase(2017, 07, 24, 23, 00, 01, 000, "59 мин")]
        [TestCase(2017, 07, 24, 23, 00, 00, 000, "1 ч")]
        [TestCase(2017, 07, 24, 22, 14, 59, 000, "1 ч")]
        [TestCase(2017, 07, 24, 22, 00, 00, 000, "2 ч")]
        [TestCase(2017, 07, 24, 00, 00, 01, 000, "23 ч")]
        [TestCase(2017, 07, 24, 00, 00, 00, 000, "24 Июля 00:00")]
        [TestCase(2017, 01, 23, 15, 15, 30, 000, "23 Янв 15:15")]
        [TestCase(2017, 02, 23, 15, 15, 30, 000, "23 Фев 15:15")]
        [TestCase(2017, 03, 23, 15, 15, 30, 000, "23 Марта 15:15")]
        [TestCase(2017, 04, 23, 15, 00, 10, 000, "23 Апр 15:00")]
        [TestCase(2017, 05, 23, 15, 15, 30, 000, "23 Мая 15:15")]
        [TestCase(2017, 06, 23, 15, 15, 30, 000, "23 Июня 15:15")]
        [TestCase(2017, 07, 23, 15, 15, 30, 000, "23 Июля 15:15")]
        [TestCase(2017, 08, 23, 15, 15, 30, 000, "23 Авг 15:15")]
        [TestCase(2017, 09, 23, 15, 12, 30, 000, "23 Сент 15:12")]
        [TestCase(2017, 10, 23, 15, 15, 30, 000, "23 Окт 15:15")]
        [TestCase(2017, 11, 23, 15, 15, 30, 000, "23 Нояб 15:15")]
        [TestCase(2017, 11, 23, 15, 05, 30, 000, "23 Нояб 15:05")]
        [TestCase(2017, 12, 23, 00, 15, 30, 000, "23 Дек 00:15")]
        [TestCase(2010, 12, 23, 15, 15, 30, 000, "23 Дек 2010")]
        [TestCase(2016, 07, 25, 00, 00, 00, 000, "25 Июля 2016")]
        [TestCase(2016, 07, 24, 23, 59, 59, 000, "24 Июля 2016")]
        [TestCase(2016, 05, 24, 23, 59, 59, 000, "24 Мая 2016")]

        public void PostUpdateCreatedTimeTest(int year, int momth, int day, int hour, int minute, int seconds, int millisec, string expected)
        {
            DateTime createdAt = new DateTime(year, momth, day, hour, minute, seconds, millisec);
            var interactor = new InteractorPostHeader(string.Empty, _connection.Object, DataService.RepositoryController.RepositoryPost);
            string actual = interactor.CalcCreatedTime(createdAt, new DateTime(2017, 07, 25, 00, 00, 00));
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Buy")]
        [TestCase("Sell")]
        public void PrepareBrokerDataTest(string recommend)
        {
            var interactor = new InteractorPostHeader(string.Empty, _connection.Object, DataService.RepositoryController.RepositoryPost);
            DataModelQc brokerData = new DataModelQc(123, "123", "123", 123.123f, "123", 123.213f, 123.213f, 123.213f, 123.213f, "123", 123.213f, 123, 123);
            PostHeaderBrokerModel postHeaderBrokerModel = new PostHeaderBrokerModel(brokerData);
            IPostHeaderModel postHeaderModel = new DataModelPost("123", "123", "123", "123", recommend, 123.123f, "123", "123",
                "123", "123", "123", "123", "123", "123", 12, 123, true);

            interactor.Presenter = _presenterPostHeaderMock.Object;

            _presenterPostHeaderMock.Setup(f => f.GetPreviousPrice()).Returns(It.IsAny<double>());
            _presenterPostHeaderMock.Setup(f => f.SetBrokerFields(postHeaderBrokerModel, interactor.GetCamelPos(postHeaderBrokerModel.CurrentPrice)));


            foreach (var item in typeof(InteractorPostHeader).GetRuntimeMethods())
            {
                if (item.Name.Equals("PrepareBrokerData"))
                {
                    item.Invoke(interactor, new object[] { postHeaderBrokerModel, postHeaderModel });
                    break;
                }
            }

            _presenterPostHeaderMock.Verify(f => f.GetPreviousPrice(), Times.AtLeastOnce);
            _presenterPostHeaderMock.Verify(f => f.SetBrokerFields(postHeaderBrokerModel, interactor.GetCamelPos(postHeaderBrokerModel.CurrentPrice)), Times.Once);
        }

        [Test]
        public void PrepareBrokerDataNoBuySellTest()
        {
            var interactor = new InteractorPostHeader(string.Empty, _connection.Object, DataService.RepositoryController.RepositoryPost);
            DataModelQc brokerData = new DataModelQc(123, "123", "123", 123.123f, "123", 123.213f, 123.213f, 123.213f, 123.213f, "123", 123.213f, 123, 123);
            PostHeaderBrokerModel postHeaderBrokerModel = new PostHeaderBrokerModel(brokerData);
            IPostHeaderModel postHeaderModel = new DataModelPost("123", "123", "123", "123", "123", 123.123f, "123", "123",
                "123", "123", "123", "123", "123", "123", 12, 123, true);

            interactor.Presenter = _presenterPostHeaderMock.Object;

            foreach (var item in typeof(InteractorPostHeader).GetRuntimeMethods())
            {
                if (item.Name.Equals("PrepareBrokerData"))
                {
                    item.Invoke(interactor, new object[] { postHeaderBrokerModel, postHeaderModel });
                    break;
                }
            }

            _presenterPostHeaderMock.Verify(f => f.GetPreviousPrice(), Times.Never);
            _presenterPostHeaderMock.Verify(f => f.SetBrokerFields(postHeaderBrokerModel, interactor.GetCamelPos(postHeaderBrokerModel.CurrentPrice)), Times.Never);
        }

        [TestCase("Buy", false)]
        [TestCase("Sell", true)]
        public void SetBidAskPriceTest(string recommend, bool expected)
        {
            var interactor = new InteractorPostHeader(string.Empty, _connection.Object, DataService.RepositoryController.RepositoryPost);
            DataModelQc brokerData = new DataModelQc(123, "123", "123", 123.123f, "123", 123.213f, 123.213f, 123.213f, 123.213f, "123", 123.213f, 123, 123);
            PostHeaderBrokerModel postHeaderBrokerModel = new PostHeaderBrokerModel(brokerData);
            IPostHeaderModel postHeaderModel = new DataModelPost("123", "123", "123", "123", recommend, 123.123f, "123", "123",
                "123", "123", "123", "123", "123", "123", 12, 123, true);

            interactor.Presenter = _presenterPostHeaderMock.Object;

            foreach (var item in typeof(InteractorPostHeader).GetRuntimeMethods())
            {
                if (item.Name.Equals("SetBidAskPrice"))
                {
                    Enum.TryParse(postHeaderModel.Recommend, out EBuySell res);
                    var actual = item.Invoke(interactor, new object[] { postHeaderBrokerModel, res });
                    Assert.AreEqual(expected, actual);
                    break;
                }
            }
        }

        [TestCase(2017, 07, 24, 00, 00, 00, 000, 2017, 07, 24, 00, 00, 00, 000, "0d 00:00:00")]
        [TestCase(2017, 07, 24, 00, 00, 00, 000, 2017, 07, 25, 00, 00, 00, 000, "1d 00:00:00")]
        [TestCase(2017, 07, 24, 00, 00, 00, 000, 2017, 07, 25, 10, 00, 00, 000, "1d 10:00:00")]
        [TestCase(2017, 07, 24, 00, 00, 00, 000, 2017, 07, 25, 10, 25, 00, 000, "1d 10:25:00")]
        [TestCase(2017, 07, 24, 00, 00, 00, 000, 2017, 07, 25, 10, 25, 59, 000, "1d 10:25:59")]
        public void ChangeTimeTest(int year, int momth, int day, int hour, int minute, int seconds, int millisec, int fyear, int fmomth, int fday, int fhour, int fminute, int fseconds, int fmillisec, string expected)
        {
            DateTime nowTime = new DateTime(year, momth, day, hour, minute, seconds, millisec);
            DateTime forecastDateTime = new DateTime(fyear, fmomth, fday, fhour, fminute, fseconds, fmillisec);

            var interactor = new InteractorPostHeader(string.Empty, _connection.Object, DataService.RepositoryController.RepositoryPost);

            var forecastTime = interactor.GetType().GetField("_forecastDate", BindingFlags.NonPublic | BindingFlags.Instance);
            forecastTime.SetValue(interactor, forecastDateTime);

            interactor.Presenter = _presenterPostHeaderMock.Object;
            _presenterPostHeaderMock.Setup(f => f.UpdateTime(expected));
            interactor.ChangeTime(nowTime);
            _presenterPostHeaderMock.Verify(f => f.UpdateTime(expected), Times.AtLeastOnce);
        }

        [TestCase("1.1", "1.1", "1.1")]
        [TestCase("1.11", "1.1", "1.10")]
        [TestCase("1.111", "1.1", "1.100")]
        [TestCase("1.111", "1.11", "1.110")]
        [TestCase("11.1", "11.1", "11.1")]
        [TestCase("11.11", "11.1", "11.10")]
        [TestCase("11.111", "11.1", "11.100")]
        [TestCase("11.000", "11", "11.000")]
        [TestCase("10.0", "10", "10.0")]
        [TestCase("1,1", "1.1", "1.1")]
        [TestCase("1,11", "1.1", "1.10")]
        [TestCase("1,111", "1.1", "1.100")]
        [TestCase("1,111", "1.11", "1.110")]
        [TestCase("11,1", "11.1", "11.1")]
        [TestCase("11,11", "11.1", "11.10")]
        [TestCase("11,111", "11.1", "11.100")]
        [TestCase("11,000", "11", "11.000")]
        [TestCase("10,0", "10", "10.0")]
        [TestCase("1.1", "1,1", "1.1")]
        [TestCase("1.11", "1,1", "1.10")]
        [TestCase("1.111", "1,1", "1.100")]
        [TestCase("1.111", "1,11", "1.110")]
        [TestCase("11.1", "11,1", "11.1")]
        [TestCase("11.11", "11,1", "11.10")]
        [TestCase("11.111", "11,1", "11.100")]
        [TestCase("11.000", "11", "11.000")]
        [TestCase("10.0", "10", "10.0")]
        [TestCase("1,1", "1,1", "1.1")]
        [TestCase("1,11", "1,1", "1.10")]
        [TestCase("1,111", "1,1", "1.100")]
        [TestCase("1,111", "1,11", "1.110")]
        [TestCase("11,1", "11,1", "11.1")]
        [TestCase("11,11", "11,1", "11.10")]
        [TestCase("11,111", "11,1", "11.100")]
        [TestCase("11,000", "11", "11.000")]
        [TestCase("10,0", "10", "10.0")]
        public void AlignRorPriceTest(string accordancePrice, string changablePrice, string expectedPrice)
        {
            expectedPrice = expectedPrice.Replace(".", NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
            var interactor = new InteractorPostHeader(string.Empty, _connection.Object, DataService.RepositoryController.RepositoryPost);

            var alignRorPrice = interactor.GetType().GetMethod("AlignRorPrice", BindingFlags.NonPublic | BindingFlags.Instance);
            var resultPrice = alignRorPrice?.Invoke(interactor, new object[]{accordancePrice, changablePrice});

            Assert.AreEqual(expectedPrice, resultPrice);
        }
    }
}
