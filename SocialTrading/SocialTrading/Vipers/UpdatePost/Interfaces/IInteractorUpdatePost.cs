using System;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Tools.Interfaces;

namespace SocialTrading.Vipers.UpdatePost.Interfaces
{
    public interface IInteractorUpdatePost : ISetConfig, IDisposable
    {
        IPresenterUpdatePostForInteractor Presenter { set; }

        void UpdatePost(EAccessMode access, string comment, string image);

        void AccessModeSelected(EAccessMode access);
        void CommentInput(string comment, bool isPressedPublish = false);

        void BackClick();
        void SelectImageClick();

        void SaveData(EAccessMode access, string comment, string image);

        void DeleteImageClick();

        void SaveAttachedImage(string attachedImage);
        string LoadAttachedImage();
    }
}
