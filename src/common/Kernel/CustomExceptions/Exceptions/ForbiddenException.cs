namespace Kernel.CustomExceptions.Exceptions;

public class ForbiddenException : BaseException
{
    public override int StatusCode => 403;
    public override string Header => "Forbidden";
    public ForbiddenException() { }
    public ForbiddenException(string message) : base(message) { }
    public ForbiddenException(string message, Exception innerException) : base(message, innerException) { }
}