using FluentValidation;
using Market.Application.Exceptions.Product;
using Market.Application.Interfaces.AppDbContext;
using Market.Application.Interfaces.Mappers;
using Market.Contracts.Models.Product.Response;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Market.Application.CQRS.Product.Commands.UpdateProduct;

public class UpdateProductCommandHandler(
    IAppDbContext context, 
    IProductServiceMappers productServiceMappers,
    IValidator<UpdateProductCommand> validator
) : IRequestHandler<UpdateProductCommand, UpdateProductResponse?>
{
    public async Task<UpdateProductResponse?> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            foreach (var failure in validationResult.Errors)
            {
                throw new InvalidRequestException(failure.ErrorMessage);
            }
        }
        
        var product = await context.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        
        if (product is null)
        {
            throw new NotFoundException(request.Id);
        }
        
        var sameProduct = await context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Title == request.Title, cancellationToken: cancellationToken);

        if (sameProduct != null)
        {
            throw new InvalidRequestException("Title", $"{request.Title}");
        }
        
        product.Title = request.Title;
        product.Description = request.Description;
        product.Price = request.Price;
        product.Quantity = request.Quantity;
        product.OpenedAt = request.OpenedAt;
        product.ClosedAt = request.ClosedAt;
        
        await context.SaveChangesAsync(cancellationToken);
        
        return productServiceMappers.ToUpdateProductResponse(product);
    }
}