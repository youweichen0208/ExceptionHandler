using Microsoft.AspNetCore.Mvc;

namespace exceptionhandlers.handlers;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }
    
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var problemDetails = new ProblemDetails
        {
            Instance = httpContext.Request.Path, 
            Title = "An unexpected error occurred."
        };

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        _logger.LogError(exception, "{ProblemDetailsTitle}", problemDetails.Title);
        problemDetails.Status = httpContext.Response.StatusCode;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        return true;
    }
}