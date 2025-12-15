using Grpc.Net.Client;
using MagicOnion.Server;
using Market.API.Interfaces.Services;
using Market.Application.CQRS.Product.Queries.GetAllProducts;
using Market.Application.Interfaces.Repositories;
using Market.Application.Mappers.ServiceMappers;
using Market.Application.Interfaces.Mappers;
using Market.Infrastructure.Repositories;
using ServiceModel.Grpc.Configuration;
using Microsoft.EntityFrameworkCore;
using Market.Infrastructure.Data;
using Market.API.Services;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddMagicOnion([typeof(IProductService).Assembly]);


builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductServiceMappers, ProductServiceMappers>();

// Grpc+MessagePack connection:
builder.Services.AddServiceModelGrpc(options =>
{
    options.DefaultMarshallerFactory = MessagePackMarshallerFactory.Default;
});

// MediatR connection:
builder.Services.AddMediatR(cfg => 
{
    cfg.RegisterServicesFromAssembly(typeof(GetAllProductsQueryHandler).Assembly);
});

// Database connection:
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(new NpgsqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"))));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    var magicOnionServiceDefinition =
        app.Services.GetRequiredService<MagicOnionServiceDefinition>();

    string baseUrl = " https://localhost:7271";
    
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

app.MapGrpcService<ProductService>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();