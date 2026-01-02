using Market.Application.Interfaces.AppDbContext;
using Market.Contracts.Models.Product.Response;
using Market.Application.Interfaces.Mappers;
using Market.Application.Exceptions.Product;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Market.Application.CQRS.Product.Queries.GetProductById;

public class GetByIdProductQueryHandler(
    IAppDbContext context, 
    IProductServiceMappers productMappers
    ) : IRequestHandler<GetByIdProductQuery, GetProductByIdResponse?>
{
    public async Task<GetProductByIdResponse?> Handle(
        GetByIdProductQuery request, 
        CancellationToken cancellationToken
    ) {
        var product = await context.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == request.Id && p.DeletedAt == null, cancellationToken);

        if (product is null)
        {
            throw new NotFoundException(request.Id);
        }
        
        return productMappers.ToGetByIdProductResponse(product);
    }
}