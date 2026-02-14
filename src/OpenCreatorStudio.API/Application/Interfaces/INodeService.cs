using OpenCreatorStudio.Application.DTOs;

namespace OpenCreatorStudio.Application.Interfaces;

/// <summary>
/// Interface du service de gestion des nœuds.
/// </summary>
public interface INodeService
{
    /// <summary>
    /// Récupère tous les nœuds d'un projet.
    /// </summary>
    Task<List<NodeDto>> GetNodesByProjectIdAsync(int projectId);
    
    /// <summary>
    /// Récupère un nœud par son ID.
    /// </summary>
    Task<NodeDto?> GetNodeByIdAsync(int nodeId);
    
    /// <summary>
    /// Crée un nouveau nœud.
    /// </summary>
    Task<NodeDto> CreateNodeAsync(int projectId, CreateNodeRequest request);
    
    /// <summary>
    /// Met à jour un nœud existant.
    /// </summary>
    Task<NodeDto> UpdateNodeAsync(int nodeId, NodeDto dto);
    
    /// <summary>
    /// Supprime un nœud.
    /// </summary>
    Task<bool> DeleteNodeAsync(int nodeId);
}
