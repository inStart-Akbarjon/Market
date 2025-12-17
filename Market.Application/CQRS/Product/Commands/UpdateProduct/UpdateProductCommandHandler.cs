using Market.Contracts.Models.Product.Response;
using Market.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.CQRS.Product.Commands.UpdateProduct;

public class UpdateProductCommandHandler(AppDbContext context)
    : IRequestHandler<UpdateProductCommand, UpdateProductResponse?>
{
    public async Task<UpdateProductResponse?> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await context.Products.FirstOrDefaultAsync(p => p.Id == request.id, cancellationToken);
        
        if (product == null)
        {
            return null;
        }
        
        product.Title = request.Title;
        product.Description = request.Description;
        product.Price = request.Price;
        product.UpdatedAt = DateTime.UtcNow;
        product.OpenedAt = request.OpenedAt;
        product.ClosedAt = request.ClosedAt;
        
        context.Update(product);
        await context.SaveChangesAsync(cancellationToken);
        
        return new UpdateProductResponse()
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            OpenedAt = product.OpenedAt,
            ClosedAt = product.ClosedAt,
        };
    }
}