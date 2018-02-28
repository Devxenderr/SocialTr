using NUnit.Framework;

using SocialTrading.Service;
using SocialTrading.Tools.Validation;
using SocialTrading.Vipers.Registration.Email.Implementation;

namespace MASTTests.Vipers.Reg.Interactor
{
    [TestFixture]
    public class InteractorRegEmailTests
    {
        private InteractorRegEmail _interactor;

        [SetUp]
        public void InitInteractor()
        {
            _interactor = new InteractorRegEmail(DataService.RepositoryController.RepositoryRA, new ValidationRA());
        }

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
            Assert.AreEqual(isValid, _interactor.EmailInput(email));
        }
    }
}
