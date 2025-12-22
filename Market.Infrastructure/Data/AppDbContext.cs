using Market.Domain.Models;
using Market.Domain.Models.Product;
using Market.Infrastructure.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace Market.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
}