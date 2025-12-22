using Market.Application.CQRS.Product.Commands.CreateProduct;
using Market.Application.CQRS.Product.Commands.DeleteProduct;
using Market.Application.CQRS.Product.Commands.UpdateProduct;
using Market.Application.CQRS.Product.Queries.GetAllProducts;
using Market.Application.CQRS.Product.Queries.GetProductById;
using Market.Contracts.Models.Product.Response;
using Market.Contracts.Models.Product.Request;
using MagicOnion.Server;
using MagicOnion;
using Grpc.Core;
using Market.Contracts.Interfaces.Services;
using MediatR;

namespace Market.API.Services;

public class ProductService(IMediator mediator) : ServiceBase<IProductService>, IProductService
{
    public async UnaryResult<List<GetAllProductsResponse>> GetAllProducts(GetAllProductRequest request)
    {
         var query = new GetAllProductsQuery(request.PageNumber, request.PageSize);
         var products = await mediator.Send(query);
         return products;
    }

    public async UnaryResult<GetProductByIdResponse?> GetProductById(GetProductByIdRequest request)
    {
         var query = new GetByIdProductQuery(request.Id);
         var res = await mediator.Send(query);
         return res ?? throw new RpcException(new Status(StatusCode.NotFound,$"Product with id {request.Id} not found"));
    }

    public async UnaryResult<CreateProductResponse> CreateProduct(CreateProductRequest request)
    {
        var command = new CreateProductCommand(request.Title, request.Description, request.Price, request.OpenedAt, request.ClosedAt);
        var res = await mediator.Send(command);
        return res;
    }

    public async UnaryResult<UpdateProductResponse> UpdateProduct(int id, UpdateProductRequest request)
    {
         var command = new UpdateProductCommand(id, request.Title, request.Description, request.Price, request.OpenedAt, request.ClosedAt);
         var res = await mediator.Send(command);
         return res ?? throw new RpcException(new Status(StatusCode.NotFound,$"Product with id {id} not found"));
    }

    public async UnaryResult<DeleteProductResponse> DeleteProduct(int id)
    {
         var command = new DeleteProductCommand(id);
         var res = await mediator.Send(command);
         return res ?? throw new RpcException(new Status(StatusCode.NotFound,$"Product with id {id} not found"));
    }
}