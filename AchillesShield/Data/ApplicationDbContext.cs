using AchillesShield.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace AchillesShield.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }

    public DbSet<Alert> Alerts { get; set; }
    public DbSet<Asset> Assets { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Incident> Incidents { get; set; }
    public DbSet<IncidentAlert> IncidentAlerts { get; set; }
    public DbSet<IncidentAsset> IncidentAssets { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Playbook> Playbooks { get; set; }
    public DbSet<PlaybookAction> PlaybookActions { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Usres { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        
        // Configure the relationships and constraints for the entities here

        // ==========================================
        // INCIDENT - ALERT
        // Many-to-Many
        // ==========================================

        modelBuilder.Entity<IncidentAlert>()
            .HasKey(ia => new { ia.IncidentId, ia.AlertId });

        modelBuilder.Entity<IncidentAlert>()
            .HasOne(ia => ia.Incident)
            .WithMany(i => i.IncidentAlerts)
            .HasForeignKey(ia => ia.IncidentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<IncidentAlert>()
            .HasOne(ia => ia.Alert)
            .WithMany(a => a.IncidentAlerts)
            .HasForeignKey(ia => ia.AlertId)
            .OnDelete(DeleteBehavior.Cascade);

        // ==========================================
        // INCIDENT - Assets
        // Many-to-Many
        // ==========================================

        modelBuilder.Entity<IncidentAsset>()
            .HasKey(ia => new { ia.IncidentId, ia.AssetId });

        modelBuilder.Entity<IncidentAsset>()
            .HasOne(ia => ia.Incident)
            .WithMany(i => i.IncidentAssets)
            .HasForeignKey(ia => ia.IncidentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<IncidentAsset>()
            .HasOne(ia => ia.Asset)
            .WithMany(a => a.IncidentAssets)
            .HasForeignKey(ia => ia.AssetId)
            .OnDelete(DeleteBehavior.Cascade);

        // ==========================================
        // ROLE - PERMISSION
        // Many-to-Many
        // ==========================================

        modelBuilder.Entity<RolePermission>()
            .HasKey(rp => new { rp.PermissionId, rp.RoleId });

        modelBuilder.Entity<RolePermission>()
            .HasOne(rp => rp.Role)
            .WithMany(r => r.RolePermissions)
            .HasForeignKey(rp => rp.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<RolePermission>()
            .HasOne(rp => rp.Permission)
            .WithMany(p => p.RolePermissions)
            .HasForeignKey(rp => rp.PermissionId)
            .OnDelete(DeleteBehavior.Cascade);

        // ==========================================
        // USER - ROLE
        // One-to-Many
        // ==========================================

        modelBuilder.Entity<User>(entity => {

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(60);
             
            entity.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
            
        });

        


        // ==========================================
        // USER - AUDIT LOG
        // One-to-Many
        // ==========================================

        modelBuilder.Entity<AuditLog>()
            .HasOne(u => u.User)
            .WithMany(r => r.AuditLogs)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Restrict);


        // ==========================================
        // USER - COMMENT
        // One-to-Many
        // ==========================================

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);


        // ==========================================
        // USER - INCIDENT
        // One-to-Many
        // ==========================================

        modelBuilder.Entity<Incident>()
            .HasOne(i => i.AssignedUser)
            .WithMany(u => u.Incidents)
            .HasForeignKey(i => i.AssignedUserId)
            .OnDelete(DeleteBehavior.Restrict);

        // ==========================================
        // PLAYBOOK - PLAYBOOK ACTION
        // One-to-Many
        // ==========================================

        modelBuilder.Entity<PlaybookAction>()
            .HasOne(pa => pa.Playbook)
            .WithMany(p => p.PlaybookActions)
            .HasForeignKey(pa => pa.PlaybookId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
