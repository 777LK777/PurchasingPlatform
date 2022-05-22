namespace Kernel.OperationResultUtils.Implementation;
public class OperationResult<T>
{
    public T Data { get; set; }
    public int StatusCode { get; set; } = 200;
    public bool IsSuccess { get; set; }
    public string ErrorMessage { get; set; }
}