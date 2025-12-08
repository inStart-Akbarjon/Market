using Market.Application.Interfaces.Repositories;
using Market.Contracts.Models.Product.Response;
using MediatR;

namespace Market.Application.CQRS.Product.Commands.UpdateProduct;

public class UpdateProductCommandHandler(IProductRepository productRepository)
    : IRequestHandler<UpdateProductCommand, UpdateProductResponse>
{
    public async Task<UpdateProductResponse?> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.id, cancellationToken);

        if (product == null)
        {
            return null;
        }
        
        product.Title = request.Title;
        product.Description = request.Description;
        product.Price = request.Price;
        
        productRepository.UpdateAsync(product, cancellationToken);
        await productRepository.SaveChangesAsync(cancellationToken);
        
        return new UpdateProductResponse()
        {
            Id = product.Id,
        };
    }
}