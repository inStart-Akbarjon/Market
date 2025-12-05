using MessagePack;

namespace Market.Contracts.Models.Response;

[MessagePackObject]
public class GetProductResponse
{
    [Key(0)] public int Id { get; set; }
    [Key(1)] public string Title { get; set; }
    [Key(2)] public string Description { get; set; }
    [Key(3)] public double Price { get; set; }
    [Key(4)] public DateTime CreatedAt { get; set; }
}