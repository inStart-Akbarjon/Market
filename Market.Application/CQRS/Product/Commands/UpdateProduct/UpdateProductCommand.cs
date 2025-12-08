using Market.Contracts.Models.Product.Response;
using MediatR;

namespace Market.Application.CQRS.Product.Commands.UpdateProduct;

public record UpdateProductCommand(int id, string Title, string? Description, double Price) : IRequest<UpdateProductResponse>
{
}