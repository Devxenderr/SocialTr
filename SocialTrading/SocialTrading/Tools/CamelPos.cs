using System;
using System.Globalization;

using SocialTrading.Tools.Interfaces;

namespace SocialTrading.Tools
{
    public class CamelPos : ICamelPos
    {
        public int GetCamelPos(string str)
        {
            int pos;

            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            var decSep = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;

            var dotPos = str.IndexOf(decSep, StringComparison.CurrentCulture);

            if (dotPos == -1)
            {
                pos = str.Length - 3;
            }
            else if (dotPos == str.Length - (1 + decSep.Length))
            {
                pos = dotPos - 2;
            }
            else if (dotPos == str.Length - (2 + decSep.Length))
            {
                pos = dotPos + decSep.Length;
            }
            else
            {
                pos = str.Length - 3;
            }

            return pos >= 0 ? pos : 0;
        }
    }
}
