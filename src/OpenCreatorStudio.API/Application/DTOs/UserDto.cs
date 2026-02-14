namespace OpenCreatorStudio.Application.DTOs;

/// <summary>
/// DTO représentant un utilisateur (sans mot de passe).
/// </summary>
public class UserDto
{
    public int Id { get; set; }
    
    public required string Username { get; set; }
    
    public string? Email { get; set; }
    
    public DateTime CreatedAt { get; set; }
}
