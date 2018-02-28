using System;

using SocialTrading.DTO;
using SocialTrading.DTO.Request;
using SocialTrading.DTO.Response;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Interfaces;
using SocialTrading.DTO.Response.UserSettings;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.Controllers.Interfaces;

namespace SocialTrading.Vipers.Controllers
{
    public class OptionsProfileController : IOptionsProfileController
    {
        public IContactCreator ContactCreator { get; set; }
        public event Action<IModel> OnRecieveModel;
        private readonly IRepositoryUserAuth _repositoryUser;


        public OptionsProfileController(IRepositoryUserAuth repositoryUser)
        {
            _repositoryUser = repositoryUser ?? throw new ArgumentNullException();
        }


        public void Send(IModelSend senderModel)
        {
            if (!(senderModel is UserInfoRequestModel model))
            {
                return;
            }

            var userData = new DataModelProfileCell(_repositoryUser.AuthData.Name, _repositoryUser.AuthData.Image)
            {
                ControllerStatus = EControllerStatus.Ok
            };
            
            OnRecieveModel?.Invoke(userData);
        }

       
        public void SetMessage(IModelResponse responseModel)
        {
        }
    }
}
