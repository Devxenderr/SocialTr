using System.Net;

namespace SocialTrading.DTO.Response
{
    internal class Response : IModelResponse
    {
        public HttpStatusCode Status { get; set; }
        public string Body { get; set; }
    }
}