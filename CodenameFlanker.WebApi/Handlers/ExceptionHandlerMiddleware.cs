using CodenameFlanker.WebApi.Controllers;
using System.Text.Json;

namespace CodenameFlanker.WebApi.Handlers;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
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
        catch (Exception exception)
        {
            HttpResponse response = context.Response;
            response.ContentType= "application/json";
            response.StatusCode = 500;
            _logger.LogError(exception.Message);
        }
    }
}
