using MessagePack;

namespace Market.Contracts.Models.Product.Request;

[MessagePackObject]
public class CreateProductRequest
{
    [Key(0)] public string Title { get; set; }
    [Key(1)] public string? Description { get; set; }
    [Key(2)] public double Price { get; set; }
    [Key(3)] public DateTime? OpenedAt { get; set; }
    [Key(4)] public DateTime? ClosedAt { get; set; }
}