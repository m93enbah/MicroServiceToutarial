namespace CleanArchitecture.Application.Common.Exceptions;

//this exception class called if not authorized
public class ForbiddenAccessException : Exception
{
    public ForbiddenAccessException() : base() { }
}
