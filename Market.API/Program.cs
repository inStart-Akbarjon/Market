using Market.Application.Mappers.ServiceMappers;
using Market.Application.Interfaces.Mappers;
using Market.Application.Extensions.Product;
using Market.Contracts.Interfaces.Services;
using Market.API.Services;
using MagicOnion.Server;
using Grpc.Net.Client;
using Market.Infrastructure.Data;
using Market.Infrastructure.Interceptors;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddOpenApi();
builder.Services.AddControllers();  

builder.Services.AddMagicOnion([
    typeof(IProductService).Assembly,
    typeof(ProductService).Assembly 
]);

builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductServiceMappers, ProductServiceMappers>();
builder.Services.AddSingleton<AuditInterceptor>();

builder.Services.AddGrpcModelService();
builder.Services.AddMediatorRegistration();
builder.Services.AddDbConnection(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
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
}

app.MapMagicOnionService();

app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();