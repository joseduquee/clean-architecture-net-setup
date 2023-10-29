using Newtonsoft.Json;
using System.Net;
using TimyApp.API.Errors;
using TimyApp.Application.Exceptions;

namespace TimyApp.API.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            } 
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var statusCode = HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var result = string.Empty;

                switch (ex)
                {
                    case NotFoundException:
                        statusCode = HttpStatusCode.NotFound;
                        break;
                    case ValidationException validationException:
                        statusCode = HttpStatusCode.BadRequest;
                        var validationJson = JsonConvert.SerializeObject(validationException.Errors);
                        result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message, validationJson));
                        break;
                    case BadRequestException badRequestException:
                        statusCode = HttpStatusCode.BadRequest;
                        result = badRequestException.Message;
                        break;
                    case Exception:
                        statusCode = HttpStatusCode.BadRequest;
                        break;
                }

                if (string.IsNullOrEmpty(result))
                {
                    result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message, ex.StackTrace));
                }

                context.Response.StatusCode = (int)statusCode;

                await context.Response.WriteAsync(result);

            }
        }
    }
}
