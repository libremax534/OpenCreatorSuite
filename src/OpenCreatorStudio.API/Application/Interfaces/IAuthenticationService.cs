using OpenCreatorStudio.Application.DTOs;

namespace OpenCreatorStudio.Application.Interfaces;

/// <summary>
/// Interface du service d'authentification.
/// </summary>
public interface IAuthenticationService
{
    /// <summary>
    /// Authentifie un utilisateur avec BCrypt.
    /// </summary>
    Task<AuthResponse> LoginAsync(AuthRequest request);
    
    /// <summary>
    /// Crée un nouvel utilisateur (admin uniquement).
    /// </summary>
    Task<UserDto> RegisterAsync(string username, string password, string? email = null);
    
    /// <summary>
    /// Vérifie si un nom d'utilisateur existe déjà.
    /// </summary>
    Task<bool> UsernameExistsAsync(string username);
}
