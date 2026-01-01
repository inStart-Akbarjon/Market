using Microsoft.Extensions.DependencyInjection;
using Market.Infrastructure.Interceptors;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Market.Infrastructure.Data;
using Npgsql;

namespace Market.Infrastructure.Extensions;

public static class DbConnectionServiceExtension
{
    public static IServiceCollection AddDbConnection(this IServiceCollection services, IConfiguration configuration)
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