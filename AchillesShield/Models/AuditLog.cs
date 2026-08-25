namespace AchillesShield.Models;

public class AuditLog
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Action { get; set; } = null!;

    public string EntityType { get; set; } = null!;
    public int EntityId { get; set; }

    public string Details { get; set; } = null!;
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    //Navigation property to the User entity
    public User User { get; set; } = null!;

}

