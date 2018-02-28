using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Interfaces;

namespace SocialTrading.DTO
{
    public class QcBidAsk : IModel
    {
        public string QcName { get; }
        public string QcBid { get; }
        public string QcAsk { get; }

        public EControllerStatus ControllerStatus { get; }


        public QcBidAsk(string qcName, string qcBid, string qcAsk)
        {
            QcName = qcName;
            QcAsk = qcAsk;
            QcBid = qcBid;
        }

    }
}
