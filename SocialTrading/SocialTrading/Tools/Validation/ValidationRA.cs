using SocialTrading.Tools.Validation.Interfaces;

namespace SocialTrading.Tools.Validation
{
    public class ValidationRA : IValidationRA
    {
        public bool CheckEmail(string email)
        {
            return Validation.CheckValue("\\A((([a-zA-Z0-9#!$%&'*+\\-\\/=?^_`{}|~]+(\\.[a-zA-Z0-9#!$%&'*+\\-\\/=?^_`{}|~]+)*)|(\"[^\"]*\"))@([a-zA-Z0-9]+(_?-?[a-zA-Z0-9]+)*)" +
                                         "(\\.([a-zA-Z0-9]+(_?-?[a-zA-Z0-9]+)*)+)*(\\.([a-zA-Z0-9]+(_?-?[a-zA-Z0-9]+)*){2,})){1,300}\\z", email);
        }

        public bool CheckPassword(string password)
        {
            return password?.Length <= 128 && Validation.CheckValue(@"^(?=^.{8,128}$)(?=.*\d)(?=.*[^\d]).*$", password);
        }

        public bool CheckName(string name)
        {
            if (name?.Length <= 200)
            {
                return Validation.CheckValue("\\A([^~!@#'`\"\\\\\\/.()?,|*&%_+$;:\\[\\]{}><=\\^\\s\\-]([^~!@#`\"\\\\\\/.()?,|*&%_+$;:\\[\\]{}><=\\^]*[^~!@#'`\"\\\\\\/.()?,|*&%_+$;:\\[\\]{}><=\\^\\s\\-])?)" +
                                             "{1,200}\\z", name);
            }
            return false;
        }

        public bool CheckNickname(string nickname)
        {
            return Validation.CheckValue(@"\A([\S](.*[\S])?)?\z", nickname);
        }

        public bool CheckPhoneCountry(string phone)
        {
            return Validation.CheckValue(@"^\+?[\d]{1,4}$", phone);
        }

        public bool CheckPhoneNumber(string phone)
        {
            return Validation.CheckValue(@"^[\d]{6,16}$", phone);
        }
    }
}
