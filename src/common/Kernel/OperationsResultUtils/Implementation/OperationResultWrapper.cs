using Kernel.OperationResultUtils;
using Kernel.CustomExceptions.Exceptions;

namespace Kernel.OperationResultUtils.Implementation;

public class OperationResultWrapper : IOperationResultWrapper
{
    public OperationResult<TRes> CreateResponse<T, TRes>(Func<T, TRes> func, T arg)
    {
        var res = new OperationResult<TRes>();

        try
        {
            res.Data = func(arg);
            res.IsSuccess = true;
            return res;
        }
        catch (BaseException e)
        {
            res.StatusCode = e.StatusCode;
            res.ErrorMessage = e.Message;
            return res;
        }
        catch (Exception)
        {
            res.StatusCode = 500;
            return res;
        }
    }
}