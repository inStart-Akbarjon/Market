using Market.Application.DTOs.Response.Product;
using Market.Application.Interfaces.Repositories;
using MediatR;

namespace Market.Application.Queries.GetProductById;

public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, GetByIdProductResponse>
{
    private readonly IProductRepository _productRepository;

    public GetByIdProductQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<GetByIdProductResponse> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);
        return product;
    }
}