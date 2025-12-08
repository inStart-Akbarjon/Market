using MagicOnion;
using Market.Contracts.Models.Product.Request;
using Market.Contracts.Models.Product.Response;

namespace Market.Contracts.Interfaces.Services;

public interface IProductService : IService<IProductService>
{
    UnaryResult<List<GetAllProductsResponse>> GetAllProducts(GetProductRequest request);
    UnaryResult<GetProductByIdResponse?>  GetProductById(GetProductByIdRequest request);
    UnaryResult<CreateProductResponse> CreateProduct(CreateProductRequest request);
    UnaryResult<UpdateProductResponse> UpdateProduct(int id, UpdateProductRequest request);
    UnaryResult<DeleteProductResponse> DeleteProduct(int id, DeleteProductRequest request);
}