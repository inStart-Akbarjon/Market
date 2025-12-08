using Market.Contracts.Models.Product.Response;
using MediatR;

namespace Market.Application.CQRS.Product.Queries.GetProductById;

public record GetByIdProductQuery(int Id) : IRequest<GetProductByIdResponse>
{
}