using System;
using System.Globalization;

using SocialTrading.Tools;
using SocialTrading.DTO.Request;
using SocialTrading.DTO.Response.Qc;
using SocialTrading.DTO.Response.Post;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.ModelCreators;
using SocialTrading.Connection.Interfaces;
using SocialTrading.DTO.Response.Post.Interfaces;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.Post.Interfaces.Header;
using SocialTrading.Vipers.Controllers.Interfaces;
using SocialTrading.DTO.Response.Post.ConstituentParts;
using System.Diagnostics;

namespace SocialTrading.Vipers.Post.Implementation.Header
{
    public class InteractorPostHeader : IInteractorPostHeader
    {
#if DEBUG
        private static int count;
#endif

        public IPresenterPostHeader Presenter { set; private get; }

        public string PostId { get; }

        private readonly IRepositoryPost _repository;
        private readonly IPostHeaderController _postHeaderController;

        private bool _isFavorite;
        private IPostHeaderModel _postHeaderModel;
        private PostHeaderBrokerModel _brokerDataModel;
        private DateTime _forecastDate = DateTime.MinValue;

        private const int CamelNumbersLength = 2;


        public InteractorPostHeader(string postId, IPostHeaderController postHeaderController, IRepositoryPost repository)
        {
            PostId = postId;
            _repository = repository;
            _postHeaderController = postHeaderController;

            _postHeaderController.OnRecieveModel += ControllerOnMessage;
            _postHeaderController.OnQcModelUpdate += OnMessageQc;
        }

        private void ControllerOnMessage(IModel incomeModel)
        {
            if (incomeModel is DataModelDeletePost model)
            {
                if (model.Status == EPostHeaderResponseStatus.Success)
                {
                    _postHeaderController.OnRecieveModel -= ControllerOnMessage;
                }

                Presenter.CheckResponseState(model.Status);
            }
            else 
            {
                Presenter.CheckResponseState(EPostHeaderResponseStatus.NoConnection);
            }
        }

        private void OnMessageQc(IModel incomeModel)
        {
            if (_postHeaderModel == null)
            {
                return;
            }

            if (incomeModel is DataModelQc modelQc)
            {
#if DEBUG
                if (modelQc.QcId == 123)
                {
                    Debug.WriteLine("#" + ++count + " _" + modelQc.QcTimestamp + " NAME_" + _postHeaderModel.AuthorName + " HASH_" + GetHashCode());
                }
#endif

                if (_brokerDataModel == null)
                {
                    _brokerDataModel = new PostHeaderBrokerModelCreator(modelQc).GetModel();
                }
                else
                {
                    _brokerDataModel.Update(modelQc);
                }

                PrepareBrokerData(_brokerDataModel, _postHeaderModel);
            }
        }

        public IRepositoryPost GetRepository()
        {
            return _repository;
        }

        public IRepositoryUserSettings GetRepositoryUserSettings()
        {
            return _repository as IRepositoryUserSettings;
        }

        public void UpdateCreatedTime(DateTime createdTime)
        {
            Presenter.UpdateCreatedTime(CalcCreatedTime(createdTime, DateTime.Now));                   
        }

        public string CalcCreatedTime(DateTime time, DateTime nowDateTime)
        {
            string result = string.Empty;

            if (time == DateTime.MinValue || nowDateTime == DateTime.MinValue)
            {
                return result;               
            }
        
            var lang = _repository.LangPost;

            var createdTime = (int) Math.Abs(nowDateTime.Subtract(time).TotalSeconds);

            if (createdTime < 60 && createdTime >= 0)
            {
                result = lang.CreateNow;
            }
            else if (createdTime >= 60 && createdTime < 3600)
            {
                result = createdTime / 60 + " " + lang.MinutesEndingCreatedAt;
            }
            else if (createdTime >= 3600 && createdTime < 24 * 3600)
            {
                result = createdTime / 3600  + " " + lang.HourEnding;
            }
            else if (Convert.ToInt32(time.Year) == nowDateTime.Year)
            {
                result = time.ToString("dd") + " " + lang.MonthsCreatedAt[Convert.ToInt32(time.ToString("MM")) - 1] + " " + time.ToString("HH") + ":" + time.ToString("mm");
            }
            else
            {
                result = time.ToString("dd") + " " + lang.MonthsCreatedAt[Convert.ToInt32(time.Month) - 1] + " " + time.ToString("yyyy");
            }

            return result;
        }

        public void FavoriteClick()
        {
            // TODO: add api
            _isFavorite = true;
            Presenter.SetQuoteFavoriteState(_isFavorite);
        }

        public void DeletePostClick()
        {
            _postHeaderController.Send(new DeletePostRequestModel(PostId));
        }

        public bool SetPriceStatus(double previousPrice, double currentPrice)
        {
            return !(previousPrice > currentPrice);
        }

        public int SetDifferenceAmmount(string price, string currentPrice, bool isSell, int camelPositionPrice, int camelPositionCurrentPrice)
        {
            var decSepPrice = price.Contains(".") ? "." : ",";
            var decSepCurrentPrice = currentPrice.Contains(".") ? "." : ",";

            var signPartPrice = price.Substring(0, camelPositionPrice + CamelNumbersLength);
            var dotPosPrice = signPartPrice.IndexOf(decSepPrice, StringComparison.Ordinal);
            var priceString = signPartPrice;

            if (dotPosPrice != -1)
            {
                 priceString = signPartPrice.Remove(dotPosPrice, 1);
            }
           
            var signPartCurrentPrice = currentPrice.Substring(0, camelPositionCurrentPrice + CamelNumbersLength);
            var dotPosCurrentPrice = signPartCurrentPrice.IndexOf(decSepCurrentPrice, StringComparison.Ordinal);

            var currentPriceString = signPartCurrentPrice;
            if (dotPosCurrentPrice != -1)
            {
                currentPriceString = signPartCurrentPrice.Remove(dotPosCurrentPrice, 1);
            }

            int priceDouble = Convert.ToInt32(priceString);
            int currentPriceDouble = Convert.ToInt32(currentPriceString);
            
            var varResultSell = (isSell ? 1 : -1) * (priceDouble - currentPriceDouble);

            return varResultSell;
        }

        public int GetCamelPos(string str)
        {
            int pos;

            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            var decSep = str.Contains(".") ? "." : ",";

            var dotPos = str.IndexOf(decSep, StringComparison.CurrentCulture);

            if (dotPos == -1)
            {
                pos = str.Length - 3;
            }
            else if (dotPos == str.Length - (1 + decSep.Length))
            {
                pos = dotPos - 2;
            }
            else if (dotPos == str.Length - (2 + decSep.Length))
            {
                pos = dotPos + decSep.Length;
            }
            else
            {
                pos = str.Length - 3;
            }

            return pos >= 0 ? pos : 0;
        }

        public void ChangeTime(DateTime nowTime)
        {
            if (_forecastDate == default(DateTime))
            {
                return;
            }
            var secondsLeft = Convert.ToInt32(_forecastDate.Subtract(nowTime).TotalSeconds);

            if (secondsLeft < 0)
            {
                Presenter.UpdateTime(_repository.LangPost
                    .ForecastTimeEnd);
                return;
            }

            if (secondsLeft.Equals(0))
            {
                Presenter.UpdateTime(_repository.LangPost.ForecastTimeEnd);
                return;
            }

            var dateTime = TimeSpan.FromSeconds(secondsLeft).ToString().GetTime();
            Presenter.UpdateTime(dateTime);
        }

        private bool SetBidAskPrice(PostHeaderBrokerModel postHeaderBrokerModel, EBuySell recommend)
        {
            if (recommend == EBuySell.Buy)
            {
                postHeaderBrokerModel.CurrentPrice = postHeaderBrokerModel.CurrentPriceAsk;
                return false;
            }

            postHeaderBrokerModel.CurrentPrice = postHeaderBrokerModel.CurrentPriceBid;
            return true;

        }

        private string AlignRorPrice(string accordancePrice, string changablePrice) //(PostHeaderBrokerModel postHeaderBrokerModel, IPostHeaderModel postHeaderModel)
        {
            var decSepA = accordancePrice.Contains(".") ? "." : ",";
            var decSepC = changablePrice.Contains(".") ? "." : ",";
            var decSepNum = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
            accordancePrice = accordancePrice.Replace(decSepA, decSepNum);
            changablePrice = changablePrice.Replace(decSepC, decSepNum);

            if (!changablePrice.Contains(decSepNum))
            {
                changablePrice += decSepNum + "0";
            }

            var accordanceLength = accordancePrice.Length - accordancePrice.IndexOf(decSepNum, StringComparison.CurrentCulture);
            var changableLength = changablePrice.Length - changablePrice.IndexOf(decSepNum, StringComparison.CurrentCulture);
            if (accordanceLength - changableLength > 0)
            {
                changablePrice += new String('0', accordanceLength - changableLength);
            }

            return changablePrice;
        }

        private void PrepareBrokerData(PostHeaderBrokerModel postHeaderBrokerModel, IPostHeaderModel postHeaderModel)
        {
            if (postHeaderModel == null || postHeaderBrokerModel == null)
            {
                return;
            }
            Enum.TryParse(postHeaderModel.Recommend, out EBuySell recommend);

            if (recommend != EBuySell.Buy && recommend != EBuySell.Sell)
            {
               return;
            }
       
            bool isSell = SetBidAskPrice(postHeaderBrokerModel, recommend);

            int camelPositionCurrentPrice = GetCamelPos(postHeaderBrokerModel.CurrentPrice);

            postHeaderModel.Price = AlignRorPrice(postHeaderBrokerModel.CurrentPrice, postHeaderModel.Price);
            int camelPositionPrice = GetCamelPos(postHeaderModel.Price);

            var prevPrice = Presenter.GetPreviousPrice();
            var doubleCurrentPrice =  double.Parse(postHeaderBrokerModel.CurrentPrice, CultureInfo.InvariantCulture);

            postHeaderBrokerModel.IsCurrentPriceIncreasing = SetPriceStatus(prevPrice, doubleCurrentPrice);

            try
            {
                postHeaderBrokerModel.IsCurrentPriceIncreasing = SetPriceStatus(Presenter.GetPreviousPrice(),Convert.ToDouble(postHeaderBrokerModel.CurrentPrice));
            }
            catch (Exception)
            {
                return;
            }

            try
            {
                var difference = SetDifferenceAmmount(postHeaderModel.Price, postHeaderBrokerModel.CurrentPrice, isSell,
                    camelPositionPrice, camelPositionCurrentPrice);

                postHeaderBrokerModel.IsDifferencePositive = difference > 0;
                postHeaderBrokerModel.Difference = difference;
            }
            catch (Exception)
            {
                return;
            }

            Presenter.SetBrokerFields(postHeaderBrokerModel, camelPositionCurrentPrice);
        }

        private void PepareHeaderData(IPostHeaderModel postHeaderModel)
        {
            Presenter.SetOptionsButtonVisibility(postHeaderModel.IsMyPost);


            if (postHeaderModel.Market == EMarketTypes.Simple.ToString())
            {
                Presenter.SetUserHeader(postHeaderModel);
            }
            else
            {
                Presenter.SetHeader(postHeaderModel, GetCamelPos(postHeaderModel.Price));
                Presenter.SetUserHeader(postHeaderModel);
            }
        }

        public void RecieveModel(DataModelPost data)
        {
            if (data is IPostHeaderModel userModel)
            {
                _postHeaderModel = userModel;
                _forecastDate = userModel.ForecastDateTime;
                PepareHeaderData(userModel);
            }
            if (_brokerDataModel == null)
            {
                _postHeaderController.GetQc();
            }
        }

        public void CacheImage(string base64)
        {
            _repository.GetPostHeaderModelById(PostId).CachedAvatar = base64;
        }


        public void Dispose()
        {
            _postHeaderController.OnRecieveModel -= ControllerOnMessage;
            _postHeaderController.OnQcModelUpdate -= OnMessageQc;
        }
    }
}