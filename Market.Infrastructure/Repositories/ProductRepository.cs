using Market.Application.DTOs.Request.Product;
using Market.Application.DTOs.Response.Product;
using Market.Application.Interfaces.Repositories;
using Market.Domain.Models;
using Market.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Market.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    
    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<GetAllProductsResponse>> GetAllAsync()
    {
        return await _context.Products.Select(c => new GetAllProductsResponse()
        {
            Id = c.Id,
            Title = c.Title,
            Description = c.Description,
            Price = c.Price,
            CreatedAt =  c.CreatedAt,
        }).ToListAsync();
    }

    public async Task<GetByIdProductResponse?> GetByIdAsync(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

        return new GetByIdProductResponse()
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            CreatedAt =  product.CreatedAt,
        };
    }

    public async Task CreateAsync(AddProductRequest product)
    {
        var productEntity = new Product()
        {
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
        };
        
        await _context.Products.AddAsync(productEntity);
        
        await _context.SaveChangesAsync();
    }

    public void UpdateAsync(Product product)
    {
        _context.Products.Update(product);
    }

    public void DeleteAsync(GetByIdProductResponse product)
    {
        var productEntity = new Product()
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            CreatedAt = product.CreatedAt,
        };
        
        _context.Products.Remove(productEntity);
    }
    
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}