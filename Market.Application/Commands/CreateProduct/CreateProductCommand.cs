using Market.Application.DTOs.Response.Product;
using Market.Domain.Models;
using MediatR;

namespace Market.Application.Commands.CreateProduct;

public class CreateProductCommand : IRequest<AddProductResponse>
{
    public Product _product { get; set; }
    
    public CreateProductCommand(Product product)
    {
        _product = product;
    }
}