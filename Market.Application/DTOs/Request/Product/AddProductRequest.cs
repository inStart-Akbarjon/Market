namespace Market.Application.DTOs.Request.Product;

public class AddProductRequest
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
}