using Market.Domain.Models;
using Market.Domain.Models.Product;

namespace Market.Application.Interfaces.Repositories;

public interface IProductRepository
{
    IQueryable<Product> GetAllAsync();
    Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task CreateAsync(Product product, CancellationToken cancellationToken);
    void UpdateAsync(Product product, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}