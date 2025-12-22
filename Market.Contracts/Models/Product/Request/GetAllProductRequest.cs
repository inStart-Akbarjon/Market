using MessagePack;

namespace Market.Contracts.Models.Product.Request;

[MessagePackObject]
public class GetAllProductRequest
{
    [Key(0)]public int PageNumber { get; set; }
    [Key(1)]public int PageSize { get; set; }
}