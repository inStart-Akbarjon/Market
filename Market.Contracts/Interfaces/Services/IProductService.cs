using Market.Contracts.Models.Request;
using Market.Contracts.Models.Response;

namespace Market.Contracts.Interfaces.Services;

public interface IProductService
{
    Task<CreateProductResponse> CreateProduct(CreateProductRequest request);
}