using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using NUnit.Framework;

using SocialTrading.Service.Repositories;
using SocialTrading.Tools.Exceptions.Parse;

namespace MASTTests.Repository
{
    [TestFixture, Author("Nickolay Liadov")]
    public class RepositoryCountriesTests
    {
        private RepositoryCountries repositoryCountries;

        [Test]
        public void CtorTestEmpty()
        {
            var json = "{}";

            repositoryCountries = new RepositoryCountries(json);

            Dictionary<string, string> expectedDictionary = new Dictionary<string, string>();

            var actual = repositoryCountries.GetType().GetRuntimeFields().First(f => f.Name.Equals("_countriesDict"))
                .GetValue(repositoryCountries) as Dictionary<string, string>;

            CollectionAssert.AreEqual(expectedDictionary, actual);
        }

        [Test]
        public void CtorTestOneElement()
        {
            var json = "{\"AD\": \"Андорра\"}";

            repositoryCountries = new RepositoryCountries(json);

            Dictionary<string, string> expectedDictionary = new Dictionary<string, string>();
            expectedDictionary.Add("AD", "Андорра");

            var actual = repositoryCountries.GetType().GetRuntimeFields().First(f => f.Name.Equals("_countriesDict"))
                .GetValue(repositoryCountries) as Dictionary<string, string>;

            CollectionAssert.AreEqual(expectedDictionary, actual);
        }

        [Test]
        public void CtorTestTwo()
        {
            var json = "{\"AD\": \"Андорра\",\"AE\": \"Объединенные Арабские Эмираты\"}";

            repositoryCountries = new RepositoryCountries(json);

            Dictionary<string, string> expectedDictionary = new Dictionary<string, string>();
            expectedDictionary.Add("AD", "Андорра");
            expectedDictionary.Add("AE", "Объединенные Арабские Эмираты");

            var actual = repositoryCountries.GetType().GetRuntimeFields().First(f => f.Name.Equals("_countriesDict"))
                .GetValue(repositoryCountries) as Dictionary<string, string>;

            CollectionAssert.AreEqual(expectedDictionary, actual);
        }
        [Test]
        public void CtorTestManyElements()
        {
            var json = "{\"AD\": \"Андорра\",\"AE\": \"Объединенные Арабские Эмираты\",\"AB\": \"Объединенные Арабские Эмираты\",\"AF\": \"Объединенные Арабские Эмираты\",\"AR\": \"Объединенные Арабские Эмираты\"}";

            repositoryCountries = new RepositoryCountries(json);

            Dictionary<string, string> expectedDictionary = new Dictionary<string, string>();
            expectedDictionary.Add("AD", "Андорра");
            expectedDictionary.Add("AE", "Объединенные Арабские Эмираты");
            expectedDictionary.Add("AB", "Объединенные Арабские Эмираты");
            expectedDictionary.Add("AF", "Объединенные Арабские Эмираты");
            expectedDictionary.Add("AR", "Объединенные Арабские Эмираты");

            var actual = repositoryCountries.GetType().GetRuntimeFields().First(f => f.Name.Equals("_countriesDict"))
                .GetValue(repositoryCountries) as Dictionary<string, string>;

            CollectionAssert.AreEqual(expectedDictionary, actual);
        }

        [Test]
        public void CtorTestJsonParseException()
        {
            var json = "\"AD\": \"Андорра\"}";
            Assert.Throws<ParseException>(() => new RepositoryCountries(json));
        }

        [Test]
        public void TuplesTest()
        {
            var json = "{}";
            repositoryCountries = new RepositoryCountries(json);
            var actual = repositoryCountries.GetNames();
            List<Tuple<string, string>> expactedTuples = new List<Tuple<string, string>>();
            Assert.AreEqual(expactedTuples, actual);
        }

        [Test]
        public void TuplesOneTest()
        {
            var json = "{\"AD\": \"Андорра\"}";
            repositoryCountries = new RepositoryCountries(json);
            var actual = repositoryCountries.GetNames();
            List<Tuple<string, string>> expactedTuples = new List<Tuple<string, string>>();
            expactedTuples.Add(Tuple.Create("AD", "Андорра"));
            Assert.AreEqual(expactedTuples, actual);
        }

        [Test]
        public void TuplesTwoTest()
        {
            var json = "{\"AD\": \"Андорра\",\"AE\": \"Объединенные Арабские Эмираты\"}";
            repositoryCountries = new RepositoryCountries(json);
            var actual = repositoryCountries.GetNames();
            List<Tuple<string, string>> expactedTuples = new List<Tuple<string, string>>();
            expactedTuples.Add(Tuple.Create("AD", "Андорра"));
            expactedTuples.Add(Tuple.Create("AE", "Объединенные Арабские Эмираты"));
            Assert.AreEqual(expactedTuples, actual);
        }

        [Test]
        public void TuplesManyTest()
        {
            var json = "{\"AD\": \"Андорра\",\"AB\": \"Андорра\",\"AG\": \"Андорра\",\"AR\": \"Андорра\",\"AS\": \"Андорра\"}";
            repositoryCountries = new RepositoryCountries(json);
            var actual = repositoryCountries.GetNames();
            List<Tuple<string, string>> expactedTuples = new List<Tuple<string, string>>();
            expactedTuples.Add(Tuple.Create("AD", "Андорра"));
            expactedTuples.Add(Tuple.Create("AB", "Андорра"));
            expactedTuples.Add(Tuple.Create("AG", "Андорра"));
            expactedTuples.Add(Tuple.Create("AR", "Андорра"));
            expactedTuples.Add(Tuple.Create("AS", "Андорра"));
            Assert.AreEqual(expactedTuples, actual);
        }
    }
}
