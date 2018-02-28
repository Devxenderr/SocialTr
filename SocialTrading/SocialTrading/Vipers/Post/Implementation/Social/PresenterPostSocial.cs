using System;

using SocialTrading.Locale.Modules;
using SocialTrading.DTO.Response.Post.Interfaces;
using SocialTrading.Vipers.Post.Interfaces.Social;

namespace SocialTrading.Vipers.Post.Implementation.Social
{
    public class PresenterPostSocial : IPresenterPostSocial
    {
        private readonly IViewPostSocial _view;
        private readonly IRouterPostSocial _router;
        private readonly IInteractorPostSocial _interactor;

        private readonly IPost _postLocaleStrings;
        private readonly IPostSocialStylesHolder _stylesHolder;

        public PresenterPostSocial(IViewPostSocial view, IInteractorPostSocial interactor, IRouterPostSocial router, IPost postLocaleStrings, IPostSocialStylesHolder stylesHolder)
        {
            if (view == null || interactor == null || router == null)
            {
                throw new NullReferenceException();
            }

            _stylesHolder = stylesHolder;
            _view = view;
            _interactor = interactor;
            _view.Presenter = this;
            _interactor.Presenter = this;
            _router = router;
            
            _postLocaleStrings = postLocaleStrings;

            SetLocale();
            _view.SetConfig();
        }


        public void SetConfig()
        {
            _view.SetLikeTheme(_stylesHolder.NotLikeTheme);
            _view.SetCommentTheme(_stylesHolder.CommentTheme);
            _view.SetShareTheme(_stylesHolder.ShareTheme);
        }

        public void SetLocale()
        {
            _view.SetShareText(_postLocaleStrings.ShareWith);
        }

        public void SetSocial(IPostSocialModel model)
        {
            if (model.IsLiked)
            {
                _view.SetLikeDrawable(_stylesHolder.LikeTheme);
            }
            else
            {
                _view.SetLikeDrawable(_stylesHolder.NotLikeTheme);
            }

            _view.SetLikeText(_postLocaleStrings.Like + " (" + model.LikeCount + ")" );
            _view.SetCommentText(_postLocaleStrings.Comments + " (" + model.CommentCount + ")");
        }

        public void LikeClick()
        {
            _interactor.LikeClick();
        }

        public void CommentClick()
        {
            _router.ToComments();
        }

        public void ShareClick()
        {
            _interactor.ShareClick();
        }

        public void Share(string link)
        {
            _router.ToShare(link);
        }

        //public void CheckLikedState(EResponseState state)
        //{
        //    switch (state)
        //    {
        //        case EResponseState.PostLikeSuccess:
        //            _view.SetLikeText(_interactor.GetRepository().LangPost.Like + " (" + _interactor.GetLikeCount() + ")");
        //            break;
        //        case EResponseState.PostLikeError:
        //            _view.ShowAlert(string.Empty, _interactor.GetRepository().LangPost.LikeError);
        //            break;

        //        case EResponseState.NoConnection:
        //            _view.ShowAlert(string.Empty, _interactor.GetRepository().LangPost.NoConnection);
        //            break;
        //        case EResponseState.NoResponse:
        //            _view.ShowAlert(string.Empty, _interactor.GetRepository().LangPost.NoResponse);
        //            break;
        //        case EResponseState.NotFound:
        //            _view.ShowAlert(string.Empty, _interactor.GetRepository().LangPost.NotFound);
        //            break;
        //        case EResponseState.ServiceUnavailable:
        //            _view.ShowAlert(string.Empty, _interactor.GetRepository().LangPost.ServiceUnavailable);
        //            break;
        //        case EResponseState.Unknown:
        //            _view.ShowAlert(string.Empty, _interactor.GetRepository().LangPost.Unknown);
        //            break;

        //        default:
        //            break;
        //    }
        //}

        public void CheckLikedState(EPostSocialResponseStatus state)
        {
            switch (state)
            {
                case EPostSocialResponseStatus.Error:
                    _view.ShowAlert(string.Empty, _postLocaleStrings.LikeError);
                    break;
                case EPostSocialResponseStatus.Unauthorized:
                    _view.ShowAlert(string.Empty, _postLocaleStrings.LikeError);
                    break;
                case EPostSocialResponseStatus.Success:
                    _view.SetLikeText(_postLocaleStrings.Like + " (" + _interactor.GetLikeCount() + ")");
                    _view.SetLikeDrawable(_interactor.GetIsLiked()
                        ? _stylesHolder.LikeTheme
                        : _stylesHolder.NotLikeTheme);
                    break;
                case EPostSocialResponseStatus.NoConnection:
                     _view.ShowAlert(string.Empty, _postLocaleStrings.NoConnection);
                    break;
                default:
                    break;                    
            }
        }

        public string GetOkLocale()
        {
            return _postLocaleStrings.OK;
        }
    }
}
