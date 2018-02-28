using NUnit.Framework;
using SocialTrading.Service;
using System;

namespace MASTTests
{
    [TestFixture]
    public class TimeTest
    {
        private DateTimeConverter _dateTimeConverter;
        [SetUp]
        public void SetUp()
        {
            _dateTimeConverter = new DateTimeConverter();
        }
        [Author("Ekaterina Zaiets")]
        [TestCase("2017-11-06T11:21:56.041Z", 2017, 11, 06, 11, 21, 56, 041)]
        [TestCase("2017-11-06T14:21:55.23Z", 2017, 11, 06, 14, 21, 55, 230)]
        [TestCase("2017-07-24T00:00:00.00Z", 2017, 07, 24, 00, 00, 00, 000)]
        [TestCase("2017-07-25T00:00:00.00Z", 2017, 07, 25, 00, 00, 00, 000)]
        [TestCase("2017-07-24T23:59:30.00Z", 2017, 07, 24, 23, 59, 30, 000)]
        [TestCase("2017-07-24T23:59:01.00Z", 2017, 07, 24, 23, 59, 01, 000)]
        [TestCase("2017-07-24T23:59:00.00Z", 2017, 07, 24, 23, 59, 00, 000)]
        [TestCase("2017-07-24T23:55:10.00Z", 2017, 07, 24, 23, 55, 10, 000)]
        [TestCase("2017-07-24T23:00:01.00Z", 2017, 07, 24, 23, 00, 01, 000)]
        [TestCase("2017-07-24T23:00:00.00Z", 2017, 07, 24, 23, 00, 00, 000)]
        [TestCase("2017-07-24T22:14:59.00Z", 2017, 07, 24, 22, 14, 59, 000)]
        [TestCase("2017-07-24T22:00:00.00Z", 2017, 07, 24, 22, 00, 00, 000)]
        [TestCase("2017-07-24T00:00:01.00Z", 2017, 07, 24, 00, 00, 01, 000)]
        [TestCase("2017-07-24T00:00:00.00Z", 2017, 07, 24, 00, 00, 00, 000)]
        [TestCase("2017-01-23T15:15:30.00Z", 2017, 01, 23, 15, 15, 30, 000)]
        [TestCase("2017-02-23T15:15:30.00Z", 2017, 02, 23, 15, 15, 30, 000)]
        [TestCase("2017-03-23T15:15:30.00Z", 2017, 03, 23, 15, 15, 30, 000)]
        [TestCase("2017-04-23T15:00:10.00Z", 2017, 04, 23, 15, 00, 10, 000)]
        [TestCase("2017-05-23T15:15:30.00Z", 2017, 05, 23, 15, 15, 30, 000)]
        [TestCase("2017-06-23T15:15:30.00Z", 2017, 06, 23, 15, 15, 30, 000)]
        [TestCase("2017-07-23T15:15:30.00Z", 2017, 07, 23, 15, 15, 30, 000)]
        [TestCase("2017-08-23T15:15:30.00Z", 2017, 08, 23, 15, 15, 30, 000)]
        [TestCase("2017-09-23T15:12:30.00Z", 2017, 09, 23, 15, 12, 30, 000)]
        [TestCase("2017-10-23T15:15:30.00Z", 2017, 10, 23, 15, 15, 30, 000)]
        [TestCase("2017-11-23T15:15:30.00Z", 2017, 11, 23, 15, 15, 30, 000)]
        [TestCase("2017-11-23T15:05:30.00Z", 2017, 11, 23, 15, 05, 30, 000)]
        [TestCase("2017-12-23T00:15:30.00Z", 2017, 12, 23, 00, 15, 30, 000)]

        [TestCase("2010-12-23T15:15:30.00Z", 2010, 12, 23, 15, 15, 30, 000)]
        [TestCase("2016-07-25T00:00:00.00Z", 2016, 07, 25, 00, 00, 00, 000)]
        [TestCase("2016-07-24T23:59:59.00Z", 2016, 07, 24, 23, 59, 59, 000)]
        [TestCase("2016-05-24T23:59:59.00Z", 2016, 05, 24, 23, 59, 59, 000)]
        public void ConvertToDateTimeTest(string time, int year, int momth, int day, int hour, int minute, int seconds, int millisec)
        {
            DateTime expected = new DateTime(year, momth, day, hour, minute, seconds, millisec).ToLocalTime();
            DateTime actual = _dateTimeConverter.Convert(time);
            Assert.AreEqual(expected, actual);
        }
    }
}
