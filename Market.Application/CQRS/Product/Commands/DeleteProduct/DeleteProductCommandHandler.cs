using Market.Application.Interfaces.Mappers;
using Market.Contracts.Models.Product.Response;
using Market.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.CQRS.Product.Commands.DeleteProduct;

public class DeleteProductCommandHandler(AppDbContext context, IProductServiceMappers productServiceMappers)
    : IRequestHandler<DeleteProductCommand, DeleteProductResponse?>
{
    public async Task<DeleteProductResponse?> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await context.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (product == null)
        {
            return null;
        }

        product.SoftDelete();
        
        await context.SaveChangesAsync(cancellationToken);
        
        return productServiceMappers.ToDeleteProductResponse(product);
    }
}