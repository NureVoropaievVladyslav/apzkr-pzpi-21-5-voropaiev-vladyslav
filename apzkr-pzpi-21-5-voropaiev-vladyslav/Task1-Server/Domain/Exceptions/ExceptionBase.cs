namespace Domain.Exceptions;

public abstract class ExceptionBase(string message, HttpStatusCode httpStatusCode) : Exception(message)
{
    public HttpStatusCode HttpStatusCode { get; } = httpStatusCode;
}