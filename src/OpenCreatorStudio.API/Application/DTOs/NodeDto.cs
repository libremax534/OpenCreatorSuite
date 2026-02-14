using OpenCreatorStudio.Domain.Enums;

namespace OpenCreatorStudio.Application.DTOs;

/// <summary>
/// DTO représentant un nœud de décision.
/// </summary>
public class NodeDto
{
    public int Id { get; set; }
    
    public int ProjectId { get; set; }
    
    public required string Name { get; set; }
    
    public FrameType FrameType { get; set; }
    
    public string? StoredProcedureName { get; set; }
    
    public string? BodyScript { get; set; }
    
    public double PositionX { get; set; }
    
    public double PositionY { get; set; }
    
    public double Width { get; set; }
    
    public double Height { get; set; }
}

/// <summary>
/// DTO pour la création/mise à jour d'un nœud.
/// </summary>
public class CreateNodeRequest
{
    public required string Name { get; set; }
    
    public FrameType FrameType { get; set; }
    
    public double PositionX { get; set; }
    
    public double PositionY { get; set; }
}
