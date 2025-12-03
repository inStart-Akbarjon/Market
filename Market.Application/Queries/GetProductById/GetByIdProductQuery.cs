using Market.Application.DTOs.Response.Product;
using MediatR;

namespace Market.Application.Queries.GetProductById;

public class GetByIdProductQuery : IRequest<GetByIdProductResponse>
{
    public int  Id { get; set; }
    public GetByIdProductQuery(int id)
    {
        Id = id;
    }
}