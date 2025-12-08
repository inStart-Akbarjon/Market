using Market.Contracts.Models.Product.Response;
using Market.Domain.Models;
using Market.Domain.Models.Product;

namespace Market.Application.Interfaces.Mappers;

public interface IProductServiceMappers
{
    public List<GetAllProductsResponse> ToGetAllProductsResponse(List<GetAllProductsResponse> products);
    public GetProductByIdResponse ToGetByIdProductResponse(Product product);
    public CreateProductResponse ToAddProductResponse(CreateProductResponse product);
    public UpdateProductResponse ToUpdateProductResponse(Product product);
    public DeleteProductResponse ToDeleteProductResponse(Product product);
}