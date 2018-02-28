using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Interfaces;

namespace SocialTrading.DTO.Response.Qc
{
    public class DataModelQc : IModel, IComparable
    {
        public int QcId { get; private set; }
        public string QcName { get; private set; }
        public string QcAsk { get; private set; }
        public float QcSSV { get; private set; }
        public string QcBid { get; private set; }
        public float QcDiff { get; private set; }
        public float QcRate { get; private set; }
        public float QcMin { get; private set; }
        public float QcMax { get; private set; }
        public string QcSession { get; private set; }
        public float QcESV { get; private set; }
        public long QcPer { get; private set; }
        public long QcTimestamp { get; private set; }

        public EControllerStatus ControllerStatus { get; }


        [JsonConstructor]
        public DataModelQc(int Id, string Name, string Ask, float SSV, string Bid, float Diff, float Rate, float Min, float Max, string Sess, float ESV, long Per, long Timestamp)
        {
            QcId = Id;
            QcName = Name ?? string.Empty;
            QcAsk = Ask;
            QcSSV = SSV;
            QcBid = Bid;
            QcDiff = Diff;
            QcRate = Rate;
            QcMin = Min;
            QcMax = Max;
            QcSession = Sess ?? string.Empty;
            QcESV = ESV;
            QcPer = Per;
            QcTimestamp = Timestamp;
        }

        public override bool Equals(object obj)
        {
            var qc = obj as DataModelQc;
            return qc != null &&
                   QcId == qc.QcId &&
                   QcName == qc.QcName &&
                   QcAsk == qc.QcAsk &&
                   QcSSV == qc.QcSSV &&
                   QcBid == qc.QcBid &&
                   QcDiff == qc.QcDiff &&
                   QcRate == qc.QcRate &&
                   QcMin == qc.QcMin &&
                   QcMax == qc.QcMax &&
                   QcSession == qc.QcSession &&
                   QcESV == qc.QcESV &&
                   QcPer == qc.QcPer &&
                   QcTimestamp == qc.QcTimestamp;
        }

        public override int GetHashCode()
        {
            var hashCode = 1235789315;
            hashCode = hashCode * -1521134295 + QcId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(QcName);
            hashCode = hashCode * -1521134295 + QcAsk.GetHashCode();
            hashCode = hashCode * -1521134295 + QcSSV.GetHashCode();
            hashCode = hashCode * -1521134295 + QcBid.GetHashCode();
            hashCode = hashCode * -1521134295 + QcDiff.GetHashCode();
            hashCode = hashCode * -1521134295 + QcRate.GetHashCode();
            hashCode = hashCode * -1521134295 + QcMin.GetHashCode();
            hashCode = hashCode * -1521134295 + QcMax.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(QcSession);
            hashCode = hashCode * -1521134295 + QcESV.GetHashCode();
            hashCode = hashCode * -1521134295 + QcPer.GetHashCode();
            hashCode = hashCode * -1521134295 + QcTimestamp.GetHashCode();
            return hashCode;
        }

        public int CompareTo(object obj)
        {
            if (obj is DataModelQc model)
            {
                return string.Compare(QcName, model.QcName, StringComparison.Ordinal);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }
}
