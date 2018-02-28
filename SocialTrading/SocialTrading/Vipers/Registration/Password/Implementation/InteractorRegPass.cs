using System;
using SocialTrading.Vipers.Entity;
using SocialTrading.DTO.Response.RA;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Tools.Validation.Interfaces;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.Controllers.Interfaces;
using SocialTrading.Vipers.Registration.Password.Interfaces;

namespace SocialTrading.Vipers.Registration.Password.Implementation
{
    public class InteractorRegPass : IInteractorRegPass
    {
        public IPresenterRegPass Presenter { private get; set; }

        private readonly IRepositoryRA _repository;
        private readonly IValidationRA _validation;
        private readonly IRegController _regController;
        private EControllerStatus _currentRecieveStatus = EControllerStatus.None;

        public InteractorRegPass(IRegController regController, IRepositoryRA repository, IValidationRA validation)
        {
            _repository = repository;
            _validation = validation;
            _regController = regController;
            _regController.OnRecieveModel += ControllerOnMessage;
        }


        public bool PasswordConfirmInput(string pass, string passConfirm)
        {
            if (!string.IsNullOrEmpty(pass) & pass.Equals(passConfirm))
            {
                Presenter?.SetPasswordConfirmState(EState.Success);
                return true;
            }
            Presenter?.SetPasswordConfirmState(EState.PassDoesNotMatch);
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

        public void RegistrationClick(RegistrationPasswordStrings data)
        {
            if (_currentRecieveStatus == EControllerStatus.Processing || !(PasswordInput(data.Password) & PasswordConfirmInput(data.Password, data.ConfirmPass)))
            {
                return;
            }

            _repository.User.Password = data.Password;
            _regController.Send(_repository.User);
        }

        public void ControllerOnMessage(IModel regModel)
        {
            _currentRecieveStatus = EControllerStatus.None;

            switch (regModel.ControllerStatus)
            {
                case EControllerStatus.Ok:
                    GetMessage(regModel);
                    break;
                case EControllerStatus.Processing:
                    Presenter.ShowHideSpinner(true);
                    _currentRecieveStatus = EControllerStatus.Processing;
                    break;
                case EControllerStatus.NoConnection:
                    Presenter.ShowHideSpinner(false);
                    Presenter.RegStateFail(ERegResponseStatus.NoConnection);
                    break;
                case EControllerStatus.None:
                case EControllerStatus.Error:
                default:
                    Presenter.ShowHideSpinner(false);
                    Presenter.RegStateFail(ERegResponseStatus.Error);
                    break;
            }
        }

        private void GetMessage(IModel regModel)
        {
            if (regModel is DataModelReg model && model.Status == ERegResponseStatus.Success)
            {
                Presenter.ShowHideSpinner(false);
                _currentRecieveStatus = EControllerStatus.None;

                _regController.OnRecieveModel -= ControllerOnMessage;
                Presenter.RegStateSuccess(model.Email);
            }
        }


        public void SaveData(RegistrationPasswordStrings data)
        {
            if (_repository.IsRepositoryRACleaned)
            {
                return;
            }

            _repository.User.Password = data.Password;
            _repository.User.ConfirmPassword = data.ConfirmPass;
        }

        public RegistrationPasswordStrings LoadData()
        {
            return new RegistrationPasswordStrings(_repository.User?.Password, _repository.User?.ConfirmPassword);
        }

        public void CleanRepositoryRA()
        {
            _repository.DisposeRepositoryRA();
        }

        public IRepositoryRA GetRepository()
        {
            return _repository;
        }


        public void Dispose()
        {
            _regController.OnRecieveModel -= ControllerOnMessage;
        }
    }
}
