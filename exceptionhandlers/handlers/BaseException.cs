using System.Net;

namespace exceptionhandlers.handlers;

/**
 * 1. centralized exception handling: by creating a base exception class, we can
 * centralize common exception logic and properties that are shared across different types
 * of exceptions in our application.
 * 2. custom exception information: it allows me to define additional properties or methods specific
 * to our application's exception handling needs. For example, we might include properties like
 * Status code in web applications, ErrorCode for custom error codes.
 * 3. Consistency: using a base exception class helps maintain consistency in error reporting and handling
 * across our application.
 */
public class BaseException : Exception
{
    public HttpStatusCode StatusCode { get; }

    public BaseException(string message, HttpStatusCode statusCode) : base(message)
    {
        StatusCode = statusCode;
    }
}