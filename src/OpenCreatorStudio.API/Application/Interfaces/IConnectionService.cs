using OpenCreatorStudio.Application.DTOs;

namespace OpenCreatorStudio.Application.Interfaces;

/// <summary>
/// Interface du service de gestion des connexions.
/// </summary>
public interface IConnectionService
{
    /// <summary>
    /// Récupère toutes les connexions d'un projet.
    /// </summary>
    Task<List<ConnectionDto>> GetConnectionsByProjectIdAsync(int projectId);
    
    /// <summary>
    /// Crée une nouvelle connexion.
    /// </summary>
    Task<ConnectionDto> CreateConnectionAsync(int projectId, CreateConnectionRequest request);
    
    /// <summary>
    /// Supprime une connexion.
    /// </summary>
    Task<bool> DeleteConnectionAsync(int connectionId);
}
