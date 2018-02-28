namespace SocialTrading.Tools.Validation
{
    public static class ValidationCreatePost
    {
        public static bool CheckDateTime(string date)
        {
            return Validation.CheckValue(@"^[0-9]{4,4}-[0-9]{1,2}-[0-9]{1,2} [0-9]{1,2}:[0-9]{1,2}$", date);
        }
    }
}
