using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MASTTest_API.API;

using NUnit.Framework;

using SocialTrading.Connection.Dispatcher;

namespace MASTTests.Connection.ParseDTO
{
    [TestFixture, Author("Oleh Marchenko")]
    public class ParseAPIResponse
    {
        private Requests _requests;
        private HeaderHandler _headerHandler;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _headerHandler = new HeaderHandler();
            _requests = new Requests(_headerHandler);
        }

        [Test]
        public void ParseDataModelUserInfoAPIResponse()
        {
            var result = TestEditContact("143dacc7-c4a4-4c78-ab72-c483041de08c", "Jon", "Snow", "Jons", 
                "https://s3-eu-central-1.amazonaws.com/investarena-avatar/1511784812", 
                "tvma@i.ua", "phone", null, "skype", "country", "city", "sgzfna").Result;

            Assert.IsTrue(result);
        }

        

        private async Task<bool>TestEditContact(string id, string first_name, string last_name, string nickname, string image,
            string email, string phone, string phone_2, string skype, string country, string city, string status)
        {
            var jObj = DataModels.GetDataModelUserInfo(id, first_name, last_name, nickname, image, email, phone, phone_2, skype, country, city, status);
            var modelExp = WebMsgParser.ParseResponsePersonalInfo(jObj.ToString());

            var statusCode = await _requests.Auth(email);
            if (statusCode != HttpStatusCode.OK)
            {
                return false;
            }

            var response = await _requests.UpdateEditContactInfo(email, skype, country, city, phone);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return false;
            }

            var responseStream = new StreamReader(response.Content.ReadAsStreamAsync().Result);
            var responseString = responseStream.ReadToEnd();
            responseStream.Dispose();

            var modelAct = WebMsgParser.ParseResponsePersonalInfo(responseString);

            var result = modelExp.Equals(modelAct);

            return result;
        }
    }
}