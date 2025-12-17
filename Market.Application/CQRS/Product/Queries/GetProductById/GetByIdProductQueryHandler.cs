using Market.Application.Interfaces.Mappers;
using Market.Contracts.Models.Product.Response;
using Market.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.CQRS.Product.Queries.GetProductById;

public class GetByIdProductQueryHandler(AppDbContext context, IProductServiceMappers productMappers) : IRequestHandler<GetByIdProductQuery, GetProductByIdResponse?>
{
    public async Task<GetProductByIdResponse?> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
    {
        var product = await context.Products.Where(p => p.DeletedAt == null).FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);;
        
        return product == null ? null : productMappers.ToGetByIdProductResponse(product);
    }
}