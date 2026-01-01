using Market.Application.CQRS.Product.Commands.CreateProduct;
using Market.Contracts.Models.Product.Response;
using Market.Domain.Entities.Product;

namespace Market.Application.Interfaces.Mappers;

public interface IProductServiceMappers
{
    public GetProductByIdResponse ToGetByIdProductResponse(Product product);
    public CreateProductResponse ToAddProductResponse(Product product);
    public UpdateProductResponse ToUpdateProductResponse(Product product);
    public DeleteProductResponse ToDeleteProductResponse(Product product);
    public Product ToProductEntity(CreateProductCommand product);
}