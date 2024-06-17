namespace Domain.Exceptions;

public class DataNotFoundException() : ExceptionBase(Resources.Resource.DataNotFound, HttpStatusCode.NotFound);