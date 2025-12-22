using Market.Contracts.Models.Product.Response;
using MediatR;

namespace Market.Application.CQRS.Product.Commands.UpdateProduct;

public record UpdateProductCommand(int Id, string Title, string? Description, double Price, DateTime? OpenedAt, DateTime? ClosedAt) : IRequest<UpdateProductResponse>
{
}