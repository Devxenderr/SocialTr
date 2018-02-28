using System;

using SocialTrading.DTO.Interfaces;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Interfaces;
using SocialTrading.DTO.Response.UserSettings;
using SocialTrading.Tools.Validation.Interfaces;
using SocialTrading.Vipers.Controllers.Interfaces;
using SocialTrading.Vipers.EditContact.Interfaces;
using SocialTrading.Vipers.ModelCreators.Interfaces;

namespace SocialTrading.Vipers.EditContact.Implementation
{
    public class InteractorEditContact : IInteractorEditContact
    {
        private readonly IEditContactController _controller;
        private readonly IValidationEditContact _validation;
        private readonly IEditContactModelCreator _modelCreator;
        private IPresenterForInteractorEditContact _presenter;

        private EControllerStatus _currentRecieveStatus = EControllerStatus.None;

        public IPresenterForInteractorEditContact Presenter
        {
            private get
            {
                return _presenter;
            }
            set
            {
                _presenter = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        public InteractorEditContact(IEditContactController controller, IEditContactModelCreator modelCreator, IValidationEditContact validation)
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _validation = validation ?? throw new ArgumentNullException(nameof(validation)); 
            _modelCreator = modelCreator ?? throw new ArgumentNullException(nameof(modelCreator)); 

            _controller.OnRecieveModel += ControllerOnMessage;
        }


        private void ControllerOnMessage(IModel editContactModel)
        {
            _currentRecieveStatus = EControllerStatus.None;
            switch (editContactModel.ControllerStatus)
            {
                case EControllerStatus.Ok:
                    GetMessage(editContactModel);
                    break;
                case EControllerStatus.Processing:
                    Presenter.ShowHideSpinner(true);
                    _currentRecieveStatus = EControllerStatus.Processing;
                    break;
                case EControllerStatus.NoConnection:
                    Presenter.ShowHideSpinner(false);
                    Presenter.EditContactState(EUserSettingsResponseState.NoConnection);
                    break;

                case EControllerStatus.None:
                case EControllerStatus.Error:
                default:
                    Presenter.ShowHideSpinner(false);
                    Presenter.EditContactState(EUserSettingsResponseState.Error);
                    break;
            }
        }
            
        private void GetMessage(IModel editContactModel)
        {
            if (!(editContactModel is DataModelUserInfo model))
            {
                return;
            }

            Presenter.ShowHideSpinner(false);
            _currentRecieveStatus = EControllerStatus.None;

            if (model.Status == EUserSettingsResponseState.Success)
            {
                _controller.OnRecieveModel -= ControllerOnMessage;
            }

            Presenter.EditContactState(model.Status);
        }
        

        public void CountryClick()
        {
            Presenter.GoToCountrySelection();
        }

        public void AlertOkClick()
        {
            Presenter.GoBack();
        }

        public void CancelClick()
        {
            Presenter.GoBack();
        }

        public void SaveClick(IEditContactEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var validationSkype = SkypeTextChanged(entity.Skype);
            var validationPhone = PhoneTextChanged(entity.Phone);
            var validationCity = CityTextChanged(entity.City);

            if (_currentRecieveStatus == EControllerStatus.Processing | !(validationSkype && validationPhone && validationCity))
            {
                if (!validationSkype)
                {
                    Presenter.InvalidSkypeInput();
                }

                if (!validationPhone)
                {
                    Presenter.InvalidPhoneInput();
                }

                if (!validationCity)
                {
                    Presenter.InvalidCityInput();
                }

                return;
            }

            _controller.Send(_modelCreator.GetRequestModel(entity));
        }


        public bool SkypeTextChanged(string skype)
        {
            if (skype == null)
            {
                throw new ArgumentNullException(nameof(skype));
            }
            return _validation.CheckSkype(skype);
        }

        public bool CityTextChanged(string city)
        {
            if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }
            return _validation.CheckCity(city);
        }

        public bool PhoneTextChanged(string phone)
        {
            if (phone == null)
            {
                throw new ArgumentNullException(nameof(phone));
            }
            return _validation.CheckPhone(phone);
        }


        public void SetConfig()
        {
            Presenter.SetData(_modelCreator.GetModel());
        }


        public void Dispose()
        {
            _controller.OnRecieveModel -= ControllerOnMessage;
        }
    }
}