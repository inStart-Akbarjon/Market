using Market.Application.DTOs.Response.Product;
using Market.Application.Interfaces.Repositories;
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
        var product = await _productRepository.GetByIdAsync(request.);

        _productRepository.UpdateAsync(new Product()
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            CreatedAt =  product.CreatedAt,
        });

        await _productRepository.SaveChangesAsync();
        return new UpdateProductResponse();
    }
}