namespace OpenCreatorStudio.Application.DTOs;

/// <summary>
/// DTO pour la réponse d'authentification.
/// </summary>
public class AuthResponse
{
    public bool Success { get; set; }
    
    public string? Token { get; set; }
    
    public UserDto? User { get; set; }
    
    public string? Message { get; set; }
}
