namespace Market.Domain.Entities.Product;

public class Product : Entity
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public int? OpenedAt { get; set; }
    public int? ClosedAt { get; set; }
}