using Microsoft.AspNetCore.Mvc;
using TaskFlow.Api.Exceptions;

namespace TaskFlow.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        private static async Task WriteProblemResponseAsync(HttpContext context, int statusCode, string title)
        {
            var problemDetails = new ProblemDetails
            {
                Title = title,
                Status = statusCode,
            };

            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                switch (ex)
                {
                    case TaskNotFoundException:
                        await WriteProblemResponseAsync(
                            context, 
                            StatusCodes.Status404NotFound, 
                            "Task Not Found"
                        );
                        break;
                    default:
                        await WriteProblemResponseAsync(
                            context, 
                            StatusCodes.Status500InternalServerError, 
                            "An unexpected error occurred"
                        );
                        break;
                }
            }
        }

    }
}
