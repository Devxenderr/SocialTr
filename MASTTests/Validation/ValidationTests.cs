using NUnit.Framework;

using SocialTrading.Tools.Validation;
using SocialTrading.Tools.Validation.Interfaces;

namespace MASTTests.Validation
{
    [TestFixture]
    public class ValidationTests
    {
        private readonly IValidationRA _validation = new ValidationRA();
        private readonly IValidationEditContact _validationEditContact = new ValidationEditContact();

        [TestCase(null, false, Author = "Elena Pakhomova")]
        [TestCase("", false, Author = "Elena Pakhomova")]
        [TestCase("123", false, Author = "Elena Pakhomova")]

        [TestCase("software", false, Author = "Elena Pakhomova")]
        [TestCase("software.ru", false, Author = "Elena Pakhomova")]
        [TestCase("software@123", false, Author = "Elena Pakhomova")]

        [TestCase(".@i.ua", false, Author = "Elena Pakhomova")]
        [TestCase(".q@i.ua", false, Author = "Elena Pakhomova")]
        [TestCase("df@ud.", false, Author = "Elena Pakhomova")]
        [TestCase("q@i.u", false, Author = "Elena Pakhomova")]
        [TestCase("q@.iu", false, Author = "Elena Pakhomova")]
        [TestCase("q.@i.ua", false, Author = "Elena Pakhomova")]
        [TestCase("q.@.dsfn.df", false, Author = "Elena Pakhomova")]
        [TestCase("1\"dfn\"@dkjgnd.dsf", false, Author = "Elena Pakhomova")]
        [TestCase("\"dfsg\"dfjh@sdfg.dfh", false, Author = "Elena Pakhomova")]
        [TestCase("dfhj@dfd.", false, Author = "Elena Pakhomova")]
        [TestCase("e...e@t.df", false, Author = "Elena Pakhomova")]
        [TestCase("уук@ывыаюувю.ва", false, Author = "Elena Pakhomova")]
        [TestCase("@df.df", false, Author = "Elena Pakhomova")]
        [TestCase("df@u--i.ud", false, Author = "Elena Pakhomova")]
        [TestCase("dsd@d__i.ud", false, Author = "Elena Pakhomova")]
        [TestCase("df@df..df.df", false, Author = "Elena Pakhomova")]
        [TestCase("df@sd.s-s", false, Author = "Elena Pakhomova")]
        [TestCase("df@sd.s_s", false, Author = "Elena Pakhomova")]

        [TestCase("software@123.ru", true, Author = "Elena Pakhomova")]
        [TestCase("123software@123.ru", true, Author = "Elena Pakhomova")]
        [TestCase("software@123software.ru", true, Author = "Elena Pakhomova")]
        [TestCase("123software@123software.ru", true, Author = "Elena Pakhomova")]

        [TestCase("q@q.qw", true, Author = "Elena Pakhomova")]
        [TestCase("q@qw.1q", true, Author = "Elena Pakhomova")]
        [TestCase("123@12.12", true, Author = "Elena Pakhomova")]
        [TestCase("qwe@12.qw", true, Author = "Elena Pakhomova")]
        [TestCase("qwe@we.12", true, Author = "Elena Pakhomova")]
        [TestCase("q-q@qw.qw", true, Author = "Elena Pakhomova")]
        [TestCase("qwe@qw.qw.qw", true, Author = "Elena Pakhomova")]
        [TestCase("\"---\"@wq.wq", true, Author = "Elena Pakhomova")]
        [TestCase("\"____\"@wq.wq", true, Author = "Elena Pakhomova")]
        [TestCase("\"@@@@\"@wq.wq", true, Author = "Elena Pakhomova")]
        [TestCase("qwe@qw.qw.qw.ty", true, Author = "Elena Pakhomova")]
        [TestCase("\"¿¡«»‹›§¶†‡∏∃⇐\"@mail.ru", true, Author = "Elena Pakhomova")]

        [TestCase("df@f-f.if", true, Author = "Elena Pakhomova")]
        [TestCase("hf@d_h.id", true, Author = "Elena Pakhomova")]
        [TestCase("df@i.i.i.i.uf", true, Author = "Elena Pakhomova")]
        [TestCase("q__hj@dkjf.dsf", true, Author = "Elena Pakhomova")]
        [TestCase("fs-----sfg@sdf.sdf", true, Author = "Elena Pakhomova")]

        [TestCase("#.!$%&'*+-/=?^_`{}|~@qw.qw", true, Author = "Elena Pakhomova")]
        [TestCase("q.#!$%&'*+-/=?^_`{}|~@qw.qw", true, Author = "Elena Pakhomova")]
        [TestCase("1.#!$%&'*+-/=?^_`{}|~@qw.qw", true, Author = "Elena Pakhomova")]

        [TestCase("qwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqw" +
            "ertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiop1@i.ua", true, Author = "Elena Pakhomova")]
        [TestCase("q@qwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwe" +
            "rtyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiop3.ua", true, Author = "Elena Pakhomova")]

        public void TestEmail(string email, bool isValid)
        {
            Assert.AreEqual(isValid, _validation.CheckEmail(email));
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


        [TestCase("1qwqwedf", true, Author = "Elena Pakhomova")]
        [TestCase("йцуfg123", true, Author = "Elena Pakhomova")]
        [TestCase("й1!\"№;%:?*()_ +/\\,.[]{}\\|'\";:/></", true, Author = "Elena Pakhomova")]
        [TestCase("本本本本本123", true, Author = "Elena Pakhomova")]
        [TestCase("123ﺒﺒﺒﺒﺐ", true, Author = "Elena Pakhomova")]
        [TestCase("ióááá123", true, Author = "Elena Pakhomova")]
        [TestCase("qew  123", true, Author = "Elena Pakhomova")]
        [TestCase("1      e", true, Author = "Elena Pakhomova")]
        [TestCase("      1q", true, Author = "Elena Pakhomova")] // rfr juj jy ghjtik
        [TestCase("1q      ", true, Author = "Elena Pakhomova")]
        [TestCase("5454gjuyguлиоои", true, Author = "Elena Pakhomova")]
        [TestCase("лолорООш15145", true, Author = "Elena Pakhomova")]
        [TestCase("Jkjbhjh45KKK", true, Author = "Elena Pakhomova")]
        [TestCase("qwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqiopqwertyuiopqh2jhjhhjkkkkkkkkkkkkkkkkkkkkopqwertyuuiopqwerlp" +
            "qwertyuiop123456", true, Author = "Elena Pakhomova")]
        
        public void TestPass(string pass, bool isValid)
        {
            Assert.AreEqual(isValid, _validation.CheckPassword(pass));
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
            Assert.AreEqual(isValid, _validation.CheckName(name));
        }

        [TestCase("1", true, Author = "Oleh Marchenko")]
        [TestCase("23", true, Author = "Oleh Marchenko")]
        [TestCase("380", true, Author = "Oleh Marchenko")]
        [TestCase("1890", true, Author = "Oleh Marchenko")]
        [TestCase("+1234", true, Author = "Oleh Marchenko")]

        [TestCase(null, false, Author = "Oleh Marchenko")]
        [TestCase("12345", false, Author = "Oleh Marchenko")]
        [TestCase("q", false, Author = "Oleh Marchenko")]
        [TestCase("+", false, Author = "Oleh Marchenko")]
        [TestCase("+12345", false, Author = "Oleh Marchenko")]
        [TestCase("3 8 2000", false, Author = "Oleh Marchenko")]
        [TestCase("1-8-90", false, Author = "Oleh Marchenko")]
        [TestCase("Σ", false, Author = "Oleh Marchenko")]

        public void TestPhoneCountry(string phoneCountry, bool isValid)
        {
            Assert.AreEqual(isValid, _validation.CheckPhoneCountry(phoneCountry));
        }

        [TestCase("666666", true, Author = "Oleh Marchenko")]
        [TestCase("7777777", true, Author = "Oleh Marchenko")]
        [TestCase("88888888", true, Author = "Oleh Marchenko")]
        [TestCase("999999999", true, Author = "Oleh Marchenko")]
        [TestCase("1010101010", true, Author = "Oleh Marchenko")]
        [TestCase("11111111111", true, Author = "Oleh Marchenko")]
        [TestCase("121212121212", true, Author = "Oleh Marchenko")]
        [TestCase("1313131313131", true, Author = "Oleh Marchenko")]
        [TestCase("14141414141414", true, Author = "Oleh Marchenko")]
        [TestCase("151515151515151", true, Author = "Oleh Marchenko")]
        [TestCase("1616161616161616", true, Author = "Oleh Marchenko")]

        [TestCase("17171717171717171", false, Author = "Oleh Marchenko")]
        [TestCase(null, false, Author = "Oleh Marchenko")]
        [TestCase("w", false, Author = "Oleh Marchenko")]
        [TestCase("/", false, Author = "Oleh Marchenko")]
        [TestCase("6 6 6 6 6 6", false, Author = "Oleh Marchenko")]
        [TestCase("7-7-7-7-7-77", false, Author = "Oleh Marchenko")]
        [TestCase("®", false, Author = "Oleh Marchenko")]
        [TestCase("+88888888", false, Author = "Oleh Marchenko")]

        public void TestPhoneNumber(string phoneNumber, bool isValid)
        {
            Assert.AreEqual(isValid, _validation.CheckPhoneNumber(phoneNumber));
        }

        [TestCase("s", true)]
        [TestCase("qwertyqwerqwertyqwerqwertyqwerqwertyqwerqwertyqwer", true)]
        [TestCase("qwertyQQWWEERRrty", true)]
        [TestCase("йцукен", true)]
        [TestCase("", true)]
        [TestCase(null, true)]
        [TestCase("qwerty1234", false)]
        [TestCase("qwerty qwerty", true)]
        [TestCase("qwertyqwerqwertyqwerqwertyqwerkkkkqwertyqwerqwertyqwerk", false)]
        [TestCase("12345", false)]
        [TestCase(".,-()/\\'+:=?!\"%&*;<>$", false)]
        public void TestCity(string city, bool expected)
        {
            Assert.AreEqual(expected, _validationEditContact.CheckCity(city));
        }

        [TestCase("123456", true)]
        [TestCase("123456123456123456", true)]
        [TestCase(null, true)]
        [TestCase("", true)]
        [TestCase("1234561234561234561", false)]
        [TestCase("12345", false)]
        [TestCase("qwertyQQWWEERRrty", false)]
        [TestCase("12345qwertyQQWWEERRrty", false)]
        [TestCase(".,-()\\/'+:=?!\"%&*;<>$", false)]
        [TestCase("1323 2134", false)]
        public void TestPhone(string phone, bool expected)
        {
            Assert.AreEqual(expected, _validationEditContact.CheckPhone(phone));
        }

        [TestCase("s", true)]
        [TestCase("qwertyqwerqwertyqwerqwertyqwerqwertyqwerqwertyqwer", true)]
        [TestCase("qwertyqwerqwertyqwerqwertyqwerqwertyqwerqwertyqw.r", true)]
        [TestCase("qwertyQQWWEERRrty", true)]
        [TestCase("qwertyqwerqwertyqwerty_111111112", true)]
        [TestCase(".,-()\\/'+:=?!\"%&*;<>${}[]|", true)]
        [TestCase(null, true)]
        [TestCase("", true)]
        [TestCase("      ", true)]
        [TestCase("qwertyqwerqwertyqwerqwertyqwerkl;klqwertyqwerqwertyqwerk", false)]
        public void TestSkype(string skype, bool expected)
        {
            Assert.AreEqual(expected, _validationEditContact.CheckSkype(skype));
        }
    }
}
