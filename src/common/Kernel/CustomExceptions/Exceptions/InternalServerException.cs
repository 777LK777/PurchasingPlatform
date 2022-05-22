namespace Kernel.CustomExceptions.Exceptions;

public class InternalServerException : BaseException
{
    public override int StatusCode => 500;
    public override string Header => "Internal server error";
    public InternalServerException() { }
    public InternalServerException(string message) : base(message) { }
    public InternalServerException(string message, Exception innerException) : base(message, innerException) { }
}