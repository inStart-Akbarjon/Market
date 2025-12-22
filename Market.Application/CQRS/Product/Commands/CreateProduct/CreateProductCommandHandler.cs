using Market.Application.Interfaces.Mappers;
using Market.Contracts.Models.Product.Response;
using Market.Infrastructure.Data;
using MediatR;

namespace Market.Application.CQRS.Product.Commands.CreateProduct;

public class CreateProductCommandHandler(AppDbContext context, IProductServiceMappers productServiceMappers)
    : IRequestHandler<CreateProductCommand, CreateProductResponse>
{
    public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = productServiceMappers.ToProductEntity(request);
        
        await context.Products.AddAsync(product, cancellationToken);
        
        await context.SaveChangesAsync(cancellationToken);
        
        return productServiceMappers.ToAddProductResponse(product);
    }
}