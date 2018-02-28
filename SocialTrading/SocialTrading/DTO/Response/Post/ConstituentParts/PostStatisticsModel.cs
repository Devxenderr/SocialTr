namespace SocialTrading.DTO.Response.Post.ConstituentParts
{
    public class PostStatisticsModel
    {
        public float PnL { get; set; }
        public int Deals { get; set; }

        public int PercentShort { get; set; }
        public int PercentLong { get; set; }
    }
}
