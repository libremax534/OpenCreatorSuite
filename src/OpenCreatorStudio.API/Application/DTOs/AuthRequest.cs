namespace OpenCreatorStudio.Application.DTOs;

/// <summary>
/// DTO pour une demande d'authentification.
/// </summary>
public class AuthRequest
{
    public required string Username { get; set; }
    
    public required string Password { get; set; }
}
