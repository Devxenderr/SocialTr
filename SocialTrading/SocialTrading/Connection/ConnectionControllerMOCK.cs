using System;
using System.Linq;
using System.Collections.Generic;

using SocialTrading.DTO;
using SocialTrading.DTO.Response;
using SocialTrading.DTO.Response.Post;
using SocialTrading.DTO.Request.Posts;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Vipers.Controllers.Interfaces;

namespace SocialTrading.Connection
{
    // TODO: return MOCKs
    public class ConnectionControllerMOCK : IPostsController
    {
        public IContactCreator ContactCreator { set; private get; }

        public event Action<IModel> OnRecieveModel;

        public void Send(IModelSend model)
        {
            if (model is PostsRequestModel)
            {
                var result = new List<DataModelPost>
                {
                    new DataModelPost("111", "111", "AUDJPY", "Currency", "Buy", 12.23f, "Public", "http://www.meridianpeakhypnosis.com/wp-content/uploads/2014/02/money-addiction.jpg", "Hello", "2017-07-24T00:00:01.00Z", "2017-07-25T00:00:01.00Z", null, "Jon Snow", "https://pbs.twimg.com/profile_images/901947348699545601/hqRMHITj.jpg", 2, 5, true),
                    new DataModelPost("222", "222", "AUDCAD", "Currency", "Buy", 58.45f, "Public", null, "This method reloads all the data in the table, including cells, headers, footers and the index array. For efficiency, only visible rows are have their cells loaded and displayed. A table view's UITableView.Source calls this method when it wants to completely reload data. This method should not be called inside other methods that insert or delete rows, especially within a UITableView.BeginUpdates-UITableView.EndUpdates animation block.", "2017-07-24T00:00:01.00Z", "2017-07-25T00:00:01.00Z", null, "Petr Ivanov", "https://bhi61nm2cr3mkdgk1dtaov18-wpengine.netdna-ssl.com/wp-content/uploads/2017/03/pig_thm.jpg", 7, 8, false),
                    new DataModelPost("333", "333", "AUDUSD", "Currency", "Sell", 58.45f, "Public", null, "Why do you want to use a TableView? Answering this question is important to implementing a proper solution. If you are going to potentially have a lot of rows in the TableView, you will have to get creative with your solution. I want to help, but need some more guidance of what you are trying to achieve in the application with this TableView (like is it a settings page, or displaying dynamic rows to users etc.", "2017-07-24T00:00:01.00Z", "2017-07-25T00:00:01.00Z", null, "Petr Azarov", null, 11, 3, false)
                };

                Service.DataService.RepositoryController.RepositoryPost.SetPosts( result.Distinct().ToDictionary(key => key.Id, value => value));

                var postsModel = new postMockModel(Service.DataService.RepositoryController.RepositoryPost.GetPostIds());
                postsModel.ControllerStatus = EControllerStatus.Ok;

                OnRecieveModel?.Invoke(postsModel);
            }
        }

        public void SetMessage(IModelResponse responseModel)
        {            
        }

        private class postMockModel : List<string>, IModel
        {
            public postMockModel(IEnumerable<string> collection) : base(collection)
            {
            }

            public EControllerStatus ControllerStatus { get; set; }
        }
    }
}
