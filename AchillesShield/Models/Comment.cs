namespace AchillesShield.Models;

public class Comment: BaseEntity
{

    public int Id { get; set; }

    public int IncidentId { get; set; }

    public int UserId { get; set; }
    public string? Content { get; set; }
    public Incident Incident { get; set; } = null!;
    public User User { get; set; } = null!;
}
