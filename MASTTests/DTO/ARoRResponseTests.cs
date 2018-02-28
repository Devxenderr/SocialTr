using System;
using System.Linq;
using System.Collections;

using NUnit.Framework;

using SocialTrading.DTO.Response;

namespace MASTTests.DTO
{
    [TestFixture, Author("Gerashchenko V.V.")]
    public class ARoRResponseTests
    {
        [Test]
        [TestCaseSource(typeof(DataTests), nameof(DataTests.StringArrayData))]
        public void Constructor_Positive(string[] errors, string testName)
        {
            ARoRResponse actResponse = new RoRResponseMock(errors);

            CollectionAssert.AreEqual(errors.ToList(), actResponse.Errors);
        }

        [Test]
        public void Constructor_Negative_NullArrray()
        {
            Assert.Throws<ArgumentException>(() => new RoRResponseMock(null));
        }

        [Test]
        [TestCaseSource(typeof(DataTests), nameof(DataTests.ArraysWithNullData))]
        public void Constructor_Negative_ArrrayWithNull(string[] errors, string testName)
        {
            Assert.Throws<ArgumentException>(() => new RoRResponseMock(errors));
        }

        [Test]
        [TestCaseSource(typeof(DataTests), nameof(DataTests.StringArrayData))]
        public void ARoRResponse_EqualsTest(string[] errors, string testName)
        {
            ARoRResponse actModel1 = new RoRResponseMock(errors);
            ARoRResponse actModel2 = new RoRResponseMock(errors);

            Assert.AreEqual(actModel1, actModel2);
        }

        [Test]
        [TestCaseSource(typeof(DataTests), nameof(DataTests.StringArrayForNotEqualsData))]
        public void ARoRResponse_NotEqualsSameModelsTest(string[] errors1, string[] errors2, string testName)
        {
            ARoRResponse actModel1 = new RoRResponseMock(errors1);
            ARoRResponse actModel2 = new RoRResponseMock(errors2);

            Assert.AreNotEqual(actModel1, actModel2);
        }

        [Test]
        public void ARoRResponse_NotEqualsDifferentModelsTest()
        {
            var actModel = new RoRResponseMock(new[] { "111" });

            Assert.AreNotEqual(actModel, new object());
            Assert.AreNotEqual(actModel, "123");
            Assert.AreNotEqual(actModel, true);
            Assert.AreNotEqual(actModel, int.MaxValue);
            Assert.AreNotEqual(actModel, new[] { "111" });
        }

        private class DataTests
        {
            public static IEnumerable StringArrayData
            {
                get
                {
                    yield return new TestCaseData(new string[] {}, "0");
                    yield return new TestCaseData(new[] { "" }, "1");
                    yield return new TestCaseData(new[] { "123", "321" }, "2");
                    yield return new TestCaseData(new[] { "123", "321", "555" }, "3");
                    yield return new TestCaseData(new[] { "111", "222", "333", "444", "555" }, "4");
                }
            }

            public static IEnumerable ArraysWithNullData
            {
                get
                {
                    yield return new TestCaseData(new string[] { null }, "0");
                    yield return new TestCaseData(new[] { "", null }, "1");
                    yield return new TestCaseData(new[] { null, "321" }, "2");
                    yield return new TestCaseData(new[] { "123", null, "555" }, "3");
                    yield return new TestCaseData(new[] { "111", "222", "333", null, "555" }, "4");
                }
            }

            public static IEnumerable StringArrayForNotEqualsData
            {
                get
                {
                    yield return new TestCaseData(new string[] { }, new[] { "" },                                        "0");
                    yield return new TestCaseData(new[] { "", "", "" }, new string[] {  },                               "1");
                    yield return new TestCaseData(new[] { "" }, new[] { "", "" },                                 "2");
                    yield return new TestCaseData(new[] { "123" }, new[] { "321" },                               "3");
                    yield return new TestCaseData(new[] { "111", "222", "333" }, new[] { "444", "222", "333" },   "4");
                }
            }
        }

        private class RoRResponseMock : ARoRResponse
        {
            public RoRResponseMock(string[] errors) : base(errors)
            {
            }
        }
    }
}
