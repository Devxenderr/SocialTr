using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

using SocialTrading.Tools;
using SocialTrading.Service;
using SocialTrading.Service.Interfaces.Repository;

namespace MASTTest_API.API
{
    public class HeaderHandler
    {
        private readonly IRepositoryRestHeader _tokenRepo;


        public HeaderHandler()
        {
            _tokenRepo = DataService.RepositoryController.RepositoryRestHeader;
        }


        public void HandleHeaders(HttpResponseHeaders headers)
        {
            if (headers.Contains(DAL.RestHeaderValues.AccessTokenTitle)
                && headers.Contains(DAL.RestHeaderValues.ClientTitle)
                && headers.Contains(DAL.RestHeaderValues.UidTitle))
            {
                if (string.IsNullOrEmpty(headers.GetValues(DAL.RestHeaderValues.AccessTokenTitle).First()))
                {
                    return;
                }

                _tokenRepo.HeaderModel.Update(
                    headers.GetValues(DAL.RestHeaderValues.AccessTokenTitle).First(),
                    headers.GetValues(DAL.RestHeaderValues.ClientTitle).First(),
                    headers.GetValues(DAL.RestHeaderValues.UidTitle).First()
                );
            }
        }

        public void SetHeaders(HttpClient client)
        {
            client.DefaultRequestHeaders.Add(_tokenRepo.HeaderModel.AccessTokenTitle, _tokenRepo.HeaderModel.AccessToken);
            client.DefaultRequestHeaders.Add(_tokenRepo.HeaderModel.AcceptLangTitle, _tokenRepo.HeaderModel.AcceptLang);
            client.DefaultRequestHeaders.Add(_tokenRepo.HeaderModel.ClientTitle, _tokenRepo.HeaderModel.Client);
            client.DefaultRequestHeaders.Add(_tokenRepo.HeaderModel.UidTitle, _tokenRepo.HeaderModel.Uid);
        }
    }
}