using SocialTrading.Tools.Validation.Interfaces;

namespace SocialTrading.Tools.Validation
{
    public class ValidationEditContact : IValidationEditContact
    {
        public bool CheckSkype(string skype)
        {
            if (string.IsNullOrWhiteSpace(skype))
            {
                return true;
            }

            if (skype.Length > 50)
            {
                return false;
            }
            
            return Validation.CheckValue("^[a-zA-Z0-9.,-_ \\/'+:=?!\"%&*;<>[$]{}|]{0,50}$", skype);
        }

        public bool CheckCity(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                return true;
            }

            if (city.Length > 50)
            {
                return false;
            }

            return Validation.CheckValue("^[a-zA-Z АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя]{0,50}$", city);
        }

        public bool CheckPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
            {
                return true;
            }

            return Validation.CheckValue("^[+]?[0-9]{6,18}$", phone);
        }
    }
}