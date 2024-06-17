namespace Domain.Exceptions;

public class PasswordDoesNotMatchException() : ExceptionBase(Resources.Resource.PasswordNoMatch, HttpStatusCode.Unauthorized);