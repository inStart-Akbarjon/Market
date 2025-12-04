using Market.Application.DTOs.Request.Product;
using Market.Application.DTOs.Response.Product;
using Market.Domain.Models;

namespace Market.Application.Mappers;

public static class ProductMappers
{
    public static GetAllProductsRequest ToGetAllProductsRequest(Product product)
    {
        return new GetAllProductsRequest{};
    }

    public static List<GetAllProductsResponse> ToGetAllProductsResponse(List<Product> products)
    {
        return products.Select(product => new GetAllProductsResponse()
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            CreatedAt = product.CreatedAt
        }).ToList();
    }

    public static GetByIdProdductRequest ToGetByIdProductRequest(Product product)
    {
        return new GetByIdProdductRequest()
        {
            Id = product.Id,
        };
    }

    public static GetByIdProductResponse ToGetByIdProductResponse(Product product)
    {
        return new GetByIdProductResponse()
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            CreatedAt = product.CreatedAt,
        };
    }

    public static AddProductRequest ToAddProductRequest(Product product)
    {
        return new AddProductRequest()
        {
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
        };
    }

    public static AddProductResponse ToAddProductResponse(Product product)
    {
        return new AddProductResponse()
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            CreatedAt = product.CreatedAt,
        };
    }

    public static Product ToAddProductEntity(AddProductRequest product)
    {
        return new Product()
        {
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
        };
    }

    public static UpdateProductRequest ToUpdateProductRequest(Product product)
    {
        return new UpdateProductRequest()
        {
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
        };
    }

    public static UpdateProductResponse ToUpdateProductResponse(Product product)
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
    
    public static Product ToUpdateProductEntity(UpdateProductRequest product)
    {
        return new Product()
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            CreatedAt = product.CreatedAt,
        };
    }

    public static DeleteProductRequest ToDeleteProductRequest(Product product)
    {
        return new DeleteProductRequest()
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            CreatedAt = product.CreatedAt,
        };
    }

    public static DeleteProductResponse ToDeleteProductResponse(Product product)
    {
        return new DeleteProductResponse()
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            CreatedAt = product.CreatedAt,
        };
    }
}