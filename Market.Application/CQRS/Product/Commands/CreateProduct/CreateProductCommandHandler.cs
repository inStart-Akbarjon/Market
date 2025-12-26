using Market.Contracts.Models.Product.Response;
using Market.Application.Interfaces.Mappers;
using Market.Infrastructure.Data;
using FluentValidation;
using MediatR;

namespace Market.Application.CQRS.Product.Commands.CreateProduct;

public class CreateProductCommandHandler(AppDbContext context, IProductServiceMappers productServiceMappers, IValidator<CreateProductCommand> validator)
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