using Market.Application.Interfaces.Repositories;
using Market.Infrastructure.Repositories;
using ServiceModel.Grpc.Configuration;
using Microsoft.EntityFrameworkCore;
using Market.Infrastructure.Data;
using Market.API.Services;
using Market.Application.CQRS.Product.Queries.GetAllProducts;
using Market.Application.Interfaces.Mappers;
using Market.Application.Mappers.ServiceMappers;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddMagicOnion();
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
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapMagicOnionService();

// app.MapGrpcService<ProductGrpcService>();
app.MapGrpcService<ProductService>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();