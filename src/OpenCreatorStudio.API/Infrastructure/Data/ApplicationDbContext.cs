using Microsoft.EntityFrameworkCore;
using OpenCreatorStudio.Domain.Entities;

namespace OpenCreatorStudio.Infrastructure.Data;

/// <summary>
/// Contexte Entity Framework pour OpenCreatorStudio.
/// </summary>
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<DecisionNode> Nodes => Set<DecisionNode>();
    public DbSet<Connection> Connections => Set<Connection>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuration User
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Username).HasMaxLength(50).IsRequired();
            entity.HasIndex(e => e.Username).IsUnique();
            entity.Property(e => e.PasswordHash).HasMaxLength(255).IsRequired();
            entity.Property(e => e.Email).HasMaxLength(100);
            
            // Relations
            entity.HasMany(e => e.Projects)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configuration Project
        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("projects");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Description).HasMaxLength(500);
            
            // Relations
            entity.HasMany(e => e.Nodes)
                .WithOne(n => n.Project)
                .HasForeignKey(n => n.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
                
            entity.HasMany(e => e.Connections)
                .WithOne(c => c.Project)
                .HasForeignKey(c => c.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configuration DecisionNode
        modelBuilder.Entity<DecisionNode>(entity =>
        {
            entity.ToTable("decision_nodes");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
            entity.Property(e => e.StoredProcedureName).HasMaxLength(100);
            entity.Property(e => e.BodyScript).HasColumnType("TEXT");
            
            // Conversion enum vers string
            entity.Property(e => e.FrameType)
                .HasConversion<string>()
                .HasMaxLength(20);
        });

        // Configuration Connection
        modelBuilder.Entity<Connection>(entity =>
        {
            entity.ToTable("connections");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Label).HasMaxLength(50);
            
            // Relations
            entity.HasOne(e => e.SourceNode)
                .WithMany(n => n.OutgoingConnections)
                .HasForeignKey(e => e.SourceNodeId)
                .OnDelete(DeleteBehavior.Restrict);
                
            entity.HasOne(e => e.TargetNode)
                .WithMany(n => n.IncomingConnections)
                .HasForeignKey(e => e.TargetNodeId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
