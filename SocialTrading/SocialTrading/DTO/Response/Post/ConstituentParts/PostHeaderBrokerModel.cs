using SocialTrading.DTO.Response.Qc;
using System.Collections.Generic;

namespace SocialTrading.DTO.Response.Post.ConstituentParts
{
    public class PostHeaderBrokerModel
    {
        public float Difference { get; set; }
        public bool IsCurrentPriceIncreasing { get; set; }
        public bool IsDifferencePositive { get; set; }
        public string CurrentPriceBid { get; set; }
        public string CurrentPriceAsk { get; set; }
        public string CurrentPrice { get; set; }
        public int TickSize { get; set; }
        public int Rounding { get; set; }


        public PostHeaderBrokerModel()
        {
        }

        public PostHeaderBrokerModel(DataModelQc brokerData)
        {
            if (brokerData != null)
            {
                Difference = brokerData.QcDiff;
                CurrentPriceBid = brokerData.QcBid;
                CurrentPriceAsk = brokerData.QcAsk;
            }
            
            TickSize = 10;
            Rounding = 10000;
        }


        public void Update(DataModelQc brokerData)
        {
            if (brokerData == null)
            {
                return;
            }

            Difference = brokerData.QcDiff;
            CurrentPriceBid = brokerData.QcBid;
            CurrentPriceAsk = brokerData.QcAsk;
        }


        public override bool Equals(object obj)
        {
            var model = obj as PostHeaderBrokerModel;
            return model != null &&
                   Difference == model.Difference &&
                   IsCurrentPriceIncreasing == model.IsCurrentPriceIncreasing &&
                   IsDifferencePositive == model.IsDifferencePositive &&
                   CurrentPriceBid == model.CurrentPriceBid &&
                   CurrentPriceAsk == model.CurrentPriceAsk &&
                   CurrentPrice == model.CurrentPrice &&
                   TickSize == model.TickSize &&
                   Rounding == model.Rounding;
        }

        public override int GetHashCode()
        {
            var hashCode = 1689275518;
            hashCode = hashCode * -1521134295 + Difference.GetHashCode();
            hashCode = hashCode * -1521134295 + IsCurrentPriceIncreasing.GetHashCode();
            hashCode = hashCode * -1521134295 + IsDifferencePositive.GetHashCode();
            hashCode = hashCode * -1521134295 + CurrentPriceBid.GetHashCode();
            hashCode = hashCode * -1521134295 + CurrentPriceAsk.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CurrentPrice);
            hashCode = hashCode * -1521134295 + TickSize.GetHashCode();
            hashCode = hashCode * -1521134295 + Rounding.GetHashCode();
            return hashCode;
        }
    }
}
