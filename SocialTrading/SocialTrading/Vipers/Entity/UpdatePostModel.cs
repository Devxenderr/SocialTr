using System;
using SocialTrading.Tools;
using SocialTrading.Tools.Enumerations;

using System.Collections.Generic;
using SocialTrading.Service;

namespace SocialTrading.Vipers.Entity
{
    public class UpdatePostModel
    {
        public bool IsSimple { get; }

        public string Id { get; } 
        public string Quote { get; }
        public string Forecast { get; }
        public string Price { get; }
        public string Recommend { get; }

        public EAccessMode Access { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }

        public UpdatePostModel(bool isSimple, string id, string quote, string forecast, string price, string recommend, string access, string image, string content)
        {
            IsSimple = isSimple;
            Id = id;
            Quote = quote;

            Forecast = new DateTimeConverter().Convert(forecast).ToString("yyyy-MM-dd hh:mm");
            Price = price;
            Enum.TryParse(recommend, true, out EBuySell buySell);
            Recommend = buySell.GetLocaleStringFromEnum();
            Enum.TryParse(access, true, out EAccessMode accessMode);
            Access = accessMode;
            Image = image;
            Content = content;
        }

        public override bool Equals(object obj)
        {
            var model = obj as UpdatePostModel;
            return model != null &&
                   IsSimple == model.IsSimple &&
                   Id == model.Id &&
                   Quote == model.Quote &&
                   Forecast == model.Forecast &&
                   Price == model.Price &&
                   Recommend == model.Recommend &&
                   Access == model.Access &&
                   Image == model.Image &&
                   Content == model.Content;
        }

        public override int GetHashCode()
        {
            var hashCode = -1079360070;
            hashCode = hashCode * -1521134295 + IsSimple.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Quote);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Forecast);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Price);
            hashCode = hashCode * -1521134295 + Recommend.GetHashCode();
            hashCode = hashCode * -1521134295 + Access.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Image);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Content);
            return hashCode;
        }
    }
}
