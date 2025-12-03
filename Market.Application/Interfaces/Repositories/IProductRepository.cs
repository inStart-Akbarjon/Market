using Market.Application.DTOs.Request.Product;
using Market.Application.DTOs.Response.Product;
using Market.Domain.Models;

namespace Market.Application.Interfaces.Repositories;

public interface IProductRepository
{
    Task<List<GetAllProductsResponse>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task CreateAsync(AddProductRequest product);
    void UpdateAsync(Product product);
    void DeleteAsync(GetByIdProductResponse product);
    Task SaveChangesAsync();
}