using MessagePack;

namespace Market.Contracts.Models.Product.Response;
[MessagePackObject]
public class CreateProductResponse
{
    [Key(0)] public int Id { get; set; }
    [Key(1)] public string Title { get; set; }
    [Key(2)] public string? Description { get; set; }
    [Key(3)] public double Price { get; set; }
    [Key(4)] public DateTime? OpenedAt { get; set; }
    [Key(5)] public DateTime? ClosedAt { get; set; }
}