using Market.Application.DTOs.Request.Product;
using Market.Application.DTOs.Response.Product;
using MediatR;

namespace Market.Application.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest<DeleteProductResponse>
{
    public int _id  { get; set; }
    
    public DeleteProductCommand(int id)
    {
        _id = id;
    }
}