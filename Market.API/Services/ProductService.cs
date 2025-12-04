using Google.Protobuf.WellKnownTypes;
using Market.Application.Commands.CreateProduct;
using Market.Application.DTOs.Request.Product;
using Market.Application.Mappers;
using Market.Contracts.Interfaces.Services;
using Market.Contracts.Models.Request;
using Market.Contracts.Models.Response;
using MediatR;

namespace Market.API.Services;

public class ProductService : IProductService
{
    private readonly IMediator _mediator;

    public ProductService(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task<CreateProductResponse> CreateProduct(CreateProductRequest request)
    {
        var product = ProductMappers.ToAddProductEntity(new AddProductRequest()
        {
            Title = request.Title,
            Description = request.Description,
            Price = request.Price
        });
        
        var command = new CreateProductCommand(product);
        var res = await _mediator.Send(command);

        return await Task.FromResult(new CreateProductResponse()
        {
            Id = res.Id,
            Title = res.Title,
            Description = res.Description,
            Price = res.Price,
            CreatedAt = res.CreatedAt,
        });
    }
}