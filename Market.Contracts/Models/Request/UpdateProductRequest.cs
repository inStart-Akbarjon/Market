using MessagePack;

namespace Market.Contracts.Models.Request;

[MessagePackObject]
public class UpdateProductRequest
{
    [Key(0)] public int Id { get; set; }
    [Key(1)] public string Title { get; set; }
    [Key(2)] public string Description { get; set; }
    [Key(3)] public double Price { get; set; }
    [Key(4)] public DateTime CreatedAt { get; set; }
}