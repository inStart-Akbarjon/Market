using Market.Application.Interfaces.Repositories;
using Market.Application.DTOs.Response.Product;
using Microsoft.EntityFrameworkCore;
using Market.Application.Mappers;
using MediatR;

namespace Market.Application.Queries.GetAllProducts;

public class GetAllProductsQueryHandler()
    : IRequestHandler<GetAllProductsQuery, List<GetAllProductsResponse>>
{
    private readonly IProductRepository _productRepository;
    
    public GetAllProductsQueryHandler(IProductRepository productRepository) : this()
    {
        _productRepository = productRepository;
    }
    
    public async Task<List<GetAllProductsResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAll().ToListAsync();
        var response = ProductMappers.ToGetAllProductsResponse(products);
        
        return response;
    }
}