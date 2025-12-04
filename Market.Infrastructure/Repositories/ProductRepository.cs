using Market.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Market.Infrastructure.Data;
using Market.Domain.Models;

namespace Market.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    
    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }
    public IQueryable<Product> GetAll()
    {
        return _context.Products.AsQueryable().AsNoTracking();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        return product;
    }

    public async Task CreateAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public void UpdateAsync(Product product)
    {
        _context.Products.Update(product);
    }

    public void DeleteAsync(Product product)
    {
        _context.Products.Remove(product);
    }
    
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}