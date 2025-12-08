using MessagePack;

namespace Market.Contracts.Models.Product.Response;

[MessagePackObject]
public class UpdateProductResponse
{
    [Key(0)] public int Id { get; set; }
}