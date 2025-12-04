using MessagePack;

namespace Market.Contracts.Models.Request;

[MessagePackObject]
public class CreateProductRequest
{
    [Key(0)] public string Title { get; set; }
    [Key(1)] public string Description { get; set; }
    [Key(2)] public double Price { get; set; }
}