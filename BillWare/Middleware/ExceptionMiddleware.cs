using BillWare.API.Errors;
using BillWare.Application.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace BillWare.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next,
                                   ILogger<ExceptionMiddleware> logger,
                                   IHostEnvironment env)
        {
            _logger = logger;
            _next = next;
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

                context.Response.ContentType = "application/json";
                var statusCode = (int)HttpStatusCode.InternalServerError;
                var result = string.Empty;

                var titleMessageError = "Se presentaron uno o más errores de validación";

                switch (ex)
                {
                    case NotFoundException notFoundException:
                        statusCode = (int)HttpStatusCode.NotFound;
                        result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, titleMessageError, notFoundException.Message));
                        break;
                    case ValidationException validationException:
                        var errorsText = string.Join(" - ", validationException.Errors.Select(kv => $"{string.Join(" y ", kv.Value)}"));
                        statusCode = (int)HttpStatusCode.BadRequest;
                        result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message, errorsText));
                        break;
                    case BadRequestException badRequestException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, titleMessageError, badRequestException.Message));
                        break;
                    default:
                        break;
                }

                if (string.IsNullOrEmpty(result))
                {
                    if(_env.IsDevelopment())
                    {
                        result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message, ex.StackTrace?.ToString()));
                    }
                    else
                    {
                        result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, titleMessageError, "Ha ocurrido un error en el lado del servidor. Contáctese con el administrador del sistema."));
                    }
                }
                
                context.Response.StatusCode = statusCode;

                await context.Response.WriteAsync(result);
            }
        }
    }
}
