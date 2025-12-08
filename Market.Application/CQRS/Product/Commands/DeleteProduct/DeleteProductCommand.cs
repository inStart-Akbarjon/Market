using Market.Contracts.Models.Product.Response;
using MediatR;

namespace Market.Application.CQRS.Product.Commands.DeleteProduct;

public record DeleteProductCommand(int id) : IRequest<DeleteProductResponse>
{
}