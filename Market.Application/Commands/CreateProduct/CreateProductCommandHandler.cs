using Market.Application.DTOs.Response.Product;
using Market.Application.Interfaces.Repositories;
using MediatR;

namespace Market.Application.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, AddProductResponse>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<AddProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await _productRepository.CreateAsync(request._product);
        return new AddProductResponse();
    }
}