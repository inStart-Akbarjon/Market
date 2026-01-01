using Market.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Interfaces.AppDbContext;

public interface IAppDbContext
{
    DbSet<Product> Products { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}