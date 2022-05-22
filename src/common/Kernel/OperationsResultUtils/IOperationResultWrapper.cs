using Kernel.OperationResultUtils.Implementation;

namespace Kernel.OperationResultUtils;

public interface IOperationResultWrapper
{
    OperationResult<TRes> CreateResponse<T, TRes>(Func<T, TRes> func, T arg);
}