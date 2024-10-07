using CleanArchitecture.Application.Common.App;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Extension;
using FluentValidation;

namespace CleanArchitecture.API.Middleware
{
    public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        #region Properties
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionMiddleware> _logger = logger;
        #endregion

        #region InvokeAsync
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (ValidationException ve)
            {
                _logger.LogError("{Message}", ve.Message);

                await HandleValidationExceptionAsync(httpContext, ve);
            }
            catch (Exception e)
            {
                _logger.LogError("{Message}", e.Message);

                await HandleExceptionAsync(httpContext, e);
            }
        }
        #endregion

        #region HandleValidationExceptionAsync
        private static async Task HandleValidationExceptionAsync(HttpContext httpContext, ValidationException validationException)
        {
            List<Error> errors = [];

            httpContext.Response.ContentType = "application/json";

            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            if (validationException?.Errors?.Count() > 0)
                foreach (var error in validationException.Errors)
                    errors.Add(new Error(error.ErrorCode, error.ErrorMessage));

            await httpContext.Response.WriteAsync(ApplicationResult.WithError(errors).ObjectToJson());
        }
        #endregion

        #region HandleExceptionAsync
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            string errorMessage = exception switch
            {
                BadRequestException => exception.Message,
                NotFoundException => exception.Message,
                _ => "Internal Server Error"
            };

            return context.Response.WriteAsync(ApplicationResult.WithError("1", errorMessage).ObjectToJson());
        }
        #endregion
    }
}
