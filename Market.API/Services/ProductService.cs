using Grpc.Core;
using Market.Application.Commands.CreateProduct;
using Market.Application.Commands.DeleteProduct;
using Market.Application.Commands.UpdateProduct;
using Market.Application.DTOs.Request.Product;
using Market.Application.Mappers;
using Market.Application.Queries.GetAllProducts;
using Market.Application.Queries.GetProductById;
using Market.Contracts.Interfaces.Services;
using Market.Contracts.Models.Request;
using Market.Contracts.Models.Response;
using MediatR;
using DeleteProductRequest = Market.Contracts.Models.Request.DeleteProductRequest;
using DeleteProductResponse = Market.Contracts.Models.Response.DeleteProductResponse;
using UpdateProductRequest = Market.Contracts.Models.Request.UpdateProductRequest;
using UpdateProductResponse = Market.Contracts.Models.Response.UpdateProductResponse;

namespace Market.API.Services;

public class ProductService : IProductService
{
    private readonly IMediator _mediator;

    public ProductService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<List<GetProductResponse>> GetProduct(GetProductRequest request)
    {
         var query = new GetAllProductsQuery();
         var products = await _mediator.Send(query);
         var response = products.Select(p => new GetProductResponse()
         {
             Id = p.Id,
             Title = p.Title,
             Description = p.Description,
             Price = p.Price,
             CreatedAt = p.CreatedAt
         }).ToList();
         
         return response;
    }

    public async Task<GetProductByIdResponse> GetProductById(GetProductByIdRequest request)
    {
         var query = new GetByIdProductQuery(request.Id);
         var res = await _mediator.Send(query);

         if (res == null)
         {
             throw new RpcException(new Status(StatusCode.NotFound,$"Product with id {request.Id} not found"));
         }

         return new GetProductByIdResponse()
         {
             Id = res.Id,
             Title = res.Title,
             Description = res.Description,
             Price = res.Price,
             CreatedAt = res.CreatedAt
         };
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

    public async Task<UpdateProductResponse> UpdateProduct(UpdateProductRequest request)
    {
         var product = new Domain.Models.Product()
         {
             Id = request.Id,
             Title = request.Title,
             Description = request.Description,
             Price = request.Price,
         };
         
         var command = new UpdateProductCommand(product);
         
         var res = await _mediator.Send(command);

         if (res == null)
         {
             throw new RpcException(new Status(StatusCode.NotFound,$"Product with id {request.Id} not found"));
         }
         else
         {
             return await Task.FromResult(new UpdateProductResponse()
             {
                 Id = res.Id,
                 Title = res.Title,
                 Description = res.Description,
                 Price = res.Price,
                 CreatedAt = res.CreatedAt,
             });
         }
         
    }

    public async Task<DeleteProductResponse> DeleteProduct(DeleteProductRequest request)
    {
         var command = new DeleteProductCommand(request.Id);
         var res = await _mediator.Send(command);

         if (res == null)
         {
             throw new RpcException(new Status(StatusCode.NotFound,$"Product with id {request.Id} not found"));
         }
         
         return await Task.FromResult(new DeleteProductResponse() {});
    }
}