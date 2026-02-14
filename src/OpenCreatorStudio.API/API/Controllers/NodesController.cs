using Microsoft.AspNetCore.Mvc;
using OpenCreatorStudio.Application.DTOs;
using OpenCreatorStudio.Domain.Entities;
using OpenCreatorStudio.Infrastructure.Data.Repositories;
using OpenCreatorStudio.Infrastructure.MySQL;

namespace OpenCreatorStudio.API.Controllers;

/// <summary>
/// Contrôleur pour la gestion des nœuds de décision.
/// </summary>
[ApiController]
[Route("api/projects/{projectId}/[controller]")]
public class NodesController : ControllerBase
{
    private readonly NodeRepository _nodeRepository;
    private readonly ProjectRepository _projectRepository;
    private readonly ILogger<NodesController> _logger;

    public NodesController(
        NodeRepository nodeRepository,
        ProjectRepository projectRepository,
        ILogger<NodesController> logger)
    {
        _nodeRepository = nodeRepository;
        _projectRepository = projectRepository;
        _logger = logger;
    }

    /// <summary>
    /// Récupère tous les nœuds d'un projet.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<List<NodeDto>>> GetNodes(int projectId)
    {
        try
        {
            var nodes = await _nodeRepository.GetByProjectIdAsync(projectId);
            var dtos = nodes.Select(MapToDto).ToList();
            return Ok(dtos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur récupération nœuds du projet {ProjectId}", projectId);
            return StatusCode(500, new { message = "Erreur serveur" });
        }
    }

    /// <summary>
    /// Récupère un nœud par son ID.
    /// </summary>
    [HttpGet("{nodeId}")]
    public async Task<ActionResult<NodeDto>> GetNode(int projectId, int nodeId)
    {
        try
        {
            var node = await _nodeRepository.GetByIdAsync(nodeId);
            if (node == null || node.ProjectId != projectId)
                return NotFound(new { message = "Nœud introuvable" });

            return Ok(MapToDto(node));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur récupération nœud {NodeId}", nodeId);
            return StatusCode(500, new { message = "Erreur serveur" });
        }
    }

    /// <summary>
    /// Crée un nouveau nœud.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<NodeDto>> CreateNode(
        int projectId,
        [FromBody] CreateNodeRequest request)
    {
        try
        {
            // Vérifier que le projet existe
            var project = await _projectRepository.GetByIdAsync(projectId);
            if (project == null)
                return NotFound(new { message = "Projet introuvable" });

            // Générer le nom de la procédure stockée
            var spName = $"SP_Aut_{request.FrameType}_{request.Name.Replace(" ", "")}";

            var node = new DecisionNode
            {
                ProjectId = projectId,
                Name = request.Name,
                FrameType = request.FrameType,
                StoredProcedureName = spName,
                PositionX = request.PositionX,
                PositionY = request.PositionY,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var created = await _nodeRepository.CreateAsync(node);
            _logger.LogInformation("Nœud créé : {NodeName} (ID: {NodeId})", created.Name, created.Id);

            return CreatedAtAction(nameof(GetNode), 
                new { projectId, nodeId = created.Id }, 
                MapToDto(created));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur création nœud");
            return StatusCode(500, new { message = "Erreur serveur" });
        }
    }

    /// <summary>
    /// Met à jour un nœud existant.
    /// </summary>
    [HttpPut("{nodeId}")]
    public async Task<ActionResult<NodeDto>> UpdateNode(
        int projectId,
        int nodeId,
        [FromBody] NodeDto dto)
    {
        try
        {
            var node = await _nodeRepository.GetByIdAsync(nodeId);
            if (node == null || node.ProjectId != projectId)
                return NotFound(new { message = "Nœud introuvable" });

            // Mise à jour des propriétés
            node.Name = dto.Name;
            node.BodyScript = dto.BodyScript;
            node.PositionX = dto.PositionX;
            node.PositionY = dto.PositionY;
            node.Width = dto.Width;
            node.Height = dto.Height;

            var updated = await _nodeRepository.UpdateAsync(node);
            _logger.LogInformation("Nœud mis à jour : {NodeId}", nodeId);

            return Ok(MapToDto(updated));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur mise à jour nœud {NodeId}", nodeId);
            return StatusCode(500, new { message = "Erreur serveur" });
        }
    }

    /// <summary>
    /// Supprime un nœud.
    /// </summary>
    [HttpDelete("{nodeId}")]
    public async Task<IActionResult> DeleteNode(int projectId, int nodeId)
    {
        try
        {
            var node = await _nodeRepository.GetByIdAsync(nodeId);
            if (node == null || node.ProjectId != projectId)
                return NotFound(new { message = "Nœud introuvable" });

            var deleted = await _nodeRepository.DeleteAsync(nodeId);
            if (!deleted)
                return NotFound(new { message = "Nœud introuvable" });

            _logger.LogInformation("Nœud supprimé : {NodeId}", nodeId);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur suppression nœud {NodeId}", nodeId);
            return StatusCode(500, new { message = "Erreur serveur" });
        }
    }

    /// <summary>
    /// Génère le script SQL d'un nœud.
    /// </summary>
    [HttpGet("{nodeId}/script")]
    public async Task<ActionResult<string>> GetNodeScript(int projectId, int nodeId)
    {
        try
        {
            var node = await _nodeRepository.GetByIdAsync(nodeId);
            if (node == null || node.ProjectId != projectId)
                return NotFound(new { message = "Nœud introuvable" });

            var script = StoredProcedureGenerator.GenerateProcedureScript(node);
            return Ok(new { script });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur génération script nœud {NodeId}", nodeId);
            return StatusCode(500, new { message = "Erreur serveur" });
        }
    }

    private static NodeDto MapToDto(DecisionNode node)
    {
        return new NodeDto
        {
            Id = node.Id,
            ProjectId = node.ProjectId,
            Name = node.Name,
            FrameType = node.FrameType,
            StoredProcedureName = node.StoredProcedureName,
            BodyScript = node.BodyScript,
            PositionX = node.PositionX,
            PositionY = node.PositionY,
            Width = node.Width,
            Height = node.Height
        };
    }
}
