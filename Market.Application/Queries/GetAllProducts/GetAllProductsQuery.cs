using Market.Application.DTOs.Response.Product;
using MediatR;

namespace Market.Application.Queries.GetAllProducts;

public class GetAllProductsQuery : IRequest<List<GetAllProductsResponse>>
{
    
}