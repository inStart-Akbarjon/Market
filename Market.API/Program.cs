using Market.Application.Interfaces.Repositories;
using Market.Application.Queries.GetAllProducts;
using Market.Infrastructure.Repositories;
using ServiceModel.Grpc.Configuration;
using Microsoft.EntityFrameworkCore;
using Market.Infrastructure.Data;
using Market.API.Services;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

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
    options.UseNpgsql(new NpgsqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")), b => b.MigrationsAssembly("Market.API")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.MapGrpcService<ProductGrpcService>();
app.MapGrpcService<ProductService>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();