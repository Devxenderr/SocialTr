using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using NUnit.Framework;

using SocialTrading.Tools;
using SocialTrading.Tools.Interfaces;

namespace MASTTests.Tools
{
    [TestFixture(Author = "Vladimir Viktorov", Category = "ISearchHelper tests", Description = "Unit tests for ISearchHelper")]
    public class SearchHelperTests
    {
        private ISearchHelper<string> _searchHelper;
        private List<Tuple<string, string>> _generaList;

        [SetUp]
        public void Setup()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SecuritySettingsWithRateMock.json");

            var dictStr = File.ReadAllText(filePath);
            _generaList = ConvertDict(JsonConvert.DeserializeObject<JObject>(dictStr));

            _searchHelper = new SearchHelper<string>();
        }

        private List<Tuple<string, string>> ConvertDict(JObject deserializeObject)
        {
            var resList = new List<Tuple<string, string>>();
            foreach (var entry in deserializeObject)
            {
                resList.Add(Tuple.Create(entry.Key, (string)entry.Value["Name"]));
            }
            return resList;
        }

        [Test]
        public void NullListTest()
        {
            Assert.Throws<ArgumentNullException>(() => _searchHelper.Search(null, ""));
        }
        [TestCase(null)]
        [TestCase("")]
        public void NullSearchStringTest(string searchStr)
        {
            var list = new List<Tuple<string, string>>();
            Assert.Throws<ArgumentNullException>(() => _searchHelper.Search(_generaList, searchStr));
        }

        [TestCase("AUDUSD", new[] { "AUDUSD" })]
        [TestCase("AUD USD", new[] { "AUDUSD" })]
        [TestCase("AUD/USD", new[] { "AUDUSD" })]
        [TestCase("AUD/UPD", new string [0])]//not found
        [TestCase("AUD", new[]
        {
            "SaudElicrto", "AUDSEK", "SaudiKayan", "EURAUD", "SaudiInvBank", "AUDCHF",
            "AUDSGD", "AUDUSD", "GBPAUD", "SaudiBriBank", "SaudiBasic", "AUDNOK",
            "AUDCAD", /*"SPIAUD",*/ "Audi", "AUDNZD", "AUDHUF", "AUDJPY"
        })]
        [TestCase(" AUD", new[]
        {
            "SaudElicrto", "AUDSEK", "SaudiKayan", "EURAUD", "SaudiInvBank", "AUDCHF",
            "AUDSGD", "AUDUSD", "GBPAUD", "SaudiBriBank", "SaudiBasic", "AUDNOK",
            "AUDCAD",/* "SPIAUD",*/ "Audi", "AUDNZD", "AUDHUF", "AUDJPY"
        })]
        [TestCase("AUD ", new[]
        {
            "SaudElicrto", "AUDSEK", "SaudiKayan", "EURAUD", "SaudiInvBank", "AUDCHF",
            "AUDSGD", "AUDUSD", "GBPAUD", "SaudiBriBank", "SaudiBasic", "AUDNOK",
            "AUDCAD", /*"SPIAUD",*/ "Audi", "AUDNZD", "AUDHUF", "AUDJPY"
        })]
        [TestCase("AUD/", new[]
        {
            "SaudElicrto", "AUDSEK", "SaudiKayan", "EURAUD", "SaudiInvBank", "AUDCHF",
            "AUDSGD", "AUDUSD", "GBPAUD", "SaudiBriBank", "SaudiBasic", "AUDNOK",
            "AUDCAD",/* "SPIAUD",*/ "Audi", "AUDNZD", "AUDHUF", "AUDJPY"
        })]
        [TestCase("aud", new[]
        {
            "SaudElicrto", "AUDSEK", "SaudiKayan", "EURAUD", "SaudiInvBank", "AUDCHF",
            "AUDSGD", "AUDUSD", "GBPAUD", "SaudiBriBank", "SaudiBasic", "AUDNOK",
            "AUDCAD",/* "SPIAUD",*/ "Audi", "AUDNZD", "AUDHUF", "AUDJPY"
        })]
        [TestCase(" aud ", new[]
        {
            "SaudElicrto", "AUDSEK", "SaudiKayan", "EURAUD", "SaudiInvBank", "AUDCHF",
            "AUDSGD", "AUDUSD", "GBPAUD", "SaudiBriBank", "SaudiBasic", "AUDNOK",
            "AUDCAD", /*"SPIAUD",*/ "Audi", "AUDNZD", "AUDHUF", "AUDJPY"
        })]
        [TestCase("gold", new[] { "XAUTRY", "XAUUSD", "GoldmanSach" })]
        [TestCase("aud AUD", new string [0])] //not found
        [TestCase("aud,usd", new[] { "AUDUSD" })]
        [TestCase("aud!@#$%^&*()_+-=?><|'\"\"~` AUD", new string[0])] //not found
        [TestCase("aud!@#$%^&*()_+-=?><|'\"\"~` usd", new[] { "AUDUSD" })]
        [TestCase("áÁéÉíÍóÓúÚüÜÑ!@#$%^&*()_+-=?><|'\"\"~` usd", new string[0])] //not found
        [TestCase("يبشس!@#$%^&*()_+-=?><|'\"\"~` usd", new string[0])] //not found
        [TestCase("ASX 200", new[] { "SPIAUD" })]
        [TestCase("200", new[] { "SPIAUD" })]
        [TestCase("audusd", new[] { "AUDUSD" })]
        public void PositiveTests(string searchStr, Array expList)
        {
            var actualRes = _searchHelper.Search(_generaList, searchStr).Select(tuple => tuple.Item1).ToArray();
            CollectionAssert.AreEquivalent(expList, actualRes);
        }

        /*
        public class FixtureData
        {
            public static IEnumerable PositiveParams
            {
                get
                {
                    yield return new TestFixtureData(
                        new List<Tuple<string, string>>(){ Tuple.Create("key1", "")}
                        );
                }
            }
        }
        */
    }
}