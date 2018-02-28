namespace SocialTrading.Locale
{
    public static class Localization 
    {
        public static ILang Lang { get; private set; }

        static Localization()
        {
            Lang = new LangRU();
        }
    }
}
