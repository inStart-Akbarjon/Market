using Market.Application.Commands.CreateProduct;
using Market.Application.Commands.DeleteProduct;
using Market.Application.Commands.UpdateProduct;
using Market.Application.DTOs.Request.Product;
using Market.Application.Queries.GetAllProducts;
using Market.Application.Queries.GetProductById;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;

namespace Market.API.gRPCServices; 

public class ProductGrpcService : Product.ProductBase
{
    private readonly IMediator _mediator;

    public ProductGrpcService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override async Task<CreateProductResponse> CreateProduct(CreateProductRequest request,
        ServerCallContext context)
    {
        var product = new AddProductRequest
        {
            Title = request.Title,
            Description = request.Description,
            Price = request.Price
        };

        var command = new CreateProductCommand(product);
        var res = await _mediator.Send(command);

        return await Task.FromResult(new CreateProductResponse()
        {
            Title = res.Title,
            Description = res.Description,
            Price = res.Price
        });
    }

    public override async Task<GetAllProductsResponse> GetAllProducts(
        GetAllProductsRequest request,
        ServerCallContext context)
    {
        var query = new GetAllProductsQuery();
        var products = await _mediator.Send(query);
        var response = new GetAllProductsResponse();

        foreach (var item in products)
        {
            response.Id = item.Id;
            response.Title = item.Title;
            response.Description = item.Description;
            response.Price = item.Price;
            response.CreatedAt = Timestamp.FromDateTime(item.CreatedAt.ToUniversalTime());
        }
        
        return response;
    }

    public override async Task<GetProductByIdResponse> GetProductById(GetProductByIdRequest request, ServerCallContext context)
    {
        var query = new GetByIdProductQuery(request.Id);
        var res = await _mediator.Send(query);
        return await Task.FromResult(new GetProductByIdResponse()
        {
            Id = res.Id,
            Title = res.Title,
            Description = res.Description,
            Price = res.Price,
            CreatedAt = Timestamp.FromDateTime(res.CreatedAt.ToUniversalTime()),
        });
    }

    public async override Task<UpdateProductResponse> UpdateProduct(UpdateProductRequest request, ServerCallContext context)
    {
        var command = new UpdateProductCommand(new Application.DTOs.Request.Product.UpdateProductRequest()
        {
            Title =  request.Title,
            Description = request.Description,
            Price = request.Price
        });
        
        var res = await _mediator.Send(command);
        return await Task.FromResult(new UpdateProductResponse()
        {
            Id = res.Id,
            Title = res.Title,
            Description = res.Description,
            Price = res.Price,
            CreatedAt = Timestamp.FromDateTime(res.CreatedAt.ToUniversalTime())
        });
    }

    public async override Task<DeleteProductResponse> DeleteProduct(DeleteProductRequest request,
        ServerCallContext context)
    {
        var command = new DeleteProductCommand(request.Id);
        var res = await _mediator.Send(command);
        return await Task.FromResult(new DeleteProductResponse());
    }
}