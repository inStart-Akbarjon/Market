using Market.Application.CQRS.Product.Commands.CreateProduct;
using Market.Application.CQRS.Product.Commands.DeleteProduct;
using Market.Application.CQRS.Product.Commands.UpdateProduct;
using Market.Application.CQRS.Product.Queries.GetAllProducts;
using Market.Application.CQRS.Product.Queries.GetProductById;
using Market.Contracts.Models.Product.Request;
using Market.Contracts.Models.Product.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<List<GetAllProductsResponse>> GetAllProducts()
    {
        var query = new GetAllProductsQuery();
        var res = await mediator.Send(query);
        
        return res;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetProductByIdResponse>> GetProductById(int id)
    {
        var query = new GetByIdProductQuery(id);
        var res = await mediator.Send(query);
        return res;
    }

    [HttpPost]
    public async Task<ActionResult<CreateProductResponse>> CreateProduct(CreateProductRequest request)
    {
        var command = new CreateProductCommand(request.Title, request.Description, request.Price, request.OpenedAt, request.ClosedAt);
        var res = await mediator.Send(command);
        return res;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateProductResponse>> UpdateProduct(int id, UpdateProductRequest request)
    {
        var command = new UpdateProductCommand(id, request.Title, request.Description, request.Price, request.OpenedAt, request.ClosedAt);
        var res = await  mediator.Send(command);
        return res;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeleteProductResponse>> DeleteProduct(int id)
    {
        var command = new DeleteProductCommand(id);
        var res = await mediator.Send(command);
        return res;
    }
}