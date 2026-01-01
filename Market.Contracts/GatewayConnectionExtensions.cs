using Grpc.Net.Client;
using MagicOnion.Client;
using Market.Contracts.Interfaces.GrpcServices;
using Microsoft.Extensions.DependencyInjection;

namespace Market.Contracts;

public static class GatewayConnectionExtensions
{
    public static IServiceCollection AddGatewayProductConnection(this IServiceCollection services)
    {
        services.AddSingleton<IProductServiceGrpc>(sp =>
        {
            var channel = GrpcChannel.ForAddress(
                "https://localhost:7271",
                new GrpcChannelOptions
                {
                    HttpHandler = new SocketsHttpHandler
                    {
                        EnableMultipleHttp2Connections = true
                    }
                });

            return MagicOnionClient.Create<IProductServiceGrpc>(channel);
        });
        
        return services;
    }
}