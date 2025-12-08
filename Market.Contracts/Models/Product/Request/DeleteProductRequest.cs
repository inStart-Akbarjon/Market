using MessagePack;

namespace Market.Contracts.Models.Product.Request;

[MessagePackObject]
public class DeleteProductRequest
{
    [Key(0)] public int Id { get; set; }
}