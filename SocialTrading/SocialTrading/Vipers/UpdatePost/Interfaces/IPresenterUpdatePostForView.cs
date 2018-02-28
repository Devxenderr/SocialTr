using SocialTrading.Tools.Enumerations;

namespace SocialTrading.Vipers.UpdatePost.Interfaces
{
    public interface IPresenterUpdatePostForView
    {
        void UpdatePost(EAccessMode access, string comment, string image);
        
        void AccessModeSelected(EAccessMode access);
        void CommentInput(string comment);

        void BackClick();
        void SelectImageClick();
        void DeleteImageClick();
        void AccessModeClick();

        void SaveData(EAccessMode access, string comment, string image);

        void SaveAttachedImage(string value);
        string LoadAttachedImage();
        void AttachmentCancelImage();
    }
}
