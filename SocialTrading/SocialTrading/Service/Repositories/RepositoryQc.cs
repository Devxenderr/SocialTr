using System;
using System.Linq;
using System.Collections.Generic;

using SocialTrading.DTO;
using SocialTrading.DTO.Response.Qc;
using SocialTrading.Service.Interfaces.Repository;

namespace SocialTrading.Service.Repositories
{
    public class RepositoryQc : IRepositoryQc, IRepositoryNames
    {
        private static RepositoryQc _repositoryQc;

        private Lazy<Dictionary<string, DataModelQc>> _quotations;
        private Lazy<HashSet<string>> _updatedQuotations;        

        private RepositoryQc()
        {
            Clear();
        }

        public static RepositoryQc GetInstance()
        {
            return _repositoryQc ?? (_repositoryQc = new RepositoryQc());
        }

        public void Clear()
        {
            _quotations = null;
            _updatedQuotations = null;
        }

        public List<DataModelQc> Quotations
        {
            get => _quotations?.Value.Values.ToList();
            private set
            {
                lock (this)
                {
                    value.Sort();
                    _quotations = new Lazy<Dictionary<string, DataModelQc>>(() => value.ToDictionary(key => key.QcName));
                }
            }
        }

        public HashSet<string> UpdatedQuotations
        {
            get => _updatedQuotations?.Value ?? new HashSet<string>(_quotations?.Value.Keys.ToList());
            private set
            {
                _updatedQuotations?.Value.Clear();
                _updatedQuotations = null;
                _updatedQuotations = new Lazy<HashSet<string>>(() => value);
            }
        }


        public void UpdateQc(List<DataModelQc> quotations)
        {
            lock (this)
            {
                UpdatedQuotations = new HashSet<string>(quotations.Select(item => item.QcName).ToList());

                if (_quotations == null)
                {
                    Quotations = quotations;
                    DataService.NotificationCenter.QcDataIncome?.Invoke(UpdatedQuotations);
                    return;
                }

                foreach (var item in quotations)
                {
                    _quotations.Value[item.QcName] = item;
                }

                DataService.NotificationCenter.QcDataIncome?.Invoke(UpdatedQuotations);
            }
        }

        public DataModelQc GetQcData(string quote)
        {
            if (_quotations?.Value == null)
            {
                return null;
            }
            lock (this)
            {
                _quotations.Value.TryGetValue(quote, out var result);

                return result;           
            }
        }
        
        public QcBidAsk GetQcBidAsk(string quote)
        {
            lock (this)
            {                
                _quotations.Value.TryGetValue(quote, out var qc);

                return string.IsNullOrWhiteSpace(quote) || qc == null ? null : new QcBidAsk(quote, qc.QcBid, qc.QcAsk); 
            }
        }

        public List<Tuple<string, string>> GetNames()
        {
            var result = new List<Tuple<string, string>>();

            lock (this)
            {
                foreach (var keyValue in _quotations.Value)
                {
                    result.Add(Tuple.Create(keyValue.Key, keyValue.Value.QcName));
                }
            }
            
            return result;
        }
    }
}
