using Microsoft.AspNetCore.Identity;

namespace AchillesShield.Models;

public class User: BaseEntity
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public bool IsActive { get; set; }
    public int RoleId { get; set; }

    //Navigation properties

    public Role Role { get; set; } = null!;
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<Incident> Incidents { get; set; } = new List<Incident>();
    public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();
}

