namespace AchillesShield.Models;

public abstract class BaseEntity
{

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; } = false;   // Soft delete
    public DateTime? DeletedAt { get; set; }
}
