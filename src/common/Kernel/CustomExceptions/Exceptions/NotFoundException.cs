namespace Kernel.CustomExceptions.Exceptions;

public class NotFoundException : BaseException
{
    public override int StatusCode => 404;
    public override string Header => "Not found";
    public NotFoundException() { }
    public NotFoundException(string message) : base(message) { }
    public NotFoundException(string message, Exception innerException) : base(message, innerException) { }
}