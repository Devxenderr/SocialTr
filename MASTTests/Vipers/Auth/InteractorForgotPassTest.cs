using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using SocialTrading.Connection;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Service;
using SocialTrading.Theme.ThemeStrings;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Tools.Validation;
using SocialTrading.Vipers.Controllers.Interfaces;
using SocialTrading.Vipers.ForgotPass.Implementation;
using SocialTrading.Vipers.ForgotPass.Interfaces;
using SocialTrading.Vipers.ForgotPass;

namespace MASTTests.Vipers.Auth
{
    [TestFixture]
    public class InteractorForgotPassTest
    {
        private IInteractorForgotPass _interactor;
        private Mock<IPresenterForgotPass> _presenterMock;
        
        [SetUp]
        public void InitInteractor()
        {
            var view = new Mock<IViewForgotPass>();
            var router = new Mock<IRouterForgotPass>();
            var connection = new Mock<IForgotPassController>();
            _interactor = new InteractorForgotPass(new ValidationRA(), connection.Object);
            //_presenter = new PresenterForgotPassMock(view.Object, _interactor, router.Object, null);
            _presenterMock = new Mock<IPresenterForgotPass>(MockBehavior.Strict);
            _interactor.Presenter = _presenterMock.Object;
        }

        [TestCase(null, false, EState.Fail, Author = " Nikolay Ekaterina")]
        [TestCase("", false, EState.Fail, Author = " Nikolay Ekaterina")]
        [TestCase("123", false, EState.Fail, Author = " Nikolay Ekaterina")]

        [TestCase("software", false, EState.Fail, Author = " Nikolay Ekaterina")]
        [TestCase("software.ru", false, EState.Fail, Author = " Nikolay Ekaterina")]
        [TestCase("software@123", false, EState.Fail, Author = " Nikolay Ekaterina")]

        [TestCase(".@i.ua", false, EState.Fail, Author = " Nikolay Ekaterina")]
        [TestCase(".q@i.ua", false, EState.Fail, Author = " Nikolay Ekaterina")]
        [TestCase("df@ud.", false, EState.Fail, Author = " Nikolay Ekaterina")]
        [TestCase("q@i.u", false, EState.Fail, Author = " Nikolay Ekaterina")]
        [TestCase("q@.iu", false, EState.Fail, Author = " Nikolay Ekaterina")]
        [TestCase("q.@i.ua", false, EState.Fail, Author = " Nikolay Ekaterina")]
        [TestCase("q.@.dsfn.df", false, EState.Fail, Author = " Nikolay Ekaterina")]
        [TestCase("1\"dfn\"@dkjgnd.dsf", false, EState.Fail, Author = " Nikolay Ekaterina")]
        [TestCase("\"dfsg\"dfjh@sdfg.dfh", false, EState.Fail, Author = " Nikolay Ekaterina")]
        [TestCase("dfhj@dfd.", false, EState.Fail, Author = " Nikolay Ekaterina")]
        [TestCase("e...e@t.df", false, EState.Fail, Author = " Nikolay Ekaterina")]
        [TestCase("уук@ывыаюувю.ва", false, EState.Fail, Author = " Nikolay Ekaterina")]
        [TestCase("@df.df", false, EState.Fail, Author = " Nikolay Ekaterina")]
        [TestCase("df@u--i.ud", false, EState.Fail, Author = " Nikolay Ekaterina")]
        [TestCase("dsd@d__i.ud", false, EState.Fail, Author = " Nikolay Ekaterina")]
        [TestCase("df@df..df.df", false, EState.Fail, Author = " Nikolay Ekaterina")]
        [TestCase("df@sd.s-s", false, EState.Fail, Author = " Nikolay Ekaterina")]
        [TestCase("df@sd.s_s", false, EState.Fail, Author = " Nikolay Ekaterina")]

        [TestCase("software@123.ru", true, EState.Success, Author = " Nikolay Ekaterina")]
        [TestCase("123software@123.ru", true, EState.Success, Author = " Nikolay Ekaterina")]
        [TestCase("software@123software.ru", true, EState.Success, Author = " Nikolay Ekaterina")]
        [TestCase("123software@123software.ru", true, EState.Success, Author = " Nikolay Ekaterina")]

        [TestCase("q@q.qw", true, EState.Success, Author = " Nikolay Ekaterina")]
        [TestCase("q@qw.1q", true, EState.Success, Author = " Nikolay Ekaterina")]
        [TestCase("123@12.12", true, EState.Success, Author = " Nikolay Ekaterina")]
        [TestCase("qwe@12.qw", true, EState.Success, Author = " Nikolay Ekaterina")]
        [TestCase("qwe@we.12", true, EState.Success, Author = " Nikolay Ekaterina")]
        [TestCase("q-q@qw.qw", true, EState.Success, Author = " Nikolay Ekaterina")]
        [TestCase("qwe@qw.qw.qw", true, EState.Success, Author = " Nikolay Ekaterina")]
        [TestCase("\"---\"@wq.wq", true, EState.Success, Author = " Nikolay Ekaterina")]
        [TestCase("\"____\"@wq.wq", true, EState.Success, Author = " Nikolay Ekaterina")]
        [TestCase("\"@@@@\"@wq.wq", true, EState.Success, Author = " Nikolay Ekaterina")]
        [TestCase("qwe@qw.qw.qw.ty", true, EState.Success, Author = " Nikolay Ekaterina")]
        [TestCase("\"¿¡«»‹›§¶†‡∏∃⇐\"@mail.ru", true, EState.Success, Author = " Nikolay Ekaterina")]

        [TestCase("df@f-f.if", true, EState.Success, Author = " Nikolay Ekaterina")]
        [TestCase("hf@d_h.id", true, EState.Success, Author = " Nikolay Ekaterina")]
        [TestCase("df@i.i.i.i.uf", true, EState.Success, Author = " Nikolay Ekaterina")]
        [TestCase("q__hj@dkjf.dsf", true, EState.Success, Author = " Nikolay Ekaterina")]
        [TestCase("fs-----sfg@sdf.sdf", true, EState.Success, Author = " Nikolay Ekaterina")]

        [TestCase("#.!$%&'*+-/=?^_`{}|~@qw.qw", true, EState.Success, Author = " Nikolay Ekaterina")]
        [TestCase("q.#!$%&'*+-/=?^_`{}|~@qw.qw", true, EState.Success, Author = " Nikolay Ekaterina")]
        [TestCase("1.#!$%&'*+-/=?^_`{}|~@qw.qw", true, EState.Success, Author = " Nikolay Ekaterina")]

        [TestCase("qwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqw" +
            "ertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiop1@i.ua", true, EState.Success, Author = " Nikolay Ekaterina")]
        [TestCase("q@qwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwe" +
            "rtyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiop3.ua", true, EState.Success, Author = " Nikolay Ekaterina")]

        public void TestEmail(string email, bool isValid, EState status)
        {            
            _presenterMock.Setup(f => f.SetEmailState(status));
            Assert.AreEqual(isValid, _interactor.EmailInput(email));
        }

        //private class PresenterForgotPassMock : IPresenterForgotPass
        //{
        //    private IViewForgotPass object1;
        //    private IInteractorForgotPass _interactor;
        //    private IRouterForgotPass object2;
        //    private object p;

        //    public PresenterForgotPassMock(IViewForgotPass object1, IInteractorForgotPass interactor,
        //        IRouterForgotPass object2, object p)
        //    {
        //        this.object1 = object1;
        //        _interactor = interactor;
        //        this.object2 = object2;
        //        this.p = p;
        //    }

        //    public void AlertButtonClick()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void BackButtonClick()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void EmailInput(string email)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void PassRecoveryClick(string email)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void SetConfig()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void SetEmailState(EState state)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void SetLocale()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void ShowAlertEmailRedirect(EForgotPassStatus eForgotPassState)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}
