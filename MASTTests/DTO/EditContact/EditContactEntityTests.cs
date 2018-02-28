using NUnit.Framework;

using SocialTrading.Vipers.Entity;

namespace MASTTests.DTO.EditContact
{
    [TestFixture, Author("Oleh Marchenko")]
    public class EditContactEntityTests
    {
        [TestCase(null, null, null, null, null)]
        [TestCase(null, "123", "123", "123", "123")]
        [TestCase("123", null, "123", "123", "123")]
        [TestCase("123", "123", null, "123", "123")]
        [TestCase("123", "123", "123", null, "123")]
        [TestCase("123", "123", "123", "123", null)]
        [TestCase("", "", "", "", "")]
        [TestCase("", "123", "123", "123", "123")]
        [TestCase("123", "", "123", "123", "123")]
        [TestCase("123", "123", "", "123", "123")]
        [TestCase("123", "123", "123", "", "123")]
        [TestCase("123", "123", "123", "123", "")]
        public void EditContactEntityTest(string email, string skype, string country, string city, string phone)
        {
            var model = new EditContactEntity(email, skype, country, city, phone);

            var result = email == model.Email;
            result &= skype == model.Skype;
            result &= country == model.Country;
            result &= city == model.City;
            result &= phone == model.Phone;

            Assert.IsTrue(result);
        }
    }
}