namespace AchillesShield.Models;

public class Incident: BaseEntity
{
    public int Id { get; set; }
    public string IncidentNumber { get; set; } = string.Empty;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Severity { get; set; } = null!;
    public string Status { get; set; } = null!;
    public DateTime? ResolvedAt { get; set; }
    public int AssignedUserId { get; set; }
    public User AssignedUser { get; set; } = null!;

    //Navigation propertis
    public ICollection<IncidentAlert> IncidentAlerts { get; set; } =
       new List<IncidentAlert>();
    public ICollection<IncidentAsset> IncidentAssets { get; set; } =
        new List<IncidentAsset>();
    public ICollection<Comment> Comments { get; set; } =
        new List<Comment>();
}
