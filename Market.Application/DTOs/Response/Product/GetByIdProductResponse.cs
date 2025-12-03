namespace Market.Application.DTOs.Response.Product;

public class GetByIdProductResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
<<<<<<< HEAD
    public double Price { get; set; }
=======
    public decimal Price { get; set; }
>>>>>>> 0cbf7de300fb8e8025bb247a7d8cffb5d24191fa
    public DateTime CreatedAt { get; set; }
}