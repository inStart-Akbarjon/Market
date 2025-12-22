using Grpc.Net.Client;
using MagicOnion.Client;
using Market.Contracts.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Market.Contracts;

public static class GatewayConnectionExtensions
{
    public static IServiceCollection AddGatewayProductConnection(this IServiceCollection services)
    {
        services.AddSingleton<IProductService>(sp =>
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

            return MagicOnionClient.Create<IProductService>(channel);
        });
        
        return services;
    }
}