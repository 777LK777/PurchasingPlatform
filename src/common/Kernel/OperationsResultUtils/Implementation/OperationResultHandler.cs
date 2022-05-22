using Kernel.CustomExceptions.Exceptions;

namespace Kernel.OperationResultUtils.Implementation;
public class OperationResultHandler
{
    public T HandleResponse<T>(OperationResult<T> response)
    {
        return response.StatusCode switch
        {
            200 => response.Data,
            400 => throw new BadRequestException(response.ErrorMessage),
            403 => throw new ForbiddenException(response.ErrorMessage),
            404 => throw new NotFoundException(response.ErrorMessage),
            _ => throw new InternalServerException(response.ErrorMessage)
        };
    }
}