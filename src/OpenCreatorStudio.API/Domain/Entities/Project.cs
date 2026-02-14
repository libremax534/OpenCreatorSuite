namespace OpenCreatorStudio.Domain.Entities;

/// <summary>
/// Entité représentant un projet OpenCreator.
/// Un projet contient un graphe de nœuds de décision.
/// </summary>
public class Project
{
    public int Id { get; set; }
    
    public required string Name { get; set; }
    
    public string? Description { get; set; }
    
    public int UserId { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public User? User { get; set; }
    
    public ICollection<DecisionNode> Nodes { get; set; } = new List<DecisionNode>();
    
    public ICollection<Connection> Connections { get; set; } = new List<Connection>();
}
