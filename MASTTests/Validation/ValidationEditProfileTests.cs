using NUnit.Framework;

using SocialTrading.Tools.Validation;
using SocialTrading.Tools.Validation.Interfaces;

namespace MASTTests.Validation
{
    [TestFixture]
    public class ValidationEditProfileTests
    {
        private readonly IValidationEditProfile _validation = new ValidationEditProfile();

        [Test, Author(Authors.Marchenko)]
        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase("df#", false)]
        [TestCase("sd@", false)]
        [TestCase("df!", false)]
        [TestCase("-1", false)]
        [TestCase("1-", false)]
        [TestCase(" 'd", false)]
        [TestCase("o'", false)]
        [TestCase("df$", false)]
        [TestCase("jhg%", false)]
        [TestCase("jgf^", false)]
        [TestCase("kjgh*", false)]
        [TestCase("hjg()", false)]
        [TestCase("kjh_+", false)]
        [TestCase("qwertyuiopqwertyuiopqwertyuiopqqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqw" +
            "ertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiop", false)] // Check API
        [TestCase("й", true)]
        [TestCase("1", true)]
        [TestCase("q", true)]
        [TestCase("1q", true)]
        [TestCase("Qwe", true)]
        [TestCase("йц-йц", true)]
        [TestCase("цй'ds", true)]
        [TestCase("er-------d", true)]
        [TestCase("12'''''''''45", true)]
        [TestCase("вап вап", true)]
        [TestCase("вап     вапв", true)]
        [TestCase("qwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyu" +
            "iopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiop", true)]

        public void TestName(string name, bool isValid)
        {
            Assert.AreEqual(isValid, _validation.CheckName(name));
        }

        [Test, Author(Authors.Viktorov)]
        [TestCase("s", true)]
        [TestCase("qwertyqwerqwertHHwerqwertyqwerqwertyqwerqwertyqwer", true)]
        [TestCase("qwertyqwerqwertyqwerqwertyqwerqwertyqwerqwertyqw.r", true)]
        [TestCase("qwertyqwerqwertyqwerty !34", true)]
        [TestCase("., -() / '+:=?!\"%&*;<>${}[]|", true)]
        [TestCase(null, false)]
        [TestCase("", true)]
        [TestCase("   ", true)]
        [TestCase("qwertyqwerqwertyqwerqwertyqweropqwertyqwerqwertyqwerk", false)]
        public void StatusTests(string status, bool expexted)
        {
            Assert.AreEqual(expexted, _validation.CheckStatus(status));
        }
    }
}