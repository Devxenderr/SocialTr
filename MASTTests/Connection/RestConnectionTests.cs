using System;
using NUnit.Framework;

using System.Net;
using System.Threading;
using SocialTrading.Connection;
using SocialTrading.Tools;
using SocialTrading.DTO.Request;
using SocialTrading.Connection.Handlers;
using System.Net.Http;

namespace MASTTests.Connection
{
    [TestFixture]
    public class RestConnectionTests
    {
        //private Timer _timer;

        //[TestCase("tvma@i.ua", "123qwerty", HttpStatusCode.OK, TestName = "Auth Success", Author = "Oleh Marchenko")]
        //[TestCase("123@123.1231", "123qwee", 401, TestName = "Auth Fail", Author = "Oleh Marchenko")]
        //public void AuthTest(string email, string pass, HttpStatusCode statusCodeExp)
        //{
        //    ARest conn = new RestRor(ConnectionController.RorUri);
        //    var senderModel = new UserAuth(email, pass);

        //    var client = new HttpClient
        //    {
        //        BaseAddress = new Uri(conn.ServerAddress + senderModel.ApiPath)
        //    };

        //     var tokenSource = new CancellationTokenSource(DAL.SendDelay);

        //    conn.Send(client, senderModel.PerformQuery()?.ToString() ?? string.Empty, tokenSource, senderModel.Method);

        //    var state = true;
        //    _timer = new Timer(e =>
        //    {
        //        _timer.Change(-1, -1);
        //        state = false;
        //    });
        //    _timer.Change(DAL.SendDelay, -1);

        //    while (state) { }
        //    var statusCodeAct = conn.OnMessage += HendelResponse;

        //    Assert.AreEqual(statusCodeExp, statusCodeAct);
        //}

        //private void HendelResponse(HttpResponseMessage obj)
        //{
        //    throw new NotImplementedException();
        //}

        //[TestCase("123", "123", "123@123.123", "123qwe", 422, TestName = "Reg Fail", Author = "Oleh Marchenko")]
        //public void RegTest(string name, string lastName, string email, string pass, HttpStatusCode statusCodeExp)
        //{
        //    ARest conn = new RestRor(ConnectionController.RorUri);
        //    conn.Send(new UserReg(name, lastName, email, pass));

        //    var state = true;
        //    _timer = new Timer(e =>
        //    {
        //        _timer.Change(-1, -1);
        //        state = false;
        //    });
        //    _timer.Change(DAL.SendDelay, -1);

        //    while (state) { }
        //    var statusCodeAct = conn.StatusCode;

        //    Assert.AreEqual(statusCodeExp, statusCodeAct);
        //}
    }
}