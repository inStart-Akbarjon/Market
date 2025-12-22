namespace Market.Domain.Models.Product;

public class Product : Entity
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public DateTime? OpenedAt { get; set; }
    public DateTime? ClosedAt { get; set; }
}