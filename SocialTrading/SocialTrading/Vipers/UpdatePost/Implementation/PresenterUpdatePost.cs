using System;
using System.Text.RegularExpressions;
using SocialTrading.Tools;
using SocialTrading.Vipers.Entity;
using SocialTrading.Locale.Modules;
using SocialTrading.Vipers.CreatePost;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.UpdatePost.Interfaces;

namespace SocialTrading.Vipers.UpdatePost.Implementation
{
    public class PresenterUpdatePost : IPresenterUpdatePost
    {
        private readonly IRouterUpdatePost _router;
        private readonly IViewUpdatePost _view;
        private readonly IInteractorUpdatePost _interactor;

        private ICreatePost _locale;
        private IUpdatePostStylesHolder _stylesHolder;

        public PresenterUpdatePost(IViewUpdatePost view, IInteractorUpdatePost interactor, IRouterUpdatePost router, IUpdatePostStylesHolder stylesHolder, ICreatePost createPostLocaleStrings)
        {
            if (view == null || interactor == null || router == null)
            {
                throw new NullReferenceException();
            }

            _router = router;
            _view = view;
            _interactor = interactor;
            _view.Presenter = this;
            _interactor.Presenter = this;
            _stylesHolder = stylesHolder;
            _locale = createPostLocaleStrings;
        }
        
        public void SetLocale(ICreatePost lang)
        {
            _locale = lang;

            if (_locale != null)
            {
                _view.SetCommentHint(_locale.EnterCommentLabel);
                _view.SetForecastTime(_locale.TimeTextView);
                _view.SetAccessMode(_locale.Public);
                _view.SetBuySell(_locale.BuySellTextView);
                _view.SetTools(_locale.ToolsButton.ToUpper());
                _view.SetPrice(_locale.PriceLabel);
                _view.SetToolBarPublishButtonLocale(_locale.PublishButton);
                _view.SetToolBarTitleTextViewLocale(_locale.UpdatePostActivityTitle);
            }
        }

        public void AccessModeSelected(EAccessMode access)
        {
            _interactor.AccessModeSelected(access);
        }

        public void AccessModeState(EState state)
        {
            if (_stylesHolder == null)
            {
                return;
            }

            switch (state)
            {
                case EState.None:
                    _view.SetAccessModeTheme(_stylesHolder.AccessModeStateNoneTheme);
                    break;
                case EState.Fail:
                    _view.SetAccessModeTheme(_stylesHolder.AccessModeStateFailTheme);
                    break;

                default:
                    break;
            }
        }

        public void BackClick()
        {
            _interactor.BackClick();
        }

        public void CommentInput(string comment)
        {
            _interactor.CommentInput(comment);
        }

        public void CommentState(EState state)
        {
            if (_stylesHolder == null)
            {
                return;
            }

            switch (state)
            {
                case EState.None:
                    _view.SetCommentTheme(_stylesHolder.CommentStateNoneTheme);
                    break;
                case EState.Fail:
                    _view.SetCommentTheme(_stylesHolder.CommentStateFailTheme);
                    break;

                default:
                    break;
            }
        }

        public void DeleteImage()
        {
            _view.ImageDeleted();
        }

        public void DeleteImageClick()
        {
            _interactor.DeleteImageClick();
        }

        public void GoToMain()
        {
            _router.ToPostsFeed();
        }

        public void GoToSelectingImage()
        {
            _router.ToGallery();
        }

        public void ImageSelected(string image)
        {
            _view.SetImage(image);
        }

        public void SaveData(EAccessMode access, string comment, string image)
        {
            _interactor.SaveData(access, comment, image);
        }

        public void SelectImageClick()
        {
            _interactor.SelectImageClick();
        }

        public void SetConfig()
        {
            _interactor.SetConfig();
        }

        public void SetData(UpdatePostModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.Content))
            {
                _view.SetComment(model.Content);
            }

            if (!string.IsNullOrWhiteSpace(model.Image))
            {
                var result = new Regex("^((https?|ftp)://|(www|ftp)\\.)?[a-z0-9-]+(\\.[a-z0-9-]+)+([/?].*)?$").IsMatch(model.Image);
                if (result)
                {
                    _view.SetImageLink(model.Image);
                }
                else
                {
                    _view.SetImage(model.Image);
                }
            }


            _view.SetAccessMode(model.Access.GetLocaleStringFromEnum());

            if (!model.IsSimple)
            {
                _view.SetPrice(model.Price);
                _view.SetBuySell(model.Recommend);
                _view.SetTools(model.Quote);
                _view.SetForecastTime(model.Forecast);
            }
        }

        public void SetUserAvatar(string image)
        {
            _view.SetUserAvatar(image);
        }

        public void SetUserName(string name)
        {
            _view.SetUserName(name);
            _view.SetCommentHint(name + _locale.EnterCommentLabel);
        }

        public void ShowHideSpinner(bool isShow)
        {
            if (isShow)
            {
                _view.ShowSpinner();
            }
            else
            {
                _view.HideSpinner();
            }
        }

        public void UpdatePost(EAccessMode access, string comment, string image)
        {
            _interactor.UpdatePost(access, comment, image);
        }

        public void UpdatePostState(EPostResponseStatus status)
        {
            switch (status)
            {
                case EPostResponseStatus.Success:
                    _view.ShowSuccessAlert(_locale.UpdatePostSuccess, _locale.OK);
                    break;

                case EPostResponseStatus.Error:
                    _view.ShowFailAlert(_locale.UnknownError, _locale.OK);
                    break;
                case EPostResponseStatus.Unauthorized:
                    _view.ShowFailAlert(_locale.CreatePostUnauthorized, _locale.OK);
                    break;
                case EPostResponseStatus.UnprocessableEntity:
                    _view.ShowFailAlert(_locale.CreatePostUnprocessableEntity, _locale.OK);
                    break;
                case EPostResponseStatus.BadRequest:
                    _view.ShowFailAlert(_locale.CreatePostBadRequest, _locale.OK);
                    break;
                case EPostResponseStatus.NoConnection:
                    _view.ShowFailAlert(_locale.NoConnection, _locale.OK);
                    break;
                case EPostResponseStatus.TooLargeImage:
                    _view.ShowFailAlert(_locale.TooLargeImage, _locale.OK);
                    break;

                default:
                    break;
            }
        }

        public void SetTheme(IUpdatePostStylesHolder stylesHolder)
        {
            _stylesHolder = stylesHolder;
            if (_stylesHolder != null)
            {
                _view.SetDividingLineTheme(_stylesHolder.DividingLineTheme);
                _view.SetNameTheme(_stylesHolder.NameTheme);
                _view.SetTitleTheme(_stylesHolder.TitleTheme);
                _view.SetAvatarTheme(_stylesHolder.AvatarTheme);
                _view.SetBackButtonTheme(_stylesHolder.BackButtonTheme);
                _view.SetAttachImageButtonTheme(_stylesHolder.AttachImageButtonTheme);
                _view.SetPublishTextViewTheme(_stylesHolder.PublishTextViewTheme);
                _view.SetToolsTheme(_stylesHolder.ToolsDisableTheme);
                _view.SetPriceTextViewTheme(_stylesHolder.TextFieldsDisableTheme);
                _view.SetBuySellTheme(_stylesHolder.TextFieldsDisableTheme);
                _view.SetAccessModeTheme(_stylesHolder.AccessModeStateNoneTheme);
                _view.SetForecastTimeTheme(_stylesHolder.TextFieldsDisableTheme);
                _view.SetCommentTheme(_stylesHolder.CommentStateNoneTheme);
                _view.SetToolbarTheme(_stylesHolder.ToolBarViewTheme);
            }
        }

        public void SaveAttachedImage(string attachedImage)
        {
            _interactor.SaveAttachedImage(attachedImage);
        }

        public string LoadAttachedImage()
        {
            return _interactor.LoadAttachedImage();
        }

        public void AttachmentCancelImage()
        {
            if (_stylesHolder != null)
            {
                _view.SetCancelAttachButtonTheme(_stylesHolder.CancelAttachButtonTheme);
            }
        }

        public void AccessModeClick()
        {
            _view.AccessModeSelection(_locale.AccessModeAlertTitle, _locale.Cancel, _locale.OK);
        }

        public void Dispose()
        {
            _interactor.Dispose();
        }

        public void NeedToSaveData()
        {
            _view.NeedToSaveData();
        }
    }
}
