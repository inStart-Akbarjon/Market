using Market.Contracts.Models.Product.Response;
using Market.Infrastructure.Data;
using MediatR;

namespace Market.Application.CQRS.Product.Commands.CreateProduct;

public class CreateProductCommandHandler(AppDbContext context)
    : IRequestHandler<CreateProductCommand, CreateProductResponse>
{
    public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Domain.Models.Product.Product()
        {
            Title = request.Title,
            Description = request.Description,
            Price = request.Price,
            OpenedAt = request.OpenedAt,
            ClosedAt = request.ClosedAt
        };
        
        await context.Products.AddAsync(product, cancellationToken);
        
        await context.SaveChangesAsync(cancellationToken);
        
        return new CreateProductResponse()
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            OpenedAt = product.OpenedAt,
            ClosedAt = product.ClosedAt
        };
    }
}