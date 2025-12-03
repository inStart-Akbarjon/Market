namespace Market.Application.DTOs.Response.Product;

public class AddProductResponse
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
}