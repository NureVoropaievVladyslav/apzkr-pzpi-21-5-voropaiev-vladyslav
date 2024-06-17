namespace Domain.Exceptions;

public class EmailIsUnavailableException() : ExceptionBase(Resources.Resource.EmailUnavailable, HttpStatusCode.Conflict);