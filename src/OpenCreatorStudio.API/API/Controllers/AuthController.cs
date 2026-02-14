using Microsoft.AspNetCore.Mvc;
using OpenCreatorStudio.Application.DTOs;
using OpenCreatorStudio.Application.Interfaces;

namespace OpenCreatorStudio.API.Controllers;

/// <summary>
/// Contrôleur pour l'authentification des utilisateurs.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthenticationService _authService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(
        IAuthenticationService authService,
        ILogger<AuthController> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    /// <summary>
    /// Connexion d'un utilisateur.
    /// </summary>
    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login([FromBody] AuthRequest request)
    {
        try
        {
            _logger.LogInformation("Tentative de connexion pour {Username}", request.Username);
            var response = await _authService.LoginAsync(request);
            
            if (!response.Success)
            {
                _logger.LogWarning("Échec de connexion pour {Username}", request.Username);
                return Unauthorized(response);
            }

            _logger.LogInformation("Connexion réussie pour {Username}", request.Username);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur lors de la connexion");
            return StatusCode(500, new AuthResponse
            {
                Success = false,
                Message = "Erreur serveur lors de la connexion"
            });
        }
    }

    /// <summary>
    /// Inscription d'un nouvel utilisateur (admin uniquement).
    /// </summary>
    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register([FromBody] RegisterRequest request)
    {
        try
        {
            // TODO: Vérifier que l'utilisateur actuel est admin
            
            if (await _authService.UsernameExistsAsync(request.Username))
            {
                return BadRequest(new { message = "Ce nom d'utilisateur existe déjà" });
            }

            var user = await _authService.RegisterAsync(
                request.Username,
                request.Password,
                request.Email);

            _logger.LogInformation("Nouvel utilisateur créé : {Username}", request.Username);
            return CreatedAtAction(nameof(Register), new { id = user.Id }, user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur lors de l'inscription");
            return StatusCode(500, new { message = "Erreur serveur lors de l'inscription" });
        }
    }
}

/// <summary>
/// DTO pour l'inscription d'un nouvel utilisateur.
/// </summary>
public class RegisterRequest
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public string? Email { get; set; }
}
