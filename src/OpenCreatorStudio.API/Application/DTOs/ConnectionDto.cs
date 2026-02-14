namespace OpenCreatorStudio.Application.DTOs;

/// <summary>
/// DTO représentant une connexion entre deux nœuds.
/// </summary>
public class ConnectionDto
{
    public int Id { get; set; }
    
    public int ProjectId { get; set; }
    
    public int SourceNodeId { get; set; }
    
    public int TargetNodeId { get; set; }
    
    public string? Label { get; set; }
}

/// <summary>
/// DTO pour la création d'une connexion.
/// </summary>
public class CreateConnectionRequest
{
    public int SourceNodeId { get; set; }
    
    public int TargetNodeId { get; set; }
    
    public string? Label { get; set; }
}
