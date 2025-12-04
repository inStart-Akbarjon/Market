using Market.Application.DTOs.Request.Product;
using Market.Application.DTOs.Response.Product;
using Market.Domain.Models;

namespace Market.Application.Interfaces.Repositories;

public interface IProductRepository
{
    IQueryable<Product> GetAll();
    Task<Product?> GetByIdAsync(int id);
    Task CreateAsync(Product product);
    void UpdateAsync(Product product);
    void DeleteAsync(Product product);
    Task SaveChangesAsync();
}