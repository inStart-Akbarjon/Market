using Market.Application.Extensions.Product;
using Market.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddOpenApi();
builder.Services.AddControllers();  

builder.Services.AddMagicOnion([
    typeof(ProductServiceGrpc).Assembly
]);

builder.Services.AddSwaggerGen();
builder.Services.AddRegisterService();
builder.Services.AddGrpcModelService();
builder.Services.AddMediatorRegistration();
builder.Services.AddDbConnection(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.AddGrpcSwaggerConfigurationService();
}

app.MapMagicOnionService();

app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();