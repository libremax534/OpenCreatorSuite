namespace OpenCreatorStudio.Domain.Entities;

/// <summary>
/// Entité représentant une connexion entre deux nœuds.
/// Définit le flux d'exécution dans le graphe.
/// </summary>
public class Connection
{
    public int Id { get; set; }
    
    public int ProjectId { get; set; }
    
    /// <summary>
    /// ID du nœud source.
    /// </summary>
    public int SourceNodeId { get; set; }
    
    /// <summary>
    /// ID du nœud de destination.
    /// </summary>
    public int TargetNodeId { get; set; }
    
    /// <summary>
    /// Label de la connexion (ex: "OK", "KO", "ERREUR").
    /// </summary>
    public string? Label { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public Project? Project { get; set; }
    
    public DecisionNode? SourceNode { get; set; }
    
    public DecisionNode? TargetNode { get; set; }
}
