namespace AchillesShield.Models;

public class PlaybookAction: BaseEntity
{
    public int Id { get; set; }
    public int PlaybookId { get; set; }
    public string Name { get; set; } = null!;
    public string ActionType { get; set; } = null!;
    public  int ExecutionOrder { get; set; }
    public string Relationship { get; set; } = null!;
    public Playbook Playbook { get; set; } = null!;
}