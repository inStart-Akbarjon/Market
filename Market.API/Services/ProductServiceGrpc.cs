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
using Market.Contracts.Interfaces.GrpcServices;
using MediatR;

namespace Market.API.Services;

public class ProductServiceGrpc(IMediator mediator) : ServiceBase<IProductServiceGrpc>, IProductServiceGrpc
{
    public async UnaryResult<PaginatedList<GetAllProductsResponse>> GetAllProducts(GetAllProductRequest request)
    {
        var query = new GetAllProductsQuery(request.PageNumber, request.PageSize);
        var products = await mediator.Send(query);
        return products;
    }

    public async UnaryResult<GetProductByIdResponse?> GetProductById(GetProductByIdRequest request)
    {
        var query = new GetByIdProductQuery(request.Id);
        var res = await mediator.Send(query);
        return res;
    }

    public async UnaryResult<CreateProductResponse> CreateProduct(CreateProductRequest request)
    {
        var command = new CreateProductCommand(request.Title, request.Description, request.Price, request.Quantity,
            request.OpenedAt, request.ClosedAt);
        var res = await mediator.Send(command);
        return res;
    }

    public async UnaryResult<UpdateProductResponse> UpdateProduct(int id, UpdateProductRequest request)
    {
        var command = new UpdateProductCommand(id, request.Title, request.Description, request.Price, request.Quantity,
            request.OpenedAt, request.ClosedAt);
        var res = await mediator.Send(command);
        return res;
    }

    public async UnaryResult<DeleteProductResponse> DeleteProduct(int id)
    {
        var command = new DeleteProductCommand(id);
        var res = await mediator.Send(command);
        return res;
    }
}