using SocialTrading.DTO.Response.Post;
using SocialTrading.DTO.Response.Post.Interfaces;
using SocialTrading.Vipers.Post.Interfaces.Body;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Service.Interfaces.Notifications;

namespace SocialTrading.Vipers.Post.Implementation.Body
{
    public class InteractorPostBody : IInteractorPostBody
    {
        public IPresenterPostBody Presenter { set; private get; }
        public bool IsPostDetailed { set; get; }

        private readonly IRepositoryPost _repository;
        private readonly INotificationCenterPostBody _notificationCenter;
        public string PostId { get; }


        public InteractorPostBody(string postId, INotificationCenterPostBody notificationCenter, IRepositoryPost repository)
        {
            PostId = postId;

            _repository = repository;
            _notificationCenter = notificationCenter;
          //  _notificationCenter.PostBodyDataIncome = OnNotificationIncome;
        }

        public IRepositoryPost GetRepository()
        {
            return _repository;
        }

        //public void OnNotificationIncome<T>(T data)
        //{
        //    if (data is IPostBodyModel model)
        //    {
        //        if (!IsPostDetailed)
        //        {
        //            int symbolsCount = CountContentLength(model.Content, _repository.MinimizedPostContentLength);
        //            Presenter.SetBody(model, symbolsCount);
        //        }
        //        else
        //        {
        //            Presenter.SetBody(model);
        //        }
        //    }
        //}

        public void RecieveModel(DataModelPost data)
        {
            if (data is IPostBodyModel model)
            {
                if (!IsPostDetailed)
                {
                    int symbolsCount = CountContentLength(model.Content, _repository.MinimizedPostContentLength, _repository.MaxMinimizedPostContentLength);
                    Presenter.SetBody(model, symbolsCount);
                }
                else
                {
                    Presenter.SetBody(model);
                }
            }
        }

        private int CountContentLength(string content, int symbolsCount, int maxSymbolsCount)
        {
            if (content.Length < symbolsCount)
            {
                return content.Length;
            }

            int minimizedContentSymbolsCount = symbolsCount;

            while (content.Length > minimizedContentSymbolsCount  && minimizedContentSymbolsCount < maxSymbolsCount && 
                !(content[minimizedContentSymbolsCount].Equals(' ') || content[minimizedContentSymbolsCount].Equals('.')
              || content[minimizedContentSymbolsCount].Equals(',') || content[minimizedContentSymbolsCount].Equals('!') 
              || content[minimizedContentSymbolsCount].Equals('?') || content[minimizedContentSymbolsCount].Equals(';') 
              || content[minimizedContentSymbolsCount].Equals(':')))
            {
                minimizedContentSymbolsCount++;
            }

            string minimizedContent = content.Substring(0, minimizedContentSymbolsCount);
            minimizedContentSymbolsCount = minimizedContent.Length;

            return minimizedContentSymbolsCount;
        }

        public void CacheImage(string base64)
        {
            _repository.GetPostBodyModelById(PostId).CachedImage = base64;
        }
    }
}
