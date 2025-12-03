// using Market.Application.Commands.CreateProduct;
// using Market.Application.Commands.DeleteProduct;
// using Market.Application.DTOs.Request.Product;
// using Market.Application.DTOs.Response.Product;
// using Market.Application.Queries.GetAllProducts;
// using Market.Application.Queries.GetProductById;
// using MediatR;
// using Microsoft.AspNetCore.Mvc;
//
// namespace Market.API.Controllers;
//
// [ApiController]
// [Route("api/[controller]")]
//
// public class ProductController : ControllerBase
// {
//     private readonly ILogger<ProductController> _logger;
//     private readonly IMediator _mediator;
//     
//     public ProductController(ILogger<ProductController> logger,  IMediator mediator)
//     {
//         _logger = logger;
//         _mediator = mediator;
//     }
//
//     // [HttpGet]
//     // public async Task<ActionResult<List<GetAllProductsResponse>>> GetProducts()
//     // {
//     //     var query = new GetAllProductsQuery();
//     //     var res = await _mediator.Send(query);
//     //     return res;
//     // }
//
//     [HttpGet("{id}")]
//     public async Task<ActionResult<GetByIdProductResponse>> GetProduct(int id)
//     {
//         var query = new GetByIdProductQuery(id);
//         var res = await _mediator.Send(query);
//         return res;
//     }
//     
//     [HttpPost]
//     public async Task<AddProductResponse> CreateProduct(AddProductRequest product)
//     {
//         var command = new CreateProductCommand(product);
//         var res = await _mediator.Send(command);
//         return res;
//     }
//
//     [HttpDelete("{id}")]
//     public async Task<ActionResult<DeleteProductResponse>> DeleteProduct(int id)
//     {
//         var command = new DeleteProductCommand(id);
//         var res = await _mediator.Send(command);
//         return res;
//     }
// }