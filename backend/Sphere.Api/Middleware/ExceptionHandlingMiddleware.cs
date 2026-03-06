using Sphere.Application.Commons.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Sphere.Api.Middleware {
    public class ExceptionHandlingMiddleware {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger) {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context) {
            try {
                await _next(context);
            } catch (Exception e) {
                await HandleExceptionAsync(context, e);
            }
        }

        public async Task HandleExceptionAsync(HttpContext context, Exception exception) {
            _logger.LogError(exception, "An Error occured: {Message}", exception.Message);

            var (statusCode, message) = exception switch {
                NotFoundException => (StatusCodes.Status404NotFound, exception.Message),
                ValidationException => (StatusCodes.Status400BadRequest, exception.Message),
                _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred.")
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var response = new {
                error = message,
                statusCode = statusCode
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
