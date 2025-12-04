using Market.Application.DTOs.Response.Product;
using Market.Application.Interfaces.Repositories;
using Market.Application.Mappers;
using Market.Domain.Models;
using MediatR;

namespace Market.Application.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductResponse>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<UpdateProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);

        if (product == null)
        {
            return null;
        }
        else
        {
            product.Id = request.Id;
            product.Title = request.Title;
            product.Description = request.Description;
            product.Price = request.Price;
            product.CreatedAt = request.CreatedAt;
            
            _productRepository.UpdateAsync(product);
            await _productRepository.SaveChangesAsync();
            
            return ProductMappers.ToUpdateProductResponse(product);
        }

    }
}