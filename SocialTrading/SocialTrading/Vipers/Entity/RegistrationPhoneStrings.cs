namespace SocialTrading.Vipers.Entity
{
    public class RegistrationPhoneStrings
    {
        public string PhoneCountry { get; set; }
        public string PhoneNumber { get; set; }

        public RegistrationPhoneStrings(string phoneCountry, string phoneNumber)
        {
            PhoneCountry = phoneCountry;
            PhoneNumber = phoneNumber;
        }
    }
}
