using Market.Contracts.Models.Product.Response;
using Market.Application.Interfaces.Mappers;
using Microsoft.EntityFrameworkCore;
using Market.Infrastructure.Data;
using MediatR;

namespace Market.Application.CQRS.Product.Queries.GetProductById;

public class GetByIdProductQueryHandler(AppDbContext context, IProductServiceMappers productMappers)
    : IRequestHandler<GetByIdProductQuery, GetProductByIdResponse?>
{
    public async Task<GetProductByIdResponse?> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
    {
        var product = await context.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == request.Id && p.DeletedAt == null, cancellationToken);

        return product == null ? null : productMappers.ToGetByIdProductResponse(product);
    }
}