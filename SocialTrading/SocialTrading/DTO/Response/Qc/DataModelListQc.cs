using System.Collections.Generic;

using SocialTrading.Vipers.Qc;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Interfaces;

namespace SocialTrading.DTO.Response.Qc
{
    public class DataModelListQc : IModel, IListQcResponseStatus
    {
        public EQcResponseStatus Status { get; set; }
        public HashSet<string> QcUpdatedList { get; set; }
        public EControllerStatus ControllerStatus { get; set; }
    }
}
