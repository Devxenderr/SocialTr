using System;
using System.Linq;
using System.Reflection;

using NUnit.Framework;

using Newtonsoft.Json.Linq;

using SocialTrading.DTO.Request;
using SocialTrading.Tools.Enumerations;

namespace MASTTests.DTO.CreatePost
{
    [TestFixture, Author(Authors.Pakhomova)]
    public class CreatePostRequestModelTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void GetStringForecastTimeFromStringEmptyTest(string forecast)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                CreatePostRequestModel model = new CreatePostRequestModel("123", "user123", EBuySell.None, string.Empty, EAccessMode.None, "My content", forecast);
            });
        }

        [TestCase("2017-01-20 08:36", "2017-01-20T08:36:00.000Z")]
        public void GetStringForecastTimeFromStringTest(string forecast, string expected)
        {
            CreatePostRequestModel model = new CreatePostRequestModel("BMW", string.Empty, EBuySell.Sell, "110.0", EAccessMode.Private, "Content", forecast);

            var actual = typeof(CreatePostRequestModel).GetRuntimeProperties().First(f => f.Name.Equals("Forecast"));

            string act = actual.GetValue(model).ToString();
            Assert.AreEqual(expected, act);
        }
        
        [TestCase(EForecastTime.Minute15)]
        [TestCase(EForecastTime.Minute30)]
        [TestCase(EForecastTime.Hour4)]
        [TestCase(EForecastTime.Hour8)]
        [TestCase(EForecastTime.Hour24)]
        [TestCase(EForecastTime.Week1)]
        public void GetStringForecastTimeFromEnumTest(EForecastTime time)
        {
            CreatePostRequestModel model = new CreatePostRequestModel("BMW", string.Empty, EBuySell.Sell, "10.4", EAccessMode.Private, "Content", time);

            var actual = typeof(CreatePostRequestModel).GetRuntimeProperties().First(f => f.Name.Equals("Forecast"));

            string expected = GetForecastTimeString(time);

            string act = actual.GetValue(model).ToString();
            Assert.AreEqual(expected, act);
        }

        [TestCase("AUDHUF", "", EBuySell.Sell, "10.1", EAccessMode.Private, null, "29-07-2017 00:00", "file123", TestName = "Content null, file not null")]
        [TestCase("AUDHUF", "", EBuySell.Sell, "10.1", EAccessMode.Private, "", "29-07-2017 00:00", "file123", TestName = "Content empty, file not null")]
        [TestCase("AUDHUF", "", EBuySell.Sell, "10.1", EAccessMode.Private, "Cool content", "29-07-2017 00:00", null, TestName = "Image null, content not null")]
        [TestCase("AUDHUF", "", EBuySell.Sell, "10.1", EAccessMode.Private, "Cool content", "29-07-2017 00:00", "", TestName = "Image empty, content not null")]
        public void PerformQueryTest(string quote, string market, EBuySell recommend, string price,
            EAccessMode access, string content, string forecast, string file)
        {
            CreatePostRequestModel model = new CreatePostRequestModel(quote, market, recommend, price, access, content, forecast, file);
            var actual = model.PerformQuery();

            foreach (var item in typeof(CreatePostRequestModel).GetRuntimeMethods())
            {
                var res = item.GetParameters();
                if (item.Name.Equals("GetStringForecastTime") && item.GetParameters().First().ParameterType == typeof(string))
                {
                    forecast = item.Invoke(model, new object[] { forecast }) as string;
                    break;
                }
            }

            var expected = new JObject
            {
                ["quote"] = quote,
                ["market"] = market,
                ["recommend"] = recommend == EBuySell.None ? string.Empty : recommend.ToString(),
                ["access"] = access == EAccessMode.None ? string.Empty : access.ToString(),
                ["forecast"] = forecast
            };
            if (!string.IsNullOrWhiteSpace(price))
            {
                expected["price"] = price;
            }
            if (!string.IsNullOrWhiteSpace(file))
            {
                expected["image"] = "data:image/gif;base64," + file;
            }
            if (!string.IsNullOrWhiteSpace(content))
            {
                expected["content"] = content;
            }

            Assert.IsTrue(JToken.DeepEquals(actual, expected));
        }
        
        [TestCase(null, null, null, null, null, null, null, null, TestName = "All null")]
        [TestCase("", "", EBuySell.None, "", EAccessMode.None, "", "", "", TestName = "All empty")]
        [TestCase(null, "", EBuySell.Sell, "10.1", EAccessMode.Private, "Cool content", "29-07-2017 00:00", "file123", TestName = "Quote null")]
        [TestCase("", "", EBuySell.Sell, "10.1", EAccessMode.Private, "Cool content", "29-07-2017 00:00", "file123", TestName = "Quote empty")]
        [TestCase("AUDHUF", "", null, "10.1", EAccessMode.Private, "Cool content", "29-07-2017 00:00", "file123", TestName = "Recommend null")]
        [TestCase("AUDHUF", "", EBuySell.None, "10.1", EAccessMode.Private, "Cool content", "29-07-2017 00:00", "file123", TestName = "Recommend none")]
        [TestCase("AUDHUF", "", EBuySell.Sell, null, EAccessMode.Private, "Cool content", "29-07-2017 00:00", "file123", TestName = "Price null")]
        [TestCase("AUDHUF", "", EBuySell.Sell, "", EAccessMode.Private, "Cool content", "29-07-2017 00:00", "file123", TestName = "Price empty")]
        [TestCase("AUDHUF", "", EBuySell.Sell, "10.1", EAccessMode.None, "Cool content", "29-07-2017 00:00", "file123", TestName = "Access mode none")]
        [TestCase("AUDHUF", "", EBuySell.Sell, "10.1", EAccessMode.Private, "Cool content", null, "file123", TestName = "Forecast time null")]
        [TestCase("AUDHUF", "", EBuySell.Sell, "10.1", EAccessMode.Private, "Cool content", "", "file123", TestName = "Forecast time empty")]
        [TestCase("AUDHUF", "", EBuySell.Sell, "10.1", EAccessMode.Private, null, "29-07-2017 00:00", null, TestName = "Null content null file")]
        [TestCase("AUDHUF", "", EBuySell.Sell, "10.1", EAccessMode.Private, "", "29-07-2017 00:00", "", TestName = "Empty content empty file")]
        public void PerformQueryTestExceptions(string quote, string market, EBuySell recommend, string price,
            EAccessMode access, string content, string forecast, string file)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var model = new CreatePostRequestModel(quote, market, recommend, price, access, content, forecast, file);
            });
        }

        private string GetForecastTimeString(EForecastTime time)
        {
            string result = string.Empty;

            DateTime dateTime = DateTime.UtcNow;

            switch (time)
            {
                case EForecastTime.Minute15:
                    dateTime = dateTime.AddMinutes(15);
                    break;
                case EForecastTime.Minute30:
                    dateTime = dateTime.AddMinutes(30);
                    break;
                case EForecastTime.Hour1:
                    dateTime = dateTime.AddHours(1);
                    break;
                case EForecastTime.Hour4:
                    dateTime = dateTime.AddHours(4);
                    break;
                case EForecastTime.Hour8:
                    dateTime = dateTime.AddHours(8);
                    break;
                case EForecastTime.Hour24:
                    dateTime = dateTime.AddDays(1);
                    break;
                case EForecastTime.Week1:
                    dateTime = dateTime.AddDays(7);
                    break;

                default:
                    return result;
            }

            result = dateTime.ToString("yyyy-MM-dd") + "T" + dateTime.ToString("HH:mm:ss") + ".000Z";

            return result;
        }
    }
}

