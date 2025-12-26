using Market.Application.CQRS.Product.Commands.CreateProduct;
using Market.Domain.Models.Product;
using Market.Application.Interfaces.Mappers;
using Market.Contracts.Models.Product.Response;
using DeleteProductResponse = Market.Contracts.Models.Product.Response.DeleteProductResponse;
using UpdateProductResponse = Market.Contracts.Models.Product.Response.UpdateProductResponse;

namespace Market.Application.Mappers.ServiceMappers;

public class ProductServiceMappers : IProductServiceMappers
{
    public GetProductByIdResponse ToGetByIdProductResponse(Product product)
    {
        return new GetProductByIdResponse()
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            Quantity = product.Quantity,
            OpenedAt = product.OpenedAt,
            ClosedAt = product.ClosedAt,
        };
    }
    
    public CreateProductResponse ToAddProductResponse(Product product)
    {
        return new CreateProductResponse()
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            Quantity = product.Quantity,
            OpenedAt = product.OpenedAt,
            ClosedAt = product.ClosedAt
        };
    }
    
    public UpdateProductResponse ToUpdateProductResponse(Product product)
    {
        return new UpdateProductResponse()
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            Quantity = product.Quantity,
            OpenedAt = product.OpenedAt,
            ClosedAt = product.ClosedAt,
        };
    }
    
    public DeleteProductResponse ToDeleteProductResponse(Product product)
    {
        return new DeleteProductResponse()
        {
            Id = product.Id,
        };
    }

    public Product ToProductEntity(CreateProductCommand product)
    {
        return new Product()
        {
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            Quantity = product.Quantity,
            OpenedAt = product.OpenedAt,
            ClosedAt = product.ClosedAt
        };
    }
}