using System;
using System.Reflection;
using System.Collections.Generic;

using Moq;

using NUnit.Framework;

using SocialTrading.Service;
using SocialTrading.Vipers.Entity;
using SocialTrading.DTO.Response.Post;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Vipers.CreatePost.Implementation;

namespace MASTTests.DTO.CreatePost
{
    [TestFixture]
    class ForecastTimeTests
    {
        private static System.Collections.IEnumerable Source()
        {
            TestCaseData data;

            data = new TestCaseData(0, new ForecastTimeModel { Years = new List<string> { "2017" }, MonthsRange = new List<int[]> { new int[] { 8, 8 } }, DaysRange = new List<int[]> { new int[] { 7, 7 } } }).SetName("0 Days");
            yield return data;

            data = new TestCaseData(1, new ForecastTimeModel { Years = new List<string> { "2017" }, MonthsRange = new List<int[]> { new int[] { 8, 8 } }, DaysRange = new List<int[]> { new int[] { 7, 8 } } }).SetName("1 Day");
            yield return data;

            data = new TestCaseData(12, new ForecastTimeModel { Years = new List<string> { "2017" }, MonthsRange = new List<int[]> { new int[] { 8, 8 } }, DaysRange = new List<int[]> { new int[] { 7, 19 } } }).SetName("12 Days");
            yield return data;

            data = new TestCaseData(30, new ForecastTimeModel { Years = new List<string> { "2017" }, MonthsRange = new List<int[]> { new int[] { 8, 9 } }, DaysRange = new List<int[]> { new int[] { 7, 31 }, new int[] { 1, 5 } } }).SetName("30 Days");
            yield return data;

            data = new TestCaseData(80, new ForecastTimeModel { Years = new List<string> { "2017" }, MonthsRange = new List<int[]> { new int[] { 8, 10 } }, DaysRange = new List<int[]> { new int[] { 7, 31 }, new int[] { 1, 30 }, new int[] { 1, 25 } } }).SetName("80 Days");
            yield return data;

            data = new TestCaseData(150, new ForecastTimeModel { Years = new List<string> { "2017", "2018" }, MonthsRange = new List<int[]> { new int[] { 8, 12 }, new int[] { 1, 1 } }, DaysRange = new List<int[]> { new int[] { 7, 31 }, new int[] { 1, 30 }, new int[] { 1, 31 }, new int[] { 1, 30 }, new int[] { 1, 31 }, new int[] { 1, 3 } } }).SetName("150 Days");
            yield return data;

            data = new TestCaseData(200, new ForecastTimeModel { Years = new List<string> { "2017", "2018" }, MonthsRange = new List<int[]> { new int[] { 8, 12 }, new int[] { 1, 2 } }, DaysRange = new List<int[]> { new int[] { 7, 31 }, new int[] { 1, 30 }, new int[] { 1, 31 }, new int[] { 1, 30 }, new int[] { 1, 31 }, new int[] { 1, 31 }, new int[] { 1, 22 } } }).SetName("200 Days");
            yield return data;

            data = new TestCaseData(520, new ForecastTimeModel { Years = new List<string> { "2017", "2018", "2019" }, MonthsRange = new List<int[]> { new int[] { 8, 12 }, new int[] { 1, 12 }, new int[] { 1, 1 } }, DaysRange = new List<int[]> { new int[] { 7, 31 }, new int[] { 1, 30 }, new int[] { 1, 31 }, new int[] { 1, 30 }, new int[] { 1, 31 }, new int[] { 1, 31 }, new int[] { 1, 28 }, new int[] { 1, 31 }, new int[] { 1, 30 }, new int[] { 1, 31 }, new int[] { 1, 30 }, new int[] { 1, 31 }, new int[] { 1, 31 }, new int[] { 1, 30 }, new int[] { 1, 31 }, new int[] { 1, 30 }, new int[] { 1, 31 }, new int[] { 1, 8 } } }).SetName("520 Days");
            yield return data;
        }

        [Test(Author = "Elena Pakhomova"), TestCaseSource(nameof(Source))]
        public void TestForecastTime(int forecastDays, ForecastTimeModel expectedModel)
        {
            var contactCreator = new Mock<IContactCreator>(MockBehavior.Strict).Object;
            InteractorCreatePost interactor = new InteractorCreatePost(new CreatePostController(contactCreator, s => It.IsAny<DataModelPost>(), 
                DataService.NotificationCenter, DataService.RepositoryController.RepoQc),
                DataService.RepositoryController.RepositoryCreatePost, DataService.RepositoryController.RepositoryUserAuth);

            MethodInfo dynMethod = typeof(InteractorCreatePost).GetMethod("CreateForecastTimeModel", BindingFlags.NonPublic | BindingFlags.Instance);
            DateTime currentDate = new DateTime(2017, 8, 7, 13, 0, 0);
            
            expectedModel = GetHoursMinutes(expectedModel);

            ForecastTimeModel actualModel = dynMethod.Invoke(interactor, new object[] { forecastDays, currentDate }) as ForecastTimeModel;

            Assert.AreEqual(expectedModel, actualModel);
        }

        private ForecastTimeModel GetHoursMinutes(ForecastTimeModel model)
        {
            model.Hours = SocialTrading.Locale.Localization.Lang.Hours;
            model.Minutes.AddRange(new Func<List<string>>(() =>
            {
                var minutes = new List<string>();

                for (int i = 0; i < 60; i++)
                {
                    minutes.Add((i < 10 ? "0" + i : i.ToString()) + " " + SocialTrading.Locale.Localization.Lang.MinutesEnding);
                }

                return minutes;
            }).Invoke());

            return model;
        }
    }
}

