using Market.Application.Interfaces.Repositories;
using Market.Contracts.Models.Product.Response;
using MediatR;

namespace Market.Application.CQRS.Product.Commands.CreateProduct;

public class CreateProductCommandHandler(IProductRepository productRepository)
    : IRequestHandler<CreateProductCommand, CreateProductResponse>
{
    public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Domain.Models.Product()
        {
            Title = request.Title,
            Description = request.Description,
            Price = request.Price,
            OpenedAt = request.OpenedAt,
            ClosedAt = request.ClosedAt
        };
        
        await productRepository.CreateAsync(product, cancellationToken);
        await productRepository.SaveChangesAsync(cancellationToken);
        
        return new CreateProductResponse()
        {
            Id = product.Id
        };
    }
}