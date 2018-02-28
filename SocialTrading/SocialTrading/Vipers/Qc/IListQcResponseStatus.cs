using System.Collections.Generic;

namespace SocialTrading.Vipers.Qc
{
    public interface IListQcResponseStatus
    {
        EQcResponseStatus Status { get; }
        HashSet<string> QcUpdatedList { get; set; }
    }
}