using Market.Application.Exceptions.Product;
using Market.Application.Interfaces.AppDbContext;
using Market.Application.Interfaces.Mappers;
using Market.Contracts.Models.Product.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.CQRS.Product.Commands.DeleteProduct;

public class DeleteProductCommandHandler(
    IAppDbContext context, 
    IProductServiceMappers productServiceMappers
    ) : IRequestHandler<DeleteProductCommand, DeleteProductResponse?>
{
    public async Task<DeleteProductResponse?> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await context.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (product is null)
        {
            throw new NotFoundException(request.Id);
        }

        product.SoftDelete();
        
        await context.SaveChangesAsync(cancellationToken);
        
        return productServiceMappers.ToDeleteProductResponse(product);
    }
}