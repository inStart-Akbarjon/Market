using Market.Contracts.Models.Product.Response;
using MediatR;

namespace Market.Application.CQRS.Product.Queries.GetAllProducts;

public class GetAllProductsQuery(int PageNumber, int PageSize) : IRequest<List<GetAllProductsResponse>>
{
    
}