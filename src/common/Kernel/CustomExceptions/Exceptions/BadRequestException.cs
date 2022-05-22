namespace Kernel.CustomExceptions.Exceptions;
public class BadRequestException : BaseException
{
    public override int StatusCode => 400;
    public override string Header => "Bad request";
    public BadRequestException() { }
    public BadRequestException(string message) : base(message) { }
    public BadRequestException(string message, Exception innerException) : base(message, innerException) { }
}