using MessagePack;

namespace Market.Contracts.Models.Request;

[MessagePackObject]
public class DeleteProductRequest
{
    [Key(0)] public int Id { get; set; }
}