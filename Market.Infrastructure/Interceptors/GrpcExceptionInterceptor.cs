using Grpc.Core;
using Grpc.Core.Interceptors;
using Market.Application.Exceptions.Abstract;
using Market.Application.Exceptions.Product;

namespace Market.Infrastructure.Interceptors;

public sealed class GrpcExceptionInterceptor : Interceptor
{
    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
        TRequest request, 
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        try
        {
            return await continuation(request, context);
        }
        catch (AppException ex)
        {
            throw HandleAppException(ex, context);
        }
        catch (Exception ex)
        {
            throw new RpcException(new Status(StatusCode.Internal, ex.Message));
        }
    }

    private static RpcException HandleAppException(AppException ex, ServerCallContext context)
    {
        switch (ex)
        {
            case InvalidRequestException:
                return new RpcException(new Status(StatusCode.InvalidArgument, ex.Message));
            case NotFoundException:
                return  new RpcException(new Status(StatusCode.NotFound, ex.Message));
            default:
                return new RpcException(new Status(StatusCode.Internal, ex.Message));
        }
    }
}
