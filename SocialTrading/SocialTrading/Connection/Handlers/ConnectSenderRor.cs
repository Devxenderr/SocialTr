using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Diagnostics;
using System.Net.Http.Headers;

using Newtonsoft.Json.Linq;

using SocialTrading.DTO;
using SocialTrading.DTO.Response;
using SocialTrading.Tools.Constants;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Connection.Enumerations;
using SocialTrading.Service.Interfaces.Repository;

namespace SocialTrading.Connection.Handlers
{
    internal class ConnectSenderRor : IConnectionSender
    {
        private readonly IRestWebConnection _connection;
        private readonly RestHeaderValues _restHeaderValues;
        private readonly Action _onTokenFail;
        private readonly int _sendDelay;

        private readonly IRepositoryRestHeader _tokenRepo;
        private CancellationTokenSource _tokenSource;

        public ERestCommands Method { get; set; }

        public HttpStatusCode StatusCode { get; private set; }

        public Action<EResponseState> OnException { get; set; }
        public event Action<IModelResponse> OnMessage;


        public ConnectSenderRor(IRestWebConnection connection, IRepositoryRestHeader tokenRepo, int sendDelay, RestHeaderValues restHeaderValues, Action onTokenFail)
        {
            _connection = connection;
            _tokenRepo = tokenRepo;
            _sendDelay = sendDelay;
            _restHeaderValues = restHeaderValues;
            _onTokenFail = onTokenFail;
            _connection.OnMessage += HandleResponse;
        }


        public void Send(IModelSend senderModel)
        {
            if (senderModel == null)
            {
                return;
            }

            Method = senderModel.Method;

            var client = new HttpClient
            {
                BaseAddress = new Uri(_connection.ServerAddress + senderModel.ApiPath)
            };

            //TODO go to repo and get Token

            if (_tokenRepo.HeaderModel != null)
            {
                client.DefaultRequestHeaders.Add(_tokenRepo.HeaderModel.AccessTokenTitle, _tokenRepo.HeaderModel.AccessToken);
                client.DefaultRequestHeaders.Add(_tokenRepo.HeaderModel.AcceptLangTitle, _tokenRepo.HeaderModel.AcceptLang);
                client.DefaultRequestHeaders.Add(_tokenRepo.HeaderModel.ClientTitle, _tokenRepo.HeaderModel.Client);
                client.DefaultRequestHeaders.Add(_tokenRepo.HeaderModel.UidTitle, _tokenRepo.HeaderModel.Uid);
            }

            _tokenSource = new CancellationTokenSource(_sendDelay);
            _tokenSource.Token.Register(() =>
            {
                OnException?.Invoke(EResponseState.NoConnection);
            });

#if DEBUG
            var api = senderModel.ApiPath;
            var headers = client.DefaultRequestHeaders.ToString();
            var body = senderModel.PerformQuery()?.ToString();
            Debug.WriteLine(" * AREST_SEND \nAPI = " + api + "\nHeaders =" + headers + "\nBody = " + body);
#endif
            _connection.Send(client, senderModel.PerformQuery()?.ToString() ?? string.Empty, _tokenSource, senderModel.Method);
        }


        private void HandleResponse(HttpResponseMessage response)
        {
            _tokenSource.Dispose();

            if (response == null)
            {
#if DEBUG
                Debug.WriteLine(" * AREST_GET_!!!ERROR!!! RESPONSE = NULL!!!");
#endif
                OnMessage?.Invoke(new Response { Status = HttpStatusCode.ExpectationFailed });
                return;
            }

            if (response.StatusCode.Equals(HttpStatusCode.ExpectationFailed))
            {
#if DEBUG
                var headersError = response.ToString();
                Debug.WriteLine(" * AREST_GET_!!!ERROR!!! \nHeaders = " + headersError);
#endif
                response.Dispose();
                OnMessage?.Invoke(new Response { Status = HttpStatusCode.ExpectationFailed });
                return;
            }

            if (response.StatusCode.Equals(HttpStatusCode.RequestEntityTooLarge))
            {
#if DEBUG
                var headersError = response.ToString();
                Debug.WriteLine(" * AREST_GET_!!!ERROR!!! \nHeaders = " + headersError);
#endif
                response.Dispose();
                OnMessage?.Invoke(new Response { Status = HttpStatusCode.RequestEntityTooLarge });
                return;
            }


            StatusCode = response.StatusCode;
            string responseString = default(string);
            if (response.Content != null)
            {
                var responseStream = new StreamReader(response.Content.ReadAsStreamAsync().Result);
                responseString = responseStream.ReadToEnd();
                responseStream.Dispose();
            }

            if (response.StatusCode.Equals(HttpStatusCode.Unauthorized) && response.Content != null)
            {
#if DEBUG
                var headersError = response.ToString();
                Debug.WriteLine(" * AREST_GET_!!!BAD TOKEN!!! \nHeaders = " + headersError);
                
#endif
                try
                {
                    var jObj = JObject.Parse(responseString);
                    bool? isBadToken = jObj.SelectToken("error_token").Value<bool?>();

                    if (isBadToken != null && isBadToken == true)
                    {
                        _onTokenFail?.Invoke();
                    }
                }
                catch (Exception)
                {

                }
            }

            HandleHeaders(response.Headers);

            IModelResponse responseMock = new Response
            {
                Body = responseString,
                Status = response.StatusCode
            };

#if DEBUG
            var headers = response.ToString();
            var body = responseMock.Body;
            Debug.WriteLine(" * AREST_GET \nHeaders = " + headers + "\nBody = " + body);
#endif

            OnMessage?.Invoke(responseMock);

            response.Dispose();
        }

        private void HandleHeaders(HttpResponseHeaders headers)
        {
            if (headers.Contains(_restHeaderValues.AccessTokenTitle)
                && headers.Contains(_restHeaderValues.ClientTitle)
                && headers.Contains(_restHeaderValues.UidTitle))
            {
                if (string.IsNullOrEmpty(headers.GetValues(_restHeaderValues.AccessTokenTitle).First()))
                {
                    return;
                }

                _tokenRepo.HeaderModel.Update(
                    headers.GetValues(_restHeaderValues.AccessTokenTitle).First(),
                    headers.GetValues(_restHeaderValues.ClientTitle).First(),
                    headers.GetValues(_restHeaderValues.UidTitle).First()
                );
            }
        }
    }
}
