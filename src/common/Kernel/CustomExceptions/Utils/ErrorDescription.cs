namespace Kernel.CustomExceptions.Utils;

public class ErrorDescription
{
    public Guid Id { get; set; }
    public Guid ParentId { get; set; }
    public string Message { get; set; }
}