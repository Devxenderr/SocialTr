using System;

using SocialTrading.Vipers.Entity;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Service.Interfaces.Repository;

namespace SocialTrading.Vipers.CreatePost.Interfaces
{
    public interface IInteractorCreatePost : IDisposable
    {
        IPresenterCreatePost Presenter { set; }

        void AddPost(string price, EBuySell recommend, EAccessMode access, string tool, string timePeriod, string comment, string img);
        void AddPost(string price, EBuySell recommend, EAccessMode access, string tool, EForecastTime timePeriod, string comment, string img);
        void ReadyToSetPrice(string tool, EBuySell recommend);

        void ToolSelected(string tool);
		void BuySellSelected(EBuySell recommend);
		void AccessModeSelected(EAccessMode access);

        void ForecastTimeSelected(EForecastTime timePeriod);
        void ForecastTimeSelected(string timePeriod);

        void CommentInput(bool state, bool isPressedPublish = false);

        ForecastTimeModel GetForecastTimeModel();

        void SaveAttachedImage(string attachedImage);
        string LoadAttachedImage();

        void SaveSelectedTool(string selectedTool);
        string LoadSelectedTool();

        void SaveData(CreatePostStrings createPostStrings);
        CreatePostStrings LoadData();

        IRepositoryCreatePost GetRepository();

        void DisposeRepositoryCreatePost();

        void SetConfig();
    }
}
