using System;

using Newtonsoft.Json.Linq;

using SocialTrading.Connection.Markers;
using SocialTrading.Connection.Enumerations;

namespace SocialTrading.DTO.Request
{
    public class WidgetModel : IModelSend
    {
        public EResponseModule ResponseModule { get; set; }
        public ERestCommands Method { get; set; }
        public string ApiPath { get; set; }

        public Type TypeMarker { get; private set; } = typeof(WidgetSocketMarker);

        public WidgetModel()
        {
        }

        public JObject PerformQuery()
        {
            return null;
        }
    }
}
