using SocialTrading.Vipers.Entity;
using SocialTrading.DTO.Request.RA;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Tools.Validation.Interfaces;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.Registration.Name.Interfaces;

namespace SocialTrading.Vipers.Registration.Name.Implementation
{
    public class InteractorRegName : IInteractorRegName
    {
        public IPresenterRegName Presenter { private get; set; }
        private IRepositoryRA _repository;
        private IValidationRA _validation;


        public InteractorRegName(IRepositoryRA repository, IValidationRA validation)
        {
            _repository = repository;
            _validation = validation;
        }


        public bool NameInput(string name)
        {
            if (_validation.CheckName(name))
            {
                Presenter?.SetNameState(EState.Success);
                return true;
            }
            Presenter?.SetNameState(EState.Fail);
            return false;
        }

        public bool LastNameInput(string lastName)
        {
            if (_validation.CheckName(lastName))
            {
                Presenter?.SetLastNameState(EState.Success);
                return true;
            }
            Presenter?.SetLastNameState(EState.Fail);
            return false;
        }

        public bool NextClick(RegistrationNamesStrings data)
        {
            if (NameInput(data.FirstName) & LastNameInput(data.LastName))
            {
                return true;
            }
            return false;
        }

        public void SaveData(RegistrationNamesStrings data)
        {
            if (_repository.User == null)
            {
                _repository.User = new UserReg()
                {
                    Name = data.FirstName,
                    LastName = data.LastName
                };
            }
            else
            {
                _repository.User.Name = data.FirstName;
                _repository.User.LastName = data.LastName;
            }
        }

        public RegistrationNamesStrings LoadData()
        {
            return new RegistrationNamesStrings(_repository.User?.Name, _repository.User?.LastName);
        }


        public IRepositoryRA GetRepository()
        {
            return _repository;
        }
    }
}
