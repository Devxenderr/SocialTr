using Newtonsoft.Json.Linq;

using SocialTrading.Connection.Interfaces;
using SocialTrading.Connection.Enumerations;

namespace SocialTrading.DTO
{
    public interface IModelSend : ITypeConnection
    {
        ERestCommands Method { get; set; }
        string ApiPath { get; set; }

        JObject PerformQuery();
    }
}
 