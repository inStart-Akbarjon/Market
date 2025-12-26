using Market.Contracts.Models.Product.Response;
using MediatR;

namespace Market.Application.CQRS.Product.Commands.UpdateProduct;

public record UpdateProductCommand(
    int Id, 
    string Title, 
    string? Description, 
    double Price, 
    int Quantity,
    int? OpenedAt, 
    int? ClosedAt
) : IRequest<UpdateProductResponse>
{
}