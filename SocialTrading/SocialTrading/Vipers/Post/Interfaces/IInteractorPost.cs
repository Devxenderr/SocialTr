using System;

using SocialTrading.Vipers.Trade.Interfaces;
using SocialTrading.Vipers.Post.Interfaces.Body;
using SocialTrading.Vipers.Post.Interfaces.Chart;
using SocialTrading.Vipers.Post.Interfaces.Header;
using SocialTrading.Vipers.Post.Interfaces.Social;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.Post.Interfaces.Statistics;

namespace SocialTrading.Vipers.Post.Interfaces
{
    public interface IInteractorPost : IDisposable
    {
        IInteractorPostBody InteractorPostBody { get; }
        IInteractorPostChart InteractorPostChart { get; }
        IInteractorPostHeader InteractorPostHeader { get; }
        IInteractorPostSocial InteractorPostSocial { get; }
        IInteractorPostStatistics InteractorPostStatistics { get; }
        IInteractorTrade InteractorTrade { get; }

        IRepositoryPost GetRepository();
        void DisposeRepositoryPost();

        void ChangeTime(DateTime nowDateTime);
    }
}
