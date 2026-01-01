namespace Market.Domain.Entities.Product;

public abstract class Entity
{
    public int Id { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    
    public void SoftDelete()
    {
        DeletedAt = DateTime.UtcNow;
    }
}