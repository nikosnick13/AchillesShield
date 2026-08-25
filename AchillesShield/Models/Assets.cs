namespace AchillesShield.Models;

public class Assets
{
    public int Id { get; set; }
    public string Hostname { get; set; } = null!;
    public string IpAddress { get; set; } = null!;
    public string AssetType { get; set; } = null!;
    public string Criticality { get; set; } = null!;
    public string OperatingSystem { get; set; } = null!;
    public bool IsActive { get; set; }


}
