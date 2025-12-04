namespace Market.Application.DTOs.Response.Product;

public class DeleteProductResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public DateTime CreatedAt { get; set; }
}