using System;
using System.IO;
using SocialTrading.Connection.Interfaces;
using SocialTrading.DTO.Request;
using SocialTrading.DTO.Response.UserSettings;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Controllers.Interfaces;
using SocialTrading.Vipers.ProfileCell.Interfaces;

namespace SocialTrading.Vipers.ProfileCell.Implementation
{
    public class InteractorProfileCell : IInteractorProfileCell
    {
        private readonly IOptionsProfileController _controller;
        private readonly string _userId;

        public IPresenterProfileCellForInteractor Presenter { get; set; }

        public InteractorProfileCell(string userId, IOptionsProfileController controller)
        {
            _controller = controller ?? throw new NullReferenceException(nameof(controller));
            _userId = userId;

            _controller.OnRecieveModel += ControllerOnMessage;
        }

        private void ControllerOnMessage(IModel userModel)
        {
            if (!(userModel is DataModelProfileCell model))
            {
                return;
            }

            if (model.ControllerStatus == EControllerStatus.Ok)
            {
                FillUserData(model);
                _controller.OnRecieveModel -= ControllerOnMessage;
            }
        }

        private void FillUserData(DataModelProfileCell model)
        {
            Presenter.SetAvatar(model.Image);
            Presenter.SetName(model.Name);
        }

        public void SetConfig()
        {
            
        }

        public void SendRequestForUserData()
        {
           _controller.Send(new UserInfoRequestModel(_userId));
        }


        public void Dispose()
        {
            _controller.OnRecieveModel -= ControllerOnMessage;
        }
    }
}
