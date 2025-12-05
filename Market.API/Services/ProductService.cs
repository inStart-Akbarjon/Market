using DeleteProductResponse = Market.Contracts.Models.Response.DeleteProductResponse;
using UpdateProductResponse = Market.Contracts.Models.Response.UpdateProductResponse;
using UpdateProductRequest = Market.Contracts.Models.Request.UpdateProductRequest;
using DeleteProductRequest = Market.Contracts.Models.Request.DeleteProductRequest;
using Market.Application.Mappers.ServiceMappers;
using Market.Application.Commands.CreateProduct;
using Market.Application.Commands.DeleteProduct;
using Market.Application.Commands.UpdateProduct;
using Market.Application.Queries.GetAllProducts;
using Market.Application.Queries.GetProductById;
using Market.Application.DTOs.Request.Product;
using Market.Contracts.Interfaces.Services;
using Market.Contracts.Models.Response;
using Market.Contracts.Models.Request;
using Market.Application.Mappers;
using Grpc.Core;
using MediatR;

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
         
         return ProductServiceMappers.ToGetProductsResponse(products);
    }

    public async Task<GetProductByIdResponse> GetProductById(GetProductByIdRequest request)
    {
         var query = new GetByIdProductQuery(request.Id);
         var res = await _mediator.Send(query);

         if (res == null)
         {
             throw new RpcException(new Status(StatusCode.NotFound,$"Product with id {request.Id} not found"));
         }

         return ProductServiceMappers.ToGetByIdProductResponse(res);
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

        return ProductServiceMappers.ToAddProductResponse(res);
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
        
         return ProductServiceMappers.ToUpdateProductResponse(res);
         
    }

    public async Task<DeleteProductResponse> DeleteProduct(DeleteProductRequest request)
    {
         var command = new DeleteProductCommand(request.Id);
         var res = await _mediator.Send(command);

         if (res == null)
         {
             throw new RpcException(new Status(StatusCode.NotFound,$"Product with id {request.Id} not found"));
         }
         
         return ProductServiceMappers.ToDeleteProductResponse(res);
    }
}