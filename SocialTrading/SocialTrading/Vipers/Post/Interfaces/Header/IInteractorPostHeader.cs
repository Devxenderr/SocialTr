using System;

using SocialTrading.DTO.Response.Post;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Service.Interfaces.Repository;

namespace SocialTrading.Vipers.Post.Interfaces.Header
{
    public interface IInteractorPostHeader : IConnectionMessage, IDisposable
    {
        IPresenterPostHeader Presenter { set; }

        string CalcCreatedTime(DateTime time, DateTime nowTime);
        void UpdateCreatedTime(DateTime time);
        void FavoriteClick();
        void DeletePostClick();
        bool SetPriceStatus(double previousPrice, double currentPrice);
        int SetDifferenceAmmount(string price, string currentPrice, bool isSell, int camelPositionPrice, int camelPositionCurrentPrice);
        void ChangeTime(DateTime nowDateTime);

        IRepositoryPost GetRepository();
        IRepositoryUserSettings GetRepositoryUserSettings();
        void CacheImage(string base64);

        void RecieveModel(DataModelPost data);
    }
}
