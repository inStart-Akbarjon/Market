using Market.Application.DTOs.Response.Product;
using Market.Contracts.Models.Response;
using Market.Domain.Models;
using DeleteProductResponse = Market.Contracts.Models.Response.DeleteProductResponse;
using UpdateProductResponse = Market.Contracts.Models.Response.UpdateProductResponse;

namespace Market.Application.Mappers.ServiceMappers;

public class ProductServiceMappers
{
    public static List<GetProductResponse> ToGetProductsResponse(List<GetAllProductsResponse> products)
    {
        return products.Select(product => new GetProductResponse()
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            CreatedAt = product.CreatedAt
        }).ToList();
    }
    
    public static GetProductByIdResponse ToGetByIdProductResponse(GetByIdProductResponse product)
    {
        return new GetProductByIdResponse()
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            CreatedAt = product.CreatedAt,
        };
    }
    
    public static CreateProductResponse ToAddProductResponse(AddProductResponse product)
    {
        return new CreateProductResponse()
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            CreatedAt = product.CreatedAt,
        };
    }
    
    public static UpdateProductResponse ToUpdateProductResponse(Market.Application.DTOs.Response.Product.UpdateProductResponse product)
    {
        return new UpdateProductResponse()
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            CreatedAt = product.CreatedAt,
        };
    }
    
    public static DeleteProductResponse ToDeleteProductResponse(Market.Application.DTOs.Response.Product.DeleteProductResponse product)
    {
        return new DeleteProductResponse() {};
    }
}