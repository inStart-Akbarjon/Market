using FluentValidation;
using Market.Application.Behaviors;
using Market.Application.CQRS.Product.Validators;
using Market.Application.Interfaces.Mappers;
using Market.Application.Mappers.ServiceMappers;
using Market.Infrastructure.Interceptors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Market.Application.Extensions.Product;

public static class RegisterServiceExtension
{
    public static IServiceCollection AddRegisterService(this IServiceCollection services)
    {
        services.AddScoped<IProductServiceMappers, ProductServiceMappers>();
        services.AddSingleton<AuditInterceptor>();
        services.AddValidatorsFromAssembly(typeof(CreateProductCommandValidator).Assembly);
        return services;
    }
}