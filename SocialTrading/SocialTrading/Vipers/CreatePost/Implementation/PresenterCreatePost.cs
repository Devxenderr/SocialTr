using System;
using System.Collections.Generic;

using SocialTrading.Vipers.Entity;
using SocialTrading.Locale.Modules;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.CreatePost.Interfaces;
using SocialTrading.Service.Interfaces.Repository;

namespace SocialTrading.Vipers.CreatePost.Implementation
{
    public class PresenterCreatePost : IPresenterCreatePost
    {
        private readonly IRouterCreatePost _router;
        private readonly IViewCreatePost _viewCreatePost;
		private readonly IInteractorCreatePost _interactor;

        private readonly ICreatePost _createPostLocaleStrings;
        private readonly ICreatePostStylesHolder _stylesHolder;
        
        public PresenterCreatePost(IViewCreatePost view, IInteractorCreatePost interactor, IRouterCreatePost router, ICreatePostStylesHolder stylesHolder, ICreatePost createPostLocaleStrings)
        {
            if (view == null || interactor == null || router == null)
            {
                throw new NullReferenceException();
            }

            _router = router;
            _viewCreatePost = view;
			_interactor = interactor;
			_viewCreatePost.Presenter = this;
			_interactor.Presenter = this;
            _stylesHolder = stylesHolder;
            _createPostLocaleStrings = createPostLocaleStrings;

            _viewCreatePost.SetConfig();
        }

        public void SetConfig()
        {
            if (_stylesHolder != null)
            {
                _viewCreatePost.SetDividingLineTheme(_stylesHolder.DividingLineTheme);
                _viewCreatePost.SetNameTheme(_stylesHolder.NameTheme);
                _viewCreatePost.SetTitleTheme(_stylesHolder.TitleTheme);
                _viewCreatePost.SetAvatarTheme(_stylesHolder.AvatarTheme);
                _viewCreatePost.SetBackButtonTheme(_stylesHolder.BackButtonTheme);
                _viewCreatePost.SetAttachImageButtonTheme(_stylesHolder.AttachImageButtonTheme);
                _viewCreatePost.SetPublishTextViewTheme(_stylesHolder.PublishTextViewTheme);
                _viewCreatePost.SetToolsTheme(_stylesHolder.ToolsStateNoneTheme);
                _viewCreatePost.SetPriceTextViewTheme(_stylesHolder.PriceTextViewTheme);
                _viewCreatePost.SetBuySellTheme(_stylesHolder.BuySellStateNoneTheme);
                _viewCreatePost.SetAccessModeTheme(_stylesHolder.AccessModeStateNoneTheme);
                _viewCreatePost.SetForecastTimeTheme(_stylesHolder.ForecastTimeStateNoneTheme);
                _viewCreatePost.SetCommentTheme(_stylesHolder.CommentStateNoneTheme);
                _viewCreatePost.SetToolbarTheme(_stylesHolder.ToolBarViewTheme);
            }

            _interactor.SetConfig();
        }

        public void SetLocale()
        {
            if (_createPostLocaleStrings != null)
            {
                _viewCreatePost.SetForecastTimeLocale(_createPostLocaleStrings.TimeTextView);
                _viewCreatePost.SetAccessModeLocale(_createPostLocaleStrings.Public);
                _viewCreatePost.SetBuySellLocale(_createPostLocaleStrings.BuySellTextView);
                _viewCreatePost.SetToolsLocale(_createPostLocaleStrings.ToolsButton.ToUpper());
                _viewCreatePost.SetPriceLocale(_createPostLocaleStrings.PriceLabel);
            }
        }

        public void SetToolBarLocale()
        {
            (_viewCreatePost as IViewCreatePostToolBar)?.SetToolBarPublishButtonLocale(_createPostLocaleStrings.PublishButton);
            (_viewCreatePost as IViewCreatePostToolBar)?.SetToolBarTitleTextViewLocale(_createPostLocaleStrings.CreatePostActivityTitle);
        }

        public void ImageSelected()
        {
            _viewCreatePost.SetAttachment();
        }

        public void ReadyToSetPrice(string tool, EBuySell recommend)
        {
            _interactor.ReadyToSetPrice(tool, recommend);
        }
        
        public void SetPrice(string price)
        {
            _viewCreatePost.Price = price;
        }

        public void AddPost(string price, EBuySell recommend, EAccessMode access, string tool, EForecastTime timePeriod, string comment, string img)
        {
            _interactor.AddPost(price, recommend, access, tool, timePeriod, comment, img);
        }

        public void AddPost(string price, EBuySell recommend, EAccessMode access, string tool, string timePeriod, string comment, string img)
        {
            _interactor.AddPost(price, recommend, access, tool, timePeriod, comment, img);
        }

        public void AttachmentCancelImage()
        {
            _viewCreatePost.SetCancelAttachButtonTheme(_stylesHolder.CancelAttachButtonTheme);
        }

        public void AccessModeState(EState state)
        {
            switch (state)
            {
                case EState.None:
                    _viewCreatePost.SetAccessModeTheme(_stylesHolder.AccessModeStateNoneTheme);
                    break;
                case EState.Fail:
                    _viewCreatePost.SetAccessModeTheme(_stylesHolder.AccessModeStateFailTheme);
                    break;

                default:
                    break;
            }
        }

        public void ForecastTimeState(EState state)
        {
            switch (state)
            {
                case EState.None:
                    _viewCreatePost.SetForecastTimeTheme(_stylesHolder.ForecastTimeStateNoneTheme);
                    break;
                case EState.Fail:
                    _viewCreatePost.SetForecastTimeTheme(_stylesHolder.ForecastTimeStateFailTheme);
                    break;

                default:
                    break;
            }
        }

        public void BuySellState(EState state)
        {
            switch (state)
            {
                case EState.None:
                    _viewCreatePost.SetBuySellTheme(_stylesHolder.BuySellStateNoneTheme);
                    break;
                case EState.Fail:
                    _viewCreatePost.SetBuySellTheme(_stylesHolder.BuySellStateFailTheme);
                    break;

                default:
                    break;
            }
        }

        public void ToolState(EState state)
        {
            switch (state)
            {
                case EState.None:
                    _viewCreatePost.SetToolsTheme(_stylesHolder.ToolsStateNoneTheme);
                    break;
                case EState.Fail:
                    _viewCreatePost.SetToolsTheme(_stylesHolder.ToolsStateFailTheme);
                    break;

                default:
                    break;
            }
        }

        public void CommentState(EState state)
        {
            switch (state)
            {
                case EState.None:
                    _viewCreatePost.SetCommentTheme(_stylesHolder.CommentStateNoneTheme);
                    break;
                case EState.Fail:
                    _viewCreatePost.SetCommentTheme(_stylesHolder.CommentStateFailTheme);
                    break;

                default:
                    break;
            }
        }
        
        public void AddPostState(EPostResponseStatus status)
        {
            switch (status)
            {
                case EPostResponseStatus.Error:
                    _viewCreatePost.ShowErrorAlert(_createPostLocaleStrings.UnknownError);
                    break;
                case EPostResponseStatus.Unauthorized:
                    _viewCreatePost.ShowErrorAlert(_createPostLocaleStrings.CreatePostUnauthorized);
                    break;
                case EPostResponseStatus.UnprocessableEntity:
                    _viewCreatePost.ShowErrorAlert(_createPostLocaleStrings.CreatePostUnprocessableEntity);
                    break;
                case EPostResponseStatus.BadRequest:
                    _viewCreatePost.ShowErrorAlert(_createPostLocaleStrings.CreatePostBadRequest);
                    break;
                case EPostResponseStatus.Success:
                    _viewCreatePost.AddPostSuccess();
                    break;
                case EPostResponseStatus.NoConnection:
                    _viewCreatePost.ShowErrorAlert(_createPostLocaleStrings.NoConnection);
                    break;
                case EPostResponseStatus.TooLargeImage:
                    _viewCreatePost.ShowErrorAlert(_createPostLocaleStrings.TooLargeImage);
                    break;
                default:
                   break;
            }
        }

        public void DeleteAttachmentImage()
        {
            _viewCreatePost.ImageDeleted();
        }

        public void AccessModeSelected(EAccessMode access)
        {
            _interactor.AccessModeSelected(access);
        }

        public void ForecastTimeSelected(EForecastTime timePeriod)
        {
            _interactor.ForecastTimeSelected(timePeriod);
        }

        public void ForecastTimeSelected(string timePeriod)
        {
            _interactor.ForecastTimeSelected(timePeriod);
        }

        public void BuySellSelected(EBuySell recommend)
        {
            _interactor.BuySellSelected(recommend);
        }

        public void ToolSelected(string tool)
        {
            _interactor.ToolSelected(tool);
        }

        public void CommentInput(bool state)
        {
            _interactor.CommentInput(state);
        }

        public void GoToSelectingImage()
        {
            _router.ToGallery();
        }

        public void GoToSelectingTool()
        {
            _router.ToToolSelection();
        }

        public void GoToMain()
        {
            _router.ToPostsFeed();
        }

        public void SaveAttachedImage(string attachedImage)
        {
            _interactor.SaveAttachedImage(attachedImage);
        }

        public string LoadAttachedImage()
        {
            return _interactor.LoadAttachedImage();
        }

        public void SaveSelectedTool(string selectedTool)
        {
            _interactor.SaveSelectedTool(selectedTool);
        }

        public void LoadSelectedTool()
        {
            var tool = _interactor.LoadSelectedTool();

            if (!string.IsNullOrEmpty(tool))
            {
                _viewCreatePost.SetSelectedTool(tool);
            }
        }

        public ForecastTimeModel GetForecastTimeModel()
        {
            return _interactor.GetForecastTimeModel();
        }

        public IRepositoryCreatePost GetRepository()
        {
            return _interactor.GetRepository();
        }


        public void DisposeRepositoryCreatePost()
        {
            _interactor.DisposeRepositoryCreatePost();
        }

        public string GetAnotherForecastTimeAlertTitleLocale()
        {
            return _createPostLocaleStrings.AnotherForecastTimeAlertTitle;
        }

        public string GetForecastTimeAlertTitleLocale()
        {
            return _createPostLocaleStrings.ForecastTimeAlertTitle;
        }

        public string GetAccessModeAlertTitleLocale()
        {
            return _createPostLocaleStrings.AccessModeAlertTitle;
        }


        public string GetBuySellLocale()
        {
            return _createPostLocaleStrings.BuySellTextView;
        }

        public string GetRecommendAlertTitleLocale()
        {
            return _createPostLocaleStrings.RecommendAlertTitle;
        }

        public string GetToolsButtonLocale()
        {
            return _createPostLocaleStrings.ToolsButton;
        }

        public string GetOtherLocale()
        {
            return _createPostLocaleStrings.Other;
        }

        public void SetUserAvatar(string image)
        {
            _viewCreatePost.SetUserAvatar(image);
        }

        public void SetUserName(string name)
        {
            _viewCreatePost.SetUserName(name);
            _viewCreatePost.SetCommentLocale(name + _createPostLocaleStrings.EnterCommentLabel);
        }

        public void ShowHideSpinner(bool isShow)
        {
            if (isShow)
            {
                _viewCreatePost.ShowSpinner();
            }
            else
            {
                _viewCreatePost.HideSpinner();
            }
        }


        public List<string> GetMonthsLocale()
        {
            return _createPostLocaleStrings.Months;
        }


        public string GetCancelLocale()
        {
            return _createPostLocaleStrings.Cancel;
        }

        public string GetErrorLocale()
        {
            return _createPostLocaleStrings.Error;
        }

        public string GetOkLocale()
        {
            return _createPostLocaleStrings.OK;
        }

        
        public string GetCreatePostSuccessLocale()
        {
            return _createPostLocaleStrings.CreatePostSuccess;
        }

        public string GetCreatePostBadRequestLocale()
        {
            return _createPostLocaleStrings.CreatePostBadRequest;
        }

        public string GetCreatePostUnauthorizedLocale()
        {
            return _createPostLocaleStrings.CreatePostUnauthorized;
        }

        public string GetCreatePostUnprocessableEntityLocale()
        {
            return _createPostLocaleStrings.CreatePostUnprocessableEntity;
        }


        public void SaveData()
        {
            _interactor.SaveData(new CreatePostStrings(_viewCreatePost.AccessModeText, _viewCreatePost.BuySellText, 
                _viewCreatePost.ForecastTimeText, _viewCreatePost.CommentText));
        }

        public void LoadData()
        {
            var createPostStrings = _interactor.LoadData();

            if (createPostStrings != null)
            {
                _viewCreatePost.AccessModeText = createPostStrings.AccessMode;
                _viewCreatePost.BuySellText = createPostStrings.BuySell;
                _viewCreatePost.ForecastTimeText = createPostStrings.ForecastTime;
                if (!string.IsNullOrWhiteSpace(createPostStrings.Comment))
                {
                    _viewCreatePost.CommentText = createPostStrings.Comment;
                }
            }

            LoadSelectedTool();
        }


        public void BackClick()
        {
            _router.ToPostsFeed();
        }
    }
}
