namespace SocialTrading.Vipers.Entity
{
    public class RegistrationNamesStrings
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public RegistrationNamesStrings(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
