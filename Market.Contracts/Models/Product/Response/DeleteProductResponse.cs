using MessagePack;

namespace Market.Contracts.Models.Product.Response;
[MessagePackObject]
public class DeleteProductResponse
{
    [Key(0)] public int Id { get; set; }
}