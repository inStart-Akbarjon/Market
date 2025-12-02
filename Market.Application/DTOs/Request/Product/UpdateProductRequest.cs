namespace Market.Application.DTOs.Request.Product;

public class UpdateProductRequest
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
}