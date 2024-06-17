namespace Domain.Exceptions;

public class UserAlreadyExistsException() : ExceptionBase(Resources.Resource.UserAlreadyExists, HttpStatusCode.Conflict);