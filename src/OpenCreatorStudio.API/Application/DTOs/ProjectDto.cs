namespace OpenCreatorStudio.Application.DTOs;

/// <summary>
/// DTO représentant un projet.
/// </summary>
public class ProjectDto
{
    public int Id { get; set; }
    
    public required string Name { get; set; }
    
    public string? Description { get; set; }
    
    public int UserId { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    
    public List<NodeDto> Nodes { get; set; } = new();
    
    public List<ConnectionDto> Connections { get; set; } = new();
}

/// <summary>
/// DTO pour la création d'un projet.
/// </summary>
public class CreateProjectRequest
{
    public required string Name { get; set; }
    
    public string? Description { get; set; }
}
