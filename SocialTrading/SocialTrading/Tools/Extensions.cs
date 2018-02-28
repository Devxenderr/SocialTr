using System;
using System.Reflection;
using System.Collections.Generic;

using SocialTrading.Tools.Validation;
using SocialTrading.Tools.Enumerations;

namespace SocialTrading.Tools
{
    public static class Extensions
    {
        public static string GetLocaleStringFromEnum(this EBuySell recommend)
        {
            var result = Locale.Localization.Lang.GetType().GetRuntimeProperty(recommend.ToString()).GetValue(Locale.Localization.Lang) as string;
            return result;
        }

        public static string GetLocaleStringFromEnum(this EForecastTime recommend)
        {
            var result = Locale.Localization.Lang.GetType().GetRuntimeProperty(recommend.ToString()).GetValue(Locale.Localization.Lang) as string;
            return result;
        }

        public static string GetLocaleStringFromEnum(this EAccessMode recommend)
        {
            var result = Locale.Localization.Lang.GetType().GetRuntimeProperty(recommend.ToString()).GetValue(Locale.Localization.Lang) as string;
            return result;
        }

        public static EBuySell GetRecommendEnum(this string recommend)
        {
            if (string.IsNullOrWhiteSpace(recommend) || recommend.Equals(Locale.Localization.Lang.BuySellTextView))
            {
                return EBuySell.None;
            }
            var list = new List<PropertyInfo>(Locale.Localization.Lang.GetType().GetRuntimeProperties());
            var propertyName = list.Find(p => p.GetValue(Locale.Localization.Lang).Equals(recommend)).Name;
            var result = (EBuySell)Enum.Parse(typeof(EBuySell), propertyName);

            return result;
        }

        public static EForecastTime GetTimePeriodEnum(this string time)
        {
            if (string.IsNullOrWhiteSpace(time) || time.Equals(Locale.Localization.Lang.TimeTextView))
            {
                return EForecastTime.None;
            }

            if (ValidationCreatePost.CheckDateTime(time))
            {
                return EForecastTime.Other;
            }

            var list = new List<PropertyInfo>(Locale.Localization.Lang.GetType().GetRuntimeProperties());
            var propertyName = list.Find(p => p.GetValue(Locale.Localization.Lang).Equals(time)).Name;
            var result = (EForecastTime)Enum.Parse(typeof(EForecastTime), propertyName);

            return result;
        }

        public static EAccessMode GetAccessEnum(this string access)
        {
            if (string.IsNullOrWhiteSpace(access) || access.Equals(Locale.Localization.Lang.AccessModeTextView))
            {
                return EAccessMode.None;
            }
            var list = new List<PropertyInfo>(Locale.Localization.Lang.GetType().GetRuntimeProperties());
            var propertyName = list.Find(p => p.GetValue(Locale.Localization.Lang).Equals(access)).Name;
            var result = (EAccessMode)Enum.Parse(typeof(EAccessMode), propertyName);

            return result;
        }
        
        public static EState GetPnLState(this float pnl)
        {
            EState state;

            if (pnl == 0f)
            {
                state = EState.None;
            }
            else if (pnl > 0f)
            {
                state = EState.Success;
            }
            else
            {
                state = EState.Fail;
            }

            return state;
        }

        public static string GetTime(this string time)
        {
            var days = string.Empty;

            if (time.Contains("."))
            {
                days = time.Substring(0, time.IndexOf("."));
                time = time.Remove(0, time.IndexOf(".") + 1);
            }
            else
            {
                days = "0";
            }

            return string.Format("{0}{1} {2}", days, "d", time);
        }
    }
}
