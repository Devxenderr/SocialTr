using System;

using SocialTrading.DTO.Request;
using SocialTrading.DTO.Request.RA;
using SocialTrading.DTO.Response.RA;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Tools.Validation.Interfaces;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.Controllers.Interfaces;
using SocialTrading.Vipers.Authorization.Interfaces;

namespace SocialTrading.Vipers.Authorization.Implementation
{
    public class InteractorAuth : IInteractorAuth
    {
        public IPresenterAuth Presenter { private get; set; }
        
        private readonly IValidationRA _validation;
        private readonly IAuthController _authController;
        private EControllerStatus _currentRecieveStatus = EControllerStatus.None;

        public event Action<ESocialType> OnSocialLogOut;

        public InteractorAuth(IAuthController authController, IValidationRA validation)
        {
            _validation = validation;
            _authController = authController;
            _authController.OnRecieveModel += ControllerOnMessage;
        }


        public void LoginClick(string email, string pass)
        {
            if (_currentRecieveStatus == EControllerStatus.Processing || !(EmailInput(email) & PasswordInput(pass)))
            {
                return;
            }

            _authController.Send(new UserAuth(email, pass));
        }

        public bool EmailInput(string email)
        {
            if (_validation.CheckEmail(email))
            {
                Presenter?.SetEmailState(EState.Success);
                return true;
            }
            Presenter?.SetEmailState(EState.Fail);
            return false;
        }
        
        public bool PasswordInput(string pass)
        {
            if (_validation.CheckPassword(pass))
            {
                Presenter?.SetPasswordState(EState.Success);
                return true;
            }
            Presenter?.SetPasswordState(EState.Fail);
            return false;
        }

        private void ControllerOnMessage(IModel authModel)
        {
            _currentRecieveStatus = EControllerStatus.None;
            switch (authModel.ControllerStatus)
            {
                case EControllerStatus.Ok:
                    GetMessage(authModel);
                    break;
                case EControllerStatus.Processing:
                    Presenter.ShowHideSpinner(true);
                    _currentRecieveStatus = EControllerStatus.Processing;
                    break;
                case EControllerStatus.NoConnection:
                    Presenter.ShowHideSpinner(false);
                    Presenter.CheckAuthState(EAuthResponseStatus.NoConnection);
                    break;
                case EControllerStatus.None:
                case EControllerStatus.Error:
                default:
                    GetMessage(authModel);
                    break;
            }
        }

        private void GetMessage(IModel authModel)
        {
            if (authModel is DataModelAuth == false)
            {
                Presenter.ShowHideSpinner(false);
                Presenter.CheckAuthState(EAuthResponseStatus.Error);
                return;
            }

            var model = (DataModelAuth) authModel;
            switch (model.Status)
            {
                case EAuthResponseStatus.Success:
                    _authController.OnRecieveModel -= ControllerOnMessage;
                    break;
                case EAuthResponseStatus.UnprocessableEntity:
                    OnSocialLogOut?.Invoke(ESocialType.Facebook);
                    break;
                default:
                case EAuthResponseStatus.Error:
                case EAuthResponseStatus.Unauthorized:                   
                case EAuthResponseStatus.NoConnection:
                    break;
            }

            Presenter.CheckAuthState(model.Status);
            Presenter.ShowHideSpinner(false);
            _currentRecieveStatus = EControllerStatus.None;
        }

        public void DisposeRepositoryRA()
        {
            // TODO For Kate: Fix it
            //_repository.ConfigRepositoryRA();
        }

        public IRepositoryRA GetRepository()
        {
            return null;
        }
        
        public void SocialLoginPerform(ESocialType socialType, Action loginActionPlatform)
        {
            loginActionPlatform?.Invoke();
        }


        public void Dispose()
        {
            _authController.OnRecieveModel -= ControllerOnMessage;
        }

        public void OnCancel(ESocialType socialType)
        {
          //  Presenter.CheckAuthState(EAuthResponseStatus.Error);
        }

        public void OnError(string error, ESocialType socialType)
        {
            Presenter.CheckAuthState(EAuthResponseStatus.Error);
        }

        public void OnSuccess(string accessToken, ESocialType socialType)
        {
            if (!string.IsNullOrEmpty(accessToken))
            {
                _authController.Send(new FacebookUserAuth(accessToken));
            }
        }
    }
}
