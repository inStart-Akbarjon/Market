using Grpc.Net.Client;
using MagicOnion.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Market.Application.Extensions.Product;

public static class GrpcConfigurationServiceExtension
{
    public static WebApplication AddGrpcSwaggerConfigurationService(this WebApplication app)
    {
        var magicOnionServiceDefinition = app.Services.GetRequiredService<MagicOnionServiceDefinition>();
        const string baseUrl = " https://localhost:7271";
    
        app.MapMagicOnionHttpGateway(
            "/api",
            magicOnionServiceDefinition.MethodHandlers,
            GrpcChannel.ForAddress(
                baseUrl,
                new GrpcChannelOptions
                {
                    HttpHandler = new HttpClientHandler
                    {
                        ServerCertificateCustomValidationCallback =
                            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                    }
                }));
    
        app.MapMagicOnionSwagger(
            "swagger",
            magicOnionServiceDefinition.MethodHandlers,
            "/api");

        return app;
    }
}