using System;
using System.Globalization;

using SocialTrading.Service.Interfaces.Timer;

namespace SocialTrading.Service
{
    public class DateTimeConverter : IDateTimeConverter
    {
        private DateTime _myDate = DateTime.MinValue;

        public DateTime Convert(string time)
        {
            if (!DateTime.TryParseExact(time, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture, DateTimeStyles.None, out _myDate))
            {
                if (!DateTime.TryParseExact(time, "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out _myDate))
                {
                    DateTime.TryParseExact(time, "yyyy-MM-ddTHH:mm:ss.ffZ", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out _myDate);
                }
            }

            return _myDate;
        }
    }
}

