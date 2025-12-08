using Market.Application.Interfaces.Repositories;
using Market.Contracts.Models.Product.Response;
using MediatR;

namespace Market.Application.CQRS.Product.Commands.DeleteProduct;

public class DeleteProductCommandHandler(IProductRepository productRepository)
    : IRequestHandler<DeleteProductCommand, DeleteProductResponse>
{
    public async Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.id, cancellationToken);

        if (product == null)
        {
            return null;
        }
        
        product.DeletedAt = DateTime.UtcNow;
        await productRepository.SaveChangesAsync(cancellationToken);
        
        return new  DeleteProductResponse()
        {
            Id = product.Id,
        };
    }
}