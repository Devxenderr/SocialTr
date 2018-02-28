using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.CreatePost;
using SocialTrading.Vipers.Entity;

namespace SocialTrading.Vipers.UpdatePost.Interfaces
{
    public interface IPresenterUpdatePostForInteractor
    {
        void UpdatePostState(EPostResponseStatus status);
        void CommentState(EState state);
        void AccessModeState(EState state);

        void GoToMain();
        void GoToSelectingImage();
        void DeleteImage();

        void SetData(UpdatePostModel model);
        void ShowHideSpinner(bool isShow);

        void SetUserName(string name);
        void SetUserAvatar(string image);
    }
}
