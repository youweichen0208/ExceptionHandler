using exceptionhandlers.handlers;

namespace exceptionhandlers.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddExceptionHandlers(this IServiceCollection services)
    {
        services.AddSingleton<IExceptionHandler, NotFoundExceptionHandler>();
        services.AddSingleton<IExceptionHandler, GlobalExceptionHandler>();
        services.AddProblemDetails();
    }
}