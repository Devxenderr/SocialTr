using System.Text.RegularExpressions;

namespace SocialTrading.Tools.Validation
{
    public static class Validation
    {
        public static bool CheckValue(string regexString, string valueToCheck)
        {
            if (valueToCheck == null || regexString == null)
            {
                return false;
            }

            Regex regex = new Regex(regexString);
            return regex.IsMatch(valueToCheck);
        }
    }
}
