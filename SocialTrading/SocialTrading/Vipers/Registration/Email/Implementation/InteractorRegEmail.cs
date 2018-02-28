using SocialTrading.Tools.Enumerations;
using SocialTrading.Tools.Validation.Interfaces;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.Registration.Email.Interfaces;

namespace SocialTrading.Vipers.Registration.Email.Implementation
{
    public class InteractorRegEmail : IInteractorRegEmail
    {
        public IPresenterRegEmail Presenter { private get;  set; }
        private IRepositoryRA _repository;
        private IValidationRA _validation;


        public InteractorRegEmail(IRepositoryRA repository, IValidationRA validation)
        {
            _repository = repository;
            _validation = validation;
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

        public bool NextClick(string email)
        {
            return EmailInput(email.Trim().ToLower());
        }

        public void SaveData(string email)
        {
            _repository.User.Email = email;
        }

        public string LoadData()
        {
            return _repository.User?.Email;
        }


        public IRepositoryRA GetRepository()
        {
            return _repository;
        }
    }
}
