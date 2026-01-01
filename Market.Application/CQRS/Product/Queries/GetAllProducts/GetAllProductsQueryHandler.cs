using Market.Application.Extensions.Pagination;
using Market.Application.Interfaces.AppDbContext;
using Market.Contracts.Models.Product.Response;
using MediatR;

namespace Market.Application.CQRS.Product.Queries.GetAllProducts;

public class GetAllProductsQueryHandler(IAppDbContext context)
    : IRequestHandler<GetAllProductsQuery, PaginatedList<GetAllProductsResponse>>
{
    public async Task<PaginatedList<GetAllProductsResponse>> Handle(
        GetAllProductsQuery request,
        CancellationToken cancellationToken
    ) {
        var products = await context.Products
            .Where(p => p.DeletedAt == null)
            .ToGetAllProductsResponse()
            .PaginateAsync(request.PageNumber, request.PageSize,
                cancellationToken: cancellationToken);
        
        return products;
    }
}