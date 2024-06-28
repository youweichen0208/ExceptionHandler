using Microsoft.AspNetCore.Mvc;

namespace exceptionhandlers.handlers;

public class NotFoundExceptionHandler : IExceptionHandler
{
    
    /**
     * benefits of including ILogger:
     * 1. logging exception details
     * 2. diagnostic  information
     * 3. severity levels
     * 4. monitoring and alerting
     */
    private readonly ILogger<NotFoundExceptionHandler> _logger;

    public NotFoundExceptionHandler(ILogger<NotFoundExceptionHandler> logger)
    {
        _logger = logger;
    }
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        // problemDetails is a class provided by ASP.NET Core that represents details about
        // an HTTP problem or error. It includes properties such as Title, Status, Detail, and Instance.
        var problemDetails = new ProblemDetails
        {
            //sets the Instance property of the ProblemDetails object to the path of the current 
            //Http request. This helps identify the specific instance of the resource or endpoint where
            //the error occurred.
            Instance = httpContext.Request.Path,
            Title = exception.Message
        };

        if (exception is BaseException baseException)
        {
            httpContext.Response.StatusCode = (int)baseException.StatusCode;
        }
        else
        {
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }
        
        _logger.LogError("{ProblemDetailsTitle}", problemDetails.Title);
        problemDetails.Status = httpContext.Response.StatusCode;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        return true;
    }
}