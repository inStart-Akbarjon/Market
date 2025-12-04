using Market.Application.DTOs.Response.Product;
using Market.Application.Interfaces.Repositories;
using Market.Application.Mappers;
using MediatR;

namespace Market.Application.Commands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, DeleteProductResponse>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request._id);

        if (product == null)
        {
            return null;
        }
        else
        {
            _productRepository.DeleteAsync(product);
            await _productRepository.SaveChangesAsync();
            return ProductMappers.ToDeleteProductResponse(product);
        }
        
    }
}