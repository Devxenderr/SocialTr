using SocialTrading.Vipers.Entity;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Tools.Validation.Interfaces;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.Registration.Phone.Interfaces;

namespace SocialTrading.Vipers.Registration.Phone.Implementation
{
    public class InteractorRegPhone : IInteractorRegPhone
    {
        public IPresenterRegPhone Presenter { private get; set; }
        private IRepositoryRA _repository;
        private IValidationRA _validation;


        public InteractorRegPhone(IRepositoryRA repository, IValidationRA validation)
        {
            _repository = repository;
            _validation = validation;
        }


        public bool NextClick(RegistrationPhoneStrings data)
        {
            if (PhoneCountryInput(data.PhoneCountry.Trim()) & PhoneNumberInput(data.PhoneNumber.Trim()))
            {
                return true;
            }
            return false;
        }

        public bool PhoneCountryInput(string phoneCountry)
        {
            if (_validation.CheckPhoneCountry(phoneCountry))
            {
                Presenter?.SetPhoneCountryState(EState.Success);
                return true;
            }
            Presenter?.SetPhoneCountryState(EState.Fail);
            return false;
        }

        public bool PhoneNumberInput(string phoneNumber)
        {
            if (_validation.CheckPhoneNumber(phoneNumber))
            {
                Presenter?.SetPhoneNumberState(EState.Success);
                return true;
            }
            Presenter?.SetPhoneNumberState(EState.Fail);
            return false;
        }

        public void SaveData(RegistrationPhoneStrings data)
        {
            _repository.User.PhoneCountry = data.PhoneCountry;
            _repository.User.PhoneNumber = data.PhoneNumber;
        }

        public RegistrationPhoneStrings LoadData()
        {
            return new RegistrationPhoneStrings(_repository.User?.PhoneCountry, _repository.User?.PhoneNumber);
        }


        public IRepositoryRA GetRepository()
        {
            return _repository;
        }
    }
}
