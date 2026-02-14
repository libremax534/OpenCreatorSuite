using OpenCreatorStudio.Domain.Enums;

namespace OpenCreatorStudio.Domain.Entities;

/// <summary>
/// Entité représentant un nœud de décision dans le graphe.
/// Chaque nœud possède un script SQL et des propriétés visuelles.
/// </summary>
public class DecisionNode
{
    public int Id { get; set; }
    
    public int ProjectId { get; set; }
    
    public required string Name { get; set; }
    
    public FrameType FrameType { get; set; }
    
    /// <summary>
    /// Nom de la procédure stockée MySQL générée.
    /// Format: SP_Aut_{FrameType}_{NodeName}
    /// </summary>
    public string? StoredProcedureName { get; set; }
    
    /// <summary>
    /// Script SQL du corps de la procédure.
    /// </summary>
    public string? BodyScript { get; set; }
    
    // Propriétés visuelles (position sur le canvas)
    public double PositionX { get; set; }
    
    public double PositionY { get; set; }
    
    public double Width { get; set; } = 200;
    
    public double Height { get; set; } = 100;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public Project? Project { get; set; }
    
    /// <summary>
    /// Connexions sortantes de ce nœud.
    /// </summary>
    public ICollection<Connection> OutgoingConnections { get; set; } = new List<Connection>();
    
    /// <summary>
    /// Connexions entrantes vers ce nœud.
    /// </summary>
    public ICollection<Connection> IncomingConnections { get; set; } = new List<Connection>();
}
