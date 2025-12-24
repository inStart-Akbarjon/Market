using Market.Contracts.Models.Product.Response;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Extensions.Pagination;

public static class IQueryableExtension
{
    public static async Task<PaginatedList<T>> PaginateAsync<T>(this IQueryable<T> queryable, int pageNumber,
        int pageSize, CancellationToken cancellationToken = default)
    {
        var totalCount = await queryable.CountAsync(cancellationToken);
        
        var paginatedItems = await queryable.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);

        return new PaginatedList<T>()
        {
            Items = paginatedItems,
            PageNumber = pageNumber + 1,
            PageSize = pageSize,
            HasNextPage = totalCount > pageSize,
        };
    }

    public static IQueryable<GetAllProductsResponse> ToGetAllProductsResponse(this IQueryable<Domain.Models.Product.Product> queryable)
    {
        var allProductsResponses = queryable.Select(x =>
            new GetAllProductsResponse()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Price = x.Price,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                DeletedAt = x.DeletedAt,
                OpenedAt = x.OpenedAt,
                ClosedAt = x.ClosedAt,
            });
        
        return allProductsResponses;
    }
}