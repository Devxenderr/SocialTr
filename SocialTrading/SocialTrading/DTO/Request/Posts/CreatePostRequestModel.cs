using System;
using System.Collections.Generic;

using Newtonsoft.Json.Linq;

using SocialTrading.DTO.Request.Posts;
using SocialTrading.Tools.Enumerations;

namespace SocialTrading.DTO.Request
{
    public class CreatePostRequestModel :  CreateSimplePostRequestModel
    {
        protected string Quote { get; private set; }
        protected string Recommend { get; private set; }
        protected string Price { get; private set; }
        protected string Forecast { get; private set; }


        public CreatePostRequestModel(string quote, string market, EBuySell recommend, string price, EAccessMode access, string content, string forecast, string image = "") 
            : base(market, access, content, image)
        {
            Forecast = GetStringForecastTime(forecast);
            CreatePostRequestModelMainPart(quote, market, recommend, price, access, content, Forecast, image);
        }

        public CreatePostRequestModel(string quote, string market, EBuySell recommend, string price, EAccessMode access, string content, EForecastTime forecast, string image = "") 
            : base(market, access, content, image)
        {
            Forecast = GetStringForecastTime(forecast);
            CreatePostRequestModelMainPart(quote, market, recommend, price, access, content, Forecast, image);
        }

        private void CreatePostRequestModelMainPart( string quote, string market, EBuySell recommend, string price, EAccessMode access, string content, string forecast, string file)
        {
            if (string.IsNullOrWhiteSpace(file) && string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentNullException(nameof(file) + " or " + nameof(content));
            }
            
            if (recommend == EBuySell.None || access == EAccessMode.None || string.IsNullOrWhiteSpace(price) ||
                string.IsNullOrWhiteSpace(forecast) || string.IsNullOrWhiteSpace(quote))
            {
                throw new ArgumentNullException(nameof(recommend) + " or " + nameof(access) + " or " + nameof(price) + " or " + nameof(forecast) + " or " + nameof(quote));
            }

            Quote = quote?.Replace("/", string.Empty);
            Recommend = recommend == EBuySell.None ? string.Empty : recommend.ToString();
            Price = price;
            Forecast = forecast;
        }

        public override JObject PerformQuery()
        {
            var json = base.PerformQuery();

            json["quote"] = Quote;
            json["recommend"] = Recommend;
            json["forecast"] = Forecast;

            if (!string.IsNullOrWhiteSpace(Price))
            {
                json["price"] = Price;
            }

            return json;
        }


        private string GetStringForecastTime(EForecastTime time)
        {
            var result = string.Empty;

            if (time == EForecastTime.None || time == EForecastTime.Other)
            {
                return result;
            }

            var dateTime = GetForecastTime(time);
            //TODO needs tests
            result = dateTime.ToString("yyyy-MM-dd") + "T" + dateTime.ToString("HH:mm:ss") + ".000Z";

            return result;
        }

        private DateTime GetForecastTime(EForecastTime time)
        {
            var forecast = DateTime.UtcNow;

            switch (time)
            {
                case EForecastTime.Minute15:
                    forecast = forecast.AddMinutes(15);
                    break;
                case EForecastTime.Minute30:
                    forecast = forecast.AddMinutes(30);
                    break;
                case EForecastTime.Hour1:
                    forecast = forecast.AddHours(1);
                    break;
                case EForecastTime.Hour4:
                    forecast = forecast.AddHours(4);
                    break;
                case EForecastTime.Hour8:
                    forecast = forecast.AddHours(8);
                    break;
                case EForecastTime.Hour24:
                    forecast = forecast.AddDays(1);
                    break;
                case EForecastTime.Week1:
                    forecast = forecast.AddDays(7);
                    break;

                default:
                    return forecast;
            }

            return forecast;
        }

        private string GetStringForecastTime(string forecast)
        {
            var result = string.Empty;

            if (string.IsNullOrWhiteSpace(forecast))
            {
                return result;
            }

            var date = forecast.Split(' ')[0];
            var time = forecast.Split(' ')[1];
            
            result = date + "T" + time + ":00.000Z";

            return result;
        }

        public override bool Equals(object obj)
        {
            var result = false;

            var model = obj as CreatePostRequestModel;

            if (obj == null)
            {
                return result;
            }

            if ( base.Equals(obj) &&
                Forecast == model?.Forecast && Price == model?.Price && Quote == model?.Quote && Recommend == model?.Recommend)
            {
                result = true;
            }

            return result;
        }

        public override int GetHashCode()
        {
            var hashCode = 229093474;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Quote);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Market);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Recommend);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Price);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Access);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Image);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Content);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Forecast);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ApiPath);
            hashCode = hashCode * -1521134295 + ResponseModule.GetHashCode();
            hashCode = hashCode * -1521134295 + Method.GetHashCode();
            return hashCode;
        }
    }
}
