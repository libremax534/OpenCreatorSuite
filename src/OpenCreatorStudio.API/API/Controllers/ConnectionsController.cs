using Microsoft.AspNetCore.Mvc;
using OpenCreatorStudio.Application.DTOs;
using OpenCreatorStudio.Domain.Entities;
using OpenCreatorStudio.Infrastructure.Data.Repositories;

namespace OpenCreatorStudio.API.Controllers;

/// <summary>
/// Contrôleur pour la gestion des connexions entre nœuds.
/// </summary>
[ApiController]
[Route("api/projects/{projectId}/[controller]")]
public class ConnectionsController : ControllerBase
{
    private readonly ConnectionRepository _connectionRepository;
    private readonly NodeRepository _nodeRepository;
    private readonly ILogger<ConnectionsController> _logger;

    public ConnectionsController(
        ConnectionRepository connectionRepository,
        NodeRepository nodeRepository,
        ILogger<ConnectionsController> logger)
    {
        _connectionRepository = connectionRepository;
        _nodeRepository = nodeRepository;
        _logger = logger;
    }

    /// <summary>
    /// Récupère toutes les connexions d'un projet.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<List<ConnectionDto>>> GetConnections(int projectId)
    {
        try
        {
            var connections = await _connectionRepository.GetByProjectIdAsync(projectId);
            var dtos = connections.Select(MapToDto).ToList();
            return Ok(dtos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur récupération connexions du projet {ProjectId}", projectId);
            return StatusCode(500, new { message = "Erreur serveur" });
        }
    }

    /// <summary>
    /// Crée une nouvelle connexion.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<ConnectionDto>> CreateConnection(
        int projectId,
        [FromBody] CreateConnectionRequest request)
    {
        try
        {
            // Vérifier que les nœuds source et cible existent
            var sourceNode = await _nodeRepository.GetByIdAsync(request.SourceNodeId);
            var targetNode = await _nodeRepository.GetByIdAsync(request.TargetNodeId);

            if (sourceNode == null || sourceNode.ProjectId != projectId)
                return BadRequest(new { message = "Nœud source invalide" });

            if (targetNode == null || targetNode.ProjectId != projectId)
                return BadRequest(new { message = "Nœud cible invalide" });

            var connection = new Connection
            {
                ProjectId = projectId,
                SourceNodeId = request.SourceNodeId,
                TargetNodeId = request.TargetNodeId,
                Label = request.Label,
                CreatedAt = DateTime.UtcNow
            };

            var created = await _connectionRepository.CreateAsync(connection);
            _logger.LogInformation("Connexion créée : {SourceId} -> {TargetId} (ID: {ConnectionId})",
                created.SourceNodeId, created.TargetNodeId, created.Id);

            return CreatedAtAction(nameof(GetConnections),
                new { projectId },
                MapToDto(created));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur création connexion");
            return StatusCode(500, new { message = "Erreur serveur" });
        }
    }

    /// <summary>
    /// Supprime une connexion.
    /// </summary>
    [HttpDelete("{connectionId}")]
    public async Task<IActionResult> DeleteConnection(int projectId, int connectionId)
    {
        try
        {
            var deleted = await _connectionRepository.DeleteAsync(connectionId);
            if (!deleted)
                return NotFound(new { message = "Connexion introuvable" });

            _logger.LogInformation("Connexion supprimée : {ConnectionId}", connectionId);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur suppression connexion {ConnectionId}", connectionId);
            return StatusCode(500, new { message = "Erreur serveur" });
        }
    }

    private static ConnectionDto MapToDto(Connection connection)
    {
        return new ConnectionDto
        {
            Id = connection.Id,
            ProjectId = connection.ProjectId,
            SourceNodeId = connection.SourceNodeId,
            TargetNodeId = connection.TargetNodeId,
            Label = connection.Label
        };
    }
}
