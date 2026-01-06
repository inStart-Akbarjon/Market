using Microsoft.Extensions.DependencyInjection;
using ServiceModel.Grpc.Configuration;

namespace Market.Application.Extensions.Common;

public static class GrpcModelServiceExtension
{
    public static IServiceCollection AddGrpcModelService(this IServiceCollection services)
    {
        services.AddServiceModelGrpc(options =>
        {
            options.DefaultMarshallerFactory = MessagePackMarshallerFactory.Default;
        });
        
        return services;
    }
}