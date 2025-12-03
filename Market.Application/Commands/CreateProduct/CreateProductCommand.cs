using Market.Application.DTOs.Request.Product;
using Market.Application.DTOs.Response.Product;
using MediatR;

namespace Market.Application.Commands.CreateProduct;

public class CreateProductCommand : IRequest<AddProductResponse>
{
    public AddProductRequest _product { get; set; }
    
    public CreateProductCommand(AddProductRequest product)
    {
        _product = product;
    }
}