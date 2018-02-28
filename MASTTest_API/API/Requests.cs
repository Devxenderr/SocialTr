using System;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using SocialTrading.Tools;
using SocialTrading.Connection;
using SocialTrading.DTO.Request.EditContact;
using SocialTrading.DTO.Request.RA;
using SocialTrading.Vipers.Entity;

namespace MASTTest_API.API
{
    public class Requests
    {
        private readonly HeaderHandler _headerHandler;


        public Requests(HeaderHandler headerHandler)
        {
            _headerHandler = headerHandler;
        }


        public async Task<HttpStatusCode> Auth(string email)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(ConnectionController.RorUri + new UserAuth(email, "123qwerty").ApiPath)
            };
            var response = await client.PostAsync(client.BaseAddress,
                new StringContent(new UserAuth(email, "123qwerty").PerformQuery().ToString(), Encoding.UTF8, DAL.RestHeaderValues.ContentType),
                new CancellationTokenSource(DAL.SendDelay).Token);

            _headerHandler.HandleHeaders(response.Headers);
            client.Dispose();

            return response.StatusCode;
        }

        public async Task<HttpResponseMessage> UpdateEditContactInfo(string email, string skype, string country, string city, string phone)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(ConnectionController.RorUri + new UserInfoDTO(new EditContactEntity(email, skype, country, city, phone)).ApiPath)
            };

            _headerHandler.SetHeaders(client);

            var response = await client.PutAsync(client.BaseAddress,
                new StringContent(new UserInfoDTO(new EditContactEntity(email, skype, country, city, phone)).PerformQuery().ToString(), Encoding.UTF8, DAL.RestHeaderValues.ContentType),
                new CancellationTokenSource(DAL.SendDelay).Token);
            client.Dispose();

            return response;
        }
    }
}