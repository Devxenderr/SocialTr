using System;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using SocialTrading.Tools;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Connection.Enumerations;

namespace SocialTrading.Connection.Handlers
{
    public abstract class ARest : IRestWebConnection
    {
        public string ServerAddress { get; set; }

        public Action<EResponseState> OnException { get; set; }

        public Action<HttpResponseMessage> OnMessage { get; set; }

        public Type TypeMarker { get; private set; }

        protected ARest(Type typeMarker)
        {
            TypeMarker = typeMarker;
        }
                
        public async void Send(HttpClient client, string parameters, CancellationTokenSource tokenSource, ERestCommands method)
        {
            HttpResponseMessage response = null;
            switch (method)
            {
                case ERestCommands.GET:
                    response = await RestCommand(() => client.GetAsync(client.BaseAddress, tokenSource.Token));
                    break;
                case ERestCommands.POST:
                    response = await RestCommand(() => client.PostAsync(client.BaseAddress, new StringContent(parameters, Encoding.UTF8, DAL.RestHeaderValues.ContentType), tokenSource.Token));
                    break;
                case ERestCommands.DELETE:
                    response = await RestCommand(() => client.DeleteAsync(client.BaseAddress, tokenSource.Token));
                    break;
                case ERestCommands.PUT:
                    response = await RestCommand(() => client.PutAsync(client.BaseAddress, new StringContent(parameters, Encoding.UTF8, DAL.RestHeaderValues.ContentType), tokenSource.Token));
                    break;

                default:
                    throw new WebException("Wrong REST command!");           
            }

            OnMessage?.Invoke(response);
        }


        private async Task<HttpResponseMessage> RestCommand(Func<Task<HttpResponseMessage>> restCommand)
        {
            try
            {
                return await restCommand?.Invoke();
            }
            catch (TaskCanceledException e)
            {
                OnException?.Invoke(EResponseState.NoResponse);
                return new HttpResponseMessage { StatusCode = HttpStatusCode.RequestTimeout };
            }
            catch (Exception e)
            {
                OnException?.Invoke(EResponseState.NoResponse);
                return new HttpResponseMessage { StatusCode = HttpStatusCode.ExpectationFailed };
            }
        }
    }
}
