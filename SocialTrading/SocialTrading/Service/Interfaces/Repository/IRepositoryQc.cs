using System.Collections.Generic;

using SocialTrading.DTO.Response.Qc;

namespace SocialTrading.Service.Interfaces.Repository
{
    public interface IRepositoryQc : IRepositoryQcPrice
    {
        List<DataModelQc> Quotations { get; }
        HashSet<string> UpdatedQuotations { get; }

        void UpdateQc(List<DataModelQc> quotations);
        DataModelQc GetQcData(string quote);
    }
}