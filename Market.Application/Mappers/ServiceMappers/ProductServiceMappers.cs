using Market.Application.Interfaces.Mappers;
using Market.Contracts.Models.Product.Response;
using Market.Domain.Models;
using DeleteProductResponse = Market.Contracts.Models.Product.Response.DeleteProductResponse;
using UpdateProductResponse = Market.Contracts.Models.Product.Response.UpdateProductResponse;

namespace Market.Application.Mappers.ServiceMappers;

public class ProductServiceMappers : IProductServiceMappers
{
    public List<GetAllProductsResponse> ToGetAllProductsResponse(List<GetAllProductsResponse> products)
    {
        return new List<GetAllProductsResponse>();
    }
    
    public GetProductByIdResponse ToGetByIdProductResponse(Product product)
    {
        return new GetProductByIdResponse()
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            CreatedAt = product.CreatedAt,
            UpdatedAt = product.UpdatedAt,
            DeletedAt = product.DeletedAt,
            OpenedAt = product.OpenedAt,
            ClosedAt = product.ClosedAt,
        };
    }
    
    public CreateProductResponse ToAddProductResponse(CreateProductResponse product)
    {
        return new CreateProductResponse()
        {
            Id = product.Id,
        };
    }
    
    public UpdateProductResponse ToUpdateProductResponse(Product product)
    {
        return new UpdateProductResponse()
        {
            Id = product.Id,
        };
    }
    
    public DeleteProductResponse ToDeleteProductResponse(Product product)
    {
        return new DeleteProductResponse() {};
    }
}