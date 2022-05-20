using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using CarRental.Service.CustomException;


namespace CarRental.Frontend.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ExceptionMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (BaseException ex)
            {
                string errorJson = JsonSerializer.Serialize(new
                {
                    message = ex.message,
                    code = ex.code
                });

                _logger.LogError(ex, ex.message);
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await HandleExceptionAsync(context, errorJson);
            }
            catch (Exception ex)
            {
                string errorJson = JsonSerializer.Serialize(new
                {
                    message = "system error",
                    code = "SYS-9999"
                });
                
                _logger.LogCritical(ex, ex.ToString());
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await HandleExceptionAsync(context, errorJson);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, string errorJson)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            await response.WriteAsync(errorJson);
        }
    }
}