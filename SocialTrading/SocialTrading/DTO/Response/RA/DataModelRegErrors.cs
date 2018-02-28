namespace SocialTrading.DTO.Response.RA
{
    public class DataModelRegErrors
    {
        public string[] FullMessages { get; }

        public DataModelRegErrors(string[] fullMessages)
        {
            FullMessages = fullMessages;
        }
    }
}