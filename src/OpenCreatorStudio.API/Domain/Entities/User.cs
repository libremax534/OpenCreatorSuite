namespace OpenCreatorStudio.Domain.Entities;

/// <summary>
/// Entité représentant un utilisateur du système.
/// </summary>
public class User
{
    public int Id { get; set; }
    
    public required string Username { get; set; }
    
    public required string PasswordHash { get; set; }
    
    public string? Email { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime? LastLoginAt { get; set; }
    
    // Navigation properties
    public ICollection<Project> Projects { get; set; } = new List<Project>();
}
