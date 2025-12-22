using Market.Infrastructure.Data;
using Market.Infrastructure.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Market.Application.Extensions.Product;

public static class DbConnectionServiceExtension
{
    public static IServiceCollection  AddDbConnection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<AuditInterceptor>();
        
        services.AddDbContext<AppDbContext>((sp, options) =>
        {
            options.UseNpgsql(new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")));
            options.AddInterceptors(sp.GetRequiredService<AuditInterceptor>());

        });
        
        return services;
    }
}