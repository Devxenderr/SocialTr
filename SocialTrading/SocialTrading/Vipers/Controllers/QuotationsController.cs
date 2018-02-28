using System;
using System.Net;
using System.Collections.Generic;

using Newtonsoft.Json.Linq;

using SocialTrading.DTO;
using SocialTrading.Vipers.Qc;
using SocialTrading.DTO.Response;
using SocialTrading.DTO.Response.Qc;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Tools.Exceptions.Parse;
using SocialTrading.Connection.Enumerations;
using SocialTrading.DTO.Response.WidgetResponse;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.Controllers.Interfaces;
using SocialTrading.DTO.Response.WidgetResponse.Enumerations;

namespace SocialTrading.Vipers.Controllers
{
    public class QuotationsController : IQuotationsController
    {
        private readonly Func<string, WidgetResponse> _parseResponseWidget;
        private readonly Func<JArray, List<DataModelQc>> _parseResponseQc;
        private readonly IRepositoryQc _repository;
        private readonly IContact _contact;

        public IContactCreator ContactCreator { get; set; }
        public event Action<IModel> OnRecieveModel;


        public QuotationsController(IContactCreator contactCreator, IRepositoryQc repository, Func<string, WidgetResponse> parseResponseWidget, Func<JArray, List<DataModelQc>> parseResponseQc, Type modelType)
        {
            _parseResponseWidget = parseResponseWidget;
            _parseResponseQc = parseResponseQc;
            _repository = repository;

            ContactCreator = contactCreator;

            _contact = ContactCreator.CreateContact(new Model(modelType));
            _contact.Reciever = this;
        }


        public void Send(IModelSend senderModel)
        {
            _contact.Sender.Send(senderModel);
        }

        public void SetMessage(IModelResponse responseModel)
        {
            if (string.IsNullOrEmpty(responseModel.Body))
            {
                return;
            }

            WidgetResponse widgetResponse = null;
            try
            {
                widgetResponse = _parseResponseWidget(responseModel.Body);
            }
            catch (ParseException)
            {
                OnRecieveModel?.Invoke(new DataModelListQc { Status = EQcResponseStatus.Error });
                return;
            }

            if (widgetResponse.Module == ESocketModuleAnswer.rates)
            {
                ParseRates(responseModel.Status, widgetResponse.Args);
            }
        }

        private void ParseRates(HttpStatusCode statusCode, JArray args)
        {
            var result = new DataModelListQc();

            if (statusCode.Equals(HttpStatusCode.OK))
            {
                try
                {
                    _repository.UpdateQc(_parseResponseQc(args));
                    result.QcUpdatedList = _repository.UpdatedQuotations;
                    result.Status = EQcResponseStatus.Success;
                }
                catch (ParseException)
                {
                    result.Status = EQcResponseStatus.Error;
                }
            }
            else if (statusCode.Equals(HttpStatusCode.Gone))
            {
                result.Status = EQcResponseStatus.Gone;
            }
            else
            {
                result.Status = EQcResponseStatus.Error;
            }

            OnRecieveModel?.Invoke(result);
        }

        private class Model : IModelSend
        {
            public Model(Type typeMarker)
            {
                TypeMarker = typeMarker;
            }

            public Type TypeMarker { get; }
            public ERestCommands Method { get; set; }
            public string ApiPath { get; set; }

            public JObject PerformQuery()
            {
                return null;
            }
        }
    }
}