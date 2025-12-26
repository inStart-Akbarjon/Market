using Market.Contracts.Models.Product.Response;
using MediatR;

namespace Market.Application.CQRS.Product.Commands.CreateProduct;

public record CreateProductCommand(
    string Title, 
    string? Description, 
    double Price,
    int Quantity,
    int? OpenedAt,
    int? ClosedAt
) : IRequest<CreateProductResponse> { }