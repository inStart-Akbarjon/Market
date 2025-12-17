using Market.Contracts.Models.Product.Response;
using Market.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.CQRS.Product.Commands.DeleteProduct;

public class DeleteProductCommandHandler(AppDbContext context)
    : IRequestHandler<DeleteProductCommand, DeleteProductResponse>
{
    public async Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await context.Products.FirstOrDefaultAsync(p => p.Id == request.id, cancellationToken);

        if (product == null)
        {
            return null;
        }
        
        product.DeletedAt = DateTime.UtcNow;
        await context.SaveChangesAsync(cancellationToken);
        
        return new  DeleteProductResponse()
        {
            Id = product.Id,
        };
    }
}