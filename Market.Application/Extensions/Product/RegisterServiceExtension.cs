using Market.Application.Interfaces.Mappers;
using Market.Application.Mappers.ServiceMappers;
using Market.Infrastructure.Interceptors;
using Microsoft.Extensions.DependencyInjection;

namespace Market.Application.Extensions.Product;

public static class RegisterServiceExtension
{
    public static IServiceCollection AddRegisterService(this IServiceCollection services)
    {
        services.AddScoped<IProductServiceMappers, ProductServiceMappers>();
        services.AddSingleton<AuditInterceptor>();
        
        return services;
    }
}