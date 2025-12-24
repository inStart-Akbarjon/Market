using Market.Application.Extensions.Pagination;
using Market.Contracts.Models.Product.Response;
using Market.Infrastructure.Data;
using MediatR;

namespace Market.Application.CQRS.Product.Queries.GetAllProducts;

public class GetAllProductsQueryHandler(AppDbContext context)
    : IRequestHandler<GetAllProductsQuery, PaginatedList<GetAllProductsResponse>>
{
    public async Task<PaginatedList<GetAllProductsResponse>> Handle(GetAllProductsQuery request,
        CancellationToken cancellationToken)
    {
        var products = await context.Products.Where(p => p.DeletedAt == null)
            .ToGetAllProductsResponse().PaginateAsync<GetAllProductsResponse>(request.PageNumber, request.PageSize,
                cancellationToken: cancellationToken);

        return products;
    }
}