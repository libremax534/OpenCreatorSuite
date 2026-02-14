using Microsoft.AspNetCore.Mvc;
using OpenCreatorStudio.Application.DTOs;
using OpenCreatorStudio.Domain.Entities;
using OpenCreatorStudio.Infrastructure.Data.Repositories;

namespace OpenCreatorStudio.API.Controllers;

/// <summary>
/// Contrôleur pour la gestion des projets.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly ProjectRepository _projectRepository;
    private readonly ILogger<ProjectsController> _logger;

    public ProjectsController(
        ProjectRepository projectRepository,
        ILogger<ProjectsController> logger)
    {
        _projectRepository = projectRepository;
        _logger = logger;
    }

    /// <summary>
    /// Récupère tous les projets d'un utilisateur.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<List<ProjectDto>>> GetProjects([FromQuery] int userId)
    {
        try
        {
            var projects = await _projectRepository.GetByUserIdAsync(userId);
            var dtos = projects.Select(MapToDto).ToList();
            return Ok(dtos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur lors de la récupération des projets");
            return StatusCode(500, new { message = "Erreur serveur" });
        }
    }

    /// <summary>
    /// Récupère un projet par son ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectDto>> GetProject(int id)
    {
        try
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null)
                return NotFound(new { message = "Projet introuvable" });

            return Ok(MapToDto(project));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur lors de la récupération du projet {ProjectId}", id);
            return StatusCode(500, new { message = "Erreur serveur" });
        }
    }

    /// <summary>
    /// Crée un nouveau projet.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<ProjectDto>> CreateProject(
        [FromQuery] int userId,
        [FromBody] CreateProjectRequest request)
    {
        try
        {
            var project = new Project
            {
                Name = request.Name,
                Description = request.Description,
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var created = await _projectRepository.CreateAsync(project);
            _logger.LogInformation("Projet créé : {ProjectName} (ID: {ProjectId})", created.Name, created.Id);
            
            return CreatedAtAction(nameof(GetProject), new { id = created.Id }, MapToDto(created));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur lors de la création du projet");
            return StatusCode(500, new { message = "Erreur serveur" });
        }
    }

    /// <summary>
    /// Supprime un projet.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        try
        {
            var deleted = await _projectRepository.DeleteAsync(id);
            if (!deleted)
                return NotFound(new { message = "Projet introuvable" });

            _logger.LogInformation("Projet supprimé : {ProjectId}", id);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur lors de la suppression du projet {ProjectId}", id);
            return StatusCode(500, new { message = "Erreur serveur" });
        }
    }

    private static ProjectDto MapToDto(Project project)
    {
        return new ProjectDto
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            UserId = project.UserId,
            CreatedAt = project.CreatedAt,
            UpdatedAt = project.UpdatedAt,
            Nodes = project.Nodes?.Select(n => new NodeDto
            {
                Id = n.Id,
                ProjectId = n.ProjectId,
                Name = n.Name,
                FrameType = n.FrameType,
                StoredProcedureName = n.StoredProcedureName,
                BodyScript = n.BodyScript,
                PositionX = n.PositionX,
                PositionY = n.PositionY,
                Width = n.Width,
                Height = n.Height
            }).ToList() ?? new(),
            Connections = project.Connections?.Select(c => new ConnectionDto
            {
                Id = c.Id,
                ProjectId = c.ProjectId,
                SourceNodeId = c.SourceNodeId,
                TargetNodeId = c.TargetNodeId,
                Label = c.Label
            }).ToList() ?? new()
        };
    }
}
