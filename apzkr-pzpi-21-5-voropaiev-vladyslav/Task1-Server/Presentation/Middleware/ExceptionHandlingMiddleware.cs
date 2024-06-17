using System.Net;
using System.Text.Json;
using Domain.Exceptions;

namespace Presentation.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ExceptionBase ex)
        {
            _logger.LogError(ex, ex.Message);

            context.Response.StatusCode = (int)ex.HttpStatusCode;

            var problem = new ProblemDetails()
            {
                Status = (int)ex.HttpStatusCode,
                Type = ex.HttpStatusCode.ToString(),
                Detail = ex.Message
            };

            string problemJson = JsonSerializer.Serialize(problem);
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(problemJson);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var problem = new ProblemDetails()
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Type = "Server error",
                Detail = ex.Message
            };

            string problemJson = JsonSerializer.Serialize(problem);
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(problemJson);
        }
    }
}