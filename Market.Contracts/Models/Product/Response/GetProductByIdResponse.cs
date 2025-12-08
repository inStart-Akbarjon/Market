using MessagePack;

namespace Market.Contracts.Models.Product.Response;

[MessagePackObject]
public class GetProductByIdResponse
{
    [Key(0)] public int Id { get; set; }
    [Key(1)] public string Title { get; set; }
    [Key(2)] public string? Description { get; set; }
    [Key(3)] public double Price { get; set; }
    [Key(4)] public DateTime CreatedAt { get; set; }
    [Key(5)] public DateTime? UpdatedAt { get; set; }
    [Key(6)] public DateTime? DeletedAt { get; set; }
    [Key(7)] public DateTime? OpenedAt { get; set; }
    [Key(8)] public DateTime? ClosedAt { get; set; }
}