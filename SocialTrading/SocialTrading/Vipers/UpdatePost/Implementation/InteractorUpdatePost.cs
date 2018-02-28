using System;

using SocialTrading.Vipers.Entity;
using SocialTrading.Vipers.CreatePost;
using SocialTrading.DTO.Request.Posts;
using SocialTrading.DTO.Response.Post;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Vipers.UpdatePost.Interfaces;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.Controllers.Interfaces;

namespace SocialTrading.Vipers.UpdatePost.Implementation
{
    public class InteractorUpdatePost : IInteractorUpdatePost
    {
        public IPresenterUpdatePostForInteractor Presenter { private get; set; }
        
        private readonly IRepositoryUpdatePost _repository;
        private readonly IRepositoryUserAuth _repositoryUser;
        private readonly IUpdatePostController _updatePostController;

        private EControllerStatus _currentRecieveStatus = EControllerStatus.None;

        public InteractorUpdatePost(string postId, IUpdatePostController updatePostController, IRepositoryUpdatePost repositoryUpdatePost, IRepositoryPost repositoryPost, IRepositoryUserAuth repositoryUser)
        {
            if (string.IsNullOrWhiteSpace(postId))
            {
                throw new ArgumentNullException(nameof(postId));
            }
            _updatePostController = updatePostController ?? throw new ArgumentNullException(nameof(updatePostController));
            _repository = repositoryUpdatePost ?? throw new ArgumentNullException(nameof(repositoryUpdatePost));
            _repositoryUser = repositoryUser ?? throw new ArgumentNullException(nameof(repositoryUser));

            if (repositoryPost == null)
            {
                throw new ArgumentNullException(nameof(repositoryPost));
            }

            var postModel = repositoryPost.GetPostById(postId);


            if (_repository.UpdatePostModel == null)
            {
                _repository.UpdatePostModel = new UpdatePostModel(postModel.Market == "Simple", postId,
                    postModel.Quote, postModel.Forecast, postModel.Price, postModel.Recommend, postModel.Access, postModel.Image,
                    postModel.Content);
            }

            _updatePostController.OnRecieveModel += ControllerOnMessage;
        }

        public void UpdatePost(EAccessMode access, string comment, string image)
        {
            if (_currentRecieveStatus == EControllerStatus.Processing)
            {
                return;
            }

            if (!IsCommentInput(comment, true) && string.IsNullOrWhiteSpace(image))
            {
                CommentInput(comment, true);
                return;
            }

            if (!IsAccessModeSelected(access))
            {
                AccessModeSelected(access);
                return;
            }

            comment = comment?.Trim(' ').Trim('\n');

            _updatePostController.Send(new UpdatePostRequestModel(_repository.UpdatePostModel.Id, access, comment, image));
        }


        public void AccessModeSelected(EAccessMode access)
        {
            Presenter.AccessModeState(IsAccessModeSelected(access) ? EState.None : EState.Fail);
        }

        private bool IsAccessModeSelected(EAccessMode access)
        {
            if (access != EAccessMode.None)
            {
                return true;
            }
            return false;
        }

        public void CommentInput(string comment, bool isPressedPublish = false)
        {
            Presenter.CommentState(IsCommentInput(comment, isPressedPublish) ? EState.None : EState.Fail);
        }

        private bool IsCommentInput(string comment, bool isPressedPublish = false)
        {
            if (!string.IsNullOrWhiteSpace(comment) || !isPressedPublish)
            {
                return true;
            }
            return false;
        }
        

        public void BackClick()
        {
            Presenter.GoToMain();
        }

        public void SelectImageClick()
        {
            Presenter.GoToSelectingImage();
        }

        public void SaveAttachedImage(string attachedImage)
        {
            _repository.UpdatePostModel.Image = attachedImage;
        }

        public string LoadAttachedImage()
        {
            return _repository.UpdatePostModel?.Image;
        }

        public void DeleteImageClick()
        {
            Presenter.DeleteImage();
        }

        public void SetConfig()
        {
            Presenter.SetUserName(_repositoryUser.AuthData.Name);
            Presenter.SetUserAvatar(_repositoryUser.AuthData.Image);

            if (_repository.UpdatePostModel != null)
            {
                Presenter.SetData(_repository.UpdatePostModel);
            }
        }

        private void ControllerOnMessage(IModel postModel)
        {
            _currentRecieveStatus = EControllerStatus.None;

            switch (postModel.ControllerStatus)
            {
                case EControllerStatus.Ok:
                    Presenter.ShowHideSpinner(false);
                    GetMessage(postModel);
                    break;
                case EControllerStatus.Processing:
                    Presenter.ShowHideSpinner(true);
                    _currentRecieveStatus = EControllerStatus.Processing;
                    break;
                case EControllerStatus.NoConnection:
                    Presenter.ShowHideSpinner(false);
                    Presenter.UpdatePostState(EPostResponseStatus.NoConnection);
                    break;
                case EControllerStatus.None:
                case EControllerStatus.Error:
                default:
                    Presenter.ShowHideSpinner(false);
                    GetErrorMessage(postModel);
                    break;
            }
        }

        private void GetErrorMessage(IModel postModel)
        {
            if (!(postModel is DataModelCreatePost model))
            {
                Presenter.UpdatePostState(EPostResponseStatus.Error);
                return;
            }
            Presenter.UpdatePostState(model.Status);
        }

        private void GetMessage(IModel postModel)
        {
            if (postModel is DataModelCreatePost model)
            {
                if (model.Status == EPostResponseStatus.Success)
                {
                    _updatePostController.OnRecieveModel -= ControllerOnMessage;
                    Presenter.GoToMain();
                }
                Presenter.UpdatePostState(model.Status);
            }
        }
        
        public void SaveData(EAccessMode access, string comment, string image)
        {
            if (_repository.UpdatePostModel != null)
            {
                _repository.UpdatePostModel.Access = access;
                _repository.UpdatePostModel.Image = image;
                _repository.UpdatePostModel.Content = comment;
            }
        }

        public void Dispose()
        {
           _repository.UpdatePostModel = null;
        }
    }
}
