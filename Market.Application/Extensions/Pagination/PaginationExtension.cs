using Market.Contracts.Models.Product.Response;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Extensions.Pagination;

public static class PaginationExtension
{
    public static async Task<PaginatedList<T>> PaginateAsync<T>(
        this IQueryable<T> queryable, 
        int pageNumber = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var paginatedItems =
            await queryable
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

        return new PaginatedList<T>()
        {
            Items = paginatedItems,
            PageNumber = pageNumber + 1,
            PageSize = pageSize,
            HasNextPage = paginatedItems.Count == pageSize,
        };
    }

    public static IQueryable<GetAllProductsResponse> ToGetAllProductsResponse(
        this IQueryable<Domain.Entities.Product.Product> queryable)
    {
        var allProductsResponses = queryable.Select(x =>
            new GetAllProductsResponse()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Price = x.Price,
                Quantity = x.Quantity,
                OpenedAt = x.OpenedAt,
                ClosedAt = x.ClosedAt,
            });

        return allProductsResponses;
    }
}