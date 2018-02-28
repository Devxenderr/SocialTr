namespace SocialTrading.Vipers.Post.Interfaces.Statistics
{
    public interface IInteractorPostStatistics
    {
        IPresenterPostStatistics Presenter { set; }

        int CalculateStatisticsLongLineSize(int percentLong, int size);
    }
}
