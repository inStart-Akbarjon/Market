using Market.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Market.Domain.Models.Product;
using Market.Infrastructure.Data;

namespace Market.Infrastructure.Repositories;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public IQueryable<Product> GetAllAsync()
    {
        return context.Products.Where(p => 
            p.DeletedAt == null 
            // && p.OpenedAt <= DateTime.UtcNow
            // && p.ClosedAt > DateTime.UtcNow
        ).AsQueryable().AsNoTracking();
    }

    public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken =  default)
    {
        return await context.Products.Where(p => 
            p.DeletedAt == null 
            // && p.OpenedAt <= DateTime.UtcNow
            // && p.ClosedAt > DateTime.UtcNow
        ).FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
        await context.Products.AddAsync(product, cancellationToken);
    }

    public void UpdateAsync(Product product, CancellationToken cancellationToken  = default)
    {
        context.Products.Update(product);
    }
    
    public async Task SaveChangesAsync(CancellationToken cancellationToken  = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}