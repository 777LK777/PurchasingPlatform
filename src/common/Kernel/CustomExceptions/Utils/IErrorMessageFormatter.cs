namespace Kernel.CustomExceptions.Utils;

public interface IErrorMessageFormatter
{
    public ErrorDescription GetMessageData(string message);
}