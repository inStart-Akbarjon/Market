using MessagePack;

namespace Market.Contracts.Models.Product.Request;

[MessagePackObject]
public class GetProductByIdRequest
{
    [Key(0)] public int Id { get; set; }
}