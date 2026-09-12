namespace AchillesShield.Models;

public class IncidentAlert
{
    public int IncidentId { get; set; }
    public int AlertId { get; set; }

    // Navigation Properties
    public Incident Incident { get; set; } = null!;
    public Alert Alert { get; set; } = null!;
}
