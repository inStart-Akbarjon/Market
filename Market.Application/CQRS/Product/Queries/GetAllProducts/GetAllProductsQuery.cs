using Market.Contracts.Models.Product.Response;
using MediatR;

namespace Market.Application.CQRS.Product.Queries.GetAllProducts;

public class GetAllProductsQuery() : IRequest<List<GetAllProductsResponse>>
{
    
}