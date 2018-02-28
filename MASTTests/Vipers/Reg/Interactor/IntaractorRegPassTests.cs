using NUnit.Framework;

using Moq;

using SocialTrading.Service;
using SocialTrading.Tools.Validation;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Vipers.Registration.Password.Implementation;
using SocialTrading.Vipers.Controllers.Interfaces;

namespace MASTTests.Vipers.Reg.Interactor
{
    [TestFixture]
    public class InteractorRegPassTests
    {
       private InteractorRegPass _interactor;

        [SetUp]
        public void InitInteractor()
        {
            var connection = new Mock<IRegController>(MockBehavior.Strict);
            _interactor = new InteractorRegPass(connection.Object, DataService.RepositoryController.RepositoryRA, new ValidationRA());
        }

        [TestCase(null, false, Author = "Elena Pakhomova")]
        [TestCase("", false, Author = "Elena Pakhomova")]
        [TestCase("qwerty", false, Author = "Elena Pakhomova")]
        [TestCase("123456", false, Author = "Elena Pakhomova")]
        [TestCase("q1123", false, Author = "Elena Pakhomova")]
        [TestCase("   1q", false, Author = "Elena Pakhomova")]
        [TestCase("!\"№;%:?*()_ + ", false, Author = "Elena Pakhomova")]
        [TestCase("KKJBJHV", false, Author = "Elena Pakhomova")]
        [TestCase("qwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwerty" +
            "uiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiop1234567", false, Author = "Elena Pakhomova")]


        [TestCase("1qwqwfde", true, Author = "Elena Pakhomova")]
        [TestCase("йцуfg123", true, Author = "Elena Pakhomova")]
        [TestCase("й1!\"№;%:?*()_ +/\\,.[]{}\\|'\";:/></", true, Author = "Elena Pakhomova")]
        [TestCase("本本本本本123", true, Author = "Elena Pakhomova")]
        [TestCase("123ﺒﺒﺒﺒﺐ", true, Author = "Elena Pakhomova")]
        [TestCase("ióááá123", true, Author = "Elena Pakhomova")]
        [TestCase("qew    123", true, Author = "Elena Pakhomova")]
        [TestCase("1      e", true, Author = "Elena Pakhomova")]
        [TestCase("       1q", true, Author = "Elena Pakhomova")]
        [TestCase("1q      ", true, Author = "Elena Pakhomova")]
        [TestCase("5454gjuyguлиоои", true, Author = "Elena Pakhomova")]
        [TestCase("лолорООш15145", true, Author = "Elena Pakhomova")]
        [TestCase("Jkjbhjh45KKK", true, Author = "Elena Pakhomova")]
        [TestCase("qwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqiopqwertyuiopqh2jhjhhjkkkkkkkkkkkkkkkkkkkkopqwertyuuiopqwerlp" +
            "qwertyuiop123456", true, Author = "Elena Pakhomova")]

        public void TestPass(string pass, bool isValid)
        {
            Assert.AreEqual(isValid, _interactor.PasswordInput(pass));
        }
    }
}
