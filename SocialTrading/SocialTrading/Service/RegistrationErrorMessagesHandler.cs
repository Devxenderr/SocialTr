using System.Linq;
using System.Collections.Generic;

using SocialTrading.Service.Interfaces.Repository;

namespace SocialTrading.Service
{
    public class RegistrationErrorMessagesHandler
    {
        private Dictionary<string, string> _messagesMap;
        private IRepositoryRA _repository;


        public RegistrationErrorMessagesHandler(IRepositoryRA repository)
        {
            _repository = repository;

            _messagesMap = new Dictionary<string, string>
            {
                {"Email has already been taken", _repository.LangRA.UserDataError},
                {"Password confirmation doesn't match Password",    _repository.LangRA.PassNotMatch},
                {"Password is too short (minimum is 8 characters)", _repository.LangRA.RegPasswordIsTooShort},
                {"Email is not an email", _repository.LangRA.RegEmailIsInvalid},
                {"Email is invalid",      _repository.LangRA.RegEmailIsInvalid},
                {"First name You can use maximum length - 200, letters, numbers, space and symbols '-'", _repository.LangRA.RegFirstNameIsIncorrect},
                {"Last name You can use maximum length - 200, letters, numbers, space and symbols '-'",  _repository.LangRA.RegLastNameIsIncorrect},
            };
        }


        public string GetMessageAccordingErrors()
        {
            //var regErrors = _repository.ModelRegErrors.FullMessages;
            //var errorMsg = _messagesMap.FirstOrDefault(pair => regErrors.Contains(pair.Key));
            var result = string.Empty;

            //if (errorMsg.Key != null)
            //{
            //    result = errorMsg.Value;
            //}
            //else
            //{
            //    result = _repository.LangRA.Unknown;
            //}

            return result;
        }
    }
}