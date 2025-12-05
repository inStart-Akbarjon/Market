using Market.Contracts.Models.Request;
using Market.Contracts.Models.Response;

namespace Market.Contracts.Interfaces.Services;

public interface IProductService
{
    Task<List<GetProductResponse>> GetProduct(GetProductRequest request);
    Task<GetProductByIdResponse>  GetProductById(GetProductByIdRequest request);
    Task<CreateProductResponse> CreateProduct(CreateProductRequest request);
    Task<UpdateProductResponse> UpdateProduct(UpdateProductRequest request);
    Task<DeleteProductResponse> DeleteProduct(DeleteProductRequest request);
}