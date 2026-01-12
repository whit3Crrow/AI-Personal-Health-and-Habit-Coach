using AIPersonalHealthAndHabitCoach.Domain.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AIPersonalHealthAndHabitCoach.API.Middlewares
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                var (title, statusCode, message, errors) = ex switch
                {
                    CustomException customException =>
                        (customException.Title, customException.StatusCode, customException.Message, null),

                    ValidationException validationException =>
                        ("Validation Failed", HttpStatusCode.BadRequest, "One or more validation errors occurred.", GetValidationErrors(validationException)),

                    _ =>
                        ("An Unexpected Error Occurred", HttpStatusCode.InternalServerError, ex.Message, null)
                };

                await ReturnErrorResponse(context, title, statusCode, message, errors);
            }
        }

        private static IDictionary<string, string[]> GetValidationErrors(ValidationException exception)
        {
            return exception.Errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(
                    group => group.Key,
                    group => group.Select(e => e.ErrorMessage).ToArray()
                );
        }

        private async Task ReturnErrorResponse(HttpContext context, string title, HttpStatusCode statusCode, string message, IDictionary<string, string[]>? errors = null)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = (int)statusCode;

            var errorResponse = new ProblemDetails
            {
                Type = $"https://httpstatuses.com/{(int)statusCode}",
                Title = title,
                Status = (int)statusCode,
                Detail = message,
                Instance = context.Request.Path,
                Extensions = { ["traceId"] = context.TraceIdentifier }
            };

            if (errors != null)
            {
                errorResponse.Extensions["errors"] = errors;
            }

            await context.Response.WriteAsJsonAsync(errorResponse);
        }
    }
}