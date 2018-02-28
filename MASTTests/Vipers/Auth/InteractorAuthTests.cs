using Moq;

using NUnit.Framework;

using SocialTrading.DTO;
using SocialTrading.Tools.Validation;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Authorization;
using SocialTrading.Vipers.Controllers.Interfaces;
using SocialTrading.Vipers.Authorization.Interfaces;
using SocialTrading.Vipers.Authorization.Implementation;

namespace MASTTests.Vipers.Auth
{
    [TestFixture]
    class IntaractorAuthTests
    {
        private InteractorAuth _interactor;
        private Mock<IAuthController> _connectionMock;

        [SetUp]
        public  void InitInteractor()
        {
            _connectionMock = new Mock<IAuthController>(MockBehavior.Strict);
            var validationMock = new Mock<ValidationRA>(MockBehavior.Strict);
            _interactor = new InteractorAuth(_connectionMock.Object, validationMock.Object);
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


        [TestCase("1qwqfdwe", true, Author = "Elena Pakhomova")]
        [TestCase("йцуfg123", true, Author = "Elena Pakhomova")]
        [TestCase("й1!\"№;%:?*()_ +/\\,.[]{}\\|'\";:/></", true, Author = "Elena Pakhomova")]
        [TestCase("本本本本本123", true, Author = "Elena Pakhomova")]
        [TestCase("123ﺒﺒﺒﺒﺐ", true, Author = "Elena Pakhomova")]
        [TestCase("ióááá123", true, Author = "Elena Pakhomova")]
        [TestCase("qew  123", true, Author = "Elena Pakhomova")]
        [TestCase("1       e", true, Author = "Elena Pakhomova")]
        [TestCase("       1q", true, Author = "Elena Pakhomova")] 
        [TestCase("1q      ", true, Author = "Elena Pakhomova")]
        [TestCase("5454gjuyguлиоои", true, Author = "Elena Pakhomova")]
        [TestCase("лолорООш15145", true, Author = "Elena Pakhomova")]
        [TestCase("Jkjbhjh45KKK", true, Author = "Elena Pakhomova")]
        [TestCase("qwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqiopqwertyuiopqh2jhjhhjkkkkkkkkkkkkkkkkkkkkopqwertyuuiopqwerlpqwerty" +
            "uiop123456", true, Author = "Elena Pakhomova")]
        
        public void TestPass(string pass, bool isValid)
        {
            Assert.AreEqual(isValid, _interactor.PasswordInput(pass));
        }

        [Test(Author = "Gerashchenko V.V.")]
        [TestCase(ESocialType.Facebook)]
        [TestCase(ESocialType.Google)]
        [TestCase(ESocialType.Ok)]
        [TestCase(ESocialType.Vk)]
        public void SocialCancelTest(ESocialType socialType)
        {
            var presenterMock = new Mock<IPresenterAuth>(MockBehavior.Strict);
            presenterMock.Setup(f => f.CheckAuthState(EAuthResponseStatus.Error));
            _interactor.Presenter = presenterMock.Object;
            _interactor.OnCancel(socialType);
        }

        [Test(Author = "Gerashchenko V.V.")]
        [TestCase(null , ESocialType.Facebook)]
        [TestCase("", ESocialType.Google)]
        [TestCase("123", ESocialType.Ok)]
        [TestCase("321", ESocialType.Vk)]
        public void SocialOnErrorTest(string error, ESocialType socialType)
        {
            var presenterMock = new Mock<IPresenterAuth>(MockBehavior.Strict);
            presenterMock.Setup(f => f.CheckAuthState(EAuthResponseStatus.Error));
            _interactor.Presenter = presenterMock.Object;
            _interactor.OnError(error, socialType);
        }

        [Test(Author = "Gerashchenko V.V.")]
        [TestCase("123")]
        [TestCase("EAAZAWLZAhHiAQBAPZCmgjjnrY4V9wOi9YTbMRBXlQtBTugQVDWL3cBf0Qszm9iuJOGIHlQaZA14QDQTWNoqNJyk19hMvCJbZASbXq3gKhY64HjScS7gD100kZAlawCzBmCXZB5wxZAwDYulZAaDMZAv3HNc5JTo0t69YIPZCnHgT2TELBR0yptDKu4L9HEsIlOyZBoVzLCZAO74JX6gZDZD")]
        public void FacebookOnSuccessTest(string token)
        {
            _connectionMock.Setup(f =>  f.Send(It.IsAny<IModelSend>()) );
            _interactor.OnSuccess(token, ESocialType.Facebook);
        }

        [Test(Author = "Gerashchenko V.V.")]
        [TestCase(null)]
        [TestCase("")]
        public void FacebookOnSuccessTest_Negative(string token)
        {
            _interactor.OnSuccess(token, ESocialType.Facebook);
        }
    }
}