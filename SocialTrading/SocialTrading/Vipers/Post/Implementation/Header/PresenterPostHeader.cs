using System;

using SocialTrading.Locale.Modules;
using SocialTrading.Tools.Enumerations;
using SocialTrading.DTO.Response.Post.Interfaces;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.Post.Interfaces.Header;
using SocialTrading.DTO.Response.Post.ConstituentParts;

namespace SocialTrading.Vipers.Post.Implementation.Header
{
    public class PresenterPostHeader : IPresenterPostHeader
    {
        private readonly IViewPostHeader _view;
        private readonly IRouterPostHeader _router;
        private readonly IInteractorPostHeader _interactor;

        private readonly IPost _postLocaleStrings;
        private readonly IPostHeaderStylesHolder _styleHolder;


        public PresenterPostHeader(IViewPostHeader view, IInteractorPostHeader interactor, IRouterPostHeader router, IPost postLocaleStrings, IPostHeaderStylesHolder styleHolder)
        {
            if (view == null || interactor == null || router == null)
            {
                throw new ArgumentNullException();
            }

            _styleHolder = styleHolder;
            _view = view;
            _interactor = interactor;
            _router = router;
            _view.Presenter = this;
            _interactor.Presenter = this;
            _postLocaleStrings = postLocaleStrings;

            _view.SetConfig();
        }


        public void ConfirmDeleteClick()
        {
            _interactor.DeletePostClick();
        }

        public void OptionsClick()
        {
            
            _view.OptionsDialogShow(_postLocaleStrings.OptionsHeader, _postLocaleStrings.DeletePost, _postLocaleStrings.Edit);
        }

        public void DeleteClick()
        {
            
            _view.ShowDeletingDialog(_postLocaleStrings.DeletePostMessage, _postLocaleStrings.DeletePostTitle, _postLocaleStrings.Yes, _postLocaleStrings.No);
        }

        public void EditClick()
        {
            _router.ToEditPost((_interactor as InteractorPostHeader).PostId);
        }

        public void FavoriteClick(bool isFavorite)
        {
            _interactor.FavoriteClick();
            SetQuoteFavoriteState(isFavorite);
        }

        public void ProfileClick()
        {
            _router.ToProfile();
        }


        public void SetHeader(IPostHeaderModel model, int position)
        {
            if (!string.IsNullOrEmpty(model.Quote) && !string.IsNullOrEmpty(model.Price) && !string.IsNullOrEmpty(model.Recommend)
                && !string.IsNullOrEmpty(model.Forecast) && !string.IsNullOrEmpty(model.CreatedAt))
            {
                _view.SetQuote(model.Quote);
                _view.SetRecommendValue(model.Price, position);
                SetRecommend(model.Recommend);             
                SetQuoteFavoriteState(model.IsQuoteFavorite);              
            }
        }

        public void SetUserHeader(IPostHeaderModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.AuthorAvatar)) // TODO
            {
                _view.SetAvatar(model.AuthorAvatar);
            }

            _view.SetName(model.AuthorName);
            _interactor.UpdateCreatedTime(model.CreatedAtDateTime);
            //SetStatusUser(model.StatusUser);
        }

        public void SetBrokerFields(PostHeaderBrokerModel model, int position)
        {
            
            _view.SetDifference(model.Difference + " " + _postLocaleStrings.Pips);
            _view.SetCurrentPrice(model.CurrentPrice, position);

            SetCurrentPriceImg(model.IsCurrentPriceIncreasing);
            SetDifferenceState(model.IsDifferencePositive);
        }

        public double GetPreviousPrice()
        {
            return _view.GetPreviousPrice();
        }

        public void SetOptionsButtonVisibility(bool isMyPost)
        {
            if (isMyPost)
            {
                _view.OptionsShow();
            }
            else
            {
                _view.OptionsHide();
            }
        }

        public void UpdateCreatedTime(string createdTime)
        {
            _view.SetCreateTime(createdTime);
        }

        public void UpdateTime(string time)
        {
            _view.SetForecastTime(time);
        }

        public void SetQuoteFavoriteState(bool isQuoteFavorite)
        {
            if (isQuoteFavorite)
            {
                _view.SetFavoriteState(isQuoteFavorite, _styleHolder.FavoriteStateActive);
            }
            else
            {
                _view.SetFavoriteState(isQuoteFavorite, _styleHolder.FavoriteStateNone);
            }
        }

        private void SetRecommend(string modelRecommend)
        {
            Enum.TryParse(modelRecommend, out EBuySell recommend);
            switch (recommend)
            {
                case EBuySell.Sell:
                    _view.SetRecommendBuySellImage(_styleHolder.RecommendSellImage);
                    _view.SetRecommend(modelRecommend);
                    break;
                case EBuySell.Buy:
                    _view.SetRecommendBuySellImage(_styleHolder.RecommendBuyImage);
                    _view.SetRecommend(modelRecommend);
                    break;
            }
        }

        private void SetDifferenceState(bool isDiffPositive)
        {
            if (isDiffPositive)
            {
                _view.SetDifferenceValue(_styleHolder.DifferenceValuePositive);
            }
            else
            {
                _view.SetDifferenceValue(_styleHolder.DifferenceValueNegative);
            }
        }

        private void SetCurrentPriceImg(bool isCurrentPriceIncreasing)
        {
            if (isCurrentPriceIncreasing)
            {
                _view.SetCurrentPriceImg(_styleHolder.CurrentPriceImgUp);
            }
            else
            {
                _view.SetCurrentPriceImg(_styleHolder.CurrentPriceImgDown);
            }
        }

        // TODO: Unused until status api won't be ready
        //private void SetStatusUser(bool userStatus)
        //{
        //    if (userStatus)
        //    {
        //        _view.SetStateOnline(_styleHolder.StateOnline);
        //    }
        //    else
        //    {
        //        _view.SetStateOffline(_styleHolder.StateOffline);
        //    }
        //}
        //TODO need to remove
        public IRepositoryPost GetRepository()
        {
            return _interactor.GetRepository();
        }

        public void SaveCachedImage(string base64)
        {
            _interactor.CacheImage(base64);
        }

        public void SetConfig()
        {
            _view.MoreOptionsButtonTheme(_styleHolder.MoreOptionsButtonTheme);
            _view.SetFirstLastNameTheme(_styleHolder.FirstLastNameTheme);
            _view.SetDateTheme(_styleHolder.DateTheme);
            _view.SetQuoteTheme(_styleHolder.QuoteTheme);
            _view.SetBuySellTheme(_styleHolder.BuySellTheme);
            _view.SetBuySellValueTheme(_styleHolder.BuySellValueTheme);
            _view.SetForecastTheme(_styleHolder.ForecastTheme);
            _view.SetCurrentPriceTheme(_styleHolder.CurrentPriceTheme);
            _view.SetDiffTheme(_styleHolder.DiffTheme);
            _view.SetDiffValueTheme(_styleHolder.DiffValueTheme);
            _view.SetDefaultAvatar(_styleHolder.DefaultAvatar);
        }

        public void SetLocale()
        {           
            _view.SetDifferenceLocale(_postLocaleStrings.Difference);
        }

        public void CheckResponseState(EPostHeaderResponseStatus state)
        {
            switch (state)
            {
                case EPostHeaderResponseStatus.Unauthorized:
                case EPostHeaderResponseStatus.Error:                
                    _view.ShowErrorAlert(_postLocaleStrings.DeletePostErrorMessage, _postLocaleStrings.DeletePostTitle);
                    break;
                case EPostHeaderResponseStatus.Success:
                    _view.ShowErrorAlert(_postLocaleStrings.DeletePostSuccessMessage, _postLocaleStrings.DeletePostTitle);
                    break;

                case EPostHeaderResponseStatus.NoConnection:
                    _view.ShowErrorAlert(_postLocaleStrings.NoConnection, _postLocaleStrings.DeletePostTitle);
                    break;
                default:
                  break;
            }
        }
    }
}
