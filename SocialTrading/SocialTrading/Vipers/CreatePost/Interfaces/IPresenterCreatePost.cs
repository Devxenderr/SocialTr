using System.Collections.Generic;

using SocialTrading.Vipers.Entity;
using SocialTrading.Tools.Interfaces;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Service.Interfaces.Repository;

namespace SocialTrading.Vipers.CreatePost.Interfaces
{
    public interface IPresenterCreatePost : ISetConfig
    {  
        void ImageSelected();
        void DeleteAttachmentImage();

        void ReadyToSetPrice(string tool, EBuySell recommend);

        void AddPost(string price, EBuySell recommend, EAccessMode access, string tool, string timePeriod, string comment, string img);
        void AddPost(string price, EBuySell recommend, EAccessMode access, string tool, EForecastTime timePeriod, string comment, string img);

        ForecastTimeModel GetForecastTimeModel();

        void AccessModeState(EState state);

		void ForecastTimeState(EState state);

        void BuySellState(EState state);
        void ToolState(EState state);
        void CommentState(EState state);

      //  void AddPostState(EResponseState state);
        void AddPostState(EPostResponseStatus status);

        void SetPrice(string price);

        void AccessModeSelected(EAccessMode access);

        void ForecastTimeSelected(EForecastTime timePeriod);
        void ForecastTimeSelected(string timePeriod);

        void BuySellSelected(EBuySell recommend);
        void ToolSelected(string tool);

        void CommentInput(bool state);

        void GoToSelectingImage();
        void GoToSelectingTool();
        void GoToMain();

        void SaveAttachedImage(string attachedImage);
        string LoadAttachedImage();

        void SaveSelectedTool(string selectedTool);
        void LoadSelectedTool();

        void BackClick();

        void SaveData();
        void LoadData();

        void AttachmentCancelImage();

        IRepositoryCreatePost GetRepository();

        void DisposeRepositoryCreatePost();

        void SetLocale();
        void SetToolBarLocale();
        string GetAnotherForecastTimeAlertTitleLocale();
        string GetForecastTimeAlertTitleLocale();
        string GetAccessModeAlertTitleLocale();
        string GetRecommendAlertTitleLocale();
        string GetBuySellLocale();
        string GetToolsButtonLocale();
        string GetOtherLocale();
        
        void SetUserAvatar(string image);
        void SetUserName(string name);

        void ShowHideSpinner(bool isShow);

        List<string> GetMonthsLocale();

        string GetOkLocale();
        string GetErrorLocale();
        string GetCancelLocale();

        string GetCreatePostSuccessLocale();
        string GetCreatePostBadRequestLocale();
        string GetCreatePostUnauthorizedLocale();
        string GetCreatePostUnprocessableEntityLocale();
    }
}
