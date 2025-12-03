using Market.Application.DTOs.Request.Product;
using Market.Application.DTOs.Response.Product;
using Market.Domain.Models;

namespace Market.Application.Interfaces.Repositories;

public interface IProductRepository
{
    Task<List<GetAllProductsResponse>> GetAllAsync();
<<<<<<< HEAD
    Task<Product?> GetByIdAsync(int id);
=======
    Task<GetByIdProductResponse?> GetByIdAsync(int id);
>>>>>>> 0cbf7de300fb8e8025bb247a7d8cffb5d24191fa
    Task CreateAsync(AddProductRequest product);
    void UpdateAsync(Product product);
    void DeleteAsync(GetByIdProductResponse product);
    Task SaveChangesAsync();
}