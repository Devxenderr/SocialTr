using System.Collections.Generic;

namespace SocialTrading.Vipers.Entity
{
    public class ForecastTimeModel
    {
        public List<string> Years       { get; set; }
        public List<int[]>  MonthsRange { get; set; }
        public List<int[]>  DaysRange   { get; set; }
        public List<string> Hours       { get; set; }
        public List<string> Minutes     { get; set; }

        public string DefaultYear => Years[0];
        public string DefaultMonth => Locale.Localization.Lang.Months[MonthsRange[0][0] - 1];
        public string DefaultDay => DaysRange[0][0].ToString();
        public string DefaultHour => Locale.Localization.Lang.Hours[System.DateTime.Now.Hour];
        public string DefaultMinute => System.DateTime.Now.Minute + " " + Locale.Localization.Lang.MinutesEnding;


        public ForecastTimeModel()
        {
            Years = new List<string>();
            MonthsRange = new List<int[]>();
            DaysRange = new List<int[]>();
            Hours = new List<string>();
            Minutes = new List<string>();
        }


        public List<string> GetDaysByMonth(int month)
        {
            var days = new List<string>();
            var daysRange = DaysRange[month];
            
            for (int i = daysRange[0]; i <= daysRange[1]; i++)
            {
                days.Add(i.ToString());
            }

            return days;
        }

        public List<string> GetMonthByYear(int year)
        {
            var month = new List<string>();
            var monthRange = MonthsRange[year];

            for (int i = monthRange[0]; i <= monthRange[1]; i++)
            {
                month.Add(Locale.Localization.Lang.Months[i - 1]);
            }

            return month;
        }

        public int MonthBias(int year)
        {
            var bias = 0;

            while (year > 0)
            {
                var months = MonthsRange[year - 1];
                bias += months[1] - months[0] + 1;
                year--;
            }

            return bias;
        }

        public override bool Equals(object obj)
        {
            ForecastTimeModel model = obj as ForecastTimeModel;
            
            if (model == null || Years.Count != model.Years.Count || MonthsRange.Count != model.MonthsRange.Count ||
                DaysRange.Count != model.DaysRange.Count || Hours.Count != model.Hours.Count || 
                Minutes.Count != model.Minutes.Count)
            {
                return false;
            }

            for (int i = 0; i < Years.Count; i++)
            {
                if (Years[i] != model.Years[i])
                {
                    return false;
                }
            }

            for (int i = 0; i < MonthsRange.Count; i++)
            {
                if (MonthsRange[i][0] != model.MonthsRange[i][0] || MonthsRange[i][1] != model.MonthsRange[i][1])
                {
                    return false;
                }
            }

            for (int i = 0; i < DaysRange.Count; i++)
            {
                if (DaysRange[i][0] != model.DaysRange[i][0] || DaysRange[i][1] != model.DaysRange[i][1])
                {
                    return false;
                }
            }

            for (int i = 0; i < Hours.Count; i++)
            {
                if (Hours[i] != model.Hours[i])
                {
                    return false;
                }
            }

            for (int i = 0; i < Minutes.Count; i++)
            {
                if (Minutes[i] != model.Minutes[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var hashCode = 752789938;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(Years);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<int[]>>.Default.GetHashCode(MonthsRange);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<int[]>>.Default.GetHashCode(DaysRange);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(Hours);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(Minutes);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DefaultYear);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DefaultMonth);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DefaultDay);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DefaultHour);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DefaultMinute);
            return hashCode;
        }
    }
}
