using System;
using System.Collections.Generic;

using SocialTrading.DTO;
using SocialTrading.Tools;
using SocialTrading.DTO.Request;
using SocialTrading.Vipers.Entity;
using SocialTrading.DTO.Response.Post;
using SocialTrading.DTO.Request.Posts;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Vipers.CreatePost.Interfaces;
using SocialTrading.Vipers.Controllers.Interfaces;
using SocialTrading.Service.Interfaces.Repository;

namespace SocialTrading.Vipers.CreatePost.Implementation
{
    public class InteractorCreatePost : IInteractorCreatePost
    {
        public IPresenterCreatePost Presenter { private get; set; }
        
        private readonly IRepositoryCreatePost _repository;
        private readonly IRepositoryUserAuth _repositoryUser;
        private readonly ICreatePostController _createPostController;

        private QcBidAsk _qcBidAsk;
        private string _selectedTool;
        private EBuySell _selectedRecommend;
        private EControllerStatus _currentRecieveStatus = EControllerStatus.None;

        public InteractorCreatePost(ICreatePostController createPostController, IRepositoryCreatePost repository, IRepositoryUserAuth reopositoryUser)
        {
            _repository = repository;
            _repositoryUser = reopositoryUser;
            _createPostController = createPostController;

            _createPostController.OnRecieveModel += ControllerOnMessage;
            _createPostController.OnQcModelUpdate += ControllerOnMessageQC;
        }

        public void AddPost(string price, EBuySell recommend, EAccessMode access, string tool, EForecastTime timePeriod, string comment, string img)
        {
            if (_currentRecieveStatus == EControllerStatus.Processing)
            {
                return;
            }
            
            if (!CheckFields(price, recommend, access, tool, timePeriod, comment, img, out bool isPostSimple))
            {
                return;
            }
            comment = comment?.Trim(' ').Trim('\n');
            
            if (isPostSimple)
            {
                _createPostController.Send(new CreateSimplePostRequestModel(market: "Simple", access: access, content: comment, image: img));
            }
            else
            {
                _createPostController.Send(new CreatePostRequestModel(quote: tool, market: "Currency",
                    recommend: recommend, price: price, access: access, content: comment, forecast: timePeriod, image: img));
            }
        }

        public void AddPost(string price, EBuySell recommend, EAccessMode access, string tool, string timePeriod, string comment, string img)
        {
            if (_currentRecieveStatus == EControllerStatus.Processing)
            {
                return;
            }

            if (!CheckFields(price, recommend, access, tool, timePeriod, comment, img, out bool isPostSimple))
            {
                return;
            }
            comment = comment?.Trim(' ').Trim('\n');

            if (isPostSimple)
            {
                _createPostController.Send(new CreateSimplePostRequestModel(market: "Simple", access: access, content: comment, image: img));
            }
            else
            {
                _createPostController.Send(new CreatePostRequestModel(quote: tool, market: "Currency",
                    recommend: recommend, price: price, access: access, content: comment, forecast: timePeriod, image: img));
            }
        }

        private bool CheckFields(string price, EBuySell recommend, EAccessMode access, string tool, EForecastTime timePeriod, string comment, string img, out bool isSimple)
        {
            bool isFieldsValid = true;
            isSimple = true;
            bool commentState = !string.IsNullOrWhiteSpace(comment);

            if (IsBuySellSelected(recommend) || IsForecastTimeSelected(timePeriod) || IsToolSelected(tool))
            {
                if (!(IsBuySellSelected(recommend) && IsForecastTimeSelected(timePeriod) && IsToolSelected(tool)
                      && IsAccessModeSelected(access) && !string.IsNullOrWhiteSpace(price)))
                {
                    BuySellSelected(recommend);
                    ForecastTimeSelected(timePeriod);
                    ToolSelected(tool);
                    AccessModeSelected(access);
                    isFieldsValid = false;
                }
                isSimple = false;
            }

            if (string.IsNullOrWhiteSpace(img) && !IsCommentInput(commentState, true))
            {
                CommentInput(commentState, true);
                isFieldsValid = false;
            }
            
            return isFieldsValid;
        }

        private bool CheckFields(string price, EBuySell recommend, EAccessMode access, string tool, string timePeriod, string comment, string img, out bool isSimple)
        {
            bool isFieldsValid = true;
            isSimple = true;
            bool commentState = !string.IsNullOrWhiteSpace(comment);

            if (IsBuySellSelected(recommend) || IsForecastTimeSelected(timePeriod) || IsToolSelected(tool))
            {
                if (!(IsBuySellSelected(recommend) && IsForecastTimeSelected(timePeriod) && IsToolSelected(tool)
                      && IsAccessModeSelected(access) && !string.IsNullOrWhiteSpace(price)))
                {
                    BuySellSelected(recommend);
                    ForecastTimeSelected(timePeriod);
                    ToolSelected(tool);
                    AccessModeSelected(access);
                    isFieldsValid = false;
                }
                isSimple = false;
            }

            if (string.IsNullOrWhiteSpace(img) && !IsCommentInput(commentState, true))
            {
                CommentInput(commentState, true);
                isFieldsValid = false;
            }

            return isFieldsValid;
        }

        private void ControllerOnMessageQC(IModel postModel)
        {
            if (postModel is QcBidAsk modelQc)
            {
                _qcBidAsk = modelQc;
                SetPrice(PreparePrice(_selectedRecommend));
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
                    Presenter.AddPostState(EPostResponseStatus.NoConnection);
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
                Presenter.AddPostState(EPostResponseStatus.Error);
                return;
            }
            Presenter.AddPostState(model.Status);
        }

        private void GetMessage(IModel postModel)
        {
            if (postModel is DataModelCreatePost model)
            {
                if (model.Status == EPostResponseStatus.Success)
                {
                    _createPostController.OnRecieveModel -= ControllerOnMessage;
                    Presenter.GoToMain();
                }
                Presenter.AddPostState(model.Status);
            }
        }

        public void ReadyToSetPrice(string tool, EBuySell recommend)
        {
            if (string.IsNullOrWhiteSpace(tool) || recommend == EBuySell.None)
            {
                SetPrice(_repository.LangCreatePost.PriceLabel);
                return;
            }

            _selectedRecommend = recommend;
            _selectedTool = tool.Replace("/", "");
            _createPostController.SetQuote(_selectedTool);
        }

        private string PreparePrice(EBuySell recommend)
        {
            if (_qcBidAsk == null)
            {
                return _repository.LangCreatePost.PriceLabel;
            }

            var price = recommend == EBuySell.Buy ? _qcBidAsk.QcAsk : _qcBidAsk.QcBid;

            return price;
        }

        private void SetPrice(string price)
        {
            Presenter.SetPrice(price);
        }


        public void CommentInput(bool state, bool isPressedPublish = false)
        {
            Presenter.CommentState(IsCommentInput(state, isPressedPublish) ? EState.None : EState.Fail);
        }

        private bool IsCommentInput(bool state, bool isPressedPublish = false)
        {
            if (state || !isPressedPublish)
            {
                return true;
            }
            return false;
        }

        public void BuySellSelected(EBuySell recommend)
        {
            Presenter.BuySellState(IsBuySellSelected(recommend) ? EState.None : EState.Fail);
        }

        private bool IsBuySellSelected(EBuySell recommend)
        {
            if (recommend != EBuySell.None)
            {
                return true;
            }
            return false;
        }

        public void ForecastTimeSelected(EForecastTime timePeriod)
        {
            Presenter.ForecastTimeState(IsForecastTimeSelected(timePeriod) ? EState.None : EState.Fail);
        }

        private bool IsForecastTimeSelected(EForecastTime timePeriod)
        {
            if (timePeriod != EForecastTime.None)
            {
                return true;
            }
            return false;
        }

        public void ForecastTimeSelected(string timePeriod)
        {
            Presenter.ForecastTimeState(IsForecastTimeSelected(timePeriod) ? EState.None : EState.Fail);
        }

        private bool IsForecastTimeSelected(string timePeriod)
        {
            if (!string.IsNullOrWhiteSpace(timePeriod))
            {
                return true;
            }
            return false;
        }
        
        public void ToolSelected(string tool)
        {
            Presenter.ToolState(IsToolSelected(tool) ? EState.None : EState.Fail);
        }

        private bool IsToolSelected(string tool)
        {
            if (string.IsNullOrWhiteSpace(tool) || tool.Equals(_repository?.LangCreatePost.ToolsButton))
			{
                return false;
			}
            return true;
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


        public void SaveAttachedImage(string attachedImage)
        {
            _repository.AttachmentImage = attachedImage;
        }

        public string LoadAttachedImage()
        {
            return _repository.AttachmentImage;
        }

        public void SaveSelectedTool(string selectedTool)
        {
            if (string.IsNullOrWhiteSpace(selectedTool))
            {
                return;
            }

            _repository.SelectedTool = selectedTool;
            _selectedTool = selectedTool;
        }

        public string LoadSelectedTool()
        {
            return _repository.SelectedTool;
        }

        public ForecastTimeModel GetForecastTimeModel()
        {
            return CreateForecastTimeModel(DAL.MaxForecastTime, DateTime.Now);
        }

        public IRepositoryCreatePost GetRepository()
        {
            return _repository;
        }

        public void DisposeRepositoryCreatePost()
        {
            _repository.ConfigRepositoryCreatePost();
        }


        public void SaveData(CreatePostStrings createPostStrings)
        {
            _repository.CreatePostStrings = createPostStrings;
        }

        public CreatePostStrings LoadData()
        {
            var savedData = _repository.CreatePostStrings;
            if (savedData != null)
            {
                _selectedRecommend = savedData.BuySell.GetRecommendEnum();
            }

            return savedData;
        }


        public void SetConfig()
        {
            Presenter.SetUserName(_repositoryUser.AuthData.Name);
            Presenter.SetUserAvatar(_repositoryUser.AuthData.Image);
        }


        public void Dispose()
        {
            _createPostController.OnRecieveModel -= ControllerOnMessage;
            _createPostController.OnQcModelUpdate -= ControllerOnMessage;
        }

        #region ForecastTime

        private ForecastTimeModel CreateForecastTimeModel(int maxForecastTime, DateTime date)
        {
            ForecastTimeModel model = new ForecastTimeModel();
            
            var daysInCurrentMonth = DateTime.DaysInMonth(date.Year, date.Month);

            model.Years.Add(date.Year.ToString());
            model.DaysRange.Add(new int[] { date.Day, date.Day + maxForecastTime > daysInCurrentMonth ? daysInCurrentMonth : date.Day + maxForecastTime});

            var forecastDate = date.AddMonths(1);
            var overlappedDays = maxForecastTime - (daysInCurrentMonth - date.Day) - 1;
            var overlappedMonths = 0;

            while (overlappedDays > 0)
            {
                daysInCurrentMonth = DateTime.DaysInMonth(forecastDate.Year, forecastDate.Month);
                model.DaysRange.Add(new int[] { 1, overlappedDays - daysInCurrentMonth > 0 ? daysInCurrentMonth : overlappedDays });
                overlappedDays -= daysInCurrentMonth;

                if (date.Year < forecastDate.Year && !model.Years.Contains(forecastDate.Year.ToString()))
                {
                    model.Years.Add(forecastDate.Year.ToString());
                }

                forecastDate = forecastDate.AddMonths(1);
                overlappedMonths++;
            }

            model = GetMonths(model, overlappedMonths, date);
            model = GetTime(model);

            return model;
        }

        private ForecastTimeModel GetTime(ForecastTimeModel model)
        {
            model.Hours.AddRange(_repository.LangCreatePost.Hours);
            model.Minutes.AddRange(new Func<List<string>>(() =>
            {
                var minutes = new List<string>();

                for (int i = 0; i < 60; i++)
                {
                    minutes.Add((i < 10 ? "0" + i : i.ToString()) + " " + _repository.LangCreatePost.MinutesEnding);
                }

                return minutes;
            }).Invoke());

            return model;
        }

        private ForecastTimeModel GetMonths(ForecastTimeModel model, int overlappedMonths, DateTime date)
        {
            model.MonthsRange.Add(new int[] { date.Month, date.Month });

            var monthsLeft = 12 - date.Month;

            if (monthsLeft + 1 < 12 && overlappedMonths > monthsLeft)
            {
                model.MonthsRange[model.MonthsRange.Count - 1][1] = 12;
            }
            else if (monthsLeft + 1 < 12 && overlappedMonths < monthsLeft)
            {
                model.MonthsRange[model.MonthsRange.Count - 1][1] += overlappedMonths;
            }

            overlappedMonths -= monthsLeft;

            if (overlappedMonths > 0)
            {
                while (overlappedMonths >= 12)
                {
                    model.MonthsRange.Add(new int[] { 1, 12 });
                    overlappedMonths -= 12;
                }

                model.MonthsRange.Add(new int[] { 1, overlappedMonths });
                overlappedMonths = 0;
            }

            return model;
        }

        #endregion
    }
}
