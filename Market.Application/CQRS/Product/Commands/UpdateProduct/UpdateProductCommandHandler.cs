using Market.Application.Interfaces.Mappers;
using Market.Application.Mappers.ServiceMappers;
using Market.Contracts.Models.Product.Response;
using Microsoft.EntityFrameworkCore;
using Market.Infrastructure.Data;
using MediatR;

namespace Market.Application.CQRS.Product.Commands.UpdateProduct;

public class UpdateProductCommandHandler(AppDbContext context, IProductServiceMappers productServiceMappers)
    : IRequestHandler<UpdateProductCommand, UpdateProductResponse?>
{
    public async Task<UpdateProductResponse?> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await context.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        
        if (product == null)
        {
            return null;
        }
        
        product.Title = request.Title;
        product.Description = request.Description;
        product.Price = request.Price;
        product.OpenedAt = request.OpenedAt;
        product.ClosedAt = request.ClosedAt;
        
        await context.SaveChangesAsync(cancellationToken);
        
        return productServiceMappers.ToUpdateProductResponse(product);
    }
}