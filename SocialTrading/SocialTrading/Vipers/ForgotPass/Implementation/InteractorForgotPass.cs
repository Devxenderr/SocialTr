using System;
using SocialTrading.DTO.Request.RA;
using SocialTrading.DTO.Response.RA;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Tools.Validation.Interfaces;
using SocialTrading.Vipers.ForgotPass.Interfaces;
using SocialTrading.Vipers.Controllers.Interfaces;

namespace SocialTrading.Vipers.ForgotPass.Implementation
{
    public class InteractorForgotPass : IInteractorForgotPass
    {
        public IPresenterForgotPass Presenter { private get; set; }

        private readonly IValidationRA _validation;
        private readonly IForgotPassController _forgotPassController;
        private EControllerStatus _currentRecieveStatus = EControllerStatus.None;

        public InteractorForgotPass(IValidationRA validation, IForgotPassController forgotPassController)
        {
            _validation = validation;
            _forgotPassController = forgotPassController;
            _forgotPassController.OnRecieveModel += ControllerOnMessage;
        }


        public bool EmailInput(string email)
        {
            if (_validation.CheckEmail(email))
            {
                Presenter.SetEmailState(EState.Success);
                return true;
            }
            Presenter.SetEmailState(EState.Fail);
            return false;
        }

        public void PassRecoveryClick(string email)
        {
            if (_currentRecieveStatus == EControllerStatus.Processing || !EmailInput(email))
            {
                return;
            }
            _forgotPassController.Send(new EmailModel(email));
        }

        public void ControllerOnMessage(IModel forgotPassModel)
        {
            _currentRecieveStatus = EControllerStatus.None;

            switch (forgotPassModel.ControllerStatus)
            {
                case EControllerStatus.Ok:
                    Presenter.ShowHideSpinner(false);
                    _currentRecieveStatus = EControllerStatus.None;
                    GetMessage(forgotPassModel as DataRecoveryPasswordResponse);
                    break;
                case EControllerStatus.Processing:
                    Presenter.ShowHideSpinner(true);
                    _currentRecieveStatus = EControllerStatus.Processing;
                    break;
                case EControllerStatus.NoConnection:
                    Presenter.ShowHideSpinner(false);
                    Presenter.ShowAlertEmailRedirect(EForgotPassStatus.NoConnection);
                    break;
                case EControllerStatus.None:
                case EControllerStatus.Error:
                default:
                    Presenter.ShowHideSpinner(false);
                    Presenter.ShowAlertEmailRedirect(EForgotPassStatus.Error);
                    break;
            }
        }

        private void GetMessage(DataRecoveryPasswordResponse dataRecoveryPasswordResponse)
        {
            if (dataRecoveryPasswordResponse == null)
            {
                return;
            }

            if (dataRecoveryPasswordResponse.Status == EForgotPassStatus.RecoverySuccess)
            {
                _forgotPassController.OnRecieveModel -= ControllerOnMessage;
            }
            
            Presenter.ShowAlertEmailRedirect(dataRecoveryPasswordResponse.Status);
        }

        public void Dispose()
        {
            _forgotPassController.OnRecieveModel -= ControllerOnMessage;
        }

    }
}
