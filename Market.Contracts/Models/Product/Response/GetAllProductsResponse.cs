using MessagePack;

namespace Market.Contracts.Models.Product.Response;

[MessagePackObject]
public class GetAllProductsResponse
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

[MessagePackObject]
public class PaginatedList<T>
{
    [Key(0)] public List<T> Items { get; set; }
    [Key(1)] public int PageNumber { get; set; }
    [Key(2)] public int PageSize { get; set; }
    [Key(3)] public bool HasNextPage { get; set; }
}