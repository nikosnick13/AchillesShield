namespace AchillesShield.Models;

public class Alert: BaseEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string AlertType { get; set; } = string.Empty;
    public string Severity { get; set; } = string.Empty;
    public string Source { get; set; } = null!;
    public string SourceIp { get; set; } = null!;
    public string DestinationIp { get; set; } = null!;
    public  string Status { get; set; } = null!;
    public ICollection<IncidentAlert> IncidentAlerts { get; set; } = new List<IncidentAlert>();
}
