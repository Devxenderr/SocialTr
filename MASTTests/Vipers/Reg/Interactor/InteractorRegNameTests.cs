using NUnit.Framework;

using SocialTrading.Service;
using SocialTrading.Tools.Validation;
using SocialTrading.Vipers.Registration.Name.Implementation;

namespace MASTTests.Vipers.Reg.Interactor
{
    [TestFixture]
    public class InteractorRegNameTests
    {
        private InteractorRegName _interactor;

        [SetUp]
        public void InitInteractor()
        {
            _interactor = new InteractorRegName(DataService.RepositoryController.RepositoryRA, new ValidationRA());
        }
        
        [TestCase(null, false, Author = "Elena Pakhomova")]
        [TestCase("", false, Author = "Elena Pakhomova")]
        [TestCase("df#", false, Author = "Elena Pakhomova")]
        [TestCase("sd@", false, Author = "Elena Pakhomova")]
        [TestCase("df!", false, Author = "Elena Pakhomova")]
        [TestCase("-1", false, Author = "Elena Pakhomova")]
        [TestCase("1-", false, Author = "Elena Pakhomova")]
        [TestCase(" 'd", false, Author = "Elena Pakhomova")]
        [TestCase("o'", false, Author = "Elena Pakhomova")]
        [TestCase("df$", false, Author = "Elena Pakhomova")]
        [TestCase("jhg%", false, Author = "Elena Pakhomova")]
        [TestCase("jgf^", false, Author = "Elena Pakhomova")]
        [TestCase("kjgh*", false, Author = "Elena Pakhomova")]
        [TestCase("hjg()", false, Author = "Elena Pakhomova")]
        [TestCase("kjh_+", false, Author = "Elena Pakhomova")]
        [TestCase("qwertyuiopqwertyuiopqwertyuiopqqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqw" +
            "ertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiop", false, Author = "Elena Pakhomova")] // Check API

        [TestCase("й", true, Author = "Elena Pakhomova")]
        [TestCase("1", true, Author = "Elena Pakhomova")]
        [TestCase("q", true, Author = "Elena Pakhomova")]
        [TestCase("1q", true, Author = "Elena Pakhomova")]
        [TestCase("Qwe", true, Author = "Elena Pakhomova")]
        [TestCase("йц-йц", true, Author = "Elena Pakhomova")]
        [TestCase("цй'ds", true, Author = "Elena Pakhomova")]
        [TestCase("er-------d", true, Author = "Elena Pakhomova")]
        [TestCase("12'''''''''45", true, Author = "Elena Pakhomova")]
        [TestCase("вап вап", true, Author = "Elena Pakhomova")]
        [TestCase("вап     вапв", true, Author = "Elena Pakhomova")]
        [TestCase("qwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyu" +
            "iopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiop", true, Author = "Elena Pakhomova")]

        public void TestName(string name, bool isValid)
        {
            Assert.AreEqual(isValid, _interactor.NameInput(name));
        }

        [TestCase(null, false, Author = "Elena Pakhomova")]
        [TestCase("", false, Author = "Elena Pakhomova")]
        [TestCase("df#", false, Author = "Elena Pakhomova")]
        [TestCase("sd@", false, Author = "Elena Pakhomova")]
        [TestCase("df!", false, Author = "Elena Pakhomova")]
        [TestCase("-1", false, Author = "Elena Pakhomova")]
        [TestCase("1-", false, Author = "Elena Pakhomova")]
        [TestCase(" 'd", false, Author = "Elena Pakhomova")]
        [TestCase("o'", false, Author = "Elena Pakhomova")]
        [TestCase("df$", false, Author = "Elena Pakhomova")]
        [TestCase("jhg%", false, Author = "Elena Pakhomova")]
        [TestCase("jgf^", false, Author = "Elena Pakhomova")]
        [TestCase("kjgh*", false, Author = "Elena Pakhomova")]
        [TestCase("hjg()", false, Author = "Elena Pakhomova")]
        [TestCase("kjh_+", false, Author = "Elena Pakhomova")]
        [TestCase("qwertyuiopqwertyuiopqwertyuiopqqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqw" +
            "ertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuxfbgdbgdfbhhdfbdfbdfbdbfbdfbiopq5wertyuiopqwertyuiopqwertyuiopqwertyuiop", false, Author = "Elena Pakhomova")] // Check API

        [TestCase("й", true, Author = "Elena Pakhomova")]
        [TestCase("1", true, Author = "Elena Pakhomova")]
        [TestCase("q", true, Author = "Elena Pakhomova")]
        [TestCase("1q", true, Author = "Elena Pakhomova")]
        [TestCase("Qwe", true, Author = "Elena Pakhomova")]
        [TestCase("йц-йц", true, Author = "Elena Pakhomova")]
        [TestCase("цй'ds", true, Author = "Elena Pakhomova")]
        [TestCase("er-------d", true, Author = "Elena Pakhomova")]
        [TestCase("12\'\'\'\'\'\'\'\'\'45", true, Author = "Elena Pakhomova")]
        [TestCase("вап вап", true, Author = "Elena Pakhomova")]
        [TestCase("вап     вапв", true, Author = "Elena Pakhomova")]
        [TestCase("qwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyu" +
            "iopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiop", true, Author = "Elena Pakhomova")]

        public void TestLastName(string lastName, bool isValid)
        {
            Assert.AreEqual(isValid, _interactor.LastNameInput(lastName));
        }
    }
}
