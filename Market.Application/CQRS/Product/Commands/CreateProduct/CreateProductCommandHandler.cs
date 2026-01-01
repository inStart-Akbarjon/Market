using Market.Contracts.Models.Product.Response;
using Market.Application.Interfaces.Mappers;
using FluentValidation;
using Market.Application.Exceptions.Product;
using Market.Application.Interfaces.AppDbContext;
using MediatR;

namespace Market.Application.CQRS.Product.Commands.CreateProduct;

public class CreateProductCommandHandler(
    IAppDbContext context, 
    IProductServiceMappers productServiceMappers, 
    IValidator<CreateProductCommand> validator
    ) : IRequestHandler<CreateProductCommand, CreateProductResponse>
{
    public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            foreach (var failure in validationResult.Errors)
            {
                throw new InvalidRequestException(failure.ErrorMessage);
            }
        }
        
        var product = productServiceMappers.ToProductEntity(request);

        await context.Products.AddAsync(product, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        
        return productServiceMappers.ToAddProductResponse(product);
    }
}