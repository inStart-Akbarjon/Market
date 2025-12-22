using Market.Application.CQRS.Product.Queries.GetAllProducts;
using Microsoft.Extensions.DependencyInjection;

namespace Market.Application.Extensions.Product;

public static class MediatorRegistrationServiceExtension
{
    public static IServiceCollection AddMediatorRegistration(this IServiceCollection services)
    {
        services.AddMediatR(cfg => 
        {
            cfg.RegisterServicesFromAssembly(typeof(GetAllProductsQueryHandler).Assembly);
        });
        
        return services;
    }
}