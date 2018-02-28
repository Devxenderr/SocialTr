using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using SocialTrading.Tools.Exceptions.Parse;
using SocialTrading.Service.Interfaces.Repository;

namespace SocialTrading.Service.Repositories
{
    public class RepositoryCountries : IRepositoryCountries
    {
        private readonly Dictionary<string, string> _countriesDict;

        public RepositoryCountries(string countriesJSON)
        {
            try
            {
                _countriesDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(countriesJSON);
            }
            catch (Exception e)
            {
                throw new ParseException(e.Message);
            }
        } 

        public List<Tuple<string, string>> GetNames()
        {
            var tuples = new List<Tuple<string, string>>();

            foreach (var country in _countriesDict)
            {
                tuples.Add(Tuple.Create(country.Key, country.Value));
            }
            return tuples;
        }
    }
}
