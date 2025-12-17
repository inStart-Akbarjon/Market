using Market.Contracts.Models.Product.Response;
using Market.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.CQRS.Product.Queries.GetAllProducts;

public class GetAllProductsQueryHandler(AppDbContext context)
    : IRequestHandler<GetAllProductsQuery, List<GetAllProductsResponse>>
{
    public async Task<List<GetAllProductsResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = context.Products.Where(product => product.DeletedAt == null);
        
        return await products.Select(product => new GetAllProductsResponse()
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            CreatedAt = product.CreatedAt,
            UpdatedAt = product.UpdatedAt,
            DeletedAt = product.DeletedAt,
            OpenedAt =  product.OpenedAt,
            ClosedAt = product.ClosedAt,
        }).ToListAsync(cancellationToken);
    }
}