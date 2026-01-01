using Market.Application.Interfaces.AppDbContext;
using Market.Domain.Entities.Product;
using Market.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Market.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IAppDbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductModelConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}