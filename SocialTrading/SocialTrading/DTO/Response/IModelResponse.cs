using System.Net;

namespace SocialTrading.DTO.Response
{
    public interface IModelResponse
    {
        HttpStatusCode Status { get; set; }
        string Body { get; set; }
    }
}
