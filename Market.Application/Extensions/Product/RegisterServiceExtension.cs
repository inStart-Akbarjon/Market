using FluentValidation;
using Market.Application.CQRS.Product.Commands.CreateProduct;
using Market.Application.CQRS.Product.Validators;
using Market.Application.Interfaces.Mappers;
using Market.Application.Mappers.ServiceMappers;
using Microsoft.Extensions.DependencyInjection;

namespace Market.Application.Extensions.Product;

public static class RegisterServiceExtension
{
    public static IServiceCollection AddRegisterService(this IServiceCollection services)
    {
        services.AddScoped<IProductServiceMappers, ProductServiceMappers>();
        services.AddScoped<IValidator<CreateProductCommand>, CreateProductCommandValidator>();
        services.AddValidatorsFromAssembly(typeof(CreateProductCommandValidator).Assembly);
        return services;
    }
}