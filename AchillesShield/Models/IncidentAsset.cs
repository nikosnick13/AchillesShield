namespace AchillesShield.Models;

public class IncidentAsset
{
    public int IncidentId { get; set; }
    public int AssetId { get; set;}

    // Navigation Properties
    public Incident Incident { get; set; } = null!;
    public Assets Assets { get; set; } = null!;
}