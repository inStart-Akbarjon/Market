using Market.Application.Interfaces.Mappers;
using Market.Application.Interfaces.Repositories;
using Market.Contracts.Models.Product.Response;
using MediatR;

namespace Market.Application.CQRS.Product.Queries.GetProductById;

public class GetByIdProductQueryHandler(IProductRepository productRepository, IProductServiceMappers productMappers) : IRequestHandler<GetByIdProductQuery, GetProductByIdResponse>
{
    public async Task<GetProductByIdResponse?> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.Id, cancellationToken);
        
        return product == null ? null : productMappers.ToGetByIdProductResponse(product);
    }
}