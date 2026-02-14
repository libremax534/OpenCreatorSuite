using OpenCreatorStudio.Application.DTOs;

namespace OpenCreatorStudio.Application.Interfaces;

/// <summary>
/// Interface du service de gestion des projets.
/// </summary>
public interface IProjectService
{
    /// <summary>
    /// Récupère tous les projets d'un utilisateur.
    /// </summary>
    Task<List<ProjectDto>> GetProjectsByUserIdAsync(int userId);
    
    /// <summary>
    /// Récupère un projet complet (avec nœuds et connexions).
    /// </summary>
    Task<ProjectDto?> GetProjectByIdAsync(int projectId);
    
    /// <summary>
    /// Crée un nouveau projet.
    /// </summary>
    Task<ProjectDto> CreateProjectAsync(int userId, CreateProjectRequest request);
    
    /// <summary>
    /// Met à jour un projet.
    /// </summary>
    Task<ProjectDto> UpdateProjectAsync(int projectId, CreateProjectRequest request);
    
    /// <summary>
    /// Supprime un projet.
    /// </summary>
    Task<bool> DeleteProjectAsync(int projectId);
}
