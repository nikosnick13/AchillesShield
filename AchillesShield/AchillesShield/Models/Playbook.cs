namespace AchillesShield.Models;

public class Playbook :BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!; 
    public string TriggerType { get; set; } = null!;
    public ICollection<PlaybookAction> PlaybookActions { get; set; } = new List<PlaybookAction>();
}
