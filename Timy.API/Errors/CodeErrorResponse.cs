using System.Net;

namespace TimyApp.API.Errors
{
    public class CodeErrorResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        public string? Message { get; set; }

        public CodeErrorResponse(HttpStatusCode statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
